using Domain.Exceptions;
using OrderManagementSystem.SharedDTO;
using Shared.ErrorModels;
using System.Net;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
            await HandleNotFoundEndPointAsync(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var response = new Response
        {
            ErrorMessage = ex.Message
        };
        response.StatusCode = ex switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            BadRequestException badRequestException => GetValidationErrors(badRequestException, response),
            _ => StatusCodes.Status500InternalServerError
        };
        context.Response.StatusCode = response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);

    }

    private static int GetValidationErrors(BadRequestException badRequestException, Response response)
    {
        response.Errors = badRequestException.Errors;
        return StatusCodes.Status400BadRequest;
    }

    private static async Task HandleNotFoundEndPointAsync(HttpContext context)
    {
        if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
        {
            context.Response.ContentType = "application/json";
            var response = new Response
            {
                ErrorMessage = $"End Point {context.Request.Path} Not Found",
                StatusCode = (int)HttpStatusCode.NotFound
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
