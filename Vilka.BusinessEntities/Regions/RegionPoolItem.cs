using BusinessEntities.Base;
using LinqToDB.Mapping;

namespace BusinessEntities
{
    [Table("RegionPool")]
    public class RegionPoolItem : IDEntityBase
    {

        [Column]
        public string Name { get; set; }

        [Column]
        public int SiteID { get; set; }

        [Column]
        public long TransactionNumber { get; set; }
        
        public override bool Equals(object obj)
        {
            RegionPoolItem compTo = obj as RegionPoolItem;
            if (obj == null) return false;
            return compTo.Name == this.Name;
        }
    }
}