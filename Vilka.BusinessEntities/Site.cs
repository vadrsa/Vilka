using BusinessEntities.Base;
using LinqToDB.Mapping;

namespace BusinessEntities
{
    [Table("Sites")]
    public class Site : IDEntityBase
    {

        [Column]
        public string Name { get; set; }

        [Column, Nullable]
        public string Link { get; set; }
    }
}