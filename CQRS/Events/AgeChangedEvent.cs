using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    class AgeChangedEvent : IEventHandler
    {
        public Person Target { get; set; }
        public int OldValue { get; set; }
        public int NewValue { get; set; }

        public AgeChangedEvent(Person target, int oldValue, int newValue)
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
