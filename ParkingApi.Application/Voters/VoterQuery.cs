using ParkingApi.Domain.Dto;
using MediatR;

namespace ParkingApi.Application.Voters;

public record VoterQuery(
    Guid uid
    ) : IRequest<VoterDto>;

public record VoterSimpleQuery(
    Guid uid
    ) : IRequest<VoterDto>;
