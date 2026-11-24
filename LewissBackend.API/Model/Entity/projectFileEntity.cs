
namespace LewissBackend.API.Model.Entity;

public class ProjectFile
{
    public required int Id { get; set; }
    public string? Name { get; set; }
    public string? Reference { get; set; }
    public string? SalesConsultant { get; set; }

    public Project? Project { get; set; }

}

public class Project
{
    public required string Id { get; set; }
    public required List<Room> Room { get; set; }
}

public class Room
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required Treatment Treatment { get; set; }
    public required List<Window> Windows { get; set; }
}

public class Treatment
{
    public required Layer InsideLayer { get; set; }
    public required Layer OutsideLayer { get; set; }

}

public class Layer
{
    public required string ProductId { get; set; }
    public required Spec Spec { get; set; }
}

public class Fabric
{
    public required string Name { get; set; }
    public required string Collection { get; set; }
    public required double Multiplier { get; set; }

}




public class Window
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    // inside
    public required int InternalWidth { get; set; }
    public required int InternalHeightL { get; set; }
    public required int InternalHeightR { get; set; }

    // butting
    public int BlindLeftWidth { get; set; }
    public int OutsideBlindLeftWidth { get; set; }


    public required string ControlSide { get; set; }
    public required string ControlLength { get; set; }
    public required string BlindCount { get; set; }


    // outside
    public required int BlindLeft { get; set; }
    public required int BlindRight { get; set; }
    public required int BlindUnderhang { get; set; }
    public required int BlindAbove { get; set; }



    public required string OutsideBlindCount { get; set; }

}