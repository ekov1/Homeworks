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

        public Bowl GetBowl()
        {
            var bowl = new Bowl();
            this.speachLogger.Say("We have a bowl now!");

            return bowl;
        }

        public Carrot GetCarrot()
        {
            var carrot = new Carrot();
            this.speachLogger.Say("Alright, here we have a carrot!");

            return carrot;
        }

        public Potato GetPotato()
        {
            var potato = new Potato();
            this.speachLogger.Say("We got a potato, that's great!");

            return potato;
        }

        public void Cut(Vegetable vegetable)
        {
            vegetable.IsCut = true;
            this.speachLogger.Say("Alright, we're done with cutting the vegetables!");
        }

        public void Peel(Vegetable vegetable)
        {
            vegetable.IsPeeled = true;
            this.speachLogger.Say("Alright, we're done with peeling the vegetable!");
        }

        // There can be an option to input ingridients in the method contructor
        public void Cook(Vegetable potato, Vegetable carrot, Bowl bowl)
        {
            var areIngridientsAvaliable = (potato != null) && (carrot != null) && (bowl != null);

            if (!areIngridientsAvaliable)
            {
                this.speachLogger.Say("Oops, something went wrong with the ingridients, lets try again!");
                return;
            }

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            // Task 2
            var isPreparationComplete = this.CheckIfVegetableIsReadyToCook(potato) && this.CheckIfVegetableIsReadyToCook(carrot);

            if (isPreparationComplete)
            {
                bowl.BowlContent.Add(carrot);
                bowl.BowlContent.Add(potato);

                this.speachLogger.Say("Awesome we got ourselves a carrot a potato in a bowl!");
            }
            else
            {
                this.speachLogger.Say("Oops, I messed up the preparation of the products..");
            }
        }

        private bool CheckIfVegetableIsReadyToCook(IVegetable vegetable)
        {
            var isReady = vegetable.IsPeeled && vegetable.IsCut && !vegetable.IsRotten;

            return isReady;
        }
    }
}
