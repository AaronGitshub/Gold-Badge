using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet_Repository
{
    public class CustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();

        public void AddToList(Customer content)
        {
            _customers.Add(content);
        }

        public List<Customer> GetListOfCustomers()
        {
            return _customers;
        }

        public void RemoveCustomer(int customerID)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.CustomerID == customerID)
                {
                    _customers.Remove(customer);
                    break;
                }
            }

        }


    }
}
