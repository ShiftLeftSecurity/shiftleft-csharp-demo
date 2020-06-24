using System;
using System.Collections.Generic;

namespace netcoreWebapi
{
    public class DataBuilder
    {
        public static List<Customer> CreateCustomers()
        {
            HashSet<Account> accounts1 = new HashSet<Account>();
            accounts1.Add(new Account(1111, 321045, "CHECKING", 10000, 10));
            accounts1.Add(new Account(1112, 321045, "SAVING", 100000, 20));
            Customer customer1 = new Customer("ID-4242", 4242, "Joe", "Smith", DateTime.Parse("1982-01-10").Date,
                    "123-45-3456", "000111222", "981-110-0101", "408-123-1233", new Address("High Street", "", "Santa Clara",
                    "CA", "95054"), accounts1);

            HashSet<Account> accounts2 = new HashSet<Account>();
            accounts2.Add(new Account(2111, 421045, "CHECKING", 20000, 10));
            accounts2.Add(new Account(2112, 421045, "MMA", 200000, 20));
            Customer customer2 = new Customer("ID-4243", 4343, "Paul", "Jones", DateTime.Parse("1973-01-03").Date,
                    "321-67-3456", "222665436", "981-110-0100", "302-767-8796", new Address("Main Street", "", "Sunnyvale",
                    "CA", "94086"), accounts2);

            HashSet<Account> accounts3 = new HashSet<Account>();
            accounts3.Add(new Account(3111, 421045, "SAVING", 30000, 10));
            accounts3.Add(new Account(3112, 421045, "MMA", 300000, 20));
            Customer customer3 = new Customer("ID-4244", 4244, "Steve", "Toale", DateTime.Parse("1979-03-08").Date,
                    "769-12-9987", "888225436", "981-110-0101", "650-897-2366", new Address("Main Street", "", "Redwood City",
                    "CA", "95058"), accounts3);

            return new List<Customer>
            {
                customer1, customer2, customer3
            };  
        }

    }
}