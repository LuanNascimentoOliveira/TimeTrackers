using app.Infrastructure;
using app.Mapper;
using app.Repository;
using app.Repository.Interfaces;
using app.Services;
using app.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TimeTracker API", Version = "v1" });
});

// Add database context
builder.Services.AddDbContextPool<TimeTrackerContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("TimeTracker"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TimeTracker")), // Detecta a versão automaticamente
        mySqlOptions => mySqlOptions.EnableRetryOnFailure( // Corrigido para remover redundância
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(60),
            errorNumbersToAdd: null
        )
    );
});

// Add services to the container.
builder.Services.AddScoped<ITimeTrackerService, TimeTrackerService>();
builder.Services.AddScoped<ITimeTrackerRepo, TimeTrackerRepo>();

// Add CORS
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowSpecificOrigin",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Add automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

//add logging
builder.Services.AddLogging(logginBuilder =>
{
    logginBuilder.ClearProviders();
    logginBuilder.AddConsole();
    logginBuilder.AddDebug();
});

var app = builder.Build();

// Configure global exception handler middleware
app.UseMiddleware<GlobalExceptionHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
