using BusinessEntities.Base;
using LinqToDB;
using LinqToDB.Mapping;

namespace BusinessEntities {

    [Table ("Regions")]
    public class Region : IDEntityBase
    {

        [Column, NotNull]
        public string Name { get; set; }

    }

    public enum RegionAnswer{
        Yes = 1,
        No = 2
    }

}