// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

using IDbConnection connection = new SqlConnection("Data Source=");

public class Result<T>
{
    public string GetResult()
    {
        return string.Empty;
    }

    public T value;

    public bool IsSuccess;
    public bool IsError;

    public string GetError() => string.Empty;

    public static Result<T> Create => new();

}

// Take condition
// Get result of that condition
// Map that to result


public static class ResultExtension
{

    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> function)
    {
        if (result.IsError) return result;

        return function(result.value) ? result : new Result<T>();

    }

    public static bool Run(Func<string, bool> predicate)
    {
        return predicate(string.Empty);
    }


    public static bool GetRun()
    {
        return Run((x) => x != null);
    }

}
