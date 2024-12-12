using Diaryapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Diaryapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<DiaryModel> DiaryModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryModel>().HasData(
                    new DiaryModel { Id = 1, Title = "Went for a walk", Content = "dfididjf", Created_at = DateTime.Now },
                    new DiaryModel { Id = 2, Title = "I need to lock-in", Content = "I hate Jake", Created_at = DateTime.Now }
                );
        }
    }
}
