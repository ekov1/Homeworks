namespace _02.BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units.BankAccounts;
    using Units.Customers;
    using Units;

    class Startup
    {
        static void Main()
        {
            var accounts = Bank.GetAccountData();
            Console.WriteLine("Calculating interest ammount of bank accounts! \n" + new string('-', 60));
            foreach (var account in accounts)
            {
                account.CalculateInterest(13);
            }
            Console.WriteLine("\nBank account actions(deposit/withdraw money)! \n" + new string('-', 60));
            Bank.DepositAccountActions();
            Bank.LoanAccountActions();
            Bank.MortgageAccountActions();
        }
    }
}
