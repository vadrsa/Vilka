using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessEntities;
using VilkaApi.ResourceAccess.Base;
using LinqToDB;
using LinqToDB.Data;

namespace VilkaApi.ResourceAccess.Regions
{
    public class RegionPoolRepository : RepositoryBase<RegionPoolItem, RegionPoolRepository>
    {
        protected override Expression<Func<DBContext, ITable<RegionPoolItem>>> TableExpression => c => c.RegionPool;

        public List<int> GetPoolItemProcessingQueue()
        {
            using (DBContext context = new DBContext())
            {
                return context.QueryProc<int>("[SportCompare]..[regionGetQuestionPoolUniqueIDs]").ToList();
            }
        }

        public void MarkFinished(int regionPoolItemID)
        {
            using (DBContext context = new DBContext())
            {
                RegionPoolItem item = SelectByKey(regionPoolItemID);
                item.Finished = true;
                context.Update(item);
            }
        }
    }
}