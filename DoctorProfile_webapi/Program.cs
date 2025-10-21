using HospitalAppointment.Aspects;
using HospitalAppointment.Auth;
using HospitalAppointment.Repositories;
using HospitalAppointment.Repository;
using HospitalAppointment.Service;
using HospitalAppointment.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using System.Text;
using System.Text.Json.Serialization;
//using webapi.IRepository;
//using webapi.IServices;
//using webapi.Repository;
//using webapi.Services;

namespace HospitalAppointment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure DbContext
            builder.Services.AddDbContext<Appointment_BookingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Appointment_BookingContext")
                    ?? throw new InvalidOperationException("Connection string 'Appointment_BookingContext' not found.")));

            // Register repositories and services
            // Register repositories and services
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(); 
            builder.Services.AddScoped<IDoctorService, DoctorService>(); 
            builder.Services.AddScoped<ILocationRepository, LocationRepository>(); 
            builder.Services.AddScoped<ILocationService, LocationService>(); 
            builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>(); 
            builder.Services.AddScoped<IAvailabilityService, AvailabilityService>(); 
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IMedicalHistRepository, MedicalHistRepository>();
            builder.Services.AddScoped<IMedicalHistService, MedicalHistService>();

            // Register global exception handler attribute
            builder.Services.AddScoped<ExceptionHandlerAttribute>();

            // Add controllers with exception filter and JSON enum support
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionHandlerAttribute>();
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            });

            // Swagger configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

// Register repositories and services
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFAQRepository, FAQRepository>();
builder.Services.AddScoped<IFAQService, FAQService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<ITokenService, TokenService>();





// Add JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();
// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();