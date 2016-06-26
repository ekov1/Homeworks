namespace _03.RangeExceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class InvalidRangeException<T> where T : IComparable<T>
    {

    }
}
