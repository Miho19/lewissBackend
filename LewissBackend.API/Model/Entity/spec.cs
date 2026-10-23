
using System.Text.Json.Serialization;

namespace LewissBackend.API.Model.Entity;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "blindType")]
[JsonDerivedType(typeof(KineticsRollerSpec), typeDiscriminator: "Kinetics Sunscreen Roller Blind")]
[JsonDerivedType(typeof(KineticsRollerSpec), typeDiscriminator: "Kinetics Blockout Roller Blind")]
[JsonDerivedType(typeof(KineticsRollerSpec), typeDiscriminator: "Kinetics Light Filtering Roller Blind")]

[JsonDerivedType(typeof(KineticsCellularSpec), typeDiscriminator: "Kinetics 10mm Cellular Blind")]
[JsonDerivedType(typeof(KineticsCellularSpec), typeDiscriminator: "Kinetics 20mm Cellular Blind")]

public class Spec
{
    public required Fabric fabric;
    public required string motorisation;

    public required string controlSide;

}

public class KineticsRollerSpec : Spec
{
    public required string rollDirection;
    public required string bracketColour;
    public required string bottomRailType;
    public required string bottomRailColour;
    public required string chainColour;
    public required string pelmetType;
    public required bool customColour;
}

public class KineticsCellularSpec : Spec
{
    public required string bracketColour;
    public required bool customColour;
    public required bool sideChannels;

}
