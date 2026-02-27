using Industry.Api.Mapping;
using Industry.Contracts.requests;
using Industry.Infrastructure.Repositories;

namespace Industry.Api.Endpoints.Machines;

public static class CreateMachineJob
{
    public const string Name = "CreateMachineJob";
    
    public static IEndpointRouteBuilder MapCreateMachineJob(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Machines.CreateJob, async (CreateMachineJobRequest request, 
                IJobRepository jobRepository, CancellationToken cancellationToken) =>
            {
                var machineJob = request.MapToMachineJob();
                await jobRepository.AddJobAsync(machineJob, cancellationToken);
                return Results.Ok();
            })
            .WithName(Name);
        
        return app;
    }
}