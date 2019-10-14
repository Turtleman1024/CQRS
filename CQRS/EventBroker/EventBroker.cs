using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public class EventBroker
    {
        //1. All events that happened
        public IList<Event> AllEvents = new List<Event>();
        //2. Commands posts
        public event EventHandler<Command> Commands;
        //3. Query
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
    }
}
