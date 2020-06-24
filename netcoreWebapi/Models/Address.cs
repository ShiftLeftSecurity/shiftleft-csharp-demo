using System;

namespace netcoreWebapi
{
    public class Address 
    {

        public Address() 
        {
        }

        public Address(string address1, string address2, string city, string state, string zipCode)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public long Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City {get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }


        public override string ToString() 
        {
            return "Address [id=" + Id + ", address1=" + Address1 + ", address2=" + Address2 + ", city=" + City + ", state="
                + State + ", zipCode=" + ZipCode + "]";
        }
    }
}