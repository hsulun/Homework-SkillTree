using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public class LedgerCreateModel
    {
        /// <summary>
        /// 類別，0=收入, 1=支出
        /// </summary>
        [Required(ErrorMessage = "請選擇類別")]
        public string LedgerCategory { get; set; }

        /// <summary>
        /// 金額 (Range好像不能用decimal.MaxValue，只好將欄位型態改成double)
        /// </summary>
        [Required(ErrorMessage = "請輸入金額")]
        [Range(0, double.MaxValue, ErrorMessage = "金額不能為0")]
        public double? LedgerAmount { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Required(ErrorMessage = "請輸入日期")]
        [DataType(DataType.Date, ErrorMessage = "日期格式不正確")]
        public DateTime? LedgerDate { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Required(ErrorMessage = "請輸入備註")]
        public string LedgerNote { get; set; }
    }
}
