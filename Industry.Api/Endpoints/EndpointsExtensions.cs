using Industry.Api.Endpoints.Machines;

namespace Industry.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapMachineEndpoints();
        return app;
    }
}