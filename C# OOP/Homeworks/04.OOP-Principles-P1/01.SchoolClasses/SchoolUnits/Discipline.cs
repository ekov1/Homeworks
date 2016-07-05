namespace _01.SchoolClasses.SchoolUnits
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Discipline : INameable, ICommentable
    {
        private string name;
        private int lecturesNum;
        private int excNum;

        public Discipline(string name)
        {
            this.Name = name;
            this.LecturesNumber = lecturesNum;
            this.ExcersiceNumber = excNum;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be left empty!");
                }
                this.name = value;
            }
        }

        public int LecturesNumber
        {
            get
            {
                return this.lecturesNum;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Lectures number cannot be less than 0!");
                }
                this.lecturesNum = value;
            }
        }

        public int ExcersiceNumber
        {
            get
            {
                return this.excNum;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Excersice number cannot be less than 0!");
                }
                this.excNum = value;
            }
        }

        public string Comment { get; set; }
       
    }
}
