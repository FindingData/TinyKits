using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FD.Tiny.FormBuilder  
{
    // //数据源接口表
    [Table("T_API")]
	public partial class ApiPO :EntityBase
	{		      
         	        		
                               
         /// <summary>
		/// 接口ID
        /// </summary>    
            
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
				
        public int  API_ID
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 接口名称
        /// </summary>    
        		
        public string  API_NAME
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 接口描述
        /// </summary>    
        		
        public string  API_DESC
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// SQL语句
        /// </summary>    
        		
        public string  SQL_CONTENT
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 接口地址
        /// </summary>    
        		
        public string  API_URL
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 请求参数
        /// </summary>    
        		
        public string  REQUEST_PARAMETER_CONTENT
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 返回参数
        /// </summary>    
        		
        public string  RESPONSE_PARAMETER_CONTENT
        {
            get;set;
        }			
     	        		
                 	        		
                 	        		
                 	        		
                 	        		
                					 
    }
}
