using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using Microsoft.Ajax.Utilities;
using WebApiApplication1.DB;
using WebApiApplication1.Models;


namespace WebApiApplication1.Controllers
{
    public class LoginController : ApiController
    {
        private IDB DB = new FakeDB();
        public void setDB()
        {
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;
            if (httpContext.Application["DB"] != null)
            {
                DB = (IDB) httpContext.Application["DB"];
            }
            httpContext.Application["DB"] = DB;
        }
        [HttpGet]
        public bool Login(string user, string pass)
        {
            setDB();
            //IDB DB = new FakeDB();

            return DB.Login(user,pass);
        }

        [HttpGet]
        public void CreateUser(string username, string pass)
        {
            setDB();
            //IDB DB = new FakeDB();
            DB.CreateUser(username,pass);
        }
    }
}