using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_SkillTree.Models
{
    public class LedgerModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //流水號
        public int Id { get; set; }

        //類別
        [Required]
        [StringLength(1)]
        public string LedgerCategory { get; set; }

        // 金額
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LedgerAmount { get; set; }

        // 備註
        [Required]
        [StringLength(250)]
        public string LedgerNote { get; set; }

        //日期
        [Required]
        [Column(TypeName ="datetime")]
        public DateTime LedgerDate { get; set; }
    }
}
