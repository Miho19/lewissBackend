
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LewissBackend.API.Model.Entity;

public abstract class Spec
{
    public required string BlindType { get; set; }
}

public class BlindTypeSpecConverter : JsonConverter<Spec>

{
    public override Spec? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("BlindType", out var blindType))
        {
            throw new JsonException("Missing Blind Type property");
        }


        var discriminator = blindType.GetString();
        var rawJson = root.GetRawText();

        return discriminator switch
        {
            "Kinetics 10mm Cellular Blind" or "Kinetics 20mm Cellular Blind" => JsonSerializer.Deserialize<KineticsCellularSpec>(rawJson, options),
            "Kinetics Sunscreen Roller Blind" or "Kinetics Blockout Roller Blind" or "Kinetics Light Filtering Roller Blind" => JsonSerializer.Deserialize<KineticsRollerSpec>(rawJson, options),
            _ => throw new JsonException($"Unknown discriminator: {discriminator}")
        };
    }

    public override void Write(Utf8JsonWriter writer, Spec value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}


public class KineticsRollerSpec : Spec
{
    public required Fabric Fabric { get; set; }
    public required string ControlSide { get; set; }
    public required string Motorisation { get; set; }
    public required string RollDirection { get; set; }
    public required string BracketColour { get; set; }
    public required string BottomRailType { get; set; }
    public required string BottomRailColour { get; set; }
    public required string ChainColour { get; set; }
    public required string PelmetType { get; set; }
    public required bool CustomColour { get; set; }
}

public class KineticsCellularSpec : Spec
{
    public required Fabric Fabric { get; set; }
    public required string ControlSide { get; set; }
    public required string Motorisation { get; set; }

    public required string BracketColour { get; set; }
    public required bool CustomColour { get; set; }
    public required bool SideChannels { get; set; }

}
