namespace webapi.NewFolder2
{
    public class Exceptions
    {
        public class UserIdAlreadyExistsException : ApplicationException
        {
            public UserIdAlreadyExistsException() { }
            public UserIdAlreadyExistsException(string message) : base(message) { }
        }
        public class UserNotFoundException : ApplicationException
        {
            public UserNotFoundException() { }
            public UserNotFoundException(string message) : base(message) { }
        }
       
        public class InvalidRatingException : ApplicationException
        {
            public InvalidRatingException() { }
            public InvalidRatingException(string message) : base(message) { }
        }
        public class NotFoundException : Exception
        {
            public NotFoundException() { }
            public NotFoundException(string message) : base(message) { }
        }
        public class BadRequestException : Exception
        {
            public BadRequestException() { }
            public BadRequestException(string message) : base(message) { }
        }

    }

}


