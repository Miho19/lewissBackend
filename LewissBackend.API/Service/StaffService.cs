using FluentResults;
using LewissBackend.API.Model.DTO;
using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Service;

public class StaffService
{
    private readonly List<StaffEntity> staffEntities = [
        new StaffEntity() {name = "Joshua", function = "Consultant", secret = "Random Secret"},
        new StaffEntity() {name = "April", function = "Admin", secret = "Random Secret 2"}
    ];


    async public Task<Result<List<StaffDTO>>> GetStaffList()
    {
        if (staffEntities.Count == 0) return Result.Fail("List is empty");

        var staffList = new List<StaffDTO>();

        staffEntities.ForEach(entity =>
        {
            var dto = entity.ToDTO();
            if (dto != null) staffList.Add(dto);
        });

        return Result.Ok(staffList);

    }
}