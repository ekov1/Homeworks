namespace _02.BankAccounts.Units.BankAccounts
{
    using Contracts;
    using Customers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Mortgage : Account, IDepositable 
    {
        public Mortgage(CustomerType customerType, decimal balance, decimal interestRate) 
            :base(customerType, balance, interestRate)
        {

        }

        public override void CalculateInterest(int numOfMonths)
        {
            decimal interestAmmount = 0.00M;

            if (this.CustomerType == CustomerType.company && numOfMonths > 12) //Number of months should be greater than 12
            {
                //Half the interest for the first 12 months
                interestAmmount = ((12 * (this.InterestRate / 100)) / 2) + ((numOfMonths - 12) * (this.InterestRate / 100));
            }

            else if (this.CustomerType == CustomerType.individual && numOfMonths > 6) //Number of months should be greater than 6
            {
                //No interest for the first 6 months
                interestAmmount = (numOfMonths - 6) * (this.InterestRate / 100);
            }

            Console.WriteLine("Interest ammount: {0} - For period of: {1} months - Initial balance: {2} ", interestAmmount, numOfMonths, this.Balance);
        }

        //When depositing money to a Mortgage account the deposited money are withdrawn from the mortgage you have to pay off :)

        public void DepositMoney(decimal moneyToDeposit)
        {
            this.Balance -= moneyToDeposit;
            Console.WriteLine("${0} paid off to your mortgage account! - Remaining to pay off: {1}", moneyToDeposit, this.Balance);
        }
    }
}
