using BusinessEntities.Base;
using LinqToDB.Mapping;
using System;

namespace BusinessEntities
{
    [Table("RegionHistory")]
    public class RegionHistoryItem : IDEntityBase
    {

        [Column]
        public int RegionQuestionID { get; set; }

        [Column]
        public RegionAnswer Answer { get; set; }
        [Column]
        public string UserID { get; set; }

        [Column]
        public DateTime AnsweredOn { get; set; }
    }
}