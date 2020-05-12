using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgramVer2
{
    
    class Account
    {

        private string name, address;
        private decimal balance = 0; //private does not let unathorized access from outside to balance
                                     //name starts with low letter==means Private        

        public static decimal InterestRateCharged; //using word STATIC to make it a memeber of a class, and not member of an instance(object)
        public static decimal minIncome=10000;
        public static int minAge = 18;

        public static bool AccountAllowed (decimal income, int age)//(using STATIC method) checking income and age of client to open an account
        {
            if ((income >=minIncome) && (age >=minAge))
               {
                return true;
               }
            else
            {
                return false;
            }

        }

        public bool WithdrawFunds(decimal amount) //name starts with capital letter==means Public
        {
            if (balance<amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        public void PayInFunds (decimal amount)
        {
            balance = balance + amount;
        }

        public decimal GetBalance ()
        {
            return balance;
        }

              
    }

    class Bank
    {
        static void Main()
        {
            if (Account.AccountAllowed(25000, 33))
            {
                Console.WriteLine("Account allowed");
            }
            else
            {
                Console.WriteLine("Account cannot be opened due to Income or/and Age restriction");
            }


            Account RobsAccount;
            RobsAccount = new Account(); //creating "tag"(reference) to an object Account
            if (RobsAccount.WithdrawFunds(5))
            {
                Console.WriteLine("Cash Withdrawn");
            }
            else
            {
                Console.WriteLine("Insufficient Funds");
            }
           

            RobsAccount.PayInFunds(50); //calling method PayInFunds

            if (RobsAccount.GetBalance() !=50)
            {
                Console.WriteLine("pay in test failed");
            }
            else
            {
                Console.WriteLine("pay in test succeeded");
            }
            Account.InterestRateCharged = 10; //call it using class name ACCOUNT, because used word STATIC above.

            
            Console.ReadKey();
        }
    }
}
