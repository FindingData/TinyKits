using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FD.Tiny.Common.Utility;
using FD.Tiny.Common.Utility.EntityFramework;

namespace FD.Tiny.FormBuilder
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        protected FormBuilderContent Context;

        public BaseRepository()
        {
            Context = new FormBuilderContent();
        }

        public BaseRepository(FormBuilderContent contenxt)
        {
            Context = contenxt;
        }
        
        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageindex">The pageindex.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="orderby">排序，格式如："Id"/"Id descending"</param>
        public IQueryable<T> Find(int pageindex, int pagesize, string orderby = "", Expression<Func<T, bool>> exp = null)
        {
            if (pageindex < 1) pageindex = 1;
            if (string.IsNullOrEmpty(orderby))
                orderby = "CREATED_TIME descending";

            return Filter(exp).OrderBy(orderby).Skip(pagesize * (pageindex - 1)).Take(pagesize);
        }

        /// <summary>
        /// 查找单个，且不被上下文所跟踪
        /// </summary>
        public T FindSingle(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }

        public dynamic DynamicFromSql(string sql, Dictionary<string, object> parameters)
        {
            return DynamicListFromSql(sql,parameters).FirstOrDefault();
        }

        public List<dynamic> DynamicListFromSql(string sql, Dictionary<string, object> parameters)
        {
            return Context.DynamicListFromSql(sql, parameters).ToList();
        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public void Add(T entity,int userId)
        {
            entity.CREATED_BY = userId;
            Context.Set<T>().Add(entity);
            Save();            
        }
       
        public void Update(T entity,int userId)
        {
            entity.MODIFIED_BY = userId;
            entity.MODIFIED_TIME = DateTime.Now;
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;

            //如果数据没有发生变化
            if (!this.Context.ChangeTracker.HasChanges())
            {
                return;
            }

            Save();
        }

        public void SoftDelete(T entity, int userId)
        {
            entity.IS_DELETED = 1;
            Update(entity, userId);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw new Exception(e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }
        }

        private IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = Context.Set<T>().AsNoTracking().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }

        public int ExecuteSql(string sql)
        {
            return Context.Database.ExecuteSqlCommand(sql);
        }
        
    }
}
