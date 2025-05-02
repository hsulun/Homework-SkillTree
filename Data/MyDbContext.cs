using Homework_SkillTree.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Respository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public DbSet<LedgerModel> Ledger { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LedgerModel>().ToTable("AccountBook");
        }

    }
}
