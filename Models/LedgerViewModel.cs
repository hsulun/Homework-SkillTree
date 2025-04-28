namespace Homework_SkillTree.Models
{
    public class LedgerViewModel
    {//流水號
        public int Id { get; set; }

        public string ShowID { get; set; }

        public string LedgerCategory { get; set; }
        public string LedgerCategoryName { get; set; }

        //金額
        public decimal LedgerAmount { get; set; }

        // 備註
        public string LedgerNote { get; set; }

        //日期
        public DateTime LedgerDate { get; set; }
    }
}
