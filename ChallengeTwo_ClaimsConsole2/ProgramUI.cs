using ChallengeTwo_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_ClaimsConsole2
{
    public class ProgramUI
    {
        protected readonly ClaimsRepository _claimsItemDirectory = new ClaimsRepository();

        public void Run()
        {
            SeedContentList();
            DisplayFormat();
        }

        private void DisplayFormat()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. See all claims.\n" +
                    "2. Take care of next claim. \n" +
                    "3. Enter a new claim. \n" +
                    "4. Exit.. \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "Press Enter to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void SeeAllClaims()
        {
            Console.Clear();

            // Get Content
            Queue<Claims> listOfContent = _claimsItemDirectory.GetContents();
            //Loop through Contents
            foreach (Claims content in listOfContent)
            {
                //Console Write (Dispaly Content)
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();

            // Get Content
            Queue<Claims> listOfContent = _claimsItemDirectory.GetContents();
            Claims topitem = listOfContent.Dequeue();

            DisplayContent(topitem); 
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string option = Console.ReadLine();
            if (option == "y")
            {
                DisplayContent(topitem);
            }
            else
            {
                listOfContent.Enqueue(topitem);
            }
            DisplayFormat();

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Add a New Claim
        private void EnterNewClaim()
        {
            //int ClaimID
            Console.Write("Please enter a Claim ID: (1-10,000)");
            int claimid = int.Parse(Console.ReadLine());
             
            //string Claim Type
            Console.Write("Please enter the claim Type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string claimtype = Console.ReadLine();

            //string Claim Description
            Console.Write("Please enter a description of the claim.");
            string claimdesc = Console.ReadLine();

            //string Claim Amount
            Console.Write("Please enter the claim Amount.");
            decimal claimamount = Decimal.Parse(Console.ReadLine());

            //datetime DateOfIncident
            Console.Write("Please enter the Date of the Incident. Use the following Date format:  dd/mm/yyyy ");
            DateTime dateofincident = DateTime.Parse(Console.ReadLine());

            //datetime DateOfClaim
            Console.Write("Please enter the Date of the Claim. Use the following Date format:  dd/mm/yyyy ");
            DateTime dateofclaim = DateTime.Parse(Console.ReadLine());


            Claims content = new Claims(claimid, claimtype, claimdesc, claimamount, dateofincident, dateofclaim);
            _claimsItemDirectory.AddContentToDirectory(content);
        }


        //Display All Claim Content
        private void DisplayContent(Claims content)
        {
            Console.WriteLine("{0,5}{1,15}{2,25}{3,17}{4,20}{5,17}{6,10}", "Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date of Incident", "Date of Claim", "IsVaild");
            Console.WriteLine("{0,5}{1,18}{2,25}{3,17}{4,20}{5,17}{6,10}", content.ClaimID, content.TypeOfClaim, content.ClaimDesc, content.ClaimAmount.ToString("C2"), content.DateOfIncident.ToString("MM/dd/yyyy"), content.DateOfClaim.ToString("MM/dd/yyyy"), content.IsValid);
        }
        private void WriteAndRead()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }


        //Seed Method
        private void SeedContentList()
        {
            Claims claim1 = new Claims(1, "Car", "Car accident on 465", 400m, new DateTime(2018,04,25), new DateTime(2018,04,27));
            Claims claim2 = new Claims(2, "Home", "House fire in kitchen", 4000m, new DateTime(2018,04,11), new DateTime(2018,04,12));
            Claims claim3 = new Claims(3, "Theft", "Stolen pancakes", 4m, new DateTime(2018,04,27), new DateTime(2018,06,01));

            _claimsItemDirectory.AddContentToDirectory(claim1);
            _claimsItemDirectory.AddContentToDirectory(claim2);
            _claimsItemDirectory.AddContentToDirectory(claim3);
        }
    }
}
