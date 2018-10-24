using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder 
{
	//标签表
    [Table("T_LABEL")]
	public partial class LabelPO :EntityBase
	{		 

      					
		/// <summary>
		/// 标签ID
        /// </summary>        
				
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
        public decimal LABEL_ID
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
		/// 数据类型
        /// </summary>        
				
        public decimal? DATA_TYPE
        {
            get;set;
        }
						
		/// <summary>
		/// 标签名称
        /// </summary>        
				
        public string LABEL_NAME_CHS
        {
            get;set;
        }
						
		/// <summary>
		/// 控件类型
        /// </summary>        
				
        public string CONTROL_TYPE
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
		/// 分组名称
        /// </summary>        
				
        public string GROUP_NAME
        {
            get;set;
        }
						
		/// <summary>
		/// 排序
        /// </summary>        
				
        public decimal? LABEL_SORT
        {
            get;set;
        }
						
		/// <summary>
		/// 标签配置
        /// </summary>        
				
        public string LABEL_CONFIG
        {
            get;set;
        }
												 
	}
}