using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FD.Tiny.FormBuilder  
{
    // //数据表
    [Table("T_DATA")]
	public partial class DataPO :EntityBase
	{		      
         	        		
                               
         /// <summary>
		/// 数据ID
        /// </summary>    
            
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
				
        public int  DATA_ID
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 数据名称
        /// </summary>    
        		
        public string  DATA_NAME
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 同义词ID
        /// </summary>    
        		
        public int ? SYN_DATA_ID
        {
            get;set;
        }			
     	        		
                               
         /// <summary>
		/// 分组名称
        /// </summary>    
        		
        public string  GROUP_NAME
        {
            get;set;
        }			
     	        		
                 	        		
                 	        		
                 	        		
                 	        		
                					 
    }
}
