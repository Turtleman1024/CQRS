using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public class Command
    {
        public Person Target { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Registered { get; set; } = true;
    }
}
