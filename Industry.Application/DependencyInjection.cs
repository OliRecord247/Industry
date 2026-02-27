using Industry.Application.Messaging;
using Industry.Application.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace Industry.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMqttService, MqttService>();
        services.AddHostedService<TimetableWorker>();
        return services;
    }
}