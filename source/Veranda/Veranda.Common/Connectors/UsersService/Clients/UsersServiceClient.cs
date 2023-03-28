using System.Threading.Channels;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcUsersService;

namespace Veranda.Common.Connectors.UsersService.Clients;
//public class UsersServiceClient
//{
//    private readonly Users.UsersClient _client;

//    public UsersServiceClient(string url)
//    {
//        _client = new Users.UsersClient(GrpcChannel.ForAddress(url));
//    }

//    public async Task<GetUsersResponse> GetUsers()
//    {
//        return await _client.GetUsersAsync(new GetUsersRequest());
//    }
//}
