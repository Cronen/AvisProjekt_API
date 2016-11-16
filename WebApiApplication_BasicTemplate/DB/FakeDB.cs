using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiApplication1.Models;

namespace WebApiApplication1.DB
{
    public class FakeDB : IDB
    {
        public List<Reservation> DB = new List<Reservation>();
        private List<string> CatList = new List<string>();
        private List<User> UserList = new List<User>();

        public FakeDB()
        {
            CreateCatList(CatList);
            CreateDB(DB);
            CreateUserList(UserList);
        }

        public bool Create(Reservation res)
        {
            try
            {
                Reservation newRes = new Reservation();
                newRes = res;
                DB.Add(newRes);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Reservation> GetAllRes()
        {
            return DB;
        }

        public bool Login(string user, string password)
        {
            Helper help = new Helper();
            foreach (User us in UserList)
            {
                if (us.Username == user && help.Hasher(password, us.Salt) == us.HashPass)
                {
                    return true;
                }
            }
            return false;
        }

        public void CreateUser(string user, string pass)
        {
            Helper help = new Helper();
            UserList.Add(new User(user, pass, help.CreateSalt()));
        }

        public void CreateCatList(List<string> cat)
        {
            cat.Add("Kategori A");
            cat.Add("Kategori B");
            cat.Add("Kategori C");
            cat.Add("Kategori D");
            cat.Add("Kategori E");
        }
        public void CreateDB(List<Reservation> DBList)
        {
            DB.Add(new Reservation(CatList[0], "Odense", DateTime.Today, DateTime.Today.AddDays(9), "Karina", "Trump", "stump@trump.com", 51236248));
            DB.Add(new Reservation(CatList[0], "Odense", DateTime.Today, DateTime.Today.AddDays(1), "Mac", "Donald", "mc@donald.com", 11442255));
            DB.Add(new Reservation(CatList[1], "KBH", DateTime.Today.AddDays(-2), DateTime.Today, "Carina", "Cena", "CC@badboi.com", 65498732));
            DB.Add(new Reservation(CatList[2], "Århus", DateTime.Today, DateTime.Today.AddDays(3), "Crone", "Jewels", "Royal@balls.com", 11442255));
            DB.Add(new Reservation(CatList[0], "Odense", DateTime.Today, DateTime.Today.AddDays(7), "King", "Arthas", "Lich@King.boy", 99999999));
        }
        private void CreateUserList(List<User> list)
        {
            Helper help = new Helper();
            list.Add(new User("Crone", "password", help.CreateSalt()));
            Thread.Sleep(50);
            list.Add(new User("Cena", "password", help.CreateSalt()));
            Thread.Sleep(50);
            list.Add(new User("Hackme", "password", help.CreateSalt()));
            Thread.Sleep(50);
            list.Add(new User("Avis", "password", help.CreateSalt()));
        }
    }
}
