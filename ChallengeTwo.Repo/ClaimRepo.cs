using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repo
{
    public class ClaimRepo
    {
        private List<Claim> _listOfClaims = new List<Claim>();

        private int _count = 0;

        public void CreateClaim(Claim newClaim)
        {
            _count++;
            newClaim.ClaimID = _count;
            _listOfClaims.Add(newClaim);
        }

        public List<Claim> GetAllClaims()
        {
            return _listOfClaims;
        }

        public Claim GetClaimById(int id)
        {
            foreach(Claim claim in _listOfClaims)
            {
                if(id == claim.ClaimID)
                {
                    return claim;
                }
            }

            return null;
        }

        public bool UpdateClaim(int id, Claim updatedClaim)
        {
            Claim claimToUpdate = GetClaimById(id);

            if(claimToUpdate == null)
            {
                return false;
            }

            claimToUpdate.TypeOfClaim = updatedClaim.TypeOfClaim;
            claimToUpdate.Description = updatedClaim.Description;
            claimToUpdate.ClaimAmount = updatedClaim.ClaimAmount;
            claimToUpdate.DateOfIncident = updatedClaim.DateOfIncident;
            claimToUpdate.DateOfClaim = updatedClaim.DateOfClaim;
            claimToUpdate.IsValid = updatedClaim.IsValid;

            return true;
        }

        public bool DeleteClaim(int id)
        {
            Claim claimToDelete = GetClaimById(id);

            if(claimToDelete == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count();
            _listOfClaims.Remove(claimToDelete);

            if(initialCount > _listOfClaims.Count())
            {
                return true;
            }

            return false;
        }
    }
}
