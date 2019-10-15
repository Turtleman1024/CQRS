using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    class AgeQuery : Query
    {
        public Person Target { get; set; }
    }
}
