using Microsoft.AspNetCore.Builder;
using System.Text;
using System.Xml.Linq;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<UserService>();
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
builder.Configuration.AddJsonFile("Book.json");
builder.Configuration.AddJsonFile("User.json");
app.Map("/library", () => "Welcome!");
app.Map("/library/books", (IConfiguration appConfig, HttpContext context) =>
{
    StringBuilder sb = new();
    context.Response.ContentType = "text/html; charset=utf-8";
    sb.Append("Books info");
    sb.Append("<table>");
    sb.Append("<td>Name</td><td>Year</td><td>Genre</td><td>Author</td>");
    foreach (var book in appConfig.GetSection("books").GetChildren())
    {
        Book book1 = book.Get<Book>();
        sb.Append("<tr>" + book1.GetBookInfo() + "</tr>");
    }
    sb.Append("</table>");
    return sb.ToString();
});
app.Map("/library/profile/{id:range(0,5)?}", (UserService user1, HttpContext context, int? id) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    return user1.GetUserProfile(id);
});
app.Run();
