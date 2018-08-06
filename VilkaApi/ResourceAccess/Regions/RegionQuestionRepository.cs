using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using BusinessEntities;
using VilkaApi.ResourceAccess.Base;
using LinqToDB.Data;
using System;
using System.Linq.Expressions;

namespace VilkaApi.ResourceAccess.Regions
{
    public class RegionQuestionRepository : RepositoryBase<RegionQuestion, RegionQuestionRepository>
    {
        protected override Expression<Func<DBContext, ITable<RegionQuestion>>> TableExpression => c => c.RegionQuestions;

        public List<RegionQuestionAnswer> GetQuestionAnswersForPoolItem(int poolItemID){
            using(DBContext context = new DBContext()){
                return context.QueryProc<RegionQuestionAnswer>(
                    "[SportCompare]..[regionGetQuestionAnswers]"
                    , new DataParameter("poolItemID", poolItemID, LinqToDB.DataType.Int32)
                ).ToList();
            }
        }

        public List<RegionQuestion> GetAllForPoolItem(int poolItemID){
            using(DBContext context = new DBContext()){
                return context.RegionQuestions
                    .LoadWith(q => q.PoolItem)
                    .LoadWith(q => q.Region)
                    .Where(q => q.RegionPoolItemID == poolItemID)
                    .ToList();
            }
        }
    }
}