using LewissBackend.API.Model.DTO;

namespace LewissBackend.API.Tests.Fixtures;

public static class StaffFixture
{
    private static readonly List<StaffDTO> _staffDTOList = new List<StaffDTO>()
    {
        new StaffDTO {name = "Joshua", functions = "Consultant"},
        new StaffDTO {name = "April", functions = "Admin"}
    };

    public static List<StaffDTO> GetStaffDTOList()
    {
        return _staffDTOList;
    }
}