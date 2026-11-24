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
    public abstract Task<Result<string>> HandleRequestAsync();
}

public class DownloadJsonAction : NetlifyRequestPayloadDTO
{
    public required string itemId;

    private readonly IJSONFileHandler _jsonFileHandler;
    public DownloadJsonAction(IJSONFileHandler jSONFileHandler)
    {
        _jsonFileHandler = jSONFileHandler;
    }


    public override async Task<Result<string>> HandleRequestAsync()
    {

        var jsonFileAsString = await _jsonFileHandler.GetJSONFileAsync(itemId);
        if (jsonFileAsString is null)
        {
            return Result.Fail(new FailedToFetchFileError($"JSON File {itemId}"));
        }


        return Result.Ok(jsonFileAsString);
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


    public override async Task<Result<string>> HandleRequestAsync()
    {
        throw new NotImplementedException();
    }
}















