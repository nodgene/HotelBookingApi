
using HotelBookingApi.Data;
using HotelBookingApi.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add EF Core (SQLite for simplicity).  
builder.Services.AddDbContext<HotelContext>(opt =>
    opt.UseSqlite("Data Source=hotel.db"));
builder.Services.AddScoped<IHotelService, HotelService>();

// Add controllers and swagger.  
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
    app.Run();
