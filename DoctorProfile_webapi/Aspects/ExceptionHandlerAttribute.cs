using HospitalAppointment.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static webapi.NewFolder2.Exceptions;

namespace HospitalAppointment.Aspects
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var message = exception.Message;
            var exceptionType = context.Exception.GetType();
            var messages= context.Exception.Message;

            //var message = context.Exception.Message;

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
                _ => new ObjectResult(new { error = "An unexpected error occurred." })
                {
                    StatusCode = 500
                }
            };

            context.ExceptionHandled = true;
           
        {

            if (exceptionType == typeof(AppointmentNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(SlotUnavailableException))
            {
                context.Result = new BadRequestObjectResult(message);
            }
            else if (exceptionType == typeof(DoctorNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(PatientNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(InvalidAppointmentStatusException))
            {
                context.Result = new BadRequestObjectResult(message);
            }
            else if (exceptionType == typeof(NotificationNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(NotificationAlreadyReadException))
            {
                context.Result = new BadRequestObjectResult(message);
            }
            else if (exceptionType == typeof(NotificationCreationFailedException))
            {
                context.Result = new ObjectResult(message)
                {
                    StatusCode = 500
                };
            }
            else
            {
                context.Result = new ObjectResult("An unexpected error occurred.")
                {
                    StatusCode = 500
                };
            }

            context.ExceptionHandled = true;
    }
      

            if (exceptionType == typeof(UserNotFoundException))

            {

                var result = new NotFoundObjectResult(message);

                context.Result = result;

            }

            else if (exceptionType == typeof(UserIdAlreadyExistsException))

            {

                var result = new ConflictObjectResult(message);

                context.Result = result;

            }
            else if (exceptionType == typeof(InvalidRatingException))

            {

                var result = new BadRequestObjectResult(message);

                context.Result = result;

            }
            else if (exceptionType == typeof(NotFoundException))
            {
                var result = new NotFoundObjectResult(message);

                context.Result = result;
            }


            else if (exceptionType == typeof(BadRequestException))
            {
                var result = new BadRequestObjectResult(message);

                context.Result = result;
            }
            else

            {

                var result = new StatusCodeResult(500);

                context.Result = result;
            }
        }

        // Fallback for unhandled exceptions
        
    }
}