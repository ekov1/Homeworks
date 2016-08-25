namespace _01.SchoolClasses.SchoolUnits.People
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Human : INameable, ICommentable
    {
        private string name;
        private string comment;

        public Human(string name)
        {
            this.Name = name;
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
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
    }
}
