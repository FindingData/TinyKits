using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder 
{
	//数据库表描述表
    [Table("T_DB_TABLE")]
	public partial class DbTablePO :EntityBase
	{		 

      					
		/// <summary>
		/// 表ID
        /// </summary>        
				
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
        public decimal TABLE_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 表名称
        /// </summary>        
				
        public string TABLE_NAME
        {
            get;set;
        }
						
		/// <summary>
		/// 表中文名
        /// </summary>        
				
        public string TABLE_NAME_CHS
        {
            get;set;
        }
						
		/// <summary>
		/// 表用户名称
        /// </summary>        
				
        public string SCHEMA_NAME
        {
            get;set;
        }
												 
	}
}