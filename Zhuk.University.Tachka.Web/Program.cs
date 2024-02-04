using Zhuk.University.Tachka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zhuk.University.Tachka.Web.Data;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Web;
using Microsoft.AspNetCore.Identity;
using Blazorise;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Zhuk.University.Tachka.Models.Database;

var builder = WebApplication.CreateBuilder(args);


builder.Services.RegisterDatabaseDependencies(builder.Configuration);
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ZhukUniversityTachkaWebContext>(options => 

    options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("ZhukUniversityTachkaWebContext") ?? throw new InvalidOperationException("Connection string 'ZhukUniversityTachkaWebContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TachkaDbContext>().AddDefaultTokenProviders();


builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
     {
         googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
         googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
         googleOptions.Events = new OAuthEvents()
         {
             OnRemoteFailure = (context) =>
             {
                 context.Response.Redirect(context?.Properties?.GetString("returnUrl"));
                 context.HandleResponse();
                 return Task.CompletedTask;
             }
         };
     });
<<<<<<< HEAD
=======

>>>>>>> bbf81d0fc82cedf11e1a73c512ced5f2512b79ce


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
});

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
}); 

app.Run();