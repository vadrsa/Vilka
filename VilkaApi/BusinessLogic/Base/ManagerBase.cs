using System.Collections.Generic;
using System.Reflection;
using BusinessEntities.Base;
using VilkaApi.ResourceAccess.Base;

namespace VilkaApi.BusinessLogic.Base
{
    public abstract class ManagerBase<T, R>
        where T: IDEntityBase, new()
        where R: RepositoryBase<T, R>, new()
    {

        public R Repository{
            get
            {
                return typeof(R).GetProperty("Instance", BindingFlags.Static).GetValue(null) as R;
            }
        }

        public T Insert(T obj){
            return Repository.Insert(obj);
        }

        public void Update(T obj){
            Repository.Update(obj);
        }

        public T SelectByKey(int key){
            return Repository.SelectByKey(key);
        }

        public List<T> SelectAll()
        {
            return Repository.SelectAll();            
        }

    }
}