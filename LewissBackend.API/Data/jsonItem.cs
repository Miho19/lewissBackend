using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Data;

public static class JSONItem
{

    public static ProjectFile GetProjectFile(string itemId)
    {


        var cellularFabric = new Fabric()
        {
            name = "Translucent Cotton",
            collection = "Translucent",
            multiplier = 1.0
        };

        var insideSpec = new KineticsCellularSpec()
        {
            fabric = cellularFabric,
            motorisation = "",
            controlSide = "left",
            bracketColour = "white",
            customColour = false,
            sideChannels = false,

        };

        var rollerFabric = new Fabric()
        {
            name = "Back To Nature - Lace Bark",
            collection = "Back To Nature",
            multiplier = 0.8
        };

        var outsideSpec = new KineticsRollerSpec()
        {
            fabric = rollerFabric,
            motorisation = "lithium",
            controlSide = "left",
            rollDirection = "front roll",
            bracketColour = "black",
            bottomRailType = "Flat",
            bottomRailColour = "black",
            chainColour = "",
            pelmetType = "",
            customColour = false
        };

        var insideLayer = new Layer()
        {
            productId = "Kinetics 10mm Cellular Blind",
            spec = insideSpec
        };

        var outsideLayer = new Layer()
        {
            productId = "Kinetics Blockout Roller Blind",
            spec = outsideSpec
        };


        var treatment = new Treatment()
        {
            insideLayer = insideLayer,
            outsideLayer = outsideLayer,
        };

        var window1 = new Window()
        {
            id = "1",
            name = "window 1",
            internalWidth = 1200,
            internalHeightL = 900,
            internalHeightR = 900,
            blindLeftWidth = 0,
            controlSide = "right",
            controlLength = "1000",
            blindCount = "1",

            blindLeft = 100,
            blindRight = 100,
            blindAbove = 240,
            blindUnderhang = 150,

            outsideBlindLeftWidth = 0,
            outsideBlindCount = "1"

        };

        var window2 = new Window()
        {
            id = "2",
            name = "window 2",
            internalWidth = 2400,
            internalHeightL = 1200,
            internalHeightR = 1200,
            blindLeftWidth = 0,
            controlSide = "left",
            controlLength = "1500",
            blindCount = "1",

            blindLeft = 100,
            blindRight = 100,
            blindAbove = 240,
            blindUnderhang = 150,

            outsideBlindLeftWidth = 0,
            outsideBlindCount = "1"

        };

        var room = new Room()
        {
            id = "roomId",
            name = "room 1",
            treatment = treatment,
            windows = [window1, window2]
        };


        var project = new Project()
        {
            id = "randomProjectId",
            room = [room]
        };


        var projectId = int.TryParse(itemId, out int id) ? id : 0;

        var projectFile = new ProjectFile()
        {
            id = projectId,
            name = "April",
            reference = "12345-67891",
            salesConsultant = "Terry Donald",
            project = project
        };

        return projectFile;

    }
}





