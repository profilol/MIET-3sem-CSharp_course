namespace Lab_05
{
    [Serializable]
    class Paper: IComparable
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
            Person author = new Person("Ростислав", "Протасеня", birth);
            System.DateTime publicationDate = new DateTime(1989, 10, 2);

            this.title = "Гайд на Земелю";
            this.author = author;
            this.publicationDate = publicationDate;
        }

        public int CompareTo(object? other)
        {
            if (other is Paper paper)
                return publicationDate.CompareTo(paper.publicationDate);
            else
                throw new ArgumentException("Receiving object is not a Paper");
        }

        public override string ToString()
        {
            string resultString;

            resultString = $"[{this.title}, {this.author.ToString()}, {this.publicationDate}]";
            return resultString;
        }
    }
}
