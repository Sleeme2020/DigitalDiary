using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class Presence
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public ClassWork ClassWork { get; set; }
        public bool Val { get; set; }
    }
}
