using HMS.Implementation.Interface;
using HMS.Implementation.Services;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IBookingServices, BookingService>();
builder.Services.AddTransient<IUserServices, UserService>();
builder.Services.AddTransient<ICustomerServices , CustomerServices>();
builder.Services.AddTransient<IOrderServices , OrderServices>();
builder.Services.AddTransient<IProductServices , ProductServices>(); 
builder.Services.AddTransient<ICustomerReviewService , CustomerReviewService>();

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
