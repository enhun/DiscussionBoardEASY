using DiscussionBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscussionBoard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "歡迎來到討論區",
                    Content = "這是一個測試文章，歡迎大家踴躍發言！",
                    Author = "管理員",
                    PostTime = DateTime.Now
                },
                new Post
                {
                    Id = 2,
                    Title = "新功能討論",
                    Content = "對於網站有什麼新功能建議嗎？",
                    Author = "系統管理員",
                    PostTime = DateTime.Now.AddHours(-2)
                }
            );

            modelBuilder.Entity<Reply>().HasData(
                new Reply
                {
                    Id = 1,
                    PostId = 1,
                    Content = "謝謝分享！",
                    Author = "訪客A",
                    ReplyTime = DateTime.Now.AddMinutes(-30)
                },
                new Reply
                {
                    Id = 2,
                    PostId = 1,
                    Content = "期待更多討論！",
                    Author = "訪客B",
                    ReplyTime = DateTime.Now.AddMinutes(-15)
                }
            );
        }
    }
}