namespace _03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units;
    using Units.Enums;

    public class AnimalGenerator
    {

        public static List<Dog> GenerateDogs()
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog(2, "Kucho", GenderType.Male),
                new Dog(12, "Sharka", GenderType.Female),
                new Dog(6, "Pes", GenderType.Male),
                new Dog(9, "Djeka-Blek", GenderType.Female),
            };

            return dogs;
        }

        public static List<Frog> GenerateFrogs()
        {
            List<Frog> frogs = new List<Frog>
            {
                new Frog(1, "Jabcho", GenderType.Unknown),
                new Frog(18, "Goshka", GenderType.Female),
                new Frog(3, "Kucamun", GenderType.Male),
                new Frog(50, "Jabata-Tsar-Shefa", GenderType.Male),
            };

            return frogs;
        }

        public static List<Kitten> GenerateKittens()
        {
            List<Kitten> kittens = new List<Kitten>
            {
                new Kitten(2, "Kote"),
                new Kitten(6, "Machka"),
                new Kitten(1, "Kotarana"),
                new Kitten(22, "Piska"),
            };

            return kittens;
        }

        public static List<Tomcat> GenerateTomCats()
        {
            List<Tomcat> tomcats = new List<Tomcat>
            {
                new Tomcat(20, "Kotak"),
                new Tomcat(4, "Kotarak"),
                new Tomcat(14, "Loshiq-Tomcat"),
                new Tomcat(18, "Kotka-s-Shapka"),
            };

            return tomcats;
        }
    }
}
