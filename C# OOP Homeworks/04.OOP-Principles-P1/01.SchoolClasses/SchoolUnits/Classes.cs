namespace _01.SchoolClasses.SchoolUnits
{
    using Interfaces;
    using People;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Classes : ICommentable
    {
        private string uText;
        private List<Student> students;
        private List<Teacher> teachers;

        public Classes(string uText)
        {
            this.UniqueText = uText;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
        }

        public List<Student> ClassStudents
        {
            get
            {
                return this.students;
            }

            private set
            {
                this.students = value;
            }
        }

        public List<Teacher> ClassTeachers
        {
            get
            {
                return this.teachers;
            }

            private set
            {
                this.teachers = value;
            }
        }

        public string UniqueText
        {
            get
            {
                return this.uText;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Unique class text cannot be empty!");
                }
                this.uText = value;
            }
        }

        public string Comment { get; set; }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }
    }
}
