namespace _01.StudentClass.Units.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonTest
    {
        public static void PersonToString()
        {
            Person man = new Person("Ivan Georgiev", 12);
            Person woman = new Person("Radka Piratka");

            Person.PrintPeople(man, woman);
        }
    }
}
