namespace _02.BankAccounts.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWithdrawable
    {
        void WithdrawMoney (decimal moneyToWithdraw);
    }
}
