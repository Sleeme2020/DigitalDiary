using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class HomeWork:Work
    {
        public ClassWork ClassWork { get; set; }
        public int ClassWorkId { get; set; }
        #region RefClassWork
        //public int ClassWorkSubjectId { get; set; }
        //public int ClassWorkSubjectId { get; set; }
        //public int ClassWorkSubjectId { get; set; }
        //public int ClassWorkSubjectId { get; set; }
        //public DateTime ClassWorkDate { get; set; }

        #endregion
        public DateTime DateEnd { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
