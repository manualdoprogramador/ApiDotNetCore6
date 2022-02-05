using System;
namespace MP.ApiDotNet6.Domain.Validations
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        {
        }

        public static void When(bool hasError, string erro)
        {
            if (hasError)
                throw new DomainValidationException(erro);
        }
    }
}

