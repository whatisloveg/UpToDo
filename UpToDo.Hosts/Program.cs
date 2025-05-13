using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UpToDo.Application.Shared.Common;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Application.Tasks.Commands;
using UpToDo.Application.Tasks.Queries;
using UpToDo.Application.Users.Commands;
using UpToDo.Infrastructure.DataAccess;
using UpToDo.Infrastructure.DataAccess.Repositories;
using UpToDo.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); 


builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings?.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtSettings?.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings?.Key ?? throw new InvalidOperationException())),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddDbContext<DataBaseContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DataBaseConnectionString")));


builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
builder.Services.AddScoped<ISubtaskRepository, SubtaskRepository>();
builder.Services.AddScoped<ITasksListRepository, TasksListRepository>();

builder.Services.AddScoped<IPasswordHasher, BcryptHasher>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();



builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommand>();
    cfg.RegisterServicesFromAssemblyContaining<LoginUserCommand>();
    
    cfg.RegisterServicesFromAssemblyContaining<CreateToDoTaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<DeleteToDoTaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateToDoTaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<GetAllToDoTasksQuery>();
    cfg.RegisterServicesFromAssemblyContaining<GetToDoTaskByIdQuery>();
});

var app = builder.Build();


app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        context.Response.ContentType = "application/json";

        if (exception is AppException appEx)
        {
            context.Response.StatusCode = appEx.StatusCode;
            await context.Response.WriteAsJsonAsync(new { error = appEx.Message });
        }
        else
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "Внутренняя ошибка сервера" });
        }
    });
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); 
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();   
app.Run();
