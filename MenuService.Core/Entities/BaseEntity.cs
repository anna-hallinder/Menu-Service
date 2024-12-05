using System.Text.Json.Serialization;

namespace MenuService.Core.Entities;

public abstract class BaseEntity<TId>
{
    public required TId Id { get; set; }
}