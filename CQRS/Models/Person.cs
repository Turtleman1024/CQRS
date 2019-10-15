using CQRS.Commands;
using CQRS.Querys;
using System;

namespace CQRS
{
    public class Person
    {
        private string name = "";
        private int age= 0;
        private EventBroker broker;

        public Person(EventBroker broker)
        {
            this.broker = broker;
            this.broker.Commands += BrokerOnCommands;
            this.broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query queries)
        {
            switch (queries)
            {
                case AgeQuery aq:
                    aq = queries as AgeQuery;
                    if (aq != null && aq.Target == this)
                    {
                        aq.Results = age;
                    }
                    break;
                case NameQuery nq:
                    nq = queries as NameQuery;
                    if(nq != null && nq.Target == this)
                    {
                        nq.Results = name;
                    }
                    break;
                default:
                    Console.WriteLine("No Query Implemented");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(queries));
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            switch(command){
                case ChangeAgeCommand cac:
                    cac = command as ChangeAgeCommand;
                    if (cac != null && cac.Target == this)
                    {
                        //Add/Send an event we are now recording the age has changed.
                        if (cac.Registered) broker.AllEvents.Add(new AgeChangedEvent(this, age, cac.Age));
                        age = cac.Age;
                    }
                    break;
                case ChangeNameCommand cnc:
                    cnc = command as ChangeNameCommand;
                    if (cnc != null && cnc.Target == this)
                    {
                        //Add/Send an event we are now recording the name has changed.
                        if (cnc.Registered) broker.AllEvents.Add(new NameChangedEvent(this, name, cnc.Name));
                        name = cnc.Name;
                    }
                    break;
                default:
                    Console.WriteLine("No Command Implemented");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(command));
            }
        }
    }
}
