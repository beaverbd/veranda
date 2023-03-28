using Grpc.Core;
using GrpcUsersService;
using Microsoft.EntityFrameworkCore;
using Veranda.Service.User.Api.Data;
using Veranda.Service.User.Api.Mapper;

namespace Veranda.Service.User.Api.GrpcServices;

public class UsersService : Common.Connectors.UsersService.Services.GrpcUsersService
{
    private readonly UsersDbContext _dbContext;
    private readonly IMapper _mapper;

    public UsersService(UsersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public override async Task<GetUsersResponse> GetUsers(GetUsersRequest request, ServerCallContext context)
    {
        var users = await _dbContext.Set<Data.Entities.User>()
            .OrderBy(x=>x.Id)
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync();

        var response = new GetUsersResponse();
        response.Users.AddRange(users.Select(x => _mapper.UserToUserResponse(x)));
        return response;
    }
}
