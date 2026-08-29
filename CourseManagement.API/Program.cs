
using CourseManagement.Service.Data;
using Microsoft.EntityFrameworkCore;
using CourseManagement.API.Extensions;
using DbContext = CourseManagement.Service.Data.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<DbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});
builder.Services.AddCourseServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();