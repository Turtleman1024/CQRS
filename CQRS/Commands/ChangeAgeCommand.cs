using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Commands
{
    class ChangeAgeCommand : Command
    {
        public ChangeAgeCommand(Person target, int age)
        {
            Target = target;
            Age = age;
        }
    }
}
