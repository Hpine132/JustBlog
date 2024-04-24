using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogContext : IdentityDbContext
    {
        public DbSet<PostTagMap>? PostTagMaps { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public JustBlogContext()
        {

        }
        public JustBlogContext(DbContextOptions<JustBlogContext> ops) : base(ops)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostTagMap>().HasKey(pt => new { pt.PostId, pt.TagId });
            modelBuilder.Entity<PostTagMap>().HasOne(pt => pt.Post).WithMany(p => p.PostTagMaps).HasForeignKey(pt => pt.PostId);
            modelBuilder.Entity<PostTagMap>().HasOne(pt => pt.Tag).WithMany(t => t.PostTagMaps).HasForeignKey(pt => pt.TagId);

            new JustBlogInitializer(modelBuilder).Seed();
        }   
    }
}
