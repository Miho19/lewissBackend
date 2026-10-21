using FluentResults;

namespace LewissBackend.API.CustomError;

public class ListEmptyError : Error
{

    public ListEmptyError(string listName) : base($"{listName} has no results to show")
    {

    }
}