using _05_Greet_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet_Console
{
    public class CustomerUI
    {
        private static CustomerRepository _customerRepo = new CustomerRepository();
        private List<Customer> _customerList = _customerRepo.GetListOfCustomers();


        public void Run()
        {
            SeedList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do? \n\n " +
                    "1. Create Customer\n " +
                    "2. Read Customer\n " +
                    "3. Update Customer\n " +
                    "4. Delete Customer\n " +
                    "5. Exit");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        CreateCustomer();
                        break;
                    case 2:
                        ReadCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DeleteCustomer();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void CreateCustomer()
        {
            Customer newCustomer = new Customer();

            Console.WriteLine("Enter the number of the customer that you are creating?\n " +
                "1. Potential\n " +
                "2. Current\n " +
                "3. Past\n ");
            //        "4. Concert");
            int ctCapture = int.Parse(Console.ReadLine());

            switch (ctCapture)
            {
                case 1:
                    newCustomer.CustomerType = CustomerType.Potential;
                    newCustomer.EmailMessage = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                case 2:
                    newCustomer.CustomerType = CustomerType.Current;
                    newCustomer.EmailMessage = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case 3:
                    newCustomer.CustomerType = CustomerType.Past;
                    newCustomer.EmailMessage = "It's been a long time since we've heard from you, we want you back.";
                    break;
                default:
                    break;
            }

            Console.WriteLine("What is the customer ID?");
            newCustomer.CustomerID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the Customer's First Name?");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("What is the Customer's Last Name?");
            newCustomer.LastName = Console.ReadLine();

            _customerRepo.AddToList(newCustomer);

            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
        private void ReadCustomer()
        {
            //List<Customer> list = _customerRepo.GetListOfCustomers();

            foreach (Customer customer in _customerList)
            {
                Console.WriteLine($"Type of Customer:{customer.CustomerType}\n Customer ID Number: {customer.CustomerID}\n Customer First Name:" +
                    $" {customer.FirstName}\n Customer Last Name: {customer.LastName}\n Customer Email Message:{customer.EmailMessage}");
            }

            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
        
        private void UpdateCustomer()
        {
            ReadCustomer();
            //Console.WriteLine("Press Enter");

            Console.WriteLine("Which CustomerID would you like to update?");
            int responseID = int.Parse(Console.ReadLine());


            foreach (Customer customer in _customerList)
            {
                if (responseID == customer.CustomerID)
                {
                    bool runUpdateMenu = true;
                    while (runUpdateMenu)
                    {

                        Console.WriteLine("Which detail would you like to update?\n" +
                    "1. Customer number\n" +
                    "2. Customer first name\n" +
                    "3. Customer last name\n" +
                    "4. Change customer type to Current\n" +
                    "5. Change customer type to Past\n" +
                    "6. Change customer type to Future\n" +
                    "7. Exit\n");

                        int choice = int.Parse(Console.ReadLine());

                        //CarType type;
                        switch (choice)
                        {
                            //default:
                            case 1:
                                Console.WriteLine("What is the new Customer Number?");
                                customer.CustomerID = int.Parse(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("What is the new Customer First Name?");
                                customer.FirstName = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("What is the new Customer Last Name?");
                                customer.LastName = Console.ReadLine();
                                break;
                            case 4:
                                customer.CustomerType = CustomerType.Current;
                                break;
                            case 5:
                                customer.CustomerType = CustomerType.Past;
                                break;
                            case 6:
                                customer.CustomerType = CustomerType.Potential;
                                break;
                            case 7:
                                Console.WriteLine($"Your Updated information is: {customer.CustomerID} {customer.CustomerType} {customer.FirstName} {customer.LastName} ");
                                Console.ReadKey();
                                runUpdateMenu = false;
                                break;
                            default:
                                break;
                        }

                    }
                }



            }
        }


        private void DeleteCustomer()
        {
            ReadCustomer();

            Console.WriteLine("What customer would you like to remove? Please provide the customer ID number.");
            int anynumber = int.Parse(Console.ReadLine());

            _customerRepo.RemoveCustomer(anynumber);
        }

        private void SeedList()
        {
            Customer content = new Customer(CustomerType.Potential, 1, "Aaron", "Wood", "It's been a long time since we've heard from you, we want you back.");
            Customer content1 = new Customer(CustomerType.Past, 2, "Aaron", "Wood", "It's been a long time since we've heard from you, we want you back.");
            Customer content2 = new Customer(CustomerType.Potential, 3, "Aaron", "Wood", "It's been a long time since we've heard from you, we want you back.");

            _customerRepo.AddToList(content);
            _customerRepo.AddToList(content1);
            _customerRepo.AddToList(content2);
        }


    }
}
