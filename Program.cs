global using hermesTour.Models;
global using hermesTour.Services.TravelerService;
global using hermesTour.Services.TourService;
global using hermesTour.Services.CommentService;
global using hermesTour.Services.CityCountryService;
global using hermesTour.Services.TransportationVehicleService;
global using hermesTour.Services.TransportationWorkersService;
global using hermesTour.Services.AdminService;
global using hermesTour.Services.ManagerService;
global using hermesTour.Services.HotelService;
global using hermesTour.Dtos.Traveler;
global using hermesTour.Dtos.Tour;
global using hermesTour.Dtos.Comment;
global using hermesTour.Dtos.CityCountry;
global using hermesTour.Dtos.TransportationVehicle;
global using hermesTour.Dtos.TransportationWorkers;
global using hermesTour.Dtos.Admin;
global using hermesTour.Dtos.Manager;
global using hermesTour.Dtos.Hotel;
global using hermesTour.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ITravelerService, TravelerService>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICityCountryService, CityCountryService>();
builder.Services.AddScoped<ITransportationVehicleService, TransportationVehicleService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<ITransportationWorkersService, TransportationWorkersService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
