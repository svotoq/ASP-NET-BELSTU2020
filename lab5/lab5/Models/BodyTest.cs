using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5.Models
{
    public class BodyTest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public BodyTest(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}