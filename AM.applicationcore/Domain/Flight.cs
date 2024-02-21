using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Flight
    {
        #region prop base
        public int Flightid { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimationDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public String Departure { get; set; }
        public String Destination { get; set; }
        #endregion
        #region prop navigation
        public Plane p { get; set; }
        public IList<Passenger> passengers { get; set; }
#endregion
    }
}
