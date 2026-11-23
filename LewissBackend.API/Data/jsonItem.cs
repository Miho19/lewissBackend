using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Data;

public static class JSONItem
{

    public static ProjectFile GetProjectFile(string itemId)
    {


        var cellularFabric = new Fabric()
        {
            Name = "Translucent Cotton",
            Collection = "Translucent",
            Multiplier = 1.0
        };

        var insideSpec = new KineticsCellularSpec()
        {
            BlindType = "Kinetics 10mm Cellular Blind",
            Fabric = cellularFabric,
            Motorisation = "",
            ControlSide = "left",
            BracketColour = "white",
            CustomColour = false,
            SideChannels = false,

        };

        var rollerFabric = new Fabric()
        {
            Name = "Back To Nature - Lace Bark",
            Collection = "Back To Nature",
            Multiplier = 0.8
        };

        var outsideSpec = new KineticsRollerSpec()
        {
            BlindType = "Kinetics Blockout Roller Blind",
            Fabric = rollerFabric,
            Motorisation = "lithium",
            ControlSide = "left",
            RollDirection = "front roll",
            BracketColour = "black",
            BottomRailType = "Flat",
            BottomRailColour = "black",
            ChainColour = "",
            PelmetType = "",
            CustomColour = false
        };

        var insideLayer = new Layer()
        {
            ProductId = "Kinetics 10mm Cellular Blind",
            Spec = insideSpec
        };

        var outsideLayer = new Layer()
        {
            ProductId = "Kinetics Blockout Roller Blind",
            Spec = outsideSpec
        };


        var treatment = new Treatment()
        {
            InsideLayer = insideLayer,
            OutsideLayer = outsideLayer,
        };

        var window1 = new Window()
        {
            Id = "1",
            Name = "window 1",
            InternalWidth = 1200,
            InternalHeightL = 900,
            InternalHeightR = 900,
            BlindLeftWidth = 0,
            ControlSide = "right",
            ControlLength = "1000",
            BlindCount = "1",

            BlindLeft = 100,
            BlindRight = 100,
            BlindAbove = 240,
            BlindUnderhang = 150,

            OutsideBlindLeftWidth = 0,
            OutsideBlindCount = "1"

        };

        var window2 = new Window()
        {
            Id = "2",
            Name = "window 2",
            InternalWidth = 2400,
            InternalHeightL = 1200,
            InternalHeightR = 1200,
            BlindLeftWidth = 0,
            ControlSide = "left",
            ControlLength = "1500",
            BlindCount = "1",

            BlindLeft = 100,
            BlindRight = 100,
            BlindAbove = 240,
            BlindUnderhang = 150,

            OutsideBlindLeftWidth = 0,
            OutsideBlindCount = "1"

        };

        var room = new Room()
        {
            Id = "roomId",
            Name = "room 1",
            Treatment = treatment,
            Windows = [window1, window2]
        };


        var project = new Project()
        {
            Id = "randomProjectId",
            Room = [room]
        };


        var projectId = int.TryParse(itemId, out int id) ? id : 0;

        var projectFile = new ProjectFile()
        {
            Id = projectId,
            Name = "April",
            Reference = "12345-67891",
            SalesConsultant = "Terry Donald",
            Project = project
        };


        return projectFile;

    }
}





