using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class DbColumnService : BaseService<DbColumnPO>
    {
        public DbColumnService(IRepository<DbColumnPO> repository) : base(repository)
        {
        }

        /// 
        /// <param name="column"></param>
        /// <param name="userId"></param>
        public int AddDbColumn(DbColumn column, int userId)
        {
            var columnPo = Mapper.Map<DbColumn, DbColumnPO>(column);
            Repository.Add(columnPo, userId);
            return (int)columnPo.COLUMN_ID;
        }

        /// 
		/// <param name="column"></param>
		/// <param name="userId"></param>
		public void SaveDbColumn(DbColumn column, int userId)
        {
            var columnPo = Mapper.Map<DbColumn, DbColumnPO>(column);
            Repository.Update(columnPo, userId);
        }


        /// 
        /// <param name="columnId"></param>
        /// <param name="userId"></param>
        public void DelDbColumn(int columnId, int userId)
        {
            var columnPo = Repository.FindSingle(r => r.COLUMN_ID == columnId);
            Repository.SoftDelete(columnPo, userId);
        }

        /// 
        /// <param name="tableId"></param>
        public List<DbColumn> GetTableColumns(int tableId)
        {
            var columns = Repository.Find(r => r.TABLE_ID == tableId).ToList();
            var list = Mapper.Map<List<DbColumnPO>, List<DbColumn>>(columns);
            return list;
        }
    }
}
