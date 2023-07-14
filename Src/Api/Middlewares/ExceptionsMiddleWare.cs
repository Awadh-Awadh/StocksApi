using System.Net;
using Application.Exceptions;
using Application.Models;
using Azure.Core;

namespace Api.Middlewares;

public class ExceptionsMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionsMiddleWare> _logger;

    public ExceptionsMiddleWare(RequestDelegate next, ILogger<ExceptionsMiddleWare> logger)
    { 
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong {ex}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // TO:Do log messages based on the type of exception thrown
        var message = ex switch
        {
            ArgumentException => "Arguments should not be null",
            FinhubException => "An Error occured while fetching data"
        };
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }

}