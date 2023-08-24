using Newtonsoft.Json;
using System.Diagnostics;

var time = 5;
var people = new List<Person>()
{
    new Person
    {
        Id = 1,
        Name = "Alice",
        RobotState = RobotStates.Inflight,
        ActionItemDetails = new RobotActionItemDetails
        {
            EndTime = time + 5,
            IsError = false,
        }
    },
    new Person
    {
        Id = 2,
        Name = "John",
        RobotState = RobotStates.OnGround,
        ActionItemDetails = new RobotActionItemDetails
        {
            EndTime = time,
            IsError = false,
        }
    },
    new Person
    {
        Id = 3,
        Name = "Alice",
        RobotState = RobotStates.Inflight,
        ActionItemDetails = new RobotActionItemDetails
        {
            EndTime = time,
            IsError = false,
        }
    },
    new Person
    {
        Id = 4,
        Name = "Alice",
        RobotState = RobotStates.Inflight,
        ActionItemDetails = new RobotActionItemDetails
        {
            EndTime = time+111,
            IsError = true,
        }
    },
    new Person
    {
        Id = 7,
        Name = "Alice",
        RobotState = RobotStates.Inflight,
        ActionItemDetails = new RobotActionItemDetails
        {
            EndTime = time,
            IsError = true,
        }
    },
    new Person { Id = 5, Name = "Bob", RobotState = RobotStates.OnGround, ActionItemDetails = null },
    new Person { Id = 6, Name = "Jane", RobotState = RobotStates.Inflight, ActionItemDetails = null }
};

void Printer()
{
    var inFlightError = (Person x)
        => x.ActionItemDetails is not null && x.RobotState == RobotStates.Inflight && x.ActionItemDetails.IsError;

    var inFlightHasActionItem = (Person x)
        => x.ActionItemDetails is not null && x.RobotState == RobotStates.Inflight && !x.ActionItemDetails.IsError;

    var onGroundHasActionItem = (Person x)
        => x.ActionItemDetails is not null && x.RobotState == RobotStates.OnGround;

    var onGround = (Person x)
        => x.ActionItemDetails is null && x.RobotState == RobotStates.OnGround;

    var inFlightNormal = (Person x)
        => x.ActionItemDetails is null && x.RobotState == RobotStates.Inflight;

    var inflightItemsList = people.Where(inFlightError).OrderBy(x => x.ActionItemDetails!.EndTime).ThenBy(x => x.Name);

    var inflightAndOnGroundHasActionItemList = people
        .Where(x => inFlightHasActionItem(x) || onGroundHasActionItem(x))
        .GroupBy(x => x.ActionItemDetails!.EndTime)
        .OrderBy(x => x.Key)
        .Select(x => x.OrderBy(y =>
        {
            if (y.RobotState == RobotStates.Inflight)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }))
        .SelectMany(x => x);

    var onGroundList = people.Where(onGround).OrderBy(x => x.Name);
    var inflightNormalList = people.Where(inFlightNormal).OrderBy(x => x.Name);

    var result = inflightItemsList
        .Union(inflightAndOnGroundHasActionItemList)
        .Union(onGroundList)
        .Union(inflightNormalList)
        .ToList();

    result.ForEach(x => Console.WriteLine(JsonConvert.SerializeObject(x)));
}

Printer();

Console.WriteLine("Run Again?");
while (Console.ReadLine() == "y")
{
    Console.WriteLine("Want to modify?");
    if (Console.ReadLine() == "y")
    {
        Console.WriteLine("ID?");
        var id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("New Value?");
        var value = int.Parse(Console.ReadLine()!);
        Modify(id, value);
    }
    Printer();
    Console.WriteLine("Run Again?");
}

void Modify(int id, int value)
{
    var peopleExisted = people
        .Where(x => x.Id == id).First();
    if (peopleExisted.ActionItemDetails is not null)
    {
        peopleExisted.ActionItemDetails.EndTime = value;
    }
}

[DebuggerDisplay("Id = {Id}, RobotState = {RobotState}, {ActionItemDetails}")]
class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public RobotStates RobotState { get; set; }

    public RobotActionItemDetails? ActionItemDetails { get; set; }
}

[DebuggerDisplay("EndTime = {EndTime}, IsError = {IsError}")]
public class RobotActionItemDetails
{
    public bool IsError { get; set; }

    public int EndTime { get; set; }
}

enum RobotStates
{
    OnGround = 1,
    Inflight = 2,
}