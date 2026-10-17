using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Model.DTO;


public class StaffDTO
{
    public required string name;
    public required string functions;

}

public static class StaffMappingExtensions
{
    public static StaffDTO? ToDTO(this StaffEntity staff)
    {
        if (staff == null) return null;
        return new StaffDTO
        {
            name = staff.name,
            functions = staff.function
        };
    }
}


