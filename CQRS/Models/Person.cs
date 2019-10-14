using CQRS.Commands;
using CQRS.Querys;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public class Person
    {
        private string name;
        private int age;
        EventBroker broker;

        public Person(EventBroker broker)
        {
            this.broker = broker;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query queries)
        {
            var ac = queries as AgeQuery;
            if(ac != null && ac.Target == this)
            {
                ac.Results = age;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;

            if (cac != null && cac.Target == this)
            {
                //Send an event we are now recording the age has changed.
                broker.AllEvents.Add(new AgedChangedEvent(this, age, cac.Age));
                age = cac.Age;
            }
        }
    }
}
