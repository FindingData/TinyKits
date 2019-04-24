using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FD.Tiny.FormBuilder  
{
    // //表单表
    [Table("T_FORM")]
	public partial class FormPO :EntityBase
	{		      
         	        		
                               
         /// <summary>
		/// 表单ID
        /// </summary>    
            
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
				
        public int  FORM_ID
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 表单名称
        /// </summary>    
        		
        public string  FORM_NAME
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 表单描述
        /// </summary>    
        		
        public string  FORM_DESC
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 表单配置
        /// </summary>    
        		
        public string  FORM_CONFIG
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 所属客户
        /// </summary>    
        		
        public int ? CUSTOMER_ID
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 版本编号
        /// </summary>    
        		
        public int ? VERSION_NO
        {
            get;set;
        }			
     	        		
                 	        		
                 	        		
                 	        		
                 	        		
                					 
    }
}
