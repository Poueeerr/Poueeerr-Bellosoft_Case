using Microsoft.EntityFrameworkCore;
using Studying.Models;

namespace Studying.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<NewsModel> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Name = "Felipe Skubs", Email = "skubs130@gmail.com", Password = "AQAAAAEAACcQAAAAEHPceoDJudH/02cxsFX5yobpCak0/Cb/Lh+mFZ6KPEtxajnCX3ZxzgwvuToxxIWHEg==" }
            );
        }
    }
}
