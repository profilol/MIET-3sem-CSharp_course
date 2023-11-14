namespace Lab_03
{
    class ResearchTeamCollection<TKey>
    {
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
    }
}
