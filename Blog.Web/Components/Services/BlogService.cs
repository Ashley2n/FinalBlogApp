using Blog.Application.DTOs;
// using System.Net.Http.Json;

public class BlogService
{
    private readonly HttpClient _http;

    public BlogService(HttpClient http)
    {
        _http = http;
    }

    public async Task CreatePostAsync(CreateOrderRequest request)
    {
        await _http.PostAsJsonAsync("api/posts", request);
    }

    public async Task<List<OrderSummaryDto>> GetPostsAsync()
    {
        return await _http.GetFromJsonAsync<List<OrderSummaryDto>>("api/posts");
    }
}