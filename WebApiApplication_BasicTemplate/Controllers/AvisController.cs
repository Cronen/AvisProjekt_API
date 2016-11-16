using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using WebApiApplication1.DB;
using WebApiApplication1.Models;

namespace WebApiApplication1.Controllers
{
    public class AvisController : ApiController
    {
        private IDB DB = new FakeDB();

        public void setDB(bool sandt)
        {
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;
            if (httpContext.Application["DB"] != null)
            {
                DB = (IDB)httpContext.Application["DB"];
            }
            httpContext.Application["DB"] = DB;
        }
        [HttpGet]
        public Reservation GetAReservation(string Fname, string Lname)
        {
            Reservation res = new Reservation();
            res.FirstName = Fname;
            res.LastName = Lname;
            res.StartDate = DateTime.Today;
            res.EndDate = DateTime.Today.AddDays(3);
            res.BilCat = "Kategori A";
            res.Email = "test@eal.dk";
            res.Station = "Odense";
            res.TelephoneNumber = 12345678;

            return res;
        }
        [HttpGet]
        public IEnumerable<Reservation> GetAllReservations()
        {
            setDB(true);
            return DB.GetAllRes();
        }
        [HttpGet]
        public bool search(string s1, string s2)
        {
            return new Helper().Search(s1, s2);
        }

        [HttpGet]
        public IEnumerable<Reservation> ResSearch(string var)
        {
            List<Reservation> reList = new List<Reservation>();
            setDB(true);
            Helper help = new Helper();
            int numb;
            int.TryParse(var, out numb);
            DateTime date;
            DateTime.TryParse(var, out date);
            foreach (Reservation res in DB.GetAllRes())
            {
                if (help.Search(res.FirstName, var) || help.Search(res.LastName, var) || help.Search(res.Email, var) || res.TelephoneNumber == numb || help.CheckDate(date, res))
                {
                    reList.Add(res);
                }
            }
            return reList;
        }
        [HttpPost]
        public bool PostResevation([FromBody] Reservation res)
        {
            setDB(true);
            return DB.Create(res);
        }

        [HttpGet]
        public double CalcPrice(string cat, string dest, DateTime dstart, DateTime dslut)
        {
            Reservation res = new Reservation();
            res.BilCat = cat;
            res.Station = dest;
            res.EndDate = dslut;
            res.StartDate = dstart;
           return new Helper().PriceCalc(res);
        }
        [HttpPost]
        public double CalcPrice(int ResID)
        {
            //Skal finde reservation med ID og udregne pris
            double reD = 0;
            Helper help = new Helper();
            //reD = help.PriceCalc()
            return reD;
        }

    }
}
