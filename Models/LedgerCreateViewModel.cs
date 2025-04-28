using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public class LedgerCreateViewModel
    {
        [Required(ErrorMessage = "請選擇類別")]
        // 類別，1=收入, 2=支出
        public string LedgerCategory { get; set; }

        [Required(ErrorMessage = "請輸入金額")]
        [Range(0, double.MaxValue, ErrorMessage = "金額不能為0")]
        // 金額
        public decimal? LedgerAmount { get; set; }

        [Required(ErrorMessage = "請輸入日期")]
        [DataType(DataType.Date, ErrorMessage = "日期格式不正確")]
        // 日期
        public DateTime? LedgerDate { get; set; }

        [Required(ErrorMessage = "請輸入備註")]
        // 備註
        public string LedgerNote { get; set; }
    }
}
