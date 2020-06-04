using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccountFactory factory = new BankAccountFactory();
            BankAccount savingAccount = factory.CreateAccount(AccountType.Savings);
            BankAccount currentAccount = factory.CreateAccount(AccountType.Current);
        }
    }


    public abstract class BankAccount
    {
        public decimal MinimumBalance { get; set; }
    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount()
        {
            MinimumBalance = 10000;
            Console.WriteLine($"Savings account with minimum balance {MinimumBalance} created.");
        }
    }

    public class CurrentAccount : BankAccount
    {
        public CurrentAccount()
        {
            MinimumBalance = 50000;
            Console.WriteLine($"Current account with minimum balance {MinimumBalance} created.");
        }
    }

    public enum AccountType
    {
        Savings,
        Current
    }
    public interface IAccountFactory
    {
        BankAccount CreateAccount(AccountType accountType);
    }
    public class BankAccountFactory : IAccountFactory
    {
        public BankAccount CreateAccount(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Savings:
                    return new SavingsAccount();
                case AccountType.Current:
                    return new CurrentAccount();
                default:
                    throw new Exception("Invalid account type");
            }
        }
    }
}
