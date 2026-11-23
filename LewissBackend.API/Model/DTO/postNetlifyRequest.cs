using System.Text.Json;
using System.Text.Json.Serialization;
using FluentResults;
using LewissBackend.API.Data;
using LewissBackend.API.Model.Entity;

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

        var projectFile = JSONItem.GetProjectFile(itemId);

        var options = new JsonSerializerOptions { Converters = { new BlindTypeSpecConverter() } };

        var serializedObject = JsonSerializer.SerializeToElement(projectFile, options);

        return Result.Ok(serializedObject);
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















