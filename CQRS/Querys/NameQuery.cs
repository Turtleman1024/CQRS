using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Querys
{
    class NameQuery : Query
    {
        public Person Target { get; set; }
    }
}
