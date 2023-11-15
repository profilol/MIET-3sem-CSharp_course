namespace Lab_04.model.team
{
    class ResearchTeamsChangedEventArgs<Tkey>: EventArgs
    {
        public string collectionTitle;
        public Revision eventType;
        public string changedPropertyName = "";
        public string teamTitle;

        public ResearchTeamsChangedEventArgs(
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
                $"Changed property = {changedPropertyName}" +
                $"Team title = {teamTitle}";

            return resultString;
        }
    }
}
