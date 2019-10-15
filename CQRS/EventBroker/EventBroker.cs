using CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS
{
    public class EventBroker
    {
        //1. All events that happened
        public IList<IEventHandler> AllEvents = new List<IEventHandler>();
        //2. Commands
        public event EventHandler<Command> Commands;
        //3. Queries
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }

        //Magic with generics
        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T) q.Results;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangedEvent;
            var nc = e as NameChangedEvent;
            if(ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.OldValue) { Registered = false });
                AllEvents.Remove(e);
            }
            else if (nc != null)
            {
                Command(new ChangeNameCommand(nc.Target, nc.OldValue) { Registered = false });
                AllEvents.Remove(e);
            }
        }
    }
}
