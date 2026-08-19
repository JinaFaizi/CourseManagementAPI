using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Repositories;
using CourseManagement.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICourseRepository, InMemoryCourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();