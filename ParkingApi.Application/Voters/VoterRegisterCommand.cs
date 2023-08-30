using ParkingApi.Domain.Dto;
using MediatR;


namespace ParkingApi.Application.Voters;

public record VoterRegisterCommand(
    string Nid, string Origin, DateTime Dob
    ) : IRequest<VoterDto>;

