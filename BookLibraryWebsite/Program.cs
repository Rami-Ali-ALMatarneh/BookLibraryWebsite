
using BookLibraryWebsite.Data;
using BookLibraryWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
/*********AddIdentity**********/
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
/**********Identity Password*********/
builder.Services.Configure<LockoutOptions>(options =>
{
options.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.AllowedForNewUsers = true;
    options.MaxFailedAccessAttempts = 5;
}

);

/*********************/
/*********Dependency Injection**********/

builder.Services.AddScoped<IBookRepository,SqlBookRepository>();
builder.Services.AddScoped<IAlertRepository, SqlScheduleRepository>();

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
else
    {
    app.UseStatusCodePagesWithRedirects("Error/{0}");
    app.UseExceptionHandler("/Error");
    }

app.UseStaticFiles();
app.UseAuthentication();
app.UseMvcWithDefaultRoute();
//app.UseMvc(route =>
//{
//    route.MapRoute("Default", template: "{controller=Home}/{action=Index}/{id}");
//});
app.Run();
#endregion
/*************************************************/

