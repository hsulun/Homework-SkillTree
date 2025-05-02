using Homework_SkillTree.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Respository
{
    public class LedgerRespository
    {
        private readonly MyDbContext _context;
        
        public LedgerRespository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<LedgerModel>> GetAllLedgersAsync()
        {
            return await _context.Ledger.ToListAsync();
        }

        public async Task AddLedgerAsync(LedgerModel ledger)
        {
            //移除SaveChangesAsync改由Service執行
            await _context.Ledger.AddAsync(ledger);
        }
    }
}
