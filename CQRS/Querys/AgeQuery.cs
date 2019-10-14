using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Querys
{
    class AgeQuery : Query
    {
        public Person Target { get; set; }
    }
}
