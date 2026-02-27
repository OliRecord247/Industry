namespace Industry.Api.Endpoints.Machines;

public static class MachinesEndpointsExtensions
{
    public static IEndpointRouteBuilder MapMachineEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCreateMachineJob();
        return app;
    }
}