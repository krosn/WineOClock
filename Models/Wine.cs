using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WineOClockApi.Models;

public class Wine
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string WineName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Region { get; set; } = null!;

    public string VineyardName { get; set; } = null!;
}