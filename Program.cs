using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using ConsoleTables;
using Person.Model;
using Person.Service;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Model.Person
            {
                FirstName = "Max",
                LastName = "Muster",
                Address = new Address
                {
                    City = "Wil",
                    Street = "Bahnhofstrasse",
                    HouseNumber = "73a",
                    Zip = "9500"
                }
            };


            var p1 =new Model.Person
            {
                FirstName = "Petra",
                LastName = "Muster",
                Address = new Address
                {
                    City = "St. Gallen",
                    Street = "Teufener Strasse",
                    HouseNumber = "5",
                    Zip = "9000"
                }
            };

            var personService = new PersonService();
            personService.AddPersonToCollection(p);
            personService.AddPersonToCollection(p1);

            var personList = personService.LoadAllPersons();

            foreach (var person in personList)
            {
                Console.WriteLine(person);
            }

            //var cnt = 0;

            //var table = new ConsoleTable("Number", "Firstname", "Name");
            //foreach (var person in personService.LoadAllPersons()){

            //    table.AddRow(++cnt, person.FirstName, person.LastName);
            //}


            //table.Write();
            //Console.WriteLine();

            //var rows = personService.LoadAllPersons();

            //var x = ConsoleTable
            //    .From<Model.Person>(rows)
            //    .Configure(o => o.NumberAlignment = Alignment.Right);


            //x.Write(Format.Default);
        }


    }
}
