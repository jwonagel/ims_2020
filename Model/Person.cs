namespace Person.Model
{
    internal class Person
    {
        private string _fistName;

        public string FirstName
        {
            get { return _fistName; }
            set { _fistName = value; }
        }

        public string LastName { get; set; }

        public Address Address { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} {Address}";
        }

    }
}