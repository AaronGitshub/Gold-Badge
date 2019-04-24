using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Outing_Repository
{
    public class OutingRepository
    {
        private List<Outing> _outings = new List<Outing>();

        //        1. Display a list of all outings.
        public List<Outing> GetListOfOutings()
        {
            return _outings;
        }

        //2. Add individual outings to a list(don't need to worry about delete yet)
        public void AddToList(Outing content)
        {
            _outings.Add(content);
        }

        public decimal CalculateAllOutingsByType(int ttCapture)
        {
            decimal totalByType = 0;
            foreach (Outing outing in _outings)
            {
                if (outing.TypeOfTrip == (TripType)ttCapture || ttCapture == 5)
                    totalByType += outing.CostOfEvent;
            }
            return totalByType;
        }




    }
}
