using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UpToDo.Application.AppReviews.Commands;
using UpToDo.Application.Shared.Common;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Application.Subtasks.Commands;
using UpToDo.Application.Subtasks.Queries;
using UpToDo.Application.Tags.Commands;
using UpToDo.Application.Tags.Queries;
using UpToDo.Application.Tasks.Commands;
using UpToDo.Application.Tasks.Queries;
using UpToDo.Application.TasksLists.Commands;
using UpToDo.Application.TasksLists.Queries;
using UpToDo.Application.TimeZones.Queries;
using UpToDo.Application.Users.Commands;
using UpToDo.Application.UserSettings.Commands;
using UpToDo.Application.UserSettings.Queries;
using UpToDo.Infrastructure.DataAccess;
using UpToDo.Infrastructure.DataAccess.Repositories;
using UpToDo.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); 


builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var jwtKey = builder.Configuration["Jwt:Key"];
Console.WriteLine("JWT KEY (debug): " + jwtKey);

var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
Console.WriteLine($"[DEBUG] JwtSettings: Key={jwtSettings?.Key}, Issuer={jwtSettings?.Issuer}, Audience={jwtSettings?.Audience}, Expires={jwtSettings?.ExpiresInMinutes}");


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
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IToDoTaskTagRepository, ToDoTaskTagRepository>();
builder.Services.AddScoped<ITimeZoneItemRepository, TimeZoneItemRepository>();
builder.Services.AddScoped<IUserSettingsRepository, UserSettingsRepository>();
builder.Services.AddScoped<IAppReviewRepository, AppReviewRepository>();

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
    
    cfg.RegisterServicesFromAssemblyContaining<CreateTasksListCommand>();
    cfg.RegisterServicesFromAssemblyContaining<DeleteTasksListCommand>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateTasksListCommand>();
    cfg.RegisterServicesFromAssemblyContaining<GetAllTasksListsByUserIdQuery>();
    cfg.RegisterServicesFromAssemblyContaining<GetTasksListByIdQuery>();
    
    
    cfg.RegisterServicesFromAssemblyContaining<CreateSubtaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<DeleteSubtaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateSubtaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<GetSubtaskByIdQuery>();
    cfg.RegisterServicesFromAssemblyContaining<GetSubtasksByTaskIdQuery>();
    
    cfg.RegisterServicesFromAssemblyContaining<CreateTagCommand>();
    cfg.RegisterServicesFromAssemblyContaining<DeleteTagCommand>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateTagCommand>();
    cfg.RegisterServicesFromAssemblyContaining<GetAllUserTagsQuery>();
    cfg.RegisterServicesFromAssemblyContaining<GetTagByIdQuery>();
    
    cfg.RegisterServicesFromAssemblyContaining<AddTagToTaskToTagCommand>();
    cfg.RegisterServicesFromAssemblyContaining<RemoveTagFromTaskCommand>();
    cfg.RegisterServicesFromAssemblyContaining<GetTaskTagsQuery>();
    
    cfg.RegisterServicesFromAssemblyContaining<GetAllTimeZoneItemsQuery>();
    
    cfg.RegisterServicesFromAssemblyContaining<GetUserSettingsQuery>();
    cfg.RegisterServicesFromAssemblyContaining<UpdateUserSettingsCommand>();
    
    cfg.RegisterServicesFromAssemblyContaining<CreateAppReviewCommand>();
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors();
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
