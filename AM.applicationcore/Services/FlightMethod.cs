using AM.applicationcore.Domain;
using AM.applicationcore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Services
{
    public class FlightMethod : IFlightMethod
    {
       public List<Flight> flights = new List<Flight>();
      

        

        public List<DateTime> GetFlightDates(string Destination)
        {// for structure 
            List<DateTime> dates = new List<DateTime>();
            //for(int i = 0; i < flights.Count; i++)
            //{
            //    if (Destination == flights[i].Destination)
            //        dates.Add(flights[i].FlightDate);
            //}
            //return dates;
            //foreach structure
            foreach (Flight f in flights)
                if (Destination.Equals(f.Destination))
                dates.Add(f.FlightDate);
            
            return dates;

            //with linq structure
            //var query = from f in flights
            //            where f.Destination == Destination
            //            select f.FlightDate;
            //return query.ToList();

            //La methode Lamda
            //return flights.Where(f=>f.Destination == Destination).Select(a=>a.FlightDate).ToList();

            

           
        }
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
           /* var query = from f in flights
                        group f by f.Destination;*/

            //lambda

            var query = flights.GroupBy(f => f.Destination);

            foreach(var item in query)
            {
                Console.WriteLine("destination : "+item.Key);
                //item.key pour indiquer le key IGrouping(string dans notre cas)
                foreach(var f in item)
                {
                    Console.WriteLine("flight date "+f.FlightDate);
                }
            }
            return query;
            
        }

        public double DurationAverage(string destination)
        {
            //var query = from f in flights
            //            where f.Destination.Equals(destination)
            //            select f.EstimationDuration;
            //return query.Average();

            //lambda

            return flights.Where(f => f.Destination.Equals(destination))
                .Average(f => f.EstimationDuration);
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in flights
            //            orderby f.EstimationDuration descending
            //            select f;
            //return query;

            // lambda 

            return flights.OrderByDescending(f => f.EstimationDuration);

        }

        public int ProgrammedFlightNumber(DateTime starDate)
        {
            //var query = from f in flights
            //            where DateTime.Compare(f.FlightDate, starDate) > 0 
            //            && (starDate - f.FlightDate).TotalDays <= 7
            //            select f;
            //return query.Count();

            //1ere lambda
            /*return flights.Where(f=> (starDate -  f.FlightDate).TotalDays <=7).Count();*/

            //2eme methode

            return flights.Count(f => (starDate - f.FlightDate).TotalDays <= 7);


        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //    var query = from t in travellers
            //                where DateTime.Compare(t.BirthDate)
            /*var query = from f in flight.passengers.OfType<Traveller>()
                        orderby f.BirthDate descending
                        select f;
                return query.Take(3);*/

            //lambda

            return flight.passengers.OfType<Traveller>()
                .OrderByDescending(pp => pp.BirthDate)
                .Take(3);

           
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in flights
            //            where plane == f.planes
            //            select new { f.Destination, f.FlightDate };
            //foreach(var item in query)
            //{
            //    Console.WriteLine(" Flight date : "+item.FlightDate);
            //    Console.WriteLine(" Destination : "+item.Destination);
            //}

            //Lambda

            var query = flights.Where(pp => plane == pp.planes).Select(b => new { b.Destination, b.FlightDate });
            //pp type : Flight
            //b: Flight respecte la condition precedente 
        }
    }
}
