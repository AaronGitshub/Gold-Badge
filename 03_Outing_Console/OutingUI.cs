using _03_Outing_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Outing_Console
{
    public class OutingUI
    {
        private OutingRepository _outingRepo = new OutingRepository();

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

                Console.WriteLine("What would you like to do?\n\n " +
                "1. List all Outings\n " +
                "2. Add Outing\n " +
                "3. Outing Costs\n " +
                "4. Exit\n ");

                int input = ParseInput();

                switch (input)
                {
                    case 1:
                        PrintAllOutings();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        OutingCosts();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }
        private void PrintAllOutings()
        {

            List<Outing> list = _outingRepo.GetListOfOutings();

            foreach (Outing order in list)
            {
                Console.WriteLine($"Trip Type:{order.TypeOfTrip}\n Number of Attendees: {order.AttendanceNumber}\n Trip Date:" +
                    $" {order.TripDate.ToString("M/dd/yyyy")}\n Cost Per Person: {order.CostPP}\n Cost of Event:{order.CostOfEvent}");
            }
            Console.WriteLine("");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }

        private void AddOuting()
        {

            Console.WriteLine("Enter the number of what you are you making.\n " +
                "1. Golf\n " +
                "2. Bowling\n " +
                "3. Amusement Park\n " +
                "4. Concert ");
            int ttCapture = ParseInput();

            //TripType tripType = (TripType)ttCapture; //Alternative to Switch case, this is casting.
            TripType tripType = TripType.Golf;

            switch (ttCapture)
            {
                case 1:
                    tripType = TripType.Golf;
                    break;
                case 2:
                    tripType = TripType.Bowling;
                    break;
                case 3:
                    tripType = TripType.Amusement;
                    break;
                case 4:
                    tripType = TripType.Concert;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"How many people are attending the {tripType}?");
            int attendanceNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"What is the date of the trip in mm/dd/yyyy??");
            DateTime tripDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("What is the cost per person?");
            decimal costPP = decimal.Parse(Console.ReadLine());

            //Cost of Event
            Console.WriteLine("Press Enter to calculat the Cost of the Event.");
            decimal costOfEvent = attendanceNumber * costPP;

            //the line below represents sending two variables to the CalculatorCost method (that's in repo), that method returns to the local orderCost variable.
            //decimal orderCost = _outingRepo.CalculateAllOutings(tripType, attendanceNumber);

            Outing outing = new Outing(tripType, attendanceNumber, tripDate, costPP, costOfEvent);

            _outingRepo.AddToList(outing);

            Console.ReadKey();
        }


        private void OutingCosts()
        {
            Console.WriteLine("Which Cost would you like to see?\n" +
                "1. All Golfing Events\n" +
                "2. All Bowling Events\n" +
                "3. All Amusement Park Events\n" +
                "4. All Concert Events\n" +
                "5. All Events.");
            int typeCapture = ParseInput();

            decimal cost = _outingRepo.CalculateAllOutingsByType(typeCapture);
            Console.WriteLine($"The total cost for these events was {cost}");
            Console.ReadLine();
        }

        private void SeedList()
        {
            Outing content = new Outing(TripType.Amusement, 1, DateTime.Now, 55.55m, 55.55m);
            Outing content1 = new Outing(TripType.Bowling, 5, DateTime.Now, 12.50m, 62.5m);
            Outing content2 = new Outing(TripType.Concert, 5, DateTime.Now, 10m, 50m);

            _outingRepo.AddToList(content);
            _outingRepo.AddToList(content1);
            _outingRepo.AddToList(content2);
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 5)
            {
                Console.WriteLine("Your input was invalid, please enter a valid menu number.");
                input = ParseInput();
            }
            return input;
        }
    }
}
