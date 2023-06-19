
var builder = WebApplication.CreateBuilder(args);


/***************ConfigureServices****************/
#region ConfigureServices
/*********Add Mvc**********/

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
}).AddXmlSerializerFormatters();
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
app.UseMvcWithDefaultRoute();
app.Run();
#endregion
/*************************************************/

