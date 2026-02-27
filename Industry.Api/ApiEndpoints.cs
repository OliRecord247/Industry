namespace Industry.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class Machines
    {
        private const string MachinesBase = $"{ApiBase}/machines";
        
        public const string CreateJob = $"{MachinesBase}/job";
    }
}