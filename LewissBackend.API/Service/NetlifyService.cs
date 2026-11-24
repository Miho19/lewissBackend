using System.Text.Json;
using FluentResults;
using LewissBackend.API.Model.DTO;

namespace LewissBackend.API.Service;


public interface INetlifyService
{
    Task<Result<string>> GetRequestedItemAsync(NetlifyRequestPayloadDTO json, CancellationToken cancellationToken);
}

public class NetlifyService : INetlifyService
{
    public async Task<Result<string>> GetRequestedItemAsync(NetlifyRequestPayloadDTO body, CancellationToken cancellationToken)
    {
        var result = await body.HandleRequestAsync();

        return result;
    }
}




