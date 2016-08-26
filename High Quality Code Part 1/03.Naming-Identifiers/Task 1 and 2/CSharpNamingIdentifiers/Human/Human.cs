namespace Human
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Human
    {
        public GenderType Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public static Human GenerateRandomHuman(int magicAgeNumber)
        {
            var human = new Human();
            human.Age = magicAgeNumber;

            if (human.Age % 2 == 0)
            {
                human.Name = "Badass";
                human.Gender = GenderType.ToughMan;
            }
            else
            {
                human.Name = "ChickyBaby";
                human.Gender = GenderType.LightWoman;
            }

            return human;
        }
    }
}
