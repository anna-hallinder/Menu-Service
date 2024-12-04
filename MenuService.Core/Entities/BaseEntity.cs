using System.Text.Json.Serialization;

namespace MenuService.Core.Entities;

public abstract class BaseEntity<TId>
{
    [JsonPropertyOrder(-1)]
    public TId Id { get; set; } 
}
