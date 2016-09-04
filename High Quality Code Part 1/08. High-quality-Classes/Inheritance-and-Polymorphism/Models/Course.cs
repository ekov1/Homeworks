namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        protected Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of course cannot be left empty!");
                }

                this.name = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Students list cannot be empty");
                }

                this.students = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of the teacher cannot be left empty!");
                }

                this.teacherName = value;
            }
        }

        public void AddStudents(IList<string> students)
        {
            foreach (var student in students)
            {
                this.Students.Add(student);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.GetType().Name} name => {this.Name}");

            builder.AppendLine("Teacher => " + this.TeacherName);

            builder.Append("Students => ");
            builder.Append(this.PrintAllStudents());

            return builder.ToString();
        }

        protected string PrintAllStudents()
        {
            string output = string.Empty;

            if (this.Students == null || this.Students.Count == 0)
            {
                output = "No students in course!";
            }
            else
            {
                output = "| " + string.Join(", ", this.Students) + " |";
            }

            return output;
        }
    }
}
