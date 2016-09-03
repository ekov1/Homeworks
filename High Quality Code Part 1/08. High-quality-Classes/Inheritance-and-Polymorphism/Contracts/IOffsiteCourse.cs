namespace InheritanceAndPolymorphism.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }
}
