namespace MinimalApiCrudExample.Filters.UserValidatorFilters;

public class AddUserValidatorFilter : IEndpointFilter
{
    private readonly IValidator<AddUserRequestModel> _validator;
    private readonly ILogger _logger;
    public AddUserValidatorFilter(IValidator<AddUserRequestModel> validator, ILoggerFactory loggerFactory)
    {
        _validator = validator;
        _logger = loggerFactory.CreateLogger<AddUserValidatorFilter>();
    }

    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var userRequestModel = context.GetArgument<AddUserRequestModel>(0);
        var validationResults = await _validator.ValidateAsync(userRequestModel, context.HttpContext.RequestAborted);
        if (!validationResults.IsValid)
        {
            return Results.BadRequest(validationResults.Errors);
        }
        var result = await next(context);
        return result;
    }
}
