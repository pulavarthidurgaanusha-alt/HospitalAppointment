using HospitalAppointment.Aspects;
//using HospitalMedicalHistory.Data;
using HospitalAppointment.Repositories;
using HospitalAppointment.Repository;
using HospitalAppointment.Service;
using HospitalAppointment.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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

            var app = builder.Build();

            // Development-specific middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
