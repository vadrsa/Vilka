using System;
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
                return typeof(R).GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(null, null) as R;
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

        protected void ExecuteTransaction(Action action)
        {
            using(DBContext context = new DBContext())
            {
                context.BeginTransaction();
                try
                {
                    action();
                }
                catch
                {
                    context.RollbackTransaction();
                }
                context.CommitTransaction();
            }
        }

    }
}