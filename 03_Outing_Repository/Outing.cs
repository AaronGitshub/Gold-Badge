using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Outing_Repository
{
    public enum TripType
    {
        Golf = 1, Bowling, Amusement, Concert
    }
    public class Outing
    {
        public TripType TypeOfTrip { get; set; }
        public int AttendanceNumber { get; set; }
        public DateTime TripDate { get; set; }

        public decimal CostPP { get; set; }

        public decimal CostOfEvent { get; set; }

        public Outing() {}

        public Outing(TripType tripType, int attendanceNumber, DateTime tripDate, decimal costPP, decimal costOfEvent)
        {
            TypeOfTrip = tripType;
            AttendanceNumber = attendanceNumber;
            TripDate = tripDate;
            CostPP = costPP;
            CostOfEvent = costOfEvent;
        }


    }
}
