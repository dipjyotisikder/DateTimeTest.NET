// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


object? objectData = null;


var dictionary = new Dictionary<string, object?>()
{
    {"a", null },
    {"b", "12" },
    {"c", null }
};

var done = dictionary.TryGetValue("b", out object? data);

int integerData = (int)data!;

Console.WriteLine("Done");