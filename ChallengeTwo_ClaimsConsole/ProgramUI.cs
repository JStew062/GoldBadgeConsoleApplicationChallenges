using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_ClaimsConsole
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

            private void ShowAllClaims()
            {
                Console.Clear();

                // Get Content
                List<Claims> listOfContent = _claimsItemDirectory.GetContents();
                //Loop through Contents
                foreach (Claims content in listOfContent)
                {
                    //Console Write (Dispaly Content)
                    DisplayContent(content);
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }

            //Add a New Claim
            private void AddNewClaim()
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
                Console.Write("Please enter the Date of the Incident.");
                DateTime dateofincident = Console.ReadLine();

                //datetime DateOfClaim
                Console.Write("Please enter the Date of the Claim.");
                DateTime dateofclaim = Console.ReadLine();


                Claims content = new Claims(claimid, claimtype, claimdesc, claimamount, dateofincident, dateofclaim);
                _claimsitemdirectory.AddContentToDirectory(content);
            }

            //Display Claim Content
            private void DisplayContent(Claims content)
            {
                Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                       $"Claim Type: {content.ClaimType}\n" +
                       $"Claim Description: {content.ClaimDesc}\n" +
                       $"Claim Amount: {content.ClaimAmount.ToString("C2")}\n" +
                       $"Date of Incident: {content.DateOfIncident}\n" +
                       $"Date of Date of Claim: {content.DateOfClaim}\n" +
                       $"Is Claim Valid?: {content.IsValid}\n");
            }

            private void WriteAndRead()
            {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }

            //Seed Method
            private void SeedContentList()
            {
                Claims claim1 = new Claims(1, "Car", "Car accident on 465", 400m, 4 / 27 / 18, 4 / 27 / 18, true);
                Claims claim2 = new Claims(2, "Home", "House fire in kitchen", 4000m, 4 / 11 / 18, 4 / 12 / 18, true);
                Claims claim3 = new Claims(3, "Theft", "Stolen pancakes", 4m, 4 / 27 / 18, 6 / 01 / 18, false);

                _claimsItemDirectory.AddContentToDirectory(claim1);
                _claimsItemDirectory.AddContentToDirectoryclaim2);
                _claimsItemDirectory.AddContentToDirectory(claim3);
            }
        }
    }
}