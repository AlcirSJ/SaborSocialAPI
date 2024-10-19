using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostsController : ControllerBase
{
    private readonly IBlogPostRepository _blogPostRepository;
    public BlogPostsController(IBlogPostRepository blogPostRepository)
    {
       _blogPostRepository = blogPostRepository;
    }
    // POST: {apibaseurl}/api/blogposts
    [HttpPost]
    public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
    {
        //Dto to domain model
        var blogPost = new BlogPost
        {
            Author = request.Author,
            Title = request.Title,
            Content = request.Content,
            IsVisible = request.IsVisible,
            ShortDescription = request.ShortDescription,
            FeaturedImageUrl = request.FeaturedImageUrl,
            PublishedDate = request.PublishedDate,
            UrlHandle = request.UrlHandle
        };

        blogPost = await _blogPostRepository.CreateAsync(blogPost);

        //Domain model to Dto
        var response = new BlogPostDto
        {
            Id = blogPost.Id,
            Author = blogPost.Author,
            Title = blogPost.Title,
            Content = blogPost.Content,
            IsVisible = blogPost.IsVisible,
            ShortDescription = blogPost.ShortDescription,
            FeaturedImageUrl = blogPost.FeaturedImageUrl,
            PublishedDate = blogPost.PublishedDate,
            UrlHandle = blogPost.UrlHandle
        };

        return Ok(response);
    }

    // GET: {apibaseurl}/api/blogposts
    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
       var blogPosts =  await _blogPostRepository.GetAllAsync();

        var response = new List<BlogPostDto>();
        foreach(var blogPost in blogPosts)
        {
            response.Add(new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Title = blogPost.Title,
                Content = blogPost.Content,
                IsVisible = blogPost.IsVisible,
                ShortDescription = blogPost.ShortDescription,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                PublishedDate = blogPost.PublishedDate,
                UrlHandle = blogPost.UrlHandle
            });
        }

        return Ok(response);
    }
}
