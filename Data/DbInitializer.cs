using Bogus;
using Microsoft.EntityFrameworkCore;
using BlogSite.Models;

namespace BlogSite.Data;


public static class DbInitializer
{
    public static void Initialize(BlogContext context)
    {
        if (context.Posts.Any())
        {
            return;
        }

        var authorId = 1;
        var authorFaker = new Faker<Author>()
        .Rules((f, a) =>
        {
            a.Id = authorId;
            a.FirstName = f.Name.FirstName();
            a.LastName = f.Name.LastName();

        });
        List<Author> authors = authorFaker.Generate(3);

        var postId = 1;

        var postFaker = new Faker<Post>()
        .Rules((f, p) =>
        {
            p.Id = postId++;
            p.Title = f.Lorem.Sentence();
            p.Content = f.Lorem.Paragraphs(5);
            p.Author = f.PickRandom(authors);
        });

        List<Post> posts = postFaker.Generate(5);

        List<Category> categories = new()
        {
            new Category {Id = 1, Name = "Design"},
            new Category{ Id = 2, Name= "Web Development"},
        };

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }
}

// using Bogus;
// using BlogSite.Models;

// namespace BlogSite.Data;

// public static class DbInitializer
// {
//     public static void Initialize(BlogContext context)
//     {
//         if (context.Posts.Any())
//         {
//             return;
//         }

//         var authorFaker = new Faker<Author>()
//             .Rules((f, a) =>
//             {
//                 a.FirstName = f.Name.FirstName();
//                 a.LastName = f.Name.LastName();
//             });

//         List<Author> authors = authorFaker.Generate(3);

//         context.Authors.AddRange(authors);
//         context.SaveChanges();

//         var postFaker = new Faker<Post>()
//             .Rules((f, p) =>
//             {
//                 p.Title = f.Lorem.Sentence();
//                 p.Content = f.Lorem.Paragraphs(5);
//                 p.AuthorId = f.PickRandom(authors).Id;
//             });

//         List<Post> posts = postFaker.Generate(5);

//         List<Category> categories = new()
//         {
//             new Category { Name = "Design" },
//             new Category { Name = "Web Development" },
//         };

//         context.Categories.AddRange(categories);
//         context.Posts.AddRange(posts);
//         context.SaveChanges();
//     }
// }