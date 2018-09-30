using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class FormStoreService : BaseService<FormStorePO>
    {
        public FormStoreService(IRepository<FormStorePO> repository) : base(repository)
        {
        }

        /// 
        /// <param name="store"></param>
        /// <param name="userId"></param>
        public int AddFormStore(FormStore store, int userId)
        {
            var formStorePo = Mapper.Map<FormStore, FormStorePO>(store);
            Repository.Add(formStorePo, userId);
            return (int)formStorePo.STORE_ID;
        }

        /// 
        /// <param name="store"></param>
        /// <param name="userId"></param>
        public void SaveFormStore(FormStore store, int userId)
        {
            var formStorePo = Mapper.Map<FormStore, FormStorePO>(store);
            Repository.Update(formStorePo, userId);
        }

        /// 
        /// <param name="storeId"></param>
        public void DelFormStore(int storeId)
        {
            var formStorePo = Repository.FindSingle(r => r.STORE_ID == storeId);
            Repository.SoftDelete(formStorePo, storeId);
        }

        /// 
        /// <param name="storeId"></param>
        public FormStore GetFormStore(int storeId)
        {
            var formStorePo = Repository.FindSingle(r => r.STORE_ID == storeId);
            return Mapper.Map<FormStorePO, FormStore>(formStorePo);
        }
    }
}
