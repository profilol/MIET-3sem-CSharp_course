namespace Lab_05
{
    static class PaperComparer
    {
        public class PaperTitleComparer: IComparer<Paper>
        {
            public int Compare(Paper? p1, Paper? p2)
            {
                if (p1 is null || p2 is null)
                    throw new ArgumentException("Receiving object is null");
                else
                    return p1.title.CompareTo(p2.title);
            }
        }

        public class PaperAuthorSurnameComparer : IComparer<Paper>
        {
            public int Compare(Paper? p1, Paper? p2)
            {
                if (p1 is null || p2 is null)
                    throw new ArgumentException("Receiving object is null");
                else
                    return p1.author.surname.CompareTo(p2.author.surname);
            }
        }
    }
}
