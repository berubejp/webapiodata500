using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData;
using WebApplication3;
using WebApplication3.Entites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookDbContext>(opt => opt.UseInMemoryDatabase("BookDbContext"));

builder.Services.AddControllers().AddOData(o => o.EnableQueryFeatures().AddRouteComponents("odata", EdmModel.GetEdmModel()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var serviceScope = serviceScopeFactory.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<BookDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();

