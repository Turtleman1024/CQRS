using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Commands
{
    class ChangeNameCommand : Command
    {
        public ChangeNameCommand(Person target, string name)
        {
            Target = target;
            Name = name;
        }
    }
}
