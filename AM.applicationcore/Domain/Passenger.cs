using AM_Application_Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Passenger
    {
        #region prop de base
        [Key]
        [StringLength(7) ]
        public String PassportNumber { get; set; }
        
        public FullName fullName { get; set; }

        [Display (Name = "Date of Birth")]  //affichée “Date of Birth”
        [DataType(DataType.Date)]  //une date valide
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[0-9]{8}$")]
        public int TelNumber { get; set; }

        [EmailAddress]
        //[RegularExpression(@"^[a-zA-Z0-9]?*$")]
        public String EmailAddress { get; set; }
#endregion
        #region prop navigation
        public IList<Flight> Flights { get; set; }
        #endregion
        public override string ToString()
        {
            return "FirstName: " + fullName.FirstName + " LastName: " + fullName.LastName + "BirthDate: " + BirthDate;
        }
        public bool CheckProfile(string nom,string prenom)
        {
            return nom==fullName.LastName && prenom==fullName.FirstName;
        }

        public bool CheckProfile(string nom, string prenom, string email)
        {
            return nom == fullName.LastName && prenom == fullName.FirstName && email==EmailAddress;
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
