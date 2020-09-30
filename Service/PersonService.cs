using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Person.Model;

namespace Person.Service
{
    class PersonService
    {

        //private List<Model.Person> _persons = new List<Model.Person>();

        public IEnumerable<Model.Person> LoadAllPersons()
        {
            var query = @"SELECT p.ID, p.FIRSTNAME, p.LASTNAME, a.ID, a.STREET as STREET, a.HOUSENUMBER, a.ZIP, a.CITY
                          FROM PERSON p
                          JOIN ADDRESS a ON p.ID_ADDRESS = a.ID";

            using (var connection = SqlConnectionFactory.CreateConnection())
            {
                var personList = new List<Model.Person>();
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var idx = 0;
                    var personId = (int)reader[idx++];
                    var firstName = (string) reader[idx++];
                    var lastName = (string) reader[idx++];
                    var addressId = (int) reader[idx++];
                    var street = (string) reader["STREET"];
                    idx++;
                    var houseNumber = (string) reader[idx++];
                    var zip = (string) reader[idx++];
                    var city = (string) reader[idx++];

                    var person = new Model.Person
                    {
                        Id = personId,
                        FirstName = firstName,
                        LastName = lastName,
                        Address = new Address
                        {
                            Id = addressId,
                            City = city,
                            HouseNumber = houseNumber,
                            Street = street,
                            Zip = zip
                        }
                    };
                    personList.Add(person);
                }

                return personList;
            }
        }


        public void AddPersonToCollection(Model.Person person)
        {
            var address = person.Address;

            if (address.Id == 0)
            {
                using (var connection = SqlConnectionFactory.CreateConnection())
                {
                    var sql = $"INSERT INTO ADDRESS(STREET, HOUSENUMBER, ZIP, CITY) VALUES('{address.Street}', '{address.HouseNumber}', '{address.Zip}', '{address.City}'); SELECT SCOPE_IDENTITY();";
                    var insertCommand = new SqlCommand(sql, connection);

                    connection.Open();

                    address.Id = Convert.ToInt32(insertCommand.ExecuteScalar());
                }
            }

            if (person.Id == 0)
            {
                using var connection = SqlConnectionFactory.CreateConnection();

                var sql = $"INSERT INTO PERSON(FIRSTNAME, LASTNAME, ID_ADDRESS) VALUES ('{person.FirstName}', '{person.LastName}', '{address.Id}'); SELECT SCOPE_IDENTITY();";
                var insertCommand = new SqlCommand(sql, connection);
                connection.Open();
                person.Id = Convert.ToInt32(insertCommand.ExecuteScalar());
            }
        }
    }
}
