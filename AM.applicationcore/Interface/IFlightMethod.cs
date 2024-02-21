using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.applicationcore.Domain;


namespace AM.applicationcore.Interface
{
    public interface IFlightMethod
    {
        List<DateTime> GetFlightDates(string Destination);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime starDate);

        double DurationAverage(string destination);
       
        IEnumerable<Flight> OrderedDurationFlights();


        IEnumerable<Traveller> SeniorTravellers(Flight flight);
         
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
    }
}
