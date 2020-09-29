namespace Person.Model
{
    public class Person
    {
        private string _fistName;

        public string FirstName
        {
            get { return _fistName; }
            set { _fistName = value; }
        }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


        //public string GetFistName()
        //{
        //    return _fistName;
        //}

        //internal void SetFirstName(string firstName)
        //{
        //    if (firstName == null)
        //    {
        //        throw new Exception("Can't be null");
        //    }

        //    this._fistName = firstName;
        //}

        //public string FirstName { get; set; }

        //public string LastName { get; set; }
    }
}