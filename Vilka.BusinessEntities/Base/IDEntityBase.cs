using LinqToDB.Mapping;

namespace BusinessEntities.Base
{
    public abstract class IDEntityBase
    {
        [PrimaryKey, Identity]
        public int ID { get;set; }
    }
}