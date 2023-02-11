using DigitalDiary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.App.Infrastructure
{
    internal static class SingleTon
    {
        public static User AuthUser { get; set; }
    }
}
