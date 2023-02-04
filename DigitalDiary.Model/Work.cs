using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    abstract public class Work
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
    }
}
