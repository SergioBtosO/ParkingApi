using ParkingApi.Domain.Entities;
using ParkingApi.Domain.Ports;
using ParkingApi.Infrastructure.Ports;

namespace ParkingApi.Infrastructure.Adapters
{
    [Repository]
    public class VoterRepository : IVoterRepository
    {
        readonly IRepository<Voter> _dataSource;
        public VoterRepository(IRepository<Voter> dataSource) => _dataSource = dataSource 
            ?? throw new ArgumentNullException(nameof(dataSource));        

        public async Task<Voter> SaveVoter(Voter v) => await _dataSource.AddAsync(v);

        public async Task<Voter> SingleVoter(Guid uid) => await _dataSource.GetOneAsync(uid);
        
        
    }
}
