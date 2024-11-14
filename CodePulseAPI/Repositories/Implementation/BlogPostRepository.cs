using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodePulseAPI.Repositories.Implementation;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly ApplicationDbContext _dbContext;   
    public BlogPostRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<BlogPost> CreateAsync(BlogPost blogPost)
    {
        await _dbContext.BlogPosts.AddAsync(blogPost);
        await _dbContext.SaveChangesAsync();
        return blogPost;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _dbContext.BlogPosts.Include("Categories")
                                         .ToListAsync();
    }
}
