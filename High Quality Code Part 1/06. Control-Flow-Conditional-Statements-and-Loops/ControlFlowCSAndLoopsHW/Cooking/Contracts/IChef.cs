namespace Cooking.Contracts
{
    using System;
    using Models.Comsumables;
    using Models.Vegetables;

    public interface IChef
    {
        Bowl GetBowl();

        Carrot GetCarrot();

        Potato GetPotato();

        void Cut(IVegetable vegetable);

        void Peel(IVegetable vegatable);
    }
}
