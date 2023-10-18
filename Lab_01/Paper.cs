using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    class Paper
    {
        public string title;
        public Person author;
        public System.DateTime publicationDate;


        public Paper(string title, Person author, System.DateTime publicationDate)
        {
            this.title = title;
            this.author = author;
            this.publicationDate = publicationDate;
        }

        public Paper()
        {
            System.DateTime birth = new DateTime(1946, 10, 2);
            Person author = new Person("Станислав", "Лем", birth);
            System.DateTime publicationDate = new DateTime(1989, 10, 2);

            this.title = "Солярис";
            this.author = author;
            this.publicationDate = publicationDate;
        }

        public override string ToString()
        {
            string resultString;

            resultString = $"[{this.title}, {this.author.ToString()}, {this.publicationDate}]";
            return resultString;
        }
    }
}
