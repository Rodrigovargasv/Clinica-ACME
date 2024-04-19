﻿using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ClinicaACME.Domain.Common.Exceptions;
using ClinicaACME.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;

namespace ClinicaACME.Application.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {

        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
            }

            catch (Exception ex)
            {
                using (LogContext.PushProperty("ErrorId", Guid.NewGuid().ToString()))
                {
                    ErrorResult errorResult = new()
                    {
                        Source = ex.TargetSite?.DeclaringType?.FullName,
                        Exception = ex.Message.Trim()

                    };


                    if (ex is not CustomException && ex.InnerException != null)
                    {
                        while (ex.InnerException != null)
                        {
                            ex = ex.InnerException;
                        }
                    }

                    if (ex is FluentValidation.ValidationException fluentException)
                    {
                        errorResult.Exception = "Erro na requisição. Uma ou mais validações falharam.";
                        foreach (var error in fluentException.Errors)
                        {
                            errorResult.Messages.Add($"[{error.PropertyName}] {error.ErrorMessage}");
                        }
                    }


                    switch (ex)
                    {
                        case CustomException e:
                            errorResult.StatusCode = (int)e.StatusCode;
                            if (e.ErrorMessages is not null)
                            {
                                errorResult.Messages = e.ErrorMessages;
                            }
                            if (e.Message is not null)
                            {
                                errorResult.Message = e.Message;
                            }

                            break;

                        case KeyNotFoundException:
                            errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                            break;

                        case ValidationException:
                            errorResult.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;

                        //case FluentValidation.ValidationException:
                        //    errorResult.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        //    break;

                        default:
                            errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }

                    Log.Error($"{errorResult.Exception} A solicitação falhou com o código de status {errorResult.StatusCode}.");

                    HttpResponse response = context.Response;
                    response.ContentType = "application/json";
                    response.StatusCode = errorResult.StatusCode;
                    await response.WriteAsync(JsonSerializer.Serialize(errorResult));
                }
            }
        }
    }
}
