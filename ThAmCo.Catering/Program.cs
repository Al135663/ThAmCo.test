using ThAmCo.Catering.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register database context with the framework
builder.Services.AddDbContext<CateringDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




/*  Standalone testing. comment out app.Run()
var CateringDbContext = new CateringDbContext();    // Create database context

ListMenu(CateringDbContext);// calling listmenu method


// Method to List Menu from the database
static void ListMenu(CateringDbContext dbContext)
{
    // Load list of menu from the database
    var menuList = dbContext.Menus.ToList();

    Console.WriteLine("Menu List\n");

    // Display list of menus from the memory object 
    foreach (var menu in menuList)
    {
        Console.WriteLine($"{menu.MenuId} {menu.MenuName}");
    }
    Console.WriteLine();
}
*/