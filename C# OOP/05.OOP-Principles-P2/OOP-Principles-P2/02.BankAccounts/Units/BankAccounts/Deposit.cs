namespace _02.BankAccounts.Units.BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Customers;
    using Contracts;

    public class Deposit : Account , IDepositable, IWithdrawable
    {
        public Deposit(CustomerType customerType, decimal balance, decimal interestRate) 
            :base(customerType, balance, interestRate)
        {
            
        }

        public override void CalculateInterest(int numOfMonths)
        {
            decimal interestAmmount = 0.00M;

            if (this.Balance > 0 && this.Balance < 1000) //When the balance if greater than 0 and less than $1000
            {
                interestAmmount = 0;
            }
            else if (this.Balance >= 1000) //If balance is $1000 or more
            {
                interestAmmount = (this.InterestRate / 100) * numOfMonths;
            }

            Console.WriteLine("Interest ammount: {0} - For period of: {1} months - Initial balance: {2} ", interestAmmount, numOfMonths, this.Balance);
        }

        public void DepositMoney(decimal moneyToDeposit)
        {
            this.Balance += moneyToDeposit;
            Console.WriteLine("${0} deposited to your deposit account! - Balance: ${1}", moneyToDeposit, this.Balance);
        }

        public void WithdrawMoney(decimal moneyToWithdraw)
        {
            this.Balance -= moneyToWithdraw;
            Console.WriteLine("${0} withdrawn from your deposit account! - Balance: ${1}", moneyToWithdraw, this.Balance);
        }
    }
}
