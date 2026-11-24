using System.Text.Json;
using System.Text.Json.Serialization;
using FluentResults;
using LewissBackend.API.CustomError;
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

    private readonly IJSONFileHandler _jsonFileHandler;
    public DownloadJsonAction(IJSONFileHandler jSONFileHandler)
    {
        _jsonFileHandler = jSONFileHandler;
    }


    public override async Task<Result<JsonElement>> HandleRequestAsync()
    {

        var projectFile = await _jsonFileHandler.GetProjectFileAsync(itemId);
        if (projectFile is null)
        {
            return Result.Fail(new FailedToFetchFileError($"Project File {itemId}"));
        }

        var options = new JsonSerializerOptions { Converters = { new BlindTypeSpecConverter() }, PropertyNameCaseInsensitive = true };
        var serializedObject = JsonSerializer.SerializeToElement(projectFile, options);

        return Result.Ok(serializedObject);
    }
}

public class ListFolderAction : NetlifyRequestPayloadDTO
{
    public string folderId = string.Empty;

    private readonly IJSONFileHandler _jsonFileHandler;
    public ListFolderAction(IJSONFileHandler jSONFileHandler)
    {
        _jsonFileHandler = jSONFileHandler;
    }


    public override async Task<Result<JsonElement>> HandleRequestAsync()
    {
        throw new NotImplementedException();
    }
}















