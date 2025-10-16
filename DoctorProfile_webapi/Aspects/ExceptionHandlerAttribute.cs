using HospitalAppointment.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalAppointment.Aspects
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var message = exception.Message;

            context.Result = exception switch
            {
                // Doctor-related exceptions
                DoctorAlreadyExistsException => new ConflictObjectResult(new { error = message }),
                DoctorNotFoundException => new NotFoundObjectResult(new { error = message }),
                DoctorCreationException => new BadRequestObjectResult(new { error = message }),
                DoctorUpdateException => new BadRequestObjectResult(new { error = message }),
                DoctorDeletionException => new BadRequestObjectResult(new { error = message }),
                DoctorSearchException => new BadRequestObjectResult(new { error = message }),

                // Location-related exceptions
                InvalidDoctorLocationException => new BadRequestObjectResult(new { error = message }),
                LocationNotFoundException => new NotFoundObjectResult(new { error = message }),

                // Availability-related exceptions
                AvailabilityNotFoundException => new NotFoundObjectResult(new { error = message }),
                AvailabilityNullException => new BadRequestObjectResult(new { error = message }),
                InvalidAvailabilityTimeException => new BadRequestObjectResult(new { error = message }),
                AvailabilityConflictException => new ConflictObjectResult(new { error = message }),

                // Doctor & Location combined exceptions
                DoctorAndLocationNotFoundException => new NotFoundObjectResult(new { error = message }),
                DoctorAvailabilityNotFoundException => new NotFoundObjectResult(new { error = message }),
                DoctorLocationAvailabilityNotFoundException => new NotFoundObjectResult(new { error = message }),

                // Date-related exceptions
                DateAvailabilityNotFoundException => new NotFoundObjectResult(new { error = message }),
                DateDoctorAvailabilityNotFoundException => new NotFoundObjectResult(new { error = message }),
                DateDoctorLocationAvailabilityNotFoundException => new NotFoundObjectResult(new { error = message }),

                // Fallback for unhandled exceptions
                _ => new ObjectResult(new { error = "An unexpected error occurred." })
                {
                    StatusCode = 500
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
