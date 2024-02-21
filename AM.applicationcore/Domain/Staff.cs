using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmployemenDate { get; set; }
        public double Salary { get; set; }
        public String Function { get; set; }

        public override void PassengerType()
        {
            Console.WriteLine("I am Passenger, I am staff member");
        }
    
    }
}
