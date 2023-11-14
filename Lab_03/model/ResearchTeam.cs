using System.Collections;

namespace Lab_03
{
    class ResearchTeam: Team, IEnumerable
    {
        private string _researchTitle;
        private TimeFrame _researchDuration;
        private List<Person> _researchers = new List<Person>();
        private List<Paper> _publicationList = new List<Paper>();

        public string researchTitle { 
            get { return _researchTitle; }
            set { _researchTitle = value; }
        }

        public TimeFrame researchDuration
        {
            get { return _researchDuration; }
            set { _researchDuration = value; }
        }

        public List<Paper> publicationList
        {
            get { return _publicationList; }
            set { _publicationList = value; }
        }

        public List<Person> researchers
        {
            get { return _researchers; }
            set { _researchers = value; }
        }

        public Paper lastPublication
        {
            get
            {
                Paper returnVal;
                int publicationsCount = _publicationList.Count;

                if (publicationsCount == 0) 
                { 
                    returnVal = null;
                } else
                {
                    int index = 0;
                    DateTime maxPublicationDate = DateTime.MinValue;
                    for (int i = 0; i < publicationsCount; i++)
                    {
                        Paper curPublication = (Paper)_publicationList[i];
                        if (curPublication.publicationDate > maxPublicationDate)
                        {
                            maxPublicationDate = curPublication.publicationDate;
                            index = i;
                        }
                    }
                    returnVal = (Paper)_publicationList[index];
                }

                return returnVal;
            }
        }

        public bool this[TimeFrame timeFrame]
        {
            get
            {
                return timeFrame == this._researchDuration;
            }
        }

        public Team this[Team team]
        {
            get
            {
                if (team.organization == this._organization && team.registrationNumber == this.registrationNumber)
                    return new Team(this._organization, this._registrationNumber);
                else
                    return null;
            }
            set
            {
                this._organization = team.organization;
                this._registrationNumber = team.registrationNumber;
            }
        }

        public ResearchTeam(
            string researchTitle,
            string organization,
            int registrationNumber,
            TimeFrame researchDuration) : base(organization, registrationNumber)
        { 
            this._researchTitle = researchTitle;
            this._organization = organization;
            this._registrationNumber = registrationNumber;
            this._researchDuration = researchDuration;
        }

        public ResearchTeam()
        {
            this._researchTitle = "Генеративные нейронные сети";
            this._organization = "Сбербанк";
            this._registrationNumber = 25565;
            this._researchDuration = TimeFrame.Year;
        }

        public void AddPapers(Paper[] newPapers)
        {
            List<Paper> newPublications = new List<Paper>();
            List<Paper> oldPublications = this._publicationList;

            foreach (Paper p in oldPublications)
            {
                newPublications.Add(p);
            }

            foreach (Paper p in newPapers)
            {
                newPublications.Add(p);
            }

            this._publicationList = newPublications;
        }

        public void AddMembers(Person[] members)
        {
            List<Person> newMembers = new List<Person>();
            List<Person> oldMembers = this.researchers;

            foreach (Person p in oldMembers)
            {
                newMembers.Add(p);
            }

            foreach (Person p in members)
            {
                newMembers.Add(p);
            }

            this._researchers = newMembers;
        }

        override public string ToString()
        {
            string resultString = $"[{this._researchTitle}, {this._organization}, {this._registrationNumber}, {this._researchDuration}";

            if (this._publicationList.Count != 0)
            {
                resultString += $", \n[\n";
                
                foreach(Paper p in this._publicationList)
                {
                    resultString += "\t";
                    resultString += p.ToString();
                    resultString += ",\n";
                }
                resultString += "]";
            }
            if (this.researchers.Count != 0)
            {
                resultString += $", \n[\n";

                foreach (Person p in this.researchers)
                {
                    resultString += "\t";
                    resultString += p.ToString();
                    resultString += ",\n";
                }
                resultString += "]";
            }

            resultString += "]";

            return resultString;
        }

        virtual public string ToShortString()
        {
            string resultString;

            resultString = $"[{this._researchTitle}, {this._organization}, {this._registrationNumber}, {this._researchDuration}]";
            return resultString;
        }

