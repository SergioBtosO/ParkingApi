using ParkingApi.Api.Filters;
using ParkingApi.Application.Voters;
using MediatR;
using ParkingApi.Domain.Dto;

namespace ParkingApi.Api.ApiHandlers;

public static class VoterApi
{
    public static RouteGroupBuilder MapVoter(this IEndpointRouteBuilder routeHandler)
    {
       // correct, brings one filtered by id (ef)
        routeHandler.MapGet("/{id}", async (IMediator mediator, Guid id) =>
        {
            return Results.Ok(await mediator.Send(new VoterQuery(id)));
        })
        .Produces(StatusCodes.Status200OK, typeof(VoterDto));

        // now with dapper
        routeHandler.MapGet("/dapper/{id}", async (IMediator mediator, Guid id) =>
        {
            return Results.Ok(await mediator.Send(new VoterSimpleQuery(id)));
        })
        .Produces(StatusCodes.Status200OK, typeof(VoterDto));

        // create resource, validating command like api controller 
        routeHandler.MapPost("/", async (IMediator mediator, [Validate] VoterRegisterCommand voter) =>
        {
            var vote = await mediator.Send(voter);
            return Results.Created(new Uri($"/api/voter/{vote.Id}", UriKind.Relative), vote);
        })
        .Produces(statusCode: StatusCodes.Status201Created);    

        return (RouteGroupBuilder)routeHandler;
    }
}

