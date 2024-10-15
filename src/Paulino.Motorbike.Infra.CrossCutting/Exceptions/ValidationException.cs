﻿namespace Paulino.Motorbike.Infra.CrossCutting.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(IEnumerable<string> errors)
            : base("Validation Exception")
        {
            Errors = errors;
        }
    }
}
