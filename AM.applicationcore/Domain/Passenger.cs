using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Passenger
    {
        #region prop de base
        public String PassportNumber { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public String EmailAddress { get; set; }
        public int Id { get; set; }
#endregion
        #region prop navigation
        public IList<Flight> Flights { get; set; }
        #endregion
        public override string ToString()
        {
            return "FirstName: " + FirstName + " LastName: " + LastName + "BirthDate: " + BirthDate;
        }
        public bool CheckProfile(string nom,string prenom)
        {
            return nom==LastName && prenom==FirstName;
        }

        public bool CheckProfile(string nom, string prenom, string email)
        {
            return nom == LastName && prenom == FirstName && email==EmailAddress;
        }

        public bool Login(string nom, string prenom, string email=null)
        {
            //if (email!=null)
            //    return CheckProfile(nom, prenom, email);
            //return CheckProfile(nom, prenom);
            return (email !=null) ? CheckProfile(nom, prenom, email) : CheckProfile(nom, prenom);
        }

        public virtual void PassengerType()
        {
            //cwl + tab :raccourci console.writeLine
            Console.WriteLine("I am Passenger");
        }
    }
}
