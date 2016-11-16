using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApplication1.Models;

namespace WebApiApplication1.DB
{
    interface IDB
    {
        bool Create(Reservation res);
        List<Reservation> GetAllRes();
        bool Login(string user, string password);
        void CreateUser(string user, string pass);
    }
}
