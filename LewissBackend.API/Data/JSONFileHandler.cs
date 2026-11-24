using System.Text.Json;
using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Data;

public interface IJSONFileHandler
{
    Task<string?> GetJSONFileAsync(string itemId);
}

public class JSONFileHandler : IJSONFileHandler
{

    private readonly string _path;

    public JSONFileHandler(IWebHostEnvironment env)
    {
        _path = Path.Combine(env.ContentRootPath, "Data");
    }

    public virtual async Task<string?> GetJSONFileAsync(string itemId)
    {
        if (string.IsNullOrEmpty(itemId))
        {
            Console.WriteLine($"{itemId} is not valid");
            return null;
        }

        if (!Directory.Exists(_path))
        {
            Console.WriteLine($"{_path} does not exist");
            return null;
        }

        try
        {
            return await File.ReadAllTextAsync(Path.Combine(_path, $"{itemId}.json"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}





