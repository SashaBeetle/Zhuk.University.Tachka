using Zhuk.University.Tachka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zhuk.University.Tachka.Web.Data;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Web;


var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDatabaseDependencies(builder.Configuration);

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddAutoMapper(typeof(UserProfile));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ZhukUniversityTachkaWebContext>(options =>
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZhukUniversityTachkaWebContext") ?? throw new InvalidOperationException("Connection string 'ZhukUniversityTachkaWebContext' not found.")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
