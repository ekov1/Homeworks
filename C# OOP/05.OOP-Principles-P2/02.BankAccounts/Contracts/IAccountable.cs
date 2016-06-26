namespace _02.BankAccounts.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units.Customers;

    public interface IAccountable
    {
        CustomerType CustomerType { get; }
        decimal Balance { get; }
        decimal InterestRate { get; }
    }
}
