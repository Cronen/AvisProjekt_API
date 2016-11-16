using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApplication1.Models
{
    class Helper
    {
        public bool Search(string s1, string s2)
        {
            if (CompareStrings(s1, s2) || CompareStrings(s2, s1))
            {
                return true;
            }
            return false;
        }

        private bool CompareStrings(string s1, string s2)
        {
            string s1up = s1.ToUpper();
            string s2up = s2.ToUpper();
            int count = 0;

            for (int i = 0; i < s1up.Length; i++)
            {
                if (s2up.Contains(s1up[i]))
                {
                    count++;
                    //char ch = s2up[s2up.IndexOf(s1up[i])+3];
                    //char kl = s1up[i + 3];
                    try
                    {
                        if (s2up[s2up.IndexOf(s1up[i])] == s1up[i] && s2up[s2up.IndexOf(s1up[i])+1] == s1up[i + 1] &&
                            s2up[s2up.IndexOf(s1up[i])+2] == s1up[i + 2] && s2up[s2up.IndexOf(s1up[i])+3] == s1up[i + 3])
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            //if (s2.Length - s1.Length == s2.Length - count - 1 && s1.Length - s2.Length != s1.Length - count + 1)
            //{
            //    return true;
            //}
            return false;
        }
        public string CreateSalt()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå";
            char[] reSalt = new char[5];
            Random rand = new Random();
            for (int i = 0; i < reSalt.Length; i++)
            {
                reSalt[i] = chars[rand.Next(chars.Length)];
            }
            return new string(reSalt);
        }
   
        public string Hasher(string pass, string salt)
        {
            StringBuilder sb = new StringBuilder();
            HashAlgorithm hasher = MD5.Create();
            foreach (byte b in hasher.ComputeHash(Encoding.UTF8.GetBytes(pass + salt)))
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        public bool CheckDate(DateTime date, Reservation res)
        {
            if (date >= res.StartDate && date <= res.EndDate)
            {
                return true;
            }
            return false;
        }

        public double PriceCalc(Reservation res)
        {
            double bilCatMultiplier = 0;
            int days = (res.EndDate - res.StartDate).Days;

            switch (res.BilCat)
            {
                case "A":
                    bilCatMultiplier = 100;
                    break;
                case "B":
                    bilCatMultiplier = 200;
                    break;
                case "C":
                    bilCatMultiplier = 300;
                    break;
                case "I":
                    bilCatMultiplier = 500;
                    break;
                case "O":
                    bilCatMultiplier = 250;
                    break;
                default:
                    throw new Exception("Der skete en fejl i udregningen. Prøv igen");
            }
            return bilCatMultiplier * days + 1000;
        }
    }
}
