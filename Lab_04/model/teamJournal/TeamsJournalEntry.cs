namespace Lab_04.model.teamJournal
{
    class TeamsJournalEntry
    {
        public string collectionTitle;
        public Revision eventType;
        public string changedPropertyName = "";
        public string teamTitle;

        public TeamsJournalEntry(
            string collectionTitle,
            Revision eventType,
            string changedPropertyName,
            string teamTitle
            )
        {
            this.collectionTitle = collectionTitle;
            this.eventType = eventType;
            this.changedPropertyName = changedPropertyName;
            this.teamTitle = teamTitle;
        }

        public override string ToString()
        {
            string resultString = $"Collection title = {collectionTitle}\n" +
                $"Event type = {eventType}\n" +
                $"Changed property = {changedPropertyName}\n" +
                $"Team title = {teamTitle}\n\n";

            return resultString;
        }
    }
}
