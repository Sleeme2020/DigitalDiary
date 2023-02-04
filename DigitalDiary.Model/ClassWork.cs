using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class ClassWork:Work
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }        
        public HomeWork HomeWork { get; set; }
        public List<Mark> Marks { get; set; }
        public List<Presence> Presences { get; set; }
    }
}
