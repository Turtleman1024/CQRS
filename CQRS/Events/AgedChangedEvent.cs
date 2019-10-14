using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    class AgedChangedEvent : Event
    {
        public Person Target;
        public int OldValue, NewValue;

        public AgedChangedEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Aged changed from {OldValue} to {NewValue}";
        }
    }
}
