﻿using CQRS.Commands;
using CQRS.Querys;
using System;

namespace CQRS
{
    // CQRS: Command Query Responsibility Segregation

    //Command: do/change
    //Query: 
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var p = new Person(eb);
            eb.Command(new ChangeAgeCommand(p, 123));

            int age = eb.Query<int>(new AgeQuery { Target = p });

            Console.WriteLine(age);

            Console.ReadKey();
        }
    }
}