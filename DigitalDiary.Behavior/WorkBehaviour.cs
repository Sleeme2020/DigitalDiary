using DigitalDiary.Behavior.DataBase;
using DigitalDiary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Behavior
{
    public static class WorkBehaviour
    {
        public static void PostPresence(Student student, DateTime date, bool val)
        {
            if (student == null) throw new ArgumentNullException();

            using (AppDB appDB = new AppDB())
            {
                var pres = appDB.Presences.FirstOrDefault(s => s.Id == student.Id
                                                            && s.ClassWork.Date == date);
                if (pres != null)
                {
                    pres.Val = val;
                    appDB.Update(pres);
                }
                appDB.SaveChanges();
            }
        }

        public static void PostPresence(Student[] student, DateTime date, bool[] val)
        {
            if (student == null || val == null) throw new ArgumentNullException();

            Presence[] presences = new Presence[student.Length];

            using (AppDB appDB = new AppDB())
            {
                for (int i = 0; i < student.Length; i++)
                {
                    presences[i] = appDB.Presences.FirstOrDefault(s => s.Id == student[i].Id
                                                                    && s.ClassWork.Date == date);

                    if (presences[i] != null)
                    {
                        presences[i].Val = val[i];
                        appDB.Update(presences[i]);
                    }
                }
                appDB.SaveChanges();
            }
        }
        public static void PostClassWork(PairWork pairWork)
        {
            ClassWork classWork = new ClassWork()
            {
                PairWork = pairWork
            };
            using (AppDB appDB = new AppDB())
            {
                appDB.Add(classWork);
                appDB.SaveChanges();
            }
        }

        public static void PostPairWork(DateTime StartDate, DateTime EndDate, string Name)
        {
            PairWork pairWork = new PairWork()
            {
                DateStart = StartDate,
                DateEnd = EndDate,
                Name = Name
            };
            using (AppDB appDB = new AppDB())
            {
                appDB.Add(pairWork);
                appDB.SaveChanges();
            }
        }

        public static void PostHomeWork(HomeWork homeWork)
        {
            if (homeWork == null) throw new ArgumentNullException();

            ClassWork classWork;

            using (AppDB appDB = new AppDB())
            {
                classWork = appDB.ClassWorks.FirstOrDefault(c => c.Id == homeWork.ClassWorkId);

                classWork?.HomeWorks.Add(homeWork);

                appDB.Update(classWork);
                appDB.SaveChanges();
            }
        }
        public static Student[] GetStudentsFromGroup(Group group)
        {
            Student[] students;

            using (AppDB appDB = new AppDB())
                students = appDB.Groups.FirstOrDefault(g => g.Id == group.Id).Students.ToArray();

            return students;
        }
    }
}
