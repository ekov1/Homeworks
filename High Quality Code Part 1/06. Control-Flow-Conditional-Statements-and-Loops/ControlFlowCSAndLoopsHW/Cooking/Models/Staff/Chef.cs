namespace Cooking.Models.Staff
{
    using System;
    using Comsumables;
    using Contracts;
    using Utils;
    using Vegetables;

    public class Chef
    {
        private ITalkable speachLogger;

        public Chef(string name)
        {
            this.ChefName = name;
            this.speachLogger = new Speach();
        }

        public string ChefName { get; set; }

        public void Introduce()
        {
            var message = $"Hello, my name is {this.ChefName} and I am a proffessional chef!";

            this.speachLogger.Say(message);
        }

        public IContainable GetBowl()
        {
            var bowl = new Bowl();
            this.speachLogger.Say("We have a bowl now!");

            return bowl;
        }

        public IVegetable GetCarrot()
        {
            var carrot = new Carrot();
            this.speachLogger.Say("Alright, here we have a carrot!");

            return carrot;
        }

        public IVegetable GetPotato()
        {
            var potato = new Potato();
            this.speachLogger.Say("We got a potato, that's great!");

            return potato;
        }

        public void Cut(IVegetable vegetable)
        {
            vegetable.IsCut = true;
            this.speachLogger.Say("Alright, we're done with cutting the vegetables!");
        }

        public void Peel(IVegetable vegetable)
        {
            vegetable.IsPeeled = true;
            this.speachLogger.Say("Alright, we're done with peeling the vegetable!");
        }

        public void Cook(IVegetable firstVegetable, IVegetable secondVegetable, Bowl bowl)
        {
            var areIngridientsAvaliable = (firstVegetable != null) && (secondVegetable != null) && (bowl != null);

            if (!areIngridientsAvaliable)
            {
                this.speachLogger.Say("Oops, something went wrong with the ingridients, lets try again!");
                return;
            }

            this.PrepareVegetables(firstVegetable, secondVegetable);

            // Task 2
            var isPreparationComplete = this.CheckIfVegetableIsReadyToCook(firstVegetable)
                && this.CheckIfVegetableIsReadyToCook(secondVegetable);

            if (isPreparationComplete)
            {
                bowl.Contents.Add(secondVegetable);
                bowl.Contents.Add(firstVegetable);

                this.speachLogger.Say("Awesome we got ourselves vegetables in a bowl!");
            }
            else
            {
                this.speachLogger.Say("Oops, I messed up the preparation of the products..");
            }
        }

        private void PrepareVegetables(IVegetable firstVegetable, IVegetable secondVegetable)
        {
            this.Peel(firstVegetable);
            this.Peel(firstVegetable);

            this.Cut(secondVegetable);
            this.Cut(secondVegetable);
        }

        private bool CheckIfVegetableIsReadyToCook(IVegetable vegetable)
        {
            var isReady = vegetable.IsPeeled && vegetable.IsCut && !vegetable.IsRotten;

            return isReady;
        }
    }
}
