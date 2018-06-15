using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.DataAccess.OracleTest
{
    public partial class DictionaryDTO
    {
        private decimal _id;
        /// <summary>
        /// ID
        /// </summary>		        
        public decimal ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _dic_type_id;
        /// <summary>
        /// 字典类型ID
        /// </summary>		
        public decimal DIC_TYPE_ID
        {
            get { return _dic_type_id; }
            set { _dic_type_id = value; }
        }
        private string _dic_type_name;
        /// <summary>
        /// 字典类型名称
        /// </summary>		
        public string DIC_TYPE_NAME
        {
            get { return _dic_type_name; }
            set { _dic_type_name = value; }
        }
        private decimal _dic_par_id;
        /// <summary>
        /// 字典详细ID
        /// </summary>		
        public decimal DIC_PAR_ID
        {
            get { return _dic_par_id; }
            set { _dic_par_id = value; }
        }
        private string _dic_par_name;
        /// <summary>
        /// 字典详细名称
        /// </summary>		
        public string DIC_PAR_NAME
        {
            get { return _dic_par_name; }
            set { _dic_par_name = value; }
        }
        private decimal? _order_no;
        /// <summary>
        /// 排序编号
        /// </summary>		
        public decimal? ORDER_NO
        {
            get { return _order_no; }
            set { _order_no = value; }
        }
        private decimal? _valid;
        /// <summary>
        /// 是否启用
        /// </summary>		
        public decimal? VALID
        {
            get { return _valid; }
            set { _valid = value; }
        }
        private DateTime? _created_time;
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime? CREATED_TIME
        {
            get { return _created_time; }
            set { _created_time = value; }
        }
        private decimal? _created_by;
        /// <summary>
        /// 创建人
        /// </summary>		
        
        public decimal? CREATED_BY
        {
            get { return _created_by; }
            set { _created_by = value; }
        }
        private DateTime? _modified_time;
        /// <summary>
        /// 修改时间
        /// </summary>		
        
        public DateTime? MODIFIED_TIME
        {
            get { return _modified_time; }
            set { _modified_time = value; }
        }
        private decimal? _modified_by;
        /// <summary>
        /// 修改人
        /// </summary>		
        
        public decimal? MODIFIED_BY
        {
            get { return _modified_by; }
            set { _modified_by = value; }
        }
        private decimal? _dic_class_id;
        /// <summary>
        /// 字典分类(0:常量,1:字典)
        /// </summary>		
        
        public decimal? DIC_CLASS_ID
        {
            get { return _dic_class_id; }
            set { _dic_class_id = value; }
        }
        private decimal? _dic_type_id2;
        /// <summary>
        /// 字典类型ID(1.0)
        /// </summary>		
        
        public decimal? DIC_TYPE_ID2
        {
            get { return _dic_type_id2; }
            set { _dic_type_id2 = value; }
        }
        private decimal? _dic_par_id2;
        /// <summary>
        /// 字典详细ID(1.0)
        /// </summary>		
        
        public decimal? DIC_PAR_ID2
        {
            get { return _dic_par_id2; }
            set { _dic_par_id2 = value; }
        }

    }
}
