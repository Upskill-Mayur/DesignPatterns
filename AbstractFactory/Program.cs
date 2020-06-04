using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            HeadOffice headoffice = new HeadOffice();

            var puneBranch = headoffice.GetBranch(AccountLocations.Pune);
            puneBranch.CreateLoanAccount();
            puneBranch.CreateSavingAccount();


            var mumbaiBranch = headoffice.GetBranch(AccountLocations.Mumbai);
            mumbaiBranch.CreateLoanAccount();
            mumbaiBranch.CreateSavingAccount();
        }
    }

    public enum AccountLocations
    {
        Pune,
        Mumbai,
    }

    #region Abstract Product Logic

    public abstract class SavingsAccount
    {
        public  decimal Balance { get; set; }
    }

    public abstract class LoanAccount
    {
        public decimal Mortgage { get; set; }
    }

    public class PuneSavingsAccount : SavingsAccount
    {
        public PuneSavingsAccount()
        {
            Balance = 5000;
            Console.WriteLine($"Pune Savings account with balance {Balance} created");
        }
    }

    public class MumbaiSavingsAccount : SavingsAccount
    {
        public MumbaiSavingsAccount()
        {
            Balance = 10000;
            Console.WriteLine($"Mumbai Savings account with balance {Balance} created");
        }
    }

    public class PuneLoanAccount : LoanAccount
    {
        public PuneLoanAccount()
        {
            Mortgage = 50000;
            Console.WriteLine($"Pune Loan account with mortgage {Mortgage} created");
        }
    }

    public class MumbaiLoanAccount : LoanAccount
    {
        public MumbaiLoanAccount()
        {
            Mortgage = 100000;
            Console.WriteLine($"Mumbai Loan account with mortage {Mortgage} created");
        }
    }

    #endregion

    #region AbstractFactory
    public abstract class HeadOfficeFactory
    {
        public abstract SavingsAccount CreateSavingAccount();
        public abstract LoanAccount CreateLoanAccount();
    }
    #endregion

    #region Provider
    public class HeadOffice
    {
        public HeadOfficeFactory GetBranch(AccountLocations location)
        {
            switch (location)
            {
                case AccountLocations.Pune:
                    return new PuneBranchFactory();
                case AccountLocations.Mumbai:
                    return new MumbaiBranchFactory();
            }

            return null;
        }
    }
    #endregion

    #region Concrete Factories
    public class PuneBranchFactory : HeadOfficeFactory
    {
        public override LoanAccount CreateLoanAccount()
        {
            return new PuneLoanAccount();
        }

        public override SavingsAccount CreateSavingAccount()
        {
            return new PuneSavingsAccount();
        }
    }

    public class MumbaiBranchFactory : HeadOfficeFactory
    {
        public override LoanAccount CreateLoanAccount()
        {
            return new MumbaiLoanAccount();
        }

        public override SavingsAccount CreateSavingAccount()
        {
            return new MumbaiSavingsAccount();
        }
    }
    #endregion
}
