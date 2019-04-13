using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public  class LabelService :BaseService<LabelPO>
    {
        public LabelService(IRepository<LabelPO> repository) : base(repository)
        {
        }

        /// 
        /// <param name="label"></param>
        /// <param name="userId"></param>
        public int AddLabel(Label label, int userId)
        {           
            var labelPo = Mapper.Map<Label, LabelPO>(label);
            Repository.Add(labelPo, userId);
            return (int)labelPo.LABEL_ID;
        }

        /// 
        /// <param name="label"></param>
        /// <param name="userId"></param>
        public void SaveLabel(Label label, int userId)
        {
            var labelPo = Mapper.Map<Label, LabelPO>(label);            
            Repository.Update(labelPo, userId);
        }

        /// 
        /// <param name="labelId"></param>
        public void DelLabel(int labelId,int userId)
        {
            var labelPo = Repository.FindSingle(r => r.LABEL_ID == labelId);
            Repository.SoftDelete(labelPo, userId);
        }

        /// 
        /// <param name="formId"></param>
        public List<Label> GetLabelList(int formId)
        {
            var list = Repository.Find(r => r.FORM_ID == formId && r.IS_DELETED != 1).ToList();
            return Mapper.Map<List<LabelPO>, List<Label>>(list); ;
        }

        public bool IsExistlabel(int formId, string labelName)
        {
            var labelPo = Repository.FindSingle(r => r.FORM_ID == formId && r.LABEL_NAME_CHS == labelName);
            return labelPo != null;
        }

        public Label GetLabel(int labelId)
        {
            var labelPo = Repository.FindSingle(r => r.LABEL_ID == labelId);
            return Mapper.Map<LabelPO, Label>(labelPo);
        }
        public Label GetLabel(string labelName)
        {
            var labelPo = Repository.FindSingle(r => r.LABEL_NAME_CHS == labelName);
            return Mapper.Map<LabelPO, Label>(labelPo);
        }
    }
}
