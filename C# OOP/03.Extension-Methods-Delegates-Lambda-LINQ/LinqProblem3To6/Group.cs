
namespace LinqProblems
{
    using System;
    using System.Collections.Generic;

   public class Group
    {
        private static List<Group> groups = new List<Group>()
        {
            new Group(1, "Mathematics"),
            new Group(2, "Geography"),
            new Group(3, "Literature"),
            new Group(4, "Physics")
        };


        public Group(int grNum, string depName)
        {
            this.GroupNumber = grNum;
            this.DepartmentName = depName;
        }

        public static List<Group> Groups
        {
            get
            {
                return groups;
            }
        }

        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }
    }
}
