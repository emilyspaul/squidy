namespace Squidy.Common.Data.Entities.Interfaces
{
    public interface IEntityWithIdNameDescription : IEntityWithId
    {
        string? Name { get; set; }
        string? Description { get; set; } 
    }
}
