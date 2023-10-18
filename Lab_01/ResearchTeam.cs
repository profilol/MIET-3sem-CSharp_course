using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    class ResearchTeam
    {
        private string _researchTitle;
        private string _organization;
        private int _registrationNumber;
        private TimeFrame _researchDuration;
        private Paper[] _publicationList = Array.Empty<Paper>();


        public string researchTitle { 
            get { return _researchTitle; }
            set { _researchTitle = value; }
        }

        public string organization
        {
            get { return _organization; }
            set { _organization = value; }
        }

        public int registrationNumber
        {
            get { return _registrationNumber; }
            set { _registrationNumber = value; }
        }

        public TimeFrame researchDuration
        {
            get { return _researchDuration; }
            set { _researchDuration = value; }
        }

        public Paper[] publicationList
        {
            get { return _publicationList; }
            set { _publicationList = value; }
        }

        //public Paper lastPublicationRef = null;
        public Paper lastPublication
        {
            get
            {
                Paper returnVal;
                int publicationsCount = _publicationList.Length;

                if (publicationsCount == 0) 
                { 
                    returnVal = null;
                } else
                {
                    int index = 0;
                    DateTime maxPublicationDate = DateTime.MinValue;
                    for (int i = 0; i < _publicationList.Length; i++)
                    {
                        if (_publicationList[i].publicationDate > maxPublicationDate)
                        {
                            maxPublicationDate = _publicationList[i].publicationDate;
                            index = i;
                        }
                    }
                    returnVal = _publicationList[index];
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

        public ResearchTeam(
            string researchTitle,
            string organization,
            int registrationNumber,
            TimeFrame researchDuration) 
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
            int oldSize = this._publicationList.Length;
            int addingSize = newPapers.Length;
            int newListSize = oldSize + addingSize;
            Paper[] newPublication = new Paper[newListSize];

            for (int i = 0; i < oldSize; i++)
            {
                newPublication[i] = this._publicationList[i];
            }

            for (int i = 0; i < addingSize; i++)
            {
                newPublication[oldSize + i] = newPapers[i];
            }

            this._publicationList = newPublication;
        }

        override public string ToString()
        {
            string resultString;

            if (this._publicationList.Length == 0)
                resultString = $"[{this._researchTitle}, {this._organization}, {this._registrationNumber}, {this._researchDuration}, [] ]";
            else
            {
                resultString = $"[{this._researchTitle}, {this._organization}, {this._registrationNumber}, {this._researchDuration}, \n[\n";
                
                foreach(Paper p in this._publicationList)
                {
                    resultString += p.ToString();
                    resultString += ",\n";
                }
                resultString += "]";
            }
                
            return resultString;
        }

        virtual public string ToShortString()
        {
            string resultString;

            resultString = $"[{this._researchTitle}, {this._organization}, {this._registrationNumber}, {this._researchDuration}]";
            return resultString;
        }
    }
}
