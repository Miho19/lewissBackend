using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Data;

public static class JSONItem
{

    public static ProjectFile GetProjectFile(string itemId)
    {
        var result = int.TryParse(itemId, out int id) ? id : 0;

        var project = new Project()
        {
            id = "randomProjectId",
            rooms = []
        };



        var projectFile = new ProjectFile()
        {
            id = result,
            name = "April",
            reference = "12345-67891",
            salesConsultant = "Terry Donald",
            project = project

        };

        return projectFile;

    }
}





