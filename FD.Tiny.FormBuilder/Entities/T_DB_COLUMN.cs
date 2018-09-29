using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder 
{
	//数据库字段描述表
    [Table("T_DB_COLUMN")]
	public partial class DbColumnPO :EntityBase
	{		 

      					
		/// <summary>
		/// 列Id
        /// </summary>        
				
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
        public decimal COLUMN_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 表Id
        /// </summary>        
				
        public decimal? TABLE_ID
        {
            get;set;
        }
						
		/// <summary>
		/// 列名称
        /// </summary>        
				
        public string COLUMN_NAME
        {
            get;set;
        }
						
		/// <summary>
		/// 列中文名
        /// </summary>        
				
        public string COLUMN_NAME_CHS
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
		/// 长度
        /// </summary>        
				
        public decimal? LENGTH
        {
            get;set;
        }
						
		/// <summary>
		/// 精度
        /// </summary>        
				
        public decimal? PRECISION
        {
            get;set;
        }
						
		/// <summary>
		/// 位数
        /// </summary>        
				
        public decimal? SCALE
        {
            get;set;
        }
												 
	}
}