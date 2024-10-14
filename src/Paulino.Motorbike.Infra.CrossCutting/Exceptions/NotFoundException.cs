﻿namespace Paulino.Motorbike.Infra.CrossCutting.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, Exception ex)
           : base(message, ex) { }
    }
}
