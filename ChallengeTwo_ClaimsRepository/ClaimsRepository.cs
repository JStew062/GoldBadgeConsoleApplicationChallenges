using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_ClaimsRepository
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _claimsItemDirectory = new Queue<Claims>();

        //Create
        public bool AddContentToDirectory(Claims newContent)
        {
            int startingCount = _claimsItemDirectory.Count;
            _claimsItemDirectory.Enqueue(newContent);
            bool wasAdded = (_claimsItemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public Queue<Claims> GetContents()
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
                oldContent.TypeOfClaim = newContent.TypeOfClaim;
                oldContent.ClaimDesc = newContent.ClaimDesc;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
