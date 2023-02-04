using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class Mark
    {
        public int Id { get; set; }
        public int Val { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public Student Student { get; set; }   
        public Teacher Teacher { get; set; }
    }
}
