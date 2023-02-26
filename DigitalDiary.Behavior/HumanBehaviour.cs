using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalDiary.Behavior.DataBase;
using DigitalDiary.Model;
using Microsoft.EntityFrameworkCore;

namespace DigitalDiary.Behavior
{
    public static class HumanBehaviour
    {
        public static Student[] GetAllStudents()
        {
            using (AppDB appDB = new AppDB())
            {
                appDB.Students.Load();
                return appDB.Students.ToArray();
            }
        }
        public static Parent[] GetAllParents()
        {
            using (AppDB appDB = new AppDB())
            {
                appDB.Parents.Load();
                return appDB.Parents.ToArray();
            }
        }
        public static Teacher[] GetAllTeachers()
        {
            using (AppDB appDB = new AppDB())
            {
                appDB.Teachers.Load();
                return appDB.Teachers.ToArray();
            }
        }
        public static Human GetHuman(Human someone)
        {
            Human? human;
            using (AppDB appDB = new AppDB())
            {
                switch (someone)
                {
                    case Student student:
                        human = appDB.Students.FirstOrDefault(s => s.Id == someone.Id);
                        break;

                    case Parent parent:
                        human = appDB.Parents.FirstOrDefault(p => p.Id == someone.Id);
                        break;

                    case Teacher teacher:
                        human = appDB.Teachers.FirstOrDefault(t => t.Id == someone.Id);
                        break;

                    default:
                        throw new ArgumentException("неопознанное тело");
                        break;
                }
            }
            if (human != null)
                return human;
            else
                throw new ArgumentNullException("неопознанное тело");
        }

        public static void PostHuman(Human someone)
        {
            Human human;

            if (someone == null)
                throw new ArgumentNullException();

            using (AppDB appDB = new AppDB())
            {
                switch (someone)
                {
                    case Student student:

                        human = appDB.Students.FirstOrDefault(s => s.Id == someone.Id);
                        if (human == null)
                            appDB.Add(someone);
                        break;

                    case Parent parent:

                        human = appDB.Parents.FirstOrDefault(p => p.Id == someone.Id);
                        if (human == null)
                            appDB.Add(someone);
                        break;

                    case Teacher teacher:

                        human = appDB.Teachers.FirstOrDefault(t => t.Id == someone.Id);
                        if (human == null)
                            appDB.Add(someone);
                        break;
                }
                appDB.SaveChanges();
            }
        }

        public static void EditStudent(int Id, string Name = "", string LastName = "",
            int Age = 0, DateTime BirthDay = default)
        {
            Student? student;

            using (AppDB appDB = new AppDB())
            {
                student = appDB.Students.FirstOrDefault(s => s.Id == Id);

                if (student != null && Name != "")
                    student.Name = Name;

                if (student != null && LastName != "")
                    student.LastName = LastName;

                if (student != null && Age != 0)
                    student.Age = Age;

                if (student != null && BirthDay != default)
                    student.BirthDay = BirthDay;

                if (student != null)
                    appDB.Update(student);
                appDB.SaveChanges();
            }
        }

        public static void DeleteHuman(Human someone)
        {
            if (someone == null) throw new ArgumentNullException();

            Human human;

            switch (someone)
            {
                case Student student:

                    using (AppDB appDB = new AppDB())
                    {
                        human = appDB.Students.FirstOrDefault(s => s.Id == someone.Id);
                        if (human != null)
                            appDB.Remove(human);

                        appDB.SaveChanges();
                    }
                    UserBehavior.Delete(human.User);
                    break;

                case Parent parent:

                    using (AppDB appDB = new AppDB())
                    {
                        human = appDB.Parents.FirstOrDefault(p => p.Id == someone.Id);
                        if (human != null)
                            appDB.Remove(human);

                        appDB.SaveChanges();
                    }
                    UserBehavior.Delete(human.User);
                    break;

                case Teacher teacher:

                    using (AppDB appDB = new AppDB())
                    {
                        human = appDB.Teachers.FirstOrDefault(t => t.Id == someone.Id);
                        if (human != null)
                            appDB.Remove(human);

                        appDB.SaveChanges();
                    }
                    UserBehavior.Delete(human.User);
                    break;
            }
        }

        public static Presence[] GetPresences(Student student)
        {
            if (student == null) throw new ArgumentNullException();

            using (AppDB appDB = new AppDB())
                return appDB.Presences.Where(s => s.Student == student).ToArray();
        }

        public static Student[] GetChildren(Parent parent)
        {
            if (parent == null) throw new ArgumentNullException();

            using (AppDB appDB = new AppDB())
                return appDB.Parents.FirstOrDefault(p => p.Id != parent.Id).Students.ToArray();
        }
    }
}
