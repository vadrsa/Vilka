using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessEntities;
using VilkaApi.ResourceAccess.Base;
using LinqToDB;

namespace VilkaApi.ResourceAccess.Regions
{
    public class RegionRepository : RepositoryBase<Region, RegionRepository>
    {
        protected override Expression<Func<DBContext, ITable<Region>>> TableExpression => c => c.Regions;

    }
}