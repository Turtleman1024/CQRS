using CQRS.Commands;
using CQRS.Querys;
using System;

namespace CQRS
{
    // CQRS: Command Query Responsibility Segregation

    //Command: do/change
    //Query: get something
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var p = new Person(eb);
            eb.Command(new ChangeAgeCommand(p, 123));
            eb.Command(new ChangeNameCommand(p, "TurtleMan"));
            eb.Command(new ChangeAgeCommand(p, 456));
            eb.Command(new ChangeNameCommand(p, "MuffinMan"));

            //We are now registered 
            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            int age = 0;
            age = eb.Query<int>(new AgeQuery { Target = p });

            string name = "";
            name = eb.Query<string>(new NameQuery { Target = p });

            Console.WriteLine(age);
            Console.WriteLine(name);

            eb.UndoLast();

            //Print all the events 
            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            age = eb.Query<int>(new AgeQuery { Target = p });
            name = eb.Query<string>(new NameQuery { Target = p });

            Console.WriteLine(age);

            Console.ReadKey();
        }
    }
}
