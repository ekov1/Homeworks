namespace _02.BankAccounts.Units
{
    using BankAccounts;
    using Customers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Bank
    {
        private static List<Account> accounts = new List<Account>
            {
                new Deposit(CustomerType.company, 12000, 2),
                new Loan(CustomerType.individual, 4500, 3),
                new Mortgage(CustomerType.company, 500000, 4),
                new Deposit(CustomerType.individual, 1000, 5),
                new Loan(CustomerType.company, 6000, 10)
            };

        public static List<Account> GetAccountData()
        {
            return accounts;
        }

        public static void DepositAccountActions()
        {
            Deposit acc = accounts[0] as Deposit;

            acc.DepositMoney(500);
            acc.WithdrawMoney(10000);
        }

        public static void LoanAccountActions()
        {
            Loan acc = accounts[1] as Loan;

            acc.DepositMoney(2000);
        }

        public static void MortgageAccountActions()
        {
            Mortgage acc = accounts[2] as Mortgage;

            acc.DepositMoney(400000);
        }
    }
}
