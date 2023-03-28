using GrpcUsersService;
using Riok.Mapperly.Abstractions;

namespace Veranda.Service.User.Api.Mapper;

public interface IMapper
{
    UserResponse UserToUserResponse(Data.Entities.User user);
}

[Mapper]
public partial class Mapper : IMapper
{
    public partial UserResponse UserToUserResponse(Data.Entities.User user);
}
