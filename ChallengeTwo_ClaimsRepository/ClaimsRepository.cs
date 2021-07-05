using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_ClaimsRepository
{
    public class ClaimsRepository
    {
        //FakeDatabase
        protected readonly List<Claims> _claimsItemDirectory = new List<Claims>();

        //CRUD
        //Create
        public bool AddContentToDirectory(Claims newContent)
        {
            int startingCount = _claimsItemDirectory.Count;
            _claimsItemDirectory.Add(newContent);
            bool wasAdded = (_claimsItemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<Claims> GetContents()
        {
            return _claimsItemDirectory;
        }
        public Claims GetContentByClaimID(int claimid)
        {
            foreach (Claims content in _claimsItemDirectory)
            {
                if (content.ClaimID == Claims.claimid)
                {
                    return content;
                }
            }
            return null;
        }

        //Update
        public bool UpdateExistingContent(int originalClaimID, Claims newContent)
        {
            Claims oldContent = GetContentByClaimID(originalClaimID);
            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.ClaimDesc = newContent.ClaimDesc;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.IsValid = newContent.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteExistingContent(Claims existingContent)
        {
            bool deleteResult = _claimsItemDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
