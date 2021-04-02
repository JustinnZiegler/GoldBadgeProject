using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimsRepo
    {
        protected readonly List<ClaimClass> _contentDirectory = new List<ClaimClass>();
        
        public ClaimClass NextClaim()
        {
            return _contentDirectory[0];
        }

        public bool AddContentToDirectory(ClaimClass claimContent)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(claimContent);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<ClaimClass> GetclaimContent()
        {
            return _contentDirectory;
        }
        public bool DeleteClaim(ClaimClass currentItems)
        {
            bool deleteOutcome = _contentDirectory.Remove(currentItems);
            return deleteOutcome;
        }
    }
}
