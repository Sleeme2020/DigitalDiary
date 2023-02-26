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
    public static class MarkBehavior
    {
        private static IEnumerable<Mark> DefinePerson(Human human)
        {
            using (AppDB appDB = new AppDB())
            {
                IEnumerable<Mark> marks;
                switch (human)
                {
                    case Parent parent:
                        marks = appDB.Marks.Where(u => appDB.Students.Any(s => s.Parent == parent));

                        break;

                    case Student student:
                        marks = appDB.Marks.Where(u => u.Student == student);

                        break;

                    case Teacher teacher:
                        marks = appDB.Marks.Where(u => u.Teacher == teacher);
                        break;
                    default:
                        marks = new List<Mark>();
                        break;
                }
                return marks;
            }
        }
        public static Mark[] GetMarks(Human human)
        {
            return DefinePerson(human).ToArray();
        }
        public static void DeleteMark(Human human, Work work)
        {
            IEnumerable<Mark> marks = DefinePerson(human);

            Mark mark = marks.FirstOrDefault(w => w.Id == work.Id);

            if (mark != null)
            {
                using (AppDB appDB = new AppDB())
                {
                    appDB.Remove(mark);
                    appDB.SaveChanges();
                }
            }

        }
        public static void DeleteMark(Human human, Work[] works)
        {
            IEnumerable<Mark> marks = DefinePerson(human);

            for (int i = 0; i < marks.Count(); i++)
            {
                Mark? mark = marks.FirstOrDefault(w => w.Id == works[i].Id);

                if (mark != null)
                {
                    using (AppDB appDB = new AppDB())
                    {
                        appDB.Remove(marks);
                        appDB.SaveChanges();
                    }
                }
            }
        }

        public static void DeleteMark(int Id)
        {
            using (AppDB appDB = new AppDB())
            {
                Mark mark = appDB.Marks.FirstOrDefault(m => m.Id == Id);

                if (mark != null)
                    appDB.Remove(mark);

                appDB.SaveChanges();
            }
        }

        public static void PostMark(Human human, Work work, int mark_val)
        {
            if (mark_val <= 0 && mark_val > 12)
                throw new Exception("некорректная оценка");

            if (human is Student)
            {
                using (AppDB appDB = new AppDB())
                {
                    Mark? mark = appDB.Marks.FirstOrDefault(m => m.Student.Id == human.Id
                                                           && m.WorkId == work.Id);
                    if (mark != null)
                    {
                        mark.Val = mark_val;
                        appDB.Update(mark);
                        appDB.SaveChanges();
                    }
                }
            }
            else
                throw new ArgumentException("не студент");
        }
        public static void PostMark(Human human, Mark new_mark)
        {
            IEnumerable<Mark> marks;

            if (human is Student)
            {
                using (AppDB appDB = new AppDB())
                    marks = appDB.Marks.Where(s => s.Student == human);

                Mark mark = marks.FirstOrDefault(m => m.Id == new_mark.Id);

                if (mark != null)
                {
                    mark = new_mark;

                    using (AppDB appDB = new AppDB())
                    {
                        appDB.Update(mark);
                        appDB.SaveChanges();
                    }
                }
            }
            else
                throw new ArgumentException("не студент");
        }
    }
}
