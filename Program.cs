using HospitalManagementSystem.Context;
using HospitalManagementSystem.Data.Models;
using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ====================== CORS ======================
builder.Services.AddCors(options =>
{
    options.AddPolicy("SignalRCorsPolicy", policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000", "https://localhost:3000",
            "http://localhost:5173", "https://localhost:5173",
            "http://localhost:5174", "https://localhost:5174"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

// ====================== Services ======================
var connectionString = builder.Configuration.GetConnectionString("HMS");

builder.Services.AddSignalR();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<MedicineRepository>();
builder.Services.AddScoped(sp => new ChatRepository(connectionString));
builder.Services.AddScoped(sp => new NotificationRepository(connectionString));
builder.Services.AddScoped<DashboardRepository>(sp => new DashboardRepository(connectionString!));
builder.Services.AddScoped<PrescriptionRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// ====================== JWT Authentication ======================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!)),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    // ← IMPORTANT: Prevent redirect to /Account/Login for API calls
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync("{\"message\":\"Unauthorized\"}");
        }
    };
});

builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// ====================== Middleware ======================
app.UseCors("SignalRCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/hubs/chat");
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();