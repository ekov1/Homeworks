namespace Cooking.Models.Vegetables
{
    using System;
    using Globals;

    public class Potato : Vegetable
    {
        public Potato()
            : base()
        {
            this.Calories = GlobalConstants.PotatoCalories;
        }
    }
}
