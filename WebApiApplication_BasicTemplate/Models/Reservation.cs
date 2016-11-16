using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApplication1.Models
{
    public class Reservation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BilCat { get; set; }
        public string Station { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public Reservation(string bilcat, string station, DateTime start, DateTime end, string fname, string lname, string mail, int numb)
        {
            this.StartDate = start;
            this.EndDate = end;
            this.BilCat = bilcat;
            this.Station = station;
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = mail;
            this.TelephoneNumber = numb;
        }
        public Reservation()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(3);
        }
    }
}
