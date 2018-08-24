using System.Collections.Generic;
using System.Linq;
using VilkaApi.BusinessLogic.Base;
using BusinessEntities;
using VilkaApi.ResourceAccess.Regions;
using Microsoft.Extensions.Configuration;
using System;

namespace VilkaApi.BusinessLogic.Regions
{
    public class RegionQuestionManager: ManagerBase<RegionQuestion, RegionQuestionRepository>
    {
        public RegionQuestionManager(IConfiguration config)
        {
            Configuration = config;
        }

        IConfiguration Configuration;

        public RegionQuestionInfo GetNext(string userID){
            int answerCount = Configuration.GetValue<int>("SufficientAnswerCount");
            foreach (int id in RegionPoolRepository.Instance.GetPoolItemProcessingQueue())
            {
                RegionPoolItem item = RegionPoolRepository.Instance.SelectByKey(id);
                if (item.Finished) continue;
                List<RegionQuestion> questions = RegionQuestionRepository.Instance.GetAllForPoolItem(id);
                List<RegionQuestionAnswer> answers = RegionQuestionRepository.Instance.GetQuestionAnswersForPoolItem(id);
                List<RegionQuestion> unanswered = questions.Where(q => answers.Where(a => a.RegionQuestionID == q.ID).Count() == 0 ).ToList();
                if (unanswered.Count > 0)
                    return new RegionQuestionInfo(unanswered.First());
            }
            return null;
        }

        //private List<RegionQuestion> GetAllQuestionsForPoolItem(int poolItemID, int userID)
        //{
        //    int answerCount = Configuration.GetValue<int>("SufficientAnswerCount");
        //    List<RegionQuestionAnswer> answers = RegionQuestionRepository.Instance.GetQuestionAnswersForPoolItem(poolItemID);

        //    questions.
        //}

        public void AnswerQuestion(RegionHistoryItem answer){
            RegionQuestion question = Repository.LoadWith(q => q.PoolItem).SelectByKey(answer.RegionQuestionID);
            if (question.PoolItem.Finished) return;
            RegionHistoryRepository.Instance.Insert(answer);
            if (answer.Answer == RegionAnswer.Yes)
            {
                RegionPoolRepository.Instance.MarkFinished(question.RegionPoolItemID);
            }
            else
            {
                List<RegionQuestion> questions = RegionQuestionRepository.Instance.GetAllForPoolItem(question.RegionPoolItemID);
                List<RegionQuestionAnswer> answers = RegionQuestionRepository.Instance.GetQuestionAnswersForPoolItem(question.RegionPoolItemID);
                List<RegionQuestion> unanswered = questions.Where(q => answers.Where(a => a.RegionQuestionID == q.ID).Count() == 0).ToList();
                if(unanswered.Count == 0)
                {
                    RegionPoolRepository.Instance.MarkFinished(question.RegionPoolItemID);
                }
            }
        }

        private void VerifyQuestionPool()
        {
            List<RegionQuestion> questions = RegionQuestionRepository.Instance.LoadWith(q => q.PoolItem).SelectAll();
            bool areAllAnswered = true;
            foreach(RegionQuestion question in questions)
            {
                if (!question.PoolItem.Finished)
                {
                    areAllAnswered = false;
                    break;
                }
            }
            if (areAllAnswered)
            {
                //ExecuteTransaction(() => {
                //    foreach (RegionHistoryItem i in RegionHistoryRepository.Instance.SelectAll())
                //        RegionHistoryRepository.Instance.Delete(i);
                //    foreach (RegionQuestion q in questions)
                //        RegionQuestionRepository.Instance.Delete(q);
                //    for
                //});
            }
        }
    }
}