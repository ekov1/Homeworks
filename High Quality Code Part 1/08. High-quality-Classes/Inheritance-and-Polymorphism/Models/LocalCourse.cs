namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Text;
    using Contracts;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, string teacherName, string lab)
            : base(name, teacherName)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Lab cannot be left null or empty!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());

            builder.AppendLine("Lab => " + this.Lab);
            return builder.ToString();
        }
    }
}
