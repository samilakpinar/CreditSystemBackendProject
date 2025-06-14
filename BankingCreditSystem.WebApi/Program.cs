using BankingCreditSystem.Application.Services;
//using BankingCreditSystem.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application Services
builder.Services.AddApplicationServices();

// Add Persistence Services
builder.Services.AddPersistenceServices(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();

