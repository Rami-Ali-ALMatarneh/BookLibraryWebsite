
using BookLibraryWebsite.Data;
using BookLibraryWebsite.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


/***************ConfigureServices****************/
#region ConfigureServices

/*********Add Mvc**********/

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
}).AddXmlSerializerFormatters();
/*******************/

/*********DbContext Pool ConnectionString**********/
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookLibraryWebsite"));
});
/*******************/

/*********Dependency Injection**********/
builder.Services.AddScoped<IBookRepository,SqlBookRepository>();
/*******************/

#endregion
/*************************************************/


var app = builder.Build();


/*******************Middleware********************/
#region Middleware
if(app.Environment.IsDevelopment())
    {
    app.UseDeveloperExceptionPage();
    }
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
//app.UseMvc(route =>
//{
//    route.MapRoute("Default", template:"{controller=Home}/{action=Index}/{id?}");
//});
app.Run();
#endregion
/*************************************************/

