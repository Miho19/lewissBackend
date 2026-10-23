
namespace LewissBackend.API.Model.Entity;

public class ProjectFile
{
    public required int id;
    public required string name;
    public required string reference;
    public required string salesConsultant;

    public required Project project;

}

public class Project
{
    public required string id;
    public required List<Rooms> rooms;
}

public class Rooms
{
    public required string id;
    public required string name;
    public required Treatment treatment;
    public required List<Window> windows;
}

public class Treatment
{
    public required Layer insideLayer;
    public required Layer outsideLayer;

}

public class Layer
{
    public required string productId;
    public required Spec spec;
}

public class Fabric
{
    public required string name;
    public required string collection;
    public required int multiplier;

}




public class Window
{
    public required string id;
    public required string name;

    // inside
    public required int internalWidth;
    public required int internalHeightL;
    public required int internalHeightR;

    // butting
    public int blindLeftWidth = 0;
    public int outsideBlindLeftWidth = 0;


    public required string controlSide;
    public required string controlLength;
    public required string blindCount;


    // outside
    public required int blindLeft;
    public required int blindRight;
    public required int blindUnderhang;
    public required int blindAbove;


    public required int outsideLeftWidth;
    public required string outsideBlindCount;

}