using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public interface IRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> exp = null);
        
        IQueryable<T> Find(Expression<Func<T, bool>> exp = null);

        IQueryable<T> Find(int pageindex, int pagesize, string orderby = "", Expression<Func<T, bool>> exp = null);

        int GetCount(Expression<Func<T, bool>> exp = null);

        void Add(T entity,int userId);        

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        void Update(T entity,int userId);

        void SoftDelete(T entity,int userId);

        void Delete(T entity);

        void Save();

        int ExecuteSql(string sql);
    }
}
