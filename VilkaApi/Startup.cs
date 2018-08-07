using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using BusinessEntities;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VilkaApi.ExceptionHandling;

namespace VilkaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            DataConnection
                .AddConfiguration(
					"Default",
					Configuration["ConnectionString"],
					new SqlServerDataProvider("Default", SqlServerVersion.v2012));

			DataConnection.DefaultConfiguration = "Default";
            services.AddIdentity<User, LinqToDB.Identity.IdentityRole>()
				.AddLinqToDBStores(new DefaultConnectionFactory())
				.AddDefaultTokenProviders();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options => 
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                })
				.AddCookie(options =>
				{
					options.Cookie.Name = "Interop";
					options.DataProtectionProvider =
						DataProtectionProvider.Create(new DirectoryInfo("C:\\Github\\Identity\\artifacts"));

				});

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();

            }
            var connectionString = new SqlConnectionStringBuilder(Configuration["ConnectionString"])
			{
				InitialCatalog = "master"
			}.ConnectionString;

			using (var db = new DataConnection(SqlServerTools.GetDataProvider(), connectionString))
			{
				try
				{
					var sql = "create database [" +
					          new SqlConnectionStringBuilder(Configuration["Data:DefaultConnection:ConnectionString"])
						          .InitialCatalog + "]";
					db.Execute(sql);
				}
				catch
				{
					//
				}
			}

			// Try to create tables
			using (var db = new DataConnection())
			{
				TryCreateTable<User>(db);
				TryCreateTable<LinqToDB.Identity.IdentityRole>(db);
				TryCreateTable<LinqToDB.Identity.IdentityUserClaim<string>>(db);
				TryCreateTable<LinqToDB.Identity.IdentityRoleClaim<string>>(db);
				TryCreateTable<LinqToDB.Identity.IdentityUserLogin<string>>(db);
				TryCreateTable<LinqToDB.Identity.IdentityUserRole<string>>(db);
				TryCreateTable<LinqToDB.Identity.IdentityUserToken<string>>(db);
			}

			app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();

            app.UseMvc();
        }

        private void TryCreateTable<T>(DataConnection db)
			where T : class
		{
			try
			{
				db.CreateTable<T>();
			}
			catch(Exception e)
			{
				//
			}
		}
    }
}
