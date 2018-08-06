using System.Linq;
using BusinessEntities;
using BusinessEntities.Base;
using LinqToDB;
using LinqToDB.Mapping;
using Microsoft.Extensions.Configuration;

namespace VilkaApi
{
    public class DBContext : LinqToDB.Data.DataConnection
    {

        public DBContext() : base("Default") 
        {
            FluentMappingBuilder mb = MappingSchema.GetFluentMappingBuilder();
            MappingSchema.EntityDescriptorCreatedCallback = (mappingSchema, entityDescriptor) =>
            {
                if (entityDescriptor.TypeAccessor.Type.IsSubclassOf(typeof(IDEntityBase)) && !entityDescriptor.TypeAccessor.Type.IsAbstract)
                {
                    var idCol = entityDescriptor.Columns.Where(c => c.MemberName == "ID").FirstOrDefault();
                    if (idCol.MemberName == idCol.ColumnName)
                        idCol.ColumnName = entityDescriptor.TypeAccessor.Type.Name + "ID";
                }
            }; 
        }

        public ITable<Region> Regions => GetTable<Region>();
        public ITable<RegionPoolItem> RegionPool => GetTable<RegionPoolItem>();
        public ITable<RegionDictionaryItem> RegionDictionary => GetTable<RegionDictionaryItem>();
        public ITable<RegionHistoryItem> RegionHistory => GetTable<RegionHistoryItem>();
        public ITable<RegionQuestion> RegionQuestions => GetTable<RegionQuestion>();
        public ITable<User> Users => GetTable<User>();
        public ITable<Site> Sites => GetTable<Site>();
    }
}