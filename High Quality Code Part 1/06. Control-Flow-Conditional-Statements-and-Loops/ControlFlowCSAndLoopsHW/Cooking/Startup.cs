namespace Cooking
{
    using System;
    using Models.Staff;

    public class Startup
    {
        public static void Main()
        {
            var chef = new Chef("Gordon Ramsay");
            chef.Introduce();

            var potato = chef.GetPotato();
            var carrot = chef.GetCarrot();
            var bowl = chef.GetBowl();

            chef.Cook(potato, carrot, bowl);
        }
    }
}
