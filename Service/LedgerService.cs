using Homework_SkillTree.Models;
using Homework_SkillTree.Respository;

namespace Homework_SkillTree.Service
{
    public class LedgerService
    {
        private readonly LedgerRespository _ledgerRepository;
        public LedgerService(LedgerRespository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }

        public async Task<List<LedgerViewModel>> GetLedgersData()
        {
            var data = await _ledgerRepository.GetAllLedgersAsync();

            return data.Select((x, index) => new LedgerViewModel
            {
                Id = x.Id,
                ShowID = index.ToString(), // 格式化流水號為4位數
                LedgerCategory = x.LedgerCategory,
                LedgerCategoryName = (x.LedgerCategory == "1" ? "收入" :"支出"),
                LedgerAmount = x.LedgerAmount,
                LedgerNote = x.LedgerNote,
                LedgerDate = x.LedgerDate
            }).ToList();
        }

        public async Task SaveLedgersData(LedgerCreateViewModel viewModel)
        {
            var ledgerModel = new LedgerModel
            {
                LedgerCategory = viewModel.LedgerCategory,  // 轉換類別
                LedgerAmount = (decimal)viewModel.LedgerAmount,      // 轉換金額
                LedgerDate = (DateTime)viewModel.LedgerDate,          // 轉換日期
                LedgerNote = viewModel.LedgerNote         // 轉換備註
            };

            await _ledgerRepository.AddLedgerAsync(ledgerModel);
        }
    }
}
