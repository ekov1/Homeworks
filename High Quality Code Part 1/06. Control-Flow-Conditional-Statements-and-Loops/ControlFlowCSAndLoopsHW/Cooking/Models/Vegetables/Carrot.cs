namespace Cooking.Models.Vegetables
{
    using System;
    using Globals;

    public class Carrot : Vegetable
    {
        public Carrot()
            : base()
        {
            this.Calories = GlobalConstants.CarrotCalories;
        }
    }
}
