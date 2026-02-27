using System.Globalization;
using Industry.Contracts.requests;
using Industry.Domain.Messaging;

namespace Industry.Api.Mapping;

public static class ContractMapping
{
    public static MachineJob MapToMachineJob(this CreateMachineJobRequest request)
    {
        return new MachineJob
        {
            MachineId = request.MachineId,
            Command = request.Action,
            ScheduledStart = DateTime.Parse(
                request.ScheduledTime, 
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal)
        };
    }
}