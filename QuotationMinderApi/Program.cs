using Microsoft.EntityFrameworkCore;
using QuotationMinderApi.Data;
using QuotationMinderApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<QuotationMinderDbContext>(options =>
    options.UseInMemoryDatabase("QuotationMinderDb"));

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<QuotationMinderDbContext>();
    if (app.Environment.IsDevelopment())
    {
        QuotationMinderDbSeeder.Seed(context);
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
