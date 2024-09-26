using ExamProctoringManagement.API.Extensions;
using ExamProctoringManagement.API.Middleware;
using ExamProctoringManagement.Service.Extensions;
using ExamProctoringManagement.DAO.Extensions;
using ExamProctoringManagement.Repository.Extensions;
using ExamProctoringManagement.Contract.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
//builder.Services.IdentityServices();
builder.Services.AddRepositoryLayer();
builder.Services.AddServiceLayer(builder.Configuration);
builder.Services.AddDAOLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials() // to support a SignalR
    .WithOrigins("http://localhost:5173"));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
