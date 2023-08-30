using ParkingApi.Domain.Entities;

namespace ParkingApi.Domain.Ports
{
    public interface IVoterRepository
    {
        Task<Voter> SaveVoter(Voter v);     
        Task<Voter> SingleVoter(Guid uid);   
        
    }

   
}

