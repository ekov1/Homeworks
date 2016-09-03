namespace Methods.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IStudent
    {
        string FirstName { get; }

        string LastName { get; }

        string BirthdayDate { get; }
    }
}
