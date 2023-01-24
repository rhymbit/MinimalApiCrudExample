namespace MinimalApiCrudExample.BackgroundTasks.UserTasks;

public class UserCountingServiceHostedService : BackgroundService
{
    private IServiceProvider Services { get; }

    public UserCountingServiceHostedService(IServiceProvider services)
    {
        Services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken ctoken)
    {
        using var scope = Services.CreateScope();
        var scopedProcessingService = scope.ServiceProvider.GetRequiredService<UserCountingService>();
        await scopedProcessingService.CountUsers(ctoken);
    }

    public override async Task StopAsync(CancellationToken ctoken)
    {
        await base.StopAsync(ctoken);
    }
}
