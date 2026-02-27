using Industry.Domain.Messaging;
using Industry.Infrastructure.Data;
using Industry.Infrastructure.Messaging;
using Industry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Industry.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TimetableDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddSingleton<IMessageBroker, MqttMessageBroker>();
        
        return services;
    }
}