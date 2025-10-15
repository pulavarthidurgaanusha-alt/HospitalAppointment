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
                //DoctorDeletionException => new BadRequestObjectResult(new { error = message }),
                DoctorSearchException => new BadRequestObjectResult(new { error = message }),

                // Location-related exceptions
                InvalidDoctorLocationException => new BadRequestObjectResult(new { error = message }),
                LocationNotFoundException => new NotFoundObjectResult(new { error = message }),

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