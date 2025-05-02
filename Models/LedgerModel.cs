using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Homework_SkillTree.Models
{
    public class LedgerModel
    {
        /// <summary>
        /// GUID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public LedgerCategory Categoryyy { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public int Amounttt { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Dateee { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remarkkk { get; set; }

    }

    public enum LedgerCategory
    {
        /// <summary>
        /// 收入
        /// </summary>
        [Display(Name = "收入")]
        Income = 0,
        /// <summary>
        /// 支出
        /// </summary>
        [Display(Name = "支出")]
        Expense = 1
    }
}
