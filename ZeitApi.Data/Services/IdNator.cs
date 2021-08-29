using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZeitApi.Data.Models;


namespace ZeitApi.Data.Services
{
    public static class IdNator
    {
        public static int GetId(string name, string password) 
        {
            int PersonId = 0;
            using (var ArbeitContext = new arbeitContext())
            {
                var ArbeiterList = ArbeitContext.Arbeiters.ToList();

                foreach (var item in ArbeiterList)
                {
                    if (item.Username == name && item.Password == password)
                    {
                        PersonId = (int) item.Personid;
                        return PersonId;
                    }
                    else
                    {
                        PersonId = 0;
                    }
                }
            }
            return PersonId;
        }
    }
}