using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class ClassWork:Work
    {
        public PairWork PairWork { get; set; }
        public int PairWorkId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }        
        public List<HomeWork> HomeWorks { get; set; }
        public List<Presence> Presences { get; set; }
    }
}
