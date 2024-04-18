
using System.Net;

namespace ClinicaACME.Domain.Common.Exceptions;

public class ConversionErrorException : CustomException
{
    public ConversionErrorException(string message, List<string>? errors = default)
        : base(message, errors, HttpStatusCode.InternalServerError)
    {
    }
}