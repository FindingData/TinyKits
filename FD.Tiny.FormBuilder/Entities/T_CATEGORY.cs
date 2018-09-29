using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder 
{
	//分类表
    [Table("T_CATEGORY")]
	public partial class CategoryPO :EntityBase
	{		 

      					
		/// <summary>
		/// 分类ID
        /// </summary>        
				
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
        public decimal CATEGORY_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 分类名称
        /// </summary>        
				
        public string CATEGORY_NAME
        {
            get;set;
        }
						
		/// <summary>
		/// 所属客户
        /// </summary>        
				
        public decimal? CUSTOMER_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 分类描述
        /// </summary>        
				
        public string CATEGORY_DESC
        {
            get;set;
        }
												 
	}
}