﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Model
{
    public class HomeWork:Work
    {
        public DateTime DateEnd { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
