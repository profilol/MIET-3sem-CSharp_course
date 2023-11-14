namespace Lab_04
{
    class Team: INameAndCopy
    {
        protected string _organization;
        protected int _registrationNumber;
        public string Name { get; set; }

        public string organization 
        { 
            get { return _organization; } 
            set { _organization = value; } 
        }
        public int registrationNumber 
        { 
            get { return _registrationNumber; } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number less or equal 0 can't be set as registration number!");
                }
                else _registrationNumber = value;
            } 
        }
        public Team(string organization, int registrationNumber) 
        {
            _organization = organization;
            this.registrationNumber = registrationNumber;
        }
        public Team()
        {
            _organization = "ZELENOGRAD TECHNOLOGY";
            _registrationNumber = 322322;
        }

        public virtual object DeepCopy()
        {
            return new Team(_organization, _registrationNumber);
        }

        public override string ToString()
        {
            string resultString;

            resultString = $"[{this._organization}, {this._registrationNumber}]";
            return resultString;
        }

        public override bool Equals(object? obj)
        {
            bool result = false;

            Team? anotherTeam = (Team?)obj;

            if (anotherTeam !is null && this._organization == anotherTeam.organization &&
                this._registrationNumber == anotherTeam.registrationNumber 
                )
            {
                result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this._organization, this._registrationNumber);
        }

        public static bool operator ==(Team a, Team b)
        {
            bool result = false;
            if (a.organization == b.organization &&
                a.registrationNumber == b.registrationNumber
                )
            {
                result = true;
            }

            return result;
        }

        public static bool operator !=(Team a, Team b)
        {
            bool result = false;
            if (a.organization != b.organization ||
                a.registrationNumber != b.registrationNumber
                )
            {
                result = true;
            }

            return result;
        }
    }
}
