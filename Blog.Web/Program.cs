using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Domain.Repositories;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories;
using Blog.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetSection("DefaultConnection").Value
             ?? "Data Source=../Blog.Infrastructure/blog.db";
    options.UseSqlite(cs);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBlogPostRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();


//DI Contains
// builder.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
