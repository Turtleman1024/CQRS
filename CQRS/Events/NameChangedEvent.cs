using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Events
{
    class NameChangedEvent : Event
    {
        public Person Target;
        public string OldValue, NewValue;

        public NameChangedEvent(Person target, string oldValue, string newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Name changed from {OldValue} to {NewValue}";
        }
    }
}
