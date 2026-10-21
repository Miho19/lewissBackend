using System.Text.Json.Serialization;
using FluentResults;

namespace LewissBackend.API.Model.DTO;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "action")]
[JsonDerivedType(typeof(DownloadJsonAction), typeDiscriminator: "downloadJson")]
[JsonDerivedType(typeof(ListFolderAction), typeDiscriminator: "listFolder")]
public abstract class NetlifyRequestPayloadDTO
{
    public abstract Task<Result<Object>> HandleRequestAsync();
}

public class DownloadJsonAction : NetlifyRequestPayloadDTO
{
    public required string itemId;

    public override Task<Result<object>> HandleRequestAsync()
    {
        throw new NotImplementedException();
    }
}

public class ListFolderAction : NetlifyRequestPayloadDTO
{
    public string folderId = string.Empty;

    public override Task<Result<object>> HandleRequestAsync()
    {
        throw new NotImplementedException();
    }
}















