namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }
    
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Enter cannot be left empty!");
                }
                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value <= 10000 || value >= 99999)
                {
                    throw new ArgumentException("ID must be in range 10k/99999!");
                }
                this.id = value;
            }
        }

        public void JoinCourse(Course course)
        {
            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            course.RemoveStudent(this);
        }
    }
}
