namespace FurnitureManufacturer.Interfaces
{
    using FurnitureManufacturer.Models;

    public interface IFurniture
    {
        string Model { get; }

        string Material { get; }

        decimal Price { get; set; }

        decimal Height { get; }
    }
}