        public override object DeepCopy()
        {
            ResearchTeam cloneTeam;
            
            cloneTeam = new ResearchTeam(
            _researchTitle,
            _organization,
            _registrationNumber,
            _researchDuration
            );

            int publicationCount = _publicationList.Count;

            if (publicationCount != 0 )
            {
                Paper[] clonePublications = new Paper[publicationCount];

                for (int i = 0; i < publicationCount; i++)
                {
                    Paper curPaper = (Paper)_publicationList[i];
                    clonePublications[i] = new Paper(curPaper.title, curPaper.author, curPaper.publicationDate);
                }

                cloneTeam.AddPapers(clonePublications);
            }

            int researchersCount = _researchers.Count;

            if (researchersCount != 0)
            {
                Person[] cloneResearchers = new Person[researchersCount];

                for (int i = 0; i < researchersCount; i++)
                {
                    Person curPerson = (Person)_researchers[i];
                    cloneResearchers[i] = new Person(curPerson.name, curPerson.surname, curPerson.birthDate);
                }

                cloneTeam.AddMembers(cloneResearchers);

            }

            return cloneTeam;
        }

        public IEnumerable<Person> GetResearchersWithoutPublications() 
        { 
            foreach(Person p in _researchers)
            {
                bool hasPublication = false;
                foreach (Paper paper in _publicationList)
                {
                    if (paper.author == p)
                    {
                        hasPublication = true;
                        break;
                    }
                }
                if (!hasPublication)
                    yield return p;
            }
        }

        public IEnumerable<Paper> GetRecentPapers(int year)
        {
            foreach (Paper p in _publicationList)
            {
                DateTime lastDate = new DateTime(DateTime.Now.Year - year, DateTime.Now.Month, DateTime.Now.Day);
                if (p.publicationDate >= lastDate)
                    yield return p;
            }
        }


        // Task 9
        public IEnumerable<Person> GetPersonWithMoreThanOnePublication()
        {
            foreach (Person p in _researchers)
            {
                int personPublicationsCount = 0;
                foreach (Paper paper in _publicationList)
                {
                    if (paper.author == p)
                    {
                        personPublicationsCount++;
                    }
                }
                if (personPublicationsCount > 1)
                    yield return p;
            }
        }

        // Task 10
        public IEnumerable<Paper> GetLastYearPapers()
        {
            int year = 1;
            foreach (Paper p in _publicationList)
            {
                DateTime lastDate = new DateTime(DateTime.Now.Year - year, DateTime.Now.Month, DateTime.Now.Day);
                if (p.publicationDate >= lastDate)
                    yield return p;
            }
        }

        public IEnumerator GetEnumerator()
        {
            int researchersCount = _researchers.Count;
            int publicationCount = _publicationList.Count;
            Person[] persons = new Person[researchersCount];
            Paper[] papers = new Paper[publicationCount];

            
            for (int i = 0; i < publicationCount; i++)
            {
                Paper curPaper = (Paper)_publicationList[i];
                papers[i] = new Paper(curPaper.title, curPaper.author, curPaper.publicationDate);
            }

            for (int i = 0; i < researchersCount; i++)
            {
                Person curPerson = (Person)_researchers[i];
                persons[i] = new Person(curPerson.name, curPerson.surname, curPerson.birthDate);
            }

            ResearchTeamEnumerator enumerator = new ResearchTeamEnumerator(persons, papers);

            return enumerator;
        }

        public void SortPublicationsByDate()
        {
            _publicationList.Sort();
        }

        public void SortPublicationsByTitle()
        {
            _publicationList.Sort(new PaperComparer.PaperTitleComparer());
        }

        public void SortPublicationsByAuthorSurname()
        {
            _publicationList.Sort(new PaperComparer.PaperAuthorSurnameComparer());
        }

        private class ResearchTeamEnumerator: IEnumerator
        {
            Person[] researchers;
            Paper[] publications;
            int position = -1;
            public ResearchTeamEnumerator(Person[] persons, Paper[] papers)
            {
                this.researchers = persons;
                this.publications = papers;
            }

            public object Current
            {
                get
                {
                    if (position == -1 || position >= researchers.Length)
                        throw new ArgumentException();

                    foreach (Paper p in publications) 
                    {
                        if (p.author == researchers[position])
                            return researchers[position];
                    }
                    return null;
                }
            }

            public bool MoveNext()
            {
                if (position < researchers.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset() => position = -1;

        }
    }
}
