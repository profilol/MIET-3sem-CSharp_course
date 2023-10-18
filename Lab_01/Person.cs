using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
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

        public override string ToString()
        {
            string resultString;

            resultString = $"[{this._name}, {this._surname}, {this._birthDate}]";
            return resultString;
        }

        virtual public string ToShortString()
        {
            string resultString = $"[{this._name}, {this._surname}]";
            return resultString;
        }
    }
}
