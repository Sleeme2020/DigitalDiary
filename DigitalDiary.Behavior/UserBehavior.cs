using DigitalDiary.Behavior.DataBase;
using DigitalDiary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Behavior
{
    public static class UserBehavior
    {
        public static User[] Get() 
        {
            using (AppDB appDB= new AppDB()) 
            {
                appDB.Users.Load();
                return appDB.Users.ToArray();
            }
        }

        public static User Get(int Id)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Users.FirstOrDefault(u => u.Id == Id);
        }
        public static User Get(string login)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Users.FirstOrDefault(u => u.Login == login);
        }

        public static User GetAuth(string login , string password)
        {
            using (AppDB appDB = new AppDB())
                return appDB.Users.FirstOrDefault(u=>u.Login== login && u.Password==password);
        }

        public static void Post(User user)
        {
            using (AppDB appDB = new AppDB()) {
                var us = appDB.Users.FirstOrDefault(u=>u.Login == user.Login);
                if (us != null) 
                {
                    us.UpdateEnty(user);
                    appDB.Update(us);
                }
                else
                {
                    appDB.Users.Add(user);
                }
                appDB.SaveChanges();
            }
        }

        public static void Delete(User user)
        {
            using (AppDB appDB = new AppDB())
            {
                var us = appDB.Users.FirstOrDefault(u => u.Login == user.Login);
                if (us != null)
                {
                    
                    appDB.Remove(us);
                }
                
                appDB.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (AppDB appDB = new AppDB())
            {
                var us = appDB.Users.FirstOrDefault(u => u.Id == id);
                if (us != null)
                {

                    appDB.Remove(us);
                }

                appDB.SaveChanges();
            }
        }

    }
}
