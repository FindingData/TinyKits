using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder 
{
	//表单变量表
    [Table("T_FORM_VARIABLE")]
	public partial class FormVariablePO :EntityBase
	{		 

      					
		/// <summary>
		/// 变量ID
        /// </summary>        
				
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
        public decimal VARIABLE_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 表单ID
        /// </summary>        
				
        public decimal? FORM_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 变量名称
        /// </summary>        
				
        public string VARIABLE_NAME
        {
            get;set;
        }
						
		/// <summary>
		/// 变量中文名称
        /// </summary>        
				
        public string VARIABLE_NAME_CHS
        {
            get;set;
        }
						
		/// <summary>
		/// 默认值
        /// </summary>        
				
        public string DEFAULT_VALUE
        {
            get;set;
        }
						
		/// <summary>
		/// 条件配置
        /// </summary>        
				
        public string CONDITION_CONFIG
        {
            get;set;
        }
						
		/// <summary>
		/// 数据类型
        /// </summary>        
				
        public decimal? DATA_TYEP
        {
            get;set;
        }
						
		/// <summary>
		/// 是否参数
        /// </summary>        
				
        public decimal? IS_PARAMETER
        {
            get;set;
        }
												 
	}
}