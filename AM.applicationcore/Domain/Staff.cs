using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmployemenDate { get; set; }

        [DataType(DataType.Currency)]
        //[Range(typeof(decimal), "0.01", "9999.99")]
        public double Salary { get; set; }
        public String Function { get; set; }

        public override void PassengerType()
        {
            Console.WriteLine("I am Passenger, I am staff member");
        }
    
    }
}
