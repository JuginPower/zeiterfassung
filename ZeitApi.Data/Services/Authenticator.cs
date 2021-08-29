using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZeitApi.Data.Models;


namespace ZeitApi.Data.Services
{
    public static class Authenticator
    {
        public static string ToAuthenticate(string name, string password)
        {
            using (var ArbeitContext = new arbeitContext())
            {
                var ArbeiterList = ArbeitContext.Arbeiters.ToList();
                string answer = "";
                int counter = 1;
                int i = ArbeiterList.Count();

                while (counter < i)
                {
                    foreach (var item in ArbeiterList)
                    {
                        if (item.Username == name && item.Password == password)
                        {
                            return "Ok";
                        }
                        if (item.Username != name && item.Password == password)
                        {
                            answer = "Wrong Username";
                        }
                        if (item.Username == name && item.Password != password)
                        {
                            answer = "Wrong Password";
                        }
                        else
                        {
                            answer = "Wrong Username and Wrong Password";
                        }
                    }
                    counter ++;
                }
                return answer;
            }
        }
    }
}