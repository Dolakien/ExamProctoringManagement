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

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "Google";
//    options.DefaultSignInScheme = "Google";
//    options.DefaultChallengeScheme = "Google";
//})
//.AddGoogle(options =>
//{
//    options.ClientId = "50226468847-bc42c7csek27129vhdi47ub2654li22l.apps.googleusercontent.com";
//    options.ClientSecret = "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";
//});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtOptions.Issuer,
//        ValidAudience = jwtOptions.Audience,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
//    };
//});



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

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddScoped<ExecuteValidation>();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Exam Proctoring Management API", Version = "v1" });
//});

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443; // Hoặc cổng bạn đã cấu hình cho HTTPS
});


var app = builder.Build();

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
        c.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials() // to support a SignalR
    .WithOrigins("http://localhost:8080"));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();