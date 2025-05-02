using Homework_SkillTree.Models;
using Homework_SkillTree.Respository;

namespace Homework_SkillTree.Service
{
    public class LedgerService
    {
        private readonly LedgerRespository _ledgerRepository;
        private readonly MyDbContext _context;
        public LedgerService(LedgerRespository ledgerRepository, MyDbContext context)
        {
            _ledgerRepository = ledgerRepository;
            _context = context;
        }

        public async Task<List<LedgerViewModel>> GetLedgersData()
        {
            var data = await _ledgerRepository.GetAllLedgersAsync();
            //先將DB取出的資料按照日期由新至舊排序
            data = data.OrderByDescending(x => x.Dateee).ToList();

            //再將DB取出的資料轉換成ViewModel
            return data.Select((x, index) => new LedgerViewModel
            {
                Id = index + 1,
                ShowID = (index + 1).ToString("D4"), // 格式化流水號為4位數
                LedgerCategory = x.Categoryyy.ToString(),
                LedgerCategoryName = (x.Categoryyy.ToString() == "0" ? "收入" :"支出"),
                LedgerAmount = x.Amounttt,
                LedgerNote = x.Remarkkk,
                LedgerDate = x.Dateee
            }).ToList();
        }

        public async Task SaveLedgersData(LedgerCreateModel viewModel)
        {
            //將前端Model轉成DB Model
            var ledgerModel = new LedgerModel
            {
                // 產生唯一識別碼
                Id = Guid.NewGuid(),
                // 轉換類別
                Categoryyy = (LedgerCategory)Convert.ToInt16(viewModel.LedgerCategory),
                // 轉換金額
                Amounttt = Convert.ToInt32(viewModel.LedgerAmount),
                // 轉換日期
                Dateee = (DateTime)viewModel.LedgerDate,
                // 轉換備註
                Remarkkk = viewModel.LedgerNote
            };

            await _ledgerRepository.AddLedgerAsync(ledgerModel);
            //改由Service執行SaveChangesAsync
            await _context.SaveChangesAsync();
        }
    }
}
