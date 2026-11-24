using FluentResults;

namespace LewissBackend.API.CustomError;


public class FailedToFetchFileError : Error
{
    public FailedToFetchFileError(string message) : base($"Failed to fetch {message}")
    {

    }
}