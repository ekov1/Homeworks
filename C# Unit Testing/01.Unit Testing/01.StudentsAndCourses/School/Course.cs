namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private List<Student> students;

        public Course()
        {
            students = new List<Student>();
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Any(s => s == student))
            {
                throw new ArgumentException("Student already in course!");
            }
            if (students.Count < 30)
            {
                this.students.Add(student);
            }
            else
            {
                throw new ArgumentException("Course is full!");
            }
        }

        public void RemoveStudent(Student student)
        {
            if (this.students.All(s => s != student))
            {
                throw new ArgumentException("Student already is not in class!");
            }
            this.students.Remove(student);
        }
    }
}
