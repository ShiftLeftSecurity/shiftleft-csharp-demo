using System;
using System.Collections.Generic;

namespace netcoreWebapi
{
    public class Customer
    {
        public long Id { get; set; }
        public string CustomerId { get; set; }
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Ssn { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public string Tin { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public HashSet<Account> Accounts { get; set; }

        public Customer()
        {
        }

        public Customer(string customerId, int clientId, string firstName, string lastName, DateTime dateOfBirth, string ssn,
        string socialInsuranceNumber, string tin, string phoneNumber, Address address, HashSet<Account> accounts)
        {
            ClientId = clientId;
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Ssn = ssn;
            SocialInsuranceNumber = socialInsuranceNumber;
            Tin = tin;
            PhoneNumber = phoneNumber;
            Address = address;
            Accounts = accounts;
        }

        public override string ToString() => "Customer [id=" + Id + ", customerId=" + CustomerId + ", clientId=" + ClientId + ", firstName=" + FirstName
        + ", lastName=" + LastName + ", dateOfBirth=" + DateOfBirth + ", ssn=" + Ssn + ", socialInsurancenum="
        + SocialInsuranceNumber + ", tin=" + Tin + ", phoneNumber=" + PhoneNumber + ", address=" + Address + ", accounts="
        + Accounts + "]";
    }
}