using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class Parent:Human
    {
        public List<Student> Students { get; set; }
    }
}
