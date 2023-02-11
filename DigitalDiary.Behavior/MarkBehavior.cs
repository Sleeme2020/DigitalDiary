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
        public static Mark[] GetMarks(Human human)
        {
            using (AppDB appDB = new AppDB())
            {
                IEnumerable<Mark> marks;
                switch(human)
                {
                    case Parent parent:                        
                        marks= appDB.Marks.Where(u=>appDB.Students.Any(s => s.Parent == parent));

                        break;

                    case Student student:
                        marks = appDB.Marks.Where(u => u.Student==student);

                        break;

                    case Teacher teacher:
                        marks = appDB.Marks.Where(u=>u.Teacher==teacher);
                        break;
                    default:
                        marks= new List<Mark>();
                        break;
                }

                return marks.ToArray(); 
            }
        }
    }
}
