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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Google";
    options.DefaultSignInScheme = "Google";
    options.DefaultChallengeScheme = "Google";
})
.AddGoogle(options =>
{
    options.ClientId = "50226468847-bc42c7csek27129vhdi47ub2654li22l.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IFormSlotRepository, FormSlotRepository>();
builder.Services.AddScoped<IFormSwapRepository, FormSwapRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupRoomRepository, GroupRoomRepository>();
builder.Services.AddScoped<IProctoringScheduleRepository, ProctoringScheduleRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IRegistrationFormRepository, RegistrationFormRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<ISlotRepository, SlotRepository>();
builder.Services.AddScoped<ISlotRoomSubjectRepository, SlotRoomSubjectRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IFormSlotService, FormSlotService>();
builder.Services.AddScoped<IFormSwapService, FormSwapService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IGroupRoomService, GroupRoomService>();
builder.Services.AddScoped<IProctoringScheduleService, ProctoringScheduleService>();
builder.Services.AddScoped<IRegistrationFormService, RegistrationFormService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<ISlotService, SlotService>();
builder.Services.AddScoped<ISlotRoomSubjectService, SlotRoomSubjectService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IUserService, UserService>();

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
