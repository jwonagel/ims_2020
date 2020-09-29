using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using ConsoleTables;
using Person.Service;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Person p = new Model.Person();
            p.FirstName = "Max";
            p.LastName = "Muster";

            
            Model.Person p1 = new Model.Person();
            p1.FirstName = "Felix";
            p1.LastName = "Muster";

            var personService = new PersonService();
            personService.AddPersonToCollection(p);
            personService.AddPersonToCollection(p1);

            var personList = personService.LoadAllPersons();

            foreach (var person in personList)
            {
                Console.WriteLine(person);
            }

            var cnt = 0;

            var table = new ConsoleTable("Number", "Firstname", "Name");
            foreach (var person in personService.LoadAllPersons()){

                table.AddRow(++cnt, person.FirstName, person.LastName);
            }


            table.Write();
            Console.WriteLine();

            var rows = personService.LoadAllPersons();

            ConsoleTable
                .From<Model.Person>(rows)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Default);

        }


    }
}
