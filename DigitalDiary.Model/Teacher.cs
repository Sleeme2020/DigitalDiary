using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class Teacher:Human
    {
        public List<Presence> Presences { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
