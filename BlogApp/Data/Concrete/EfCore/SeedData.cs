using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void FillTestDatas(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url ="web-programlama"},
                        new Tag { Text = "backend", Url ="backend"},
                        new Tag { Text = "frontend", Url ="frontend"},
                        new Tag { Text = "fullstack", Url ="fullstack"},
                        new Tag { Text = "php", Url ="php"}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "akifguldemir"},
                        new User { UserName = "hilalguldemir"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post { Title = "asp.net Core", Content = "Asp net core dersleri", IsActive = true, PublishedOn = DateTime.Now.AddDays(-10), Tags = context.Tags.Take(3).ToList(), Image = "1.jpg", UserId = 1, Url ="aspnet-core"}, 
                         new Post { Title = "php", Content = "php dersleri", IsActive = true, PublishedOn = DateTime.Now.AddDays(-20), Tags = context.Tags.Take(2).ToList(), Image = "2.jpg", UserId = 1, Url ="php"},
                          new Post { Title = "django", Content = "django dersleri", IsActive = true, PublishedOn = DateTime.Now.AddDays(-5), Tags = context.Tags.Take(4).ToList(), Image = "3.jpg", UserId = 2, Url ="django"}
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}