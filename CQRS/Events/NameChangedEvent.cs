using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    class NameChangedEvent : IEventHandler
    {
        public Person Target { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

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
