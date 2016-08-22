namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School
    {
        private List<Student> students;

        public School()
        {   
            // Init is done when initiating school
            this.students = new List<Student>();
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }
    }
}
