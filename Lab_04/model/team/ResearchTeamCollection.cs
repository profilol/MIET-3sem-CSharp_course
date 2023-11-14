using Lab_04.model;
using Lab_04.model.team;
using System.ComponentModel;
using System.Text;

namespace Lab_04
{
    class ResearchTeamCollection<TKey>
    {
        public string collectionTitle;

        public event ResearchTeamsChangedHandler<TKey> researchTeamsChanged;
        public DateTime lastPublication
        {
            get
            {
                DateTime publication = DateTime.MinValue;
                foreach (ResearchTeam team in _teams.Values)
                {
                    if (team.lastPublication.publicationDate > publication)
                    {
                        publication = team.lastPublication.publicationDate;
                    }
                }
                return publication;
            }
        }

        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey,ResearchTeam>>> groupTeamByDuration
        {
            get
            {
                var selectedTeam = from team in _teams
                                   group team by team.Value.researchDuration;
                          
                return selectedTeam;
            }
        }

        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value)
        {
            var selectedTeam = from team in _teams
                               where team.Value.researchDuration == value
                               select team;
            return selectedTeam;
        }

        private Dictionary<TKey, ResearchTeam> _teams = new Dictionary<TKey, ResearchTeam>();
        private KeySelector<TKey> _keySelector;

        private const int DEFAULT_COUNT = 2;

        public ResearchTeamCollection(KeySelector<TKey> keySelector)
        {
            this._keySelector = keySelector;
        }

        public void AddDefaults()
        {
            for (int i = 0; i < DEFAULT_COUNT; i++)
            {
                ResearchTeam curTeam = new ResearchTeam();
                TKey curKey = _keySelector(curTeam);

                _teams.Add(curKey, curTeam);
            }   
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam team in teams)
            {
                TKey curKey = _keySelector(team);
                
                _teams.Add(curKey, team);

                ResearchTeamPropertyChanged(Revision.Property, "teams", team.organization);
                team.PropertyChanged += HandleEvent;
            }
        }

        public override string ToString()
        {
            string resultString = "";

            foreach(TKey key in _teams.Keys)
            {
                ResearchTeam curTeam = _teams[key];
                resultString += $"[Key = {key}, Team: {curTeam}]\n";
            }

            return resultString;
        }

        public string toShortString()
        {
            string resultString = "";

            foreach(TKey key in _teams.Keys)
            {
                ResearchTeam curTeam = _teams[key];
                resultString += $"[Key = {key}, " +
                    $"Team:\ntitle = {curTeam.researchTitle}\n" +
                    $"research duration = {curTeam.researchDuration}\n" +
                    $"researchers count = {curTeam.researchers.Count}\n" +
                    $"publications count = {curTeam.publicationList.Count}]";
            }

            return resultString;
        }

        public bool Remove(ResearchTeam rt)
        {
            TKey curKey = _keySelector(rt);

            if (_teams.Remove(curKey) == false)
                return false;

            ResearchTeamPropertyChanged(Revision.Remove, "teams", rt.organization);
            rt.PropertyChanged -= HandleEvent;

            return true;
        }

        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            TKey oldKey = _keySelector(rtold);
            if (_teams.Remove(oldKey) == false)
                return false;

            TKey newKey = _keySelector(rtnew);
            _teams.Add(newKey, rtnew);

            ResearchTeamPropertyChanged(Revision.Replace, "teams", rtnew.organization);
            rtold.PropertyChanged -= HandleEvent;
            rtnew.PropertyChanged += HandleEvent;
            return true;
        }

        private void HandleEvent(object source, EventArgs e)
        {
            PropertyChangedEventArgs args = (PropertyChangedEventArgs) e;
            ResearchTeam team = (ResearchTeam) source;
            string teamTitle = team.organization;

            ResearchTeamPropertyChanged(Revision.Property, args.PropertyName, teamTitle);
        }

        private void ResearchTeamPropertyChanged(Revision revision, string propertyName, string teamTitle)
        {
            ResearchTeamsChangedEventArgs<TKey> changedArgs = new ResearchTeamsChangedEventArgs<TKey>(collectionTitle, revision, propertyName, teamTitle);
            researchTeamsChanged(this, changedArgs);
        }
    }
}
