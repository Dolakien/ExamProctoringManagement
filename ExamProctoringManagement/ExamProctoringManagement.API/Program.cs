using ExamProctoringManagement.API.Extensions;
using ExamProctoringManagement.API.Middleware;
using ExamProctoringManagement.Service.Extensions;
using ExamProctoringManagement.DAO.Extensions;
using ExamProctoringManagement.Repository.Extensions;
using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Service.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ExamProctoringManagement.Service.Usecases;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.DAO;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System.Text.Json.Serialization;
using ExamProctoringManagement.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
//builder.Services.IdentityServices();
builder.Services.IdentityServices();
builder.Services.AddRepositoryLayer();
builder.Services.AddServiceLayer(builder.Configuration);
builder.Services.AddDAOLayer(builder.Configuration);
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddScoped<ExamDAO>();
builder.Services.AddScoped<FormSlotDAO>();
builder.Services.AddScoped<FormSwapDAO>();
builder.Services.AddScoped<GroupDAO>();
builder.Services.AddScoped<GroupRoomDAO>();
builder.Services.AddScoped<ProctoringScheduleDAO>();
builder.Services.AddScoped<RegistrationFormDAO>();
builder.Services.AddScoped<ReportDAO>();
builder.Services.AddScoped<RoleDAO>();
builder.Services.AddScoped<RoomDAO>();
builder.Services.AddScoped<SemesterDAO>();
builder.Services.AddScoped<SlotDAO>();
builder.Services.AddScoped<SlotReferenceDAO>();
builder.Services.AddScoped<SlotRoomSubjectDAO>();
builder.Services.AddScoped<SubjectDAO>();

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443; // Hoặc cổng bạn đã cấu hình cho HTTPS
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "KooHee API V1");
        c.DisplayRequestDuration();
        c.RoutePrefix = string.Empty;
    });
}

// Remove or comment out the following line
// app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();