using System.Text.Json;
using System.Text.Json.Serialization;
using FluentResults;
using LewissBackend.API.Data;

namespace LewissBackend.API.Model.DTO;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "action")]
[JsonDerivedType(typeof(DownloadJsonAction), typeDiscriminator: "downloadJson")]
[JsonDerivedType(typeof(ListFolderAction), typeDiscriminator: "listFolder")]
public abstract class NetlifyRequestPayloadDTO
{
    public abstract Task<Result<JsonElement>> HandleRequestAsync();
}

public class DownloadJsonAction : NetlifyRequestPayloadDTO
{
    public required string itemId;

    public override async Task<Result<JsonElement>> HandleRequestAsync()
    {
        var projectFile = JsonSerializer.SerializeToElement(JSONItem.GetProjectFile(itemId));

        return Result.Ok(projectFile);
    }
}

public class ListFolderAction : NetlifyRequestPayloadDTO
{
    public string folderId = string.Empty;

    public override async Task<Result<JsonElement>> HandleRequestAsync()
    {
        throw new NotImplementedException();
    }
}















