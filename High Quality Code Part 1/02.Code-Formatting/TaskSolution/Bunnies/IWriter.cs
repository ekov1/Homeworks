namespace Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
