namespace MinimalApiCrudExample.Filters.UserValidatorFilters;

public class PutUserValidatorFilter : IEndpointFilter
{
    private readonly IValidator<PutUserRequestModel> _validator;
    private readonly ILogger _logger;
    public PutUserValidatorFilter(IValidator<PutUserRequestModel> validator, ILoggerFactory loggerFactory)
    {
        _validator = validator;
        _logger = loggerFactory.CreateLogger<PutUserValidator>();
    }

    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var userRequestModel = context.GetArgument<PutUserRequestModel>(0);
        var validationResults = await _validator.ValidateAsync(userRequestModel, context.HttpContext.RequestAborted);
        if (!validationResults.IsValid)
        {
            return Results.BadRequest(validationResults.Errors);
        }
        var result = await next(context);
        return result;
    }
}
