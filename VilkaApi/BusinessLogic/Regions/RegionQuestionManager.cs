using System.Collections.Generic;
using System.Linq;
using VilkaApi.BusinessLogic.Base;
using BusinessEntities;
using VilkaApi.ResourceAccess.Regions;

namespace VilkaApi.BusinessLogic.Regions
{
    public class RegionQuestionManager: ManagerBase<RegionQuestion, RegionQuestionRepository>
    {
        public RegionQuestionInfo GetNext(string userID){
            foreach(int id in RegionPoolRepository.Instance.GetPoolItemProcessingQueue())
            {
                List<RegionQuestion> questions = RegionQuestionRepository.Instance.GetAllForPoolItem(id);
                List<RegionQuestionAnswer> answers = RegionQuestionRepository.Instance.GetQuestionAnswersForPoolItem(id);
                List<RegionQuestionAnswer> yes = answers.Where(a => a.Answer == RegionAnswer.Yes).ToList();
                List<RegionQuestionAnswer> yesByNotCurrentUser = yes.Where(a => a.UserID != userID).ToList();
                List<RegionQuestionAnswer> no = answers.Where(a => a.Answer == RegionAnswer.No).ToList();
                List<RegionQuestion> unanswered = questions.Where(q => answers.Where(a => a.RegionQuestionID == q.ID).Count() == 0 ).ToList();
                if(yesByNotCurrentUser.Count > 0)
                    return new RegionQuestionInfo(
                        RegionQuestionRepository.Instance.LoadWith(q => q.PoolItem).LoadWith(q => q.Region).SelectByKey(yesByNotCurrentUser.First().RegionQuestionID)
                    );
                else if (unanswered.Count > 0)
                    return new RegionQuestionInfo(unanswered.First());
            }
            return null;
        }

        public void AnswerQuestion(RegionHistoryItem answer){
            RegionHistoryRepository.Instance.Insert(answer);
        }
    }
}