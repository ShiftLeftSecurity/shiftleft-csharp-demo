using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Fclp;

namespace netcoreWebapi 
{
    public class DataLoader
    {
        public DataLoader()
        {}

        public void Run(string[] args)
        {
            string encryptor = string.Empty;

            var parser = new FluentCommandLineParser<ApplicationArguments>();
            
            parser.Setup(arg => arg.CryptoEncryptionPassword)
                .As('p', "password")
                .Required();
            
            var result = parser.Parse(args);

            if (result.HasErrors == false)
            {
                encryptor = parser.Object.CryptoEncryptionPassword;

            }

            Console.WriteLine("Loading test data...");
            loadTestData();
            Console.WriteLine("Test data loaded.");
        }

        private void loadTestData()
        {
            foreach (var customer in DataBuilder.CreateCustomers())
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Customer");
            }
        }

    }

    public class ApplicationArguments
    {
        public string CryptoEncryptionPassword { get; set; }
    }    
}