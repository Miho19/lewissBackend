using LewissBackend.API.Model.Entity;

namespace LewissBackend.API.Service;

public class StaffService
{
    private readonly List<StaffEntity> staffEntities = [
        new StaffEntity() {name = "Joshua", function = "Consultant", secret = "Random Secret"},
        new StaffEntity() {name = "April", function = "Admin", secret = "Random Secret 2"}
    ];



}