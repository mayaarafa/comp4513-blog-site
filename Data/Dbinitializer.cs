using Bogus;
using Microsoft.EntityFrameworkCore;
using BlogSite.Models;

namespace BlogSite.Data;

public static class Dbinitializer
{
    public static void Initialize(BlogContext context)
    {
        if(context.Posts.Any())
        {
            return; // database has been seeded
        }

        List<Category> categories = new()
        {
            new Category { Id = 1, Name = "Design" },
            new Category { Id = 2, Name = "Web Development" },
        };

        int authorId = 1;

        Faker<Author> authorFaker = new Faker<Author>()
            .Rules((f, a) =>
            {
                a.Id = authorId++;
                a.FirstName = f.Name.FirstName();
                a.LastName = f.Name.LastName();
            });

        List<Author> authors = authorFaker.Generate(3);

        int postId = 1;

        Faker<Post> postFaker = new Faker<Post>()
            .Rules((f, p) =>
            {
                p.Id = postId++;
                p.Title = f.Lorem.Sentence();
                p.Content = f.Lorem.Paragraphs(5);
                p.Author = f.PickRandom(authors);
                p.Category = f.PickRandom(categories);
            });

        List<Post> posts = postFaker.Generate(5);

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }
}