using ParkingApi.Domain.Dto;

namespace ParkingApi.Domain.Ports
{
    public interface IVoterSimpleQueryRepository
    {
        Task<VoterDto> Single(Guid id);
    }
}

