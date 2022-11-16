using Microsoft.EntityFrameworkCore;
using ProductMicroservice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options => options.UseMySql(
   builder.Configuration.GetConnectionString("MySqlConnection"),
   ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))));
builder.Services.AddControllersWithViews();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
 


var app = builder.Build();

app.UseCors("corsapp");
//var datacontext = app.Services.GetRequiredService<ProductDbContext>();
//datacontext.Database.Migrate();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    db.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
