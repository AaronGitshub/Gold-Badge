using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class ClaimQueueRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        // private Queue<Claims> _claimQueue;

        //public ClaimQueueRepository()
        //{
        //    _claimQueue = new Queue<Claims>();
        //}

        public void AddToQueue(Claim content)
        {
            _claimQueue.Enqueue(content);
        }

        public Claim GetNextContent()
        {
            Claim nextContent = _claimQueue.Dequeue();
            return nextContent;
        }

        public Claim PeekNextContent()
        {
            return _claimQueue.Peek();
        }

        public Queue<Claim> GetContentQueue()
        {
            return _claimQueue;
        }

        public int GetQueueContentsCount()
        {
            int queueContentCount = _claimQueue.Count();
            return queueContentCount;
            //return int queueContentCount = _claimQueue.Count(); //seems like this should work, but it doens't.
        }




        ///These two below are for when i thought a list would do for this assignment...they can be deleted or left as my archive of shame.
        //private List<Claims> _claimRepo = new List<Claims>;

        //public List<Claims> GetAllClaims()
        //{
        //    return _claimRepo;
        //}




    }
}
