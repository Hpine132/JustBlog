using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogInitializer
    {
        private readonly ModelBuilder _builder;

        public JustBlogInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {

            _builder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Category 1", UrlSlug = "urlslug 1", Description = "Category 1 for you" },
               new Category { Id = 2, Name = "Category 2", UrlSlug = "urlslug 2", Description = "Category 2 for you" },
               new Category { Id = 3, Name = "Category 3", UrlSlug = "urlslug 3", Description = "Category 3 for you" },
               new Category { Id = 4, Name = "Category 4", UrlSlug = "urlslug 4", Description = "Category 4 for you" },
               new Category { Id = 5, Name = "Category 5", UrlSlug = "urlslug 5", Description = "Category 5 for you" }
            );

            _builder.Entity<Tag>(t =>
            {
                t.HasData(new Tag
                {
                    Id = 1,
                    Name = "Test1",
                    UrlSlug = "Test",
                    Description = "Test12"
                });
                t.HasData(new Tag
                {
                    Id = 2,
                    Name = "Test2",
                    UrlSlug = "Test",
                    Description = "Test12"
                });
                t.HasData(new Tag
                {
                    Id = 3,
                    Name = "Test3",
                    UrlSlug = "Test",
                    Description = "Test1212"
                });
            });

            _builder.Entity<Post>().HasData(
                        new Post
                        {
                            Id = 1,
                            Title = "Post 1",
                            PostContent = "Post Content 1",
                            ShortDescription = "Post 1 for you",
                            UrlSlug = "urlslug 1",
                            CategoryId = 1,
                            Published = true,
                            PostedOn = new DateTime(2022, 6, 4),
                            Modified = DateTime.Now
                        },
                        new Post
                        {
                            Id = 2,
                            Title = "Post 2",
                            PostContent = "Post Content 2",
                            ShortDescription = "Post 2 for you",
                            UrlSlug = "urlslug 2",
                            CategoryId = 4,
                            Published = false,
                            PostedOn = new DateTime(2022, 8, 4),
                            Modified = DateTime.Now
                        },
                        new Post
                        {
                            Id = 3,
                            Title = "Post 3",
                            PostContent = "Post Content 3",
                            ShortDescription = "Post 3 for you",
                            UrlSlug = "urlslug 3",
                            CategoryId = 1,
                            Published = true,
                            PostedOn = new DateTime(2023, 8, 4),
                            Modified = DateTime.Now
                        },
                        new Post
                        {
                            Id = 4,
                            Title = "Post 4",
                            PostContent = "Post Content 4",
                            ShortDescription = "Post 4 for you",
                            UrlSlug = "urlslug 4",
                            CategoryId = 2,
                            Published = false,
                            PostedOn = new DateTime(2022, 5, 1),
                            Modified = DateTime.Now
                        },
                        new Post
                        {
                            Id = 5,
                            Title = "Post 5",
                            PostContent = "Post Content 5",
                            ShortDescription = "Post 5 for you",
                            UrlSlug = "urlslug 5",
                            CategoryId = 2,
                            Published = true,
                            PostedOn = new DateTime(2023, 12, 4),
                            Modified = DateTime.Now
                        },
                        new Post
                        {
                            Id = 6,
                            Title = "Post 6",
                            PostContent = "Post Content 6",
                            ShortDescription = "Post 6 for you",
                            UrlSlug = "urlslug 6",
                            CategoryId = 1,
                            Published = true,
                            PostedOn = new DateTime(2023, 1, 1),
                            Modified = DateTime.Now
                        }
                  );

            _builder.Entity<PostTagMap>(pt =>
            {
                pt.HasData(new PostTagMap
                {
                    PostId = 1,
                    TagId = 2
                });
                pt.HasData(new PostTagMap
                {
                    PostId = 2,
                    TagId = 2
                });
                pt.HasData(new PostTagMap
                {
                    PostId = 3,
                    TagId = 1
                });
                pt.HasData(new PostTagMap
                {
                    PostId = 4,
                    TagId = 1
                });
                pt.HasData(new PostTagMap
                {
                    PostId = 2,
                    TagId = 1
                });
                pt.HasData(new PostTagMap
                {
                    PostId = 1,
                    TagId = 1
                });
            });
        }
    }
}

