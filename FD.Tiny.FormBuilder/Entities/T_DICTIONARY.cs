using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FD.Tiny.FormBuilder
{
    //字典表
    [Table("T_DICTIONARY")]
    public partial class DictionaryPO : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID
        {
            get; set;
        }

        /// <summary>
        /// 字典类型ID
        /// </summary>        

        public decimal DIC_TYPE_ID
        {
            get; set;
        }

        /// <summary>
        /// 字典类型名称
        /// </summary>        

        public string DIC_TYPE_NAME
        {
            get; set;
        }

        /// <summary>
        /// 字典详细ID
        /// </summary>        

        public decimal DIC_PAR_ID
        {
            get; set;
        }

        /// <summary>
        /// 字典详细名称
        /// </summary>        

        public string DIC_PAR_NAME
        {
            get; set;
        }

        /// <summary>
        /// 排序编号
        /// </summary>        

        public decimal? ORDER_NO
        {
            get; set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>        

        public decimal? VALID
        {
            get; set;
        }

        /// <summary>
        /// 字典分类(0:常量,1:字典)
        /// </summary>        

        public decimal? DIC_CLASS_ID
        {
            get; set;
        }

        /// <summary>
        /// 字典类型ID(1.0)
        /// </summary>        

        public decimal? DIC_TYPE_ID2
        {
            get; set;
        }

        /// <summary>
        /// 字典详细ID(1.0)
        /// </summary>        

        public decimal? DIC_PAR_ID2
        {
            get; set;
        }

    }
}