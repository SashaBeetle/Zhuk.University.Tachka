using Zhuk.University.Tachka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zhuk.University.Tachka.Web.Data;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Web;
using Microsoft.AspNetCore.Identity;
using Blazorise;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);


builder.Services.RegisterDatabaseDependencies(builder.Configuration);
//builder.Services.RegisterIdentityDependencies();
builder.Services.AddApplicationInsightsTelemetry();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ZhukUniversityTachkaWebContext>(options => 

    options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("ZhukUniversityTachkaWebContext") ?? throw new InvalidOperationException("Connection string 'ZhukUniversityTachkaWebContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TachkaDbContext>().AddDefaultTokenProviders();


//builder.Services.AddAuthentication()
//    //.AddMicrosoftAccount(microsoftOptions =>
//    //{
//    //    microsoftOptions.ClientId = builder.Configuration["WEBSITE_AUTH_MICROSOFT_CONSUMER_KEY"];
//    //    microsoftOptions.ClientSecret = builder.Configuration["WEBSITE_AUTH_MICROSOFT_CONSUMER_SECRET"];
//    //})
//    .AddGoogle(googleOptions =>
//     {
//         googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//         googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//     });
//    //.AddTwitter(twitterOptions =>
//    //{
//    //    twitterOptions.ConsumerKey = builder.Configuration["Authentication:Twitter:ConsumerAPIKey"];
//    //    twitterOptions.ConsumerSecret = builder.Configuration["Authentication:Twitter:ConsumerSecret"];
//    //});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();