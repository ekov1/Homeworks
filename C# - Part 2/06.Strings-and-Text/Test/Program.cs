using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Unicode_Characters_3
{
    class Program
    {
        string input = "http://telerikacademy.com/Courses/Courses/Details/212";
        int indexOfDots = input.IndexOf(':', 0);
        string protocol = input.Substring(0, indexOfDots);
    }
}