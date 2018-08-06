using System;
using System.Linq.Expressions;
using BusinessEntities;
using VilkaApi.ResourceAccess.Base;
using LinqToDB;

namespace VilkaApi.ResourceAccess.Regions
{
    public class RegionHistoryRepository : RepositoryBase<RegionHistoryItem, RegionHistoryRepository>
    {
        protected override Expression<Func<DBContext, ITable<RegionHistoryItem>>> TableExpression => c => c.RegionHistory;

    }
}