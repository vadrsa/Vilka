using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessEntities.Base;
using LinqToDB;

namespace VilkaApi.ResourceAccess.Base
{
    public abstract class RepositoryBase<T, R>
        where T: IDEntityBase
        where R: new()
    {

        List<Expression<Func<T, object>>> LoadWithList = new List<Expression<Func<T, object>>>();

        public RepositoryBase<T, R> LoadWith(Expression<Func<T, object>> exp){
            LoadWithList.Add(exp);
            return this;
        }

        private ITable<T> GetTable(DBContext context){
            ITable<T> table = TableExpression.Compile()(context);
            foreach(var exp in LoadWithList){
                table.LoadWith(exp);
            }
            return table;
        }

        private void ExecuteSelect(Action<ITable<T>> action, DBContext context){
            action(GetTable(context));
            LoadWithList.Clear();        
        }

        private R ExecuteSelect<R>(Func<ITable<T>, R> func, DBContext context){
            R res = func(GetTable(context));
            LoadWithList.Clear();
            return res;
        }

        protected abstract Expression<Func<DBContext, ITable<T>>> TableExpression { get; }

        private static R instance;
        public static R Instance{
            get{
                if(instance == null)
                    instance = new R();
                return instance;
            }
        }

        public T Insert(T obj){
            using(DBContext context =  new DBContext()){
                obj.ID = context.InsertWithInt32Identity(obj);
                return obj;
            }
        }

        public void Update(T obj){
            using(DBContext context = new DBContext()){
                context.Update(obj);
            }
        }

        public T SelectByKey(int key){
            using(DBContext context = new DBContext()){
                return ExecuteSelect(t => t.Where(o => o.ID == key).Single(), context);
            }
        }

        public List<T> SelectAll()
        {
            using(DBContext context = new DBContext()){
                return ExecuteSelect(t => t.ToList(), context);
            }
        }
    }
}