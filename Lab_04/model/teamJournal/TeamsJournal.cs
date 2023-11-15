using Lab_04.model.team;
using Lab_04.model.teamJournal;

namespace Lab_04.model
{
    class TeamsJournal<Tkey>
    {
        private List<TeamsJournalEntry> _entries = new List<TeamsJournalEntry>();

        public void newEntryForCollection(object source, EventArgs e)
        {
            ResearchTeamsChangedEventArgs<Tkey> args = (ResearchTeamsChangedEventArgs <Tkey>) e ;
            TeamsJournalEntry newEntry = new TeamsJournalEntry(
                    args.collectionTitle,
                    args.eventType,
                    args.changedPropertyName,
                    args.teamTitle
                );
            _entries.Add(newEntry);
        }


        public override string ToString()
        {
            string resultString = "";
            foreach( var entry in _entries ) { 
                resultString += entry.ToString() + '\n';
            }
            return resultString;
        }
    }
}
