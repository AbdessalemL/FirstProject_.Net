using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{//2eme methode
//        public enum PlaneType
//        {
//            BOING, AIRBUS
//        }
    public class Plane
    {
        //public Plane(int capacity, DateTime manufactureDate)
        //{
        //    Capacity = capacity;
        //    ManufactureDate = manufactureDate;
        //}

        //#region exemple
        //private int capacity;
        //private int getCapacity { get { return capacity; } }
        //public void setCapacity(int capacity) { this.capacity = capacity; }
        //#endregion
        //#region propversion

        ////version light:prop+2tab
        //public int MyProperty { get; set; }
        ////version secure:propg+2tab
        //public int MyProperty1 { get; private set; }
        ////version full:propfull+2tab
        //private int myVar;
        //public int MyProperty2 {
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        //#endregion


        #region prop de base
        public String airlineLogo { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int Planeid { get; set; }
        public PlaneType PlaneType { get; set; }
        #endregion
        #region prop navigation
        public IList<Flight> flights { get; set; }

        
        #endregion

    }
}