using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet_Repository
{
    public enum CustomerType
    {
        none, Potential, Current, Past
    }
    public class Customer
    {
        public CustomerType CustomerType { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailMessage { get; set; }

        public Customer() { }

        public Customer(CustomerType customerType, int customerID, string firstName, string lastName, string emailMessage)
        {
            CustomerType = customerType;
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            EmailMessage = emailMessage;
        }
    }
}
