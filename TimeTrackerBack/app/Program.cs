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
builder.Services.AddSwaggerGen();
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

builder.Services.AddScoped<ITimeTrackerService, TimeTrackerService>();
builder.Services.AddScoped<ITimeTrackerRepo, TimeTrackerRepo>();
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowSpecificOrigin",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

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
