using FluentResults;
using LewissBackend.API.Model.DTO;

namespace LewissBackend.API.Service;


public interface INetlifyService
{
    Task<Result<Object>> GetRequestedItemAsync(NetlifyRequestPayloadDTO json, CancellationToken cancellationToken);
}

public class NetlifyService : INetlifyService
{
    public async Task<Result<Object>> GetRequestedItemAsync(NetlifyRequestPayloadDTO body, CancellationToken cancellationToken)
    {
        return await body.HandleRequestAsync();
    }
}




