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

                // Middleware exceptions
                System.UnauthorizedAccessException => new UnauthorizedObjectResult(new { error = message }),
                ProfileNotFoundException => new NotFoundObjectResult(new { error = message }),
                ValidationException => new BadRequestObjectResult(new { error = message }),
                MissingDataException => new ObjectResult(new { error = message }) { StatusCode = 206 },
                NavigationException => new ObjectResult(new { error = message }) { StatusCode = 502 },

                // Medical history exceptions
                NotFoundException => new NotFoundObjectResult(new { error = message }),
                MedicalHistoryCreationException => new BadRequestObjectResult(new { error = message }),
                DoctorAuthorizationException => new ForbidResult(),

                // Fallback for unhandled exceptions
                _ => new ObjectResult(new { error = "An unexpected error occurred." })
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
