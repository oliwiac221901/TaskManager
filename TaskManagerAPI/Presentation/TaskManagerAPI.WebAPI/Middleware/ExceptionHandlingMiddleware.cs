using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManagerAPI.Application.Common.ExceptionsError;

namespace TaskManagerAPI.WebAPI.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        object problemDetails;
        int statusCode;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = StatusCodes.Status400BadRequest;
                problemDetails = new ValidationProblemDetails(
                    validationException.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        )
                )
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "One or more validation errors occurred.",
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                };
                break;

            case NotFoundException notFoundException:
                statusCode = StatusCodes.Status404NotFound;
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Resource not found",
                    Detail = notFoundException.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                };
                break;

            default:
                statusCode = StatusCodes.Status500InternalServerError;
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An unexpected error occurred.",
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                };
                break;
        }

        context.Response.StatusCode = statusCode;
        var json = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(json);
    }
}
