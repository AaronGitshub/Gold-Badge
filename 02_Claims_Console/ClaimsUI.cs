using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    public class ClaimsUI
    {
        // new-up a repo instnace here 
        private ClaimQueueRepository _claimRepo = new ClaimQueueRepository();
        
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

                Console.WriteLine("What would you like to do?\n\n" +
                   "1. See all Claims\n" +
                    "2. Take Care of Next Claim.\n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit\n");

                int input = ParseInput();

                switch (input)
                {
                    case 1:
                        // Add content (method call goes here)
                        SeeAllClaims();
                        break;
                    case 2:
                        //                //Get a list of Orders.
                        TakeCareOfNext();
                        break;
                    case 3:
                        //Add Claim
                        AddNewClaim();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }
        private void SeeAllClaims()
        {
            //newup a getqueue of the claimrepo
            Queue<Claim> list = _claimRepo.GetContentQueue();

            Console.WriteLine($"Claim ID  ClaimType   Description   Claim Amount   Date of Incident   Date of Claim   Is Valid");
            foreach (Claim order in list)
            {
                Console.WriteLine($"{order.ClaimID} \t    {order.ClaimType}\t {order.Description}\t\t ${order.ClaimAmount} \t{order.DateOfIncident.ToString("M/dd/yyyy")}\t {order.DateOfClaim.ToString("M/dd/yyyy")}\t {order.IsValid}");

            }
            Console.ReadLine();//or a console.ReadKey();
        }


        private void TakeCareOfNext()
        {
            //Add Peek
            Claim nextClaim = _claimRepo.PeekNextContent();

            Console.WriteLine($"Claim ID:{nextClaim.ClaimID} \n    {nextClaim.ClaimType}\t {nextClaim.Description}\t\t ${nextClaim.ClaimAmount} \t{nextClaim.DateOfIncident.ToString("M/dd/yyyy")}\t {nextClaim.DateOfClaim.ToString("M/dd/yyyy")}\t {nextClaim.IsValid}");

            Console.WriteLine("Do you want to deal with this claim now (y / n) ?");

            string answer = Console.ReadLine().ToLower();

            switch (answer)
            {
                case "y":
                    //dequeue\
                    _claimRepo.GetNextContent(); 
                    Console.WriteLine("The item has been removed.");
                    Console.ReadLine();
                    break;
                case "n":
                    break;
                default:
                    break;

            }
          
        }

        //Add new Claim()
        private void AddNewClaim()
        {

            //    ClaimID: 1
            Console.WriteLine("What is the Claim ID number?");
            int claimID = int.Parse(Console.ReadLine());

            //Type: Car
            Console.WriteLine("What is type of the insured product (car, house, etc)?");
            string claimType = Console.ReadLine();

            //Description: Car Accident on 464.
            Console.WriteLine("Describe the incident");
            string description = Console.ReadLine();

            //Amount: $400.00
            Console.WriteLine("What is the claim amount?");
            decimal claimAmount = decimal.Parse(Console.ReadLine());

            //DateOfAccident: 4 / 25 / 18
            Console.WriteLine("What is the date of the accident in mm/dd/yyyy?");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            //DateOfClaim: 4 / 27 / 18
            Console.WriteLine("What is the date of the claim in the format mm/dd/yyyy?");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            TimeSpan diff = dateOfClaim - dateOfIncident;

            bool isValid;
            if (diff.Days > 31) isValid = false;
            else isValid = true;

            Console.WriteLine(isValid);

            //Console.ReadLine();

            //ClaimQueueRepository claimRepo = new ClaimQueueRepository();

            Claim content = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);

            _claimRepo.AddToQueue(content);

        }




        //Seeding list, if i choose.
        private void SeedList()
        {
            //ClaimQueueRepository claimRepo = new ClaimQueueRepository();
            Claim content = new Claim(1, "House", "Fire", 400.00m, new DateTime(2019, 4, 15), new DateTime(2019, 4, 22), true);
            Claim content0 = new Claim(2, "Car", "Crash", 40.00m, new DateTime(2018, 4, 15), new DateTime(2018, 4, 22), false);
            Claim content1 = new Claim(3, "Theft", "Crash", 455.50m, new DateTime(2017, 1, 15), new DateTime(2017, 1, 30), false);
            //    StreamingContent shaunOfTheDead = new StreamingContent("Shaun of the Dead", 5, GenreType.Horror, true, "R", 120.5d);
            //    StreamingContent toyStoryTwo = new StreamingContent("Toy Story 2", 2, GenreType.Kids, false, "G", 111.11d);
            //    StreamingContent somethingAboutMary = new StreamingContent("Something About Mary", 1, GenreType.RomCom, false, "PG-13", 151.11d);

            _claimRepo.AddToQueue(content);
            _claimRepo.AddToQueue(content0);
            _claimRepo.AddToQueue(content1);
            //    _streamingRepo.AddToList(shaunOfTheDead);
            //    _streamingRepo.AddToList(toyStoryTwo);
            //    _streamingRepo.AddToList(somethingAboutMary);

        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 4)
            {
                Console.WriteLine("Your input was invalid, please enter a valid menu number.");
                input = ParseInput();
            }
            return input;
        }

    }
}

