using BusinessEntities.Base;
using LinqToDB.Mapping;

namespace BusinessEntities
{
    [Table("RegionQuestions")]
    public class RegionQuestion : IDEntityBase
    {
        
        [Column, NotNull]
        public int RegionPoolItemID { get; set; }

        [Association(ThisKey = "RegionPoolItemID", OtherKey = "ID")]
        public RegionPoolItem PoolItem { get; set; }

        [Column, NotNull]
        public int RegionID { get; set; }

        [Association(ThisKey = "RegionID", OtherKey = "ID")]
        public Region Region { get; set; }
        
    }

    public class RegionQuestionInfo{
        public RegionQuestionInfo(){}
        public RegionQuestionInfo(RegionQuestion question){
            RegionQuestionID = question.ID;
            RegionOne = question.PoolItem?.Name ?? "";
            RegionTwo = question.Region?.Name ?? "";    
        }

        public int RegionQuestionID { get; set; }

        public string RegionOne{get;set;}

        public string RegionTwo{get;set;}
    }

    public class RegionQuestionAnswer
    {
        public int RegionQuestionID { get; set; }

        public RegionAnswer Answer { get; set; }

        public string UserID { get; set; }
    }
}