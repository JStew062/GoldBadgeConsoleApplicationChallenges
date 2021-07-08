using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_ClaimsRepository
{ 
    public enum ClaimType 
    {
        Car = 1,
        Home,
        Theft
    }


    public class Claims
    {
        internal static int claimid;

        //internal static object claimsid;

        public int ClaimID { get; set; }

        public string TypeOfClaim { get; set; }

        public string ClaimDesc { get; set; }

        public decimal ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                double result2 = DateOfClaim.Subtract(DateOfIncident).TotalDays;
                if (result2 <= 30) 
                            return true;
                    else
                            return false;
            }
        }

        //Constructor Empty
        public Claims() { }

        //Constructor Full
        public Claims(int claimid, string claimtype, string claimdesc, decimal claimamount, DateTime dateofincident, DateTime dateofclaim)

        {
            ClaimID = claimid;
            TypeOfClaim = claimtype;
            ClaimDesc = claimdesc;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
            //IsValid = isvalid;
        }
    }
}
