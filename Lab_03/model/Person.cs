namespace Lab_03
{
    class Person
    {
        private string _name;
        private string _surname;
        private System.DateTime _birthDate;

        public string name
        {
            get { return _name; }
            //set { this._name = value; } 
        }

        public string surname
        {
            get { return _surname; }
            //set { this._surname = value; }
        }

        public System.DateTime birthDate
        {
            get { return _birthDate; }
            //set { this._birthDate = value; }
        }

        public System.DateTime setBirthDate
        {
            get { return _birthDate; }
            set { this._birthDate = value; }
        }

        public Person(string name, string surname, DateTime birthDate)
        {
            this._name = name;
            this._surname = surname;
            this._birthDate = birthDate;
        }

        public Person()
        {
            this._name = "Саня";
            this._surname = "Вудуш";
            this._birthDate = new DateTime(1987, 7, 25);
        }

        virtual public object DeepCopy()
        {
            return new Person(_name, _surname, _birthDate);
        }

        public override string ToString()
        {
            string resultString;

            resultString = $"[{this._name}, {this._surname}, {this._birthDate}]";
            return resultString;
        }

        public override bool Equals(object? obj)
        {
            bool result = false;

            Person? anotherPerson = (Person?)obj;

            if (anotherPerson != null && this._name == anotherPerson.name &&
                this._surname == anotherPerson.surname &&
                this._birthDate == anotherPerson.birthDate
                )
            {
                result = true ;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this._name, this._surname, this._birthDate);
        }

        public static bool operator==( Person a, Person b )
        {
            bool result = false;
            if (a.name == b.name &&
                a.surname == b.surname &&
                a.birthDate == b.birthDate
                )
            {
                result = true;
            }

            return result;
        }

        public static bool operator!=(Person a, Person b)
        {
            bool result = false;
            if (a.name != b.name ||
                a.surname != b.surname ||
                a.birthDate != b.birthDate
                )
            {
                result = true;
            }
            return result;
        }

        virtual public string ToShortString()
        {
            string resultString = $"[{this._name}, {this._surname}]";
            return resultString;
        }
    }
}
