using Sample_Server.Src.BusinessLogic;
using Sample_Server.Src.DataAccess;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// BL Dependency Injection
builder.Services.AddScoped<ICustomersBL, CustomersBL>();
builder.Services.AddScoped<IOrdersBL, OrdersBL>();

// DAL Dependency Injection
builder.Services.AddScoped<IOrdersDAL, OrdersDAL>();
builder.Services.AddScoped<ICustomersDAL, CustomersDAL>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Initiate CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                      });
});

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

app.UseCors(MyAllowSpecificOrigins);

app.Run();


