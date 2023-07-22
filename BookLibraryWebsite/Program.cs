
using BookLibraryWebsite.Data;
using BookLibraryWebsite.Models;
using BookLibraryWebsite.Models.Repository;
using BookLibraryWebsite.Models.SqlRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


/***************ConfigureServices****************/
#region ConfigureServices

/*********Add Mvc**********/

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
    /******************Authorization*******************/
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
    /**************************************************/

}).AddXmlSerializerFormatters();
/*******************/

/*********DbContext Pool ConnectionString**********/
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
     
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookLibraryWebsite"));
});
/*********AddIdentity**********/
builder.Services.AddIdentity<AppUser, IdentityRole>()
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
builder.Services.AddScoped<ICartRepository, SqlCartRepository>();
builder.Services.AddScoped<IContactUsRepository, SqlContactUsRepository>();



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

