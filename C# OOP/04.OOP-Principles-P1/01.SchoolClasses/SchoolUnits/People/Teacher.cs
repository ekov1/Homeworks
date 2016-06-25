namespace _01.SchoolClasses.SchoolUnits.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Teacher : Human
    {
        private List<Discipline> disciplines;

        public Teacher(string name) : base(name)
        {
            this.disciplines = new List<Discipline>();
        }

        public List<Discipline> TeacherDisciplines
        {
            get
            {
                return this.disciplines;
            }

            private set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }
    }
}
