using System.Text.Json;
using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Data;

public interface IJSONFileHandler
{
    Task<ProjectFile?> GetProjectFileAsync(string itemId);
}

public class JSONFileHandler : IJSONFileHandler
{

    public virtual async Task<ProjectFile?> GetProjectFileAsync(string itemId)
    {
        if (string.IsNullOrEmpty(itemId))
        {
            Console.WriteLine($"GetProjectFile: {itemId} is not valid");
            return null;
        }

        try
        {
            using FileStream fs = File.OpenRead($"{itemId}.json");
            var options = new JsonSerializerOptions { Converters = { new BlindTypeSpecConverter() }, PropertyNameCaseInsensitive = true };
            var jsonElement = await JsonSerializer.DeserializeAsync<ProjectFile>(fs, options);
            return jsonElement;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetProjectFile Error: {ex.Message}");
            return null;
        }
    }
}





