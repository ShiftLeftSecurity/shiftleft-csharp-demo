using System;

namespace netcoreWebapi
{
    public class Account
    {
        public long Id { get; set; }
        public string Type { get; set; }

        public long RoutingNumber { get; set; }

        public long AccountNumber { get; set; }
        public double Balance { get; set; }

        public double Interest { get; set; }

        public Account()
        {
            Balance = 0;
            Interest = 0;
        }

        public Account (long accountNumber, long routingNumber, string type, double initialBalance, double initialInterest) {
        AccountNumber = accountNumber;
        RoutingNumber = routingNumber;
        Type = type;
        Balance = initialBalance;
        Interest = initialInterest;
    }

        public void Deposit(double amount) 
        {
            Balance += amount;
        }

        public void Withdraw(double amount) {
            Balance -= amount;
        }

        public void AddInterest() 
        {
            Balance += (Balance * Interest);
        }

        public override string ToString() => "Account [id=" + Id + ", type=" + Type + ", routingNumber=" + RoutingNumber + ", accountNumber="
            + AccountNumber + ", balance=" + Balance + ", interest=" + Interest + "]";
    }
}

