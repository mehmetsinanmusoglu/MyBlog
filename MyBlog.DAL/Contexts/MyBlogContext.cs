using Microsoft.EntityFrameworkCore;
using MyBlog.Common.Security;
using MyBlog.DAL.Config;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;

namespace MyBlog.DAL.Contexts
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CayegoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "mehmetsinanmusoglu@gmail.com",
                Email = "mehmetsinanmusoglu@gmail.com",
                PasswordHash = HashHelper.HashPassword("Ankara1."),
                UserType = UserType.Admin
            
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Post { get; set; }



    }
}
