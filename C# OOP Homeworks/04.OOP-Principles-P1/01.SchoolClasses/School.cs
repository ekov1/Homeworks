namespace _01.SchoolClasses
{
    using SchoolUnits;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class School
    {
        private List<Classes> classes;

        public School()
        {
            this.classes = new List<Classes>();
        }

        public List<Classes> SchoolClasses
        {
            get
            {
                return this.classes;
            }
        }

        public void AddClass(Classes schoolClass)
        {
            this.classes.Add(schoolClass);
        }

        public void RemoveClass(Classes schoolClass)
        {
            this.classes.Remove(schoolClass);
        }
    }
}
