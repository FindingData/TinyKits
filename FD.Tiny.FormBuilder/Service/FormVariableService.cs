using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class FormVariableService : BaseService<FormVariablePO>
    {
        public FormVariableService(IRepository<FormVariablePO> repository) : base(repository)
        {
        }

        /// 
        /// <param name="formVariable"></param>
        /// <param name="userId"></param>
        public int AddFormVariabel(FormVariable formVariable, int userId)
        {
            var formStorePo = Mapper.Map<FormVariable, FormVariablePO>(formVariable);
            Repository.Add(formStorePo, userId);
            return (int)formStorePo.VARIABLE_ID;
        }

        /// 
        /// <param name="formVariable"></param>
        /// <param name="userId"></param>
        public void SaveFormVariable(FormVariable formVariable, int userId)
        {
            var formStorePo = Mapper.Map<FormVariable, FormVariablePO>(formVariable);
            Repository.Update(formStorePo, userId);
        }

        /// 
        /// <param name="formVariableId"></param>
        /// <param name="userId"></param>
        public void DelFormVariable(int formVariableId, int userId)
        {
            var formStorePo = Repository.FindSingle(r => r.VARIABLE_ID == formVariableId);
            Repository.SoftDelete(formStorePo, userId);
        }

        /// 
        /// <param name="formId"></param>
        public List<FormVariable> GetFormVariableList(int formId)
        {
            var list = Repository.Find(r => r.FORM_ID == formId).ToList();
            return Mapper.Map<List<FormVariablePO>,List<FormVariable>>(list);
        }

        public FormVariable GetFormVariable(int variableId)
        {
            var variable = Repository.FindSingle(r => r.VARIABLE_ID == variableId);
            return Mapper.Map<FormVariablePO, FormVariable>(variable);
        }
    }
}
