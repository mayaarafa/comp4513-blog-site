using Microsoft.EntityFrameworkCore;
using BlogSite.Models;

namespace BlogSite.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; } = default!; // database table for posts
    public DbSet<Author> Authors { get; set; } // database table for authors
    public DbSet<Category> Categories { get; set; } // database table for categories
}