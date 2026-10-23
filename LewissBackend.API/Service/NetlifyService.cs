using System.Text.Json;
using FluentResults;
using LewissBackend.API.Model.DTO;

namespace LewissBackend.API.Service;


public interface INetlifyService
{
    Task<Result<JsonElement>> GetRequestedItemAsync(NetlifyRequestPayloadDTO json, CancellationToken cancellationToken);
}

public class NetlifyService : INetlifyService
{
    public async Task<Result<JsonElement>> GetRequestedItemAsync(NetlifyRequestPayloadDTO body, CancellationToken cancellationToken)
    {
        return await body.HandleRequestAsync();
    }
}




