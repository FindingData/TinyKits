using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder 
{
	//表单存储表
    [Table("T_FORM_STORE")]
	public partial class FormStorePO :EntityBase
	{		 

      					
		/// <summary>
		/// 存储ID
        /// </summary>        
				
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
        public decimal STORE_ID
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
		/// 表单数据
        /// </summary>        
				
        public string DATA_STORE_CONTENT
        {
            get;set;
        }
						
		/// <summary>
		/// 变量数据
        /// </summary>        
				
        public string FORM_STORE_CONTENT
        {
            get;set;
        }
						
		/// <summary>
		/// 公司ID
        /// </summary>        
				
        public decimal? CUSTOMER_ID
        {
            get;set;
        }
												 
	}
}