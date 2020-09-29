using System.Collections.Generic;

namespace Person.Service
{
    class PersonService
    {

        private List<Model.Person> _persons = new List<Model.Person>();

        public IEnumerable<Model.Person> LoadAllPersons()
        {
            return _persons;
        }


        public void AddPersonToCollection(Model.Person p)
        {
            _persons.Add(p);
        }


    }
}
