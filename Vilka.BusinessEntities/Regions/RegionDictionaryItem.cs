using BusinessEntities.Base;
using LinqToDB.Mapping;

namespace BusinessEntities
{
    [Table("RegionDictionary")]
    public class RegionDictionaryItem : IDEntityBase
    {

        [Column]
        public Region Region { get; set; }

        [Column]
        public Site Site { get; set; }

        [Column]
        public string Name { get; set; }
    }
}