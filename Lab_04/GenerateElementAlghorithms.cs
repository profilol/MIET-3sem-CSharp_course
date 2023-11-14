namespace Lab_04
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    static class GenerateElementAlghorithms
    {
        public static KeyValuePair<Team, ResearchTeam> GenerateResearchTeam(int j)
        {
            string organization = $"Yandex{10000000-j}";
            organization = $"Yandex{j}";
            int registrationNumber = 12345;
            ResearchTeam certainResearchTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: organization,
                registrationNumber: registrationNumber,
                researchDuration: TimeFrame.Long
                );
            Team certainTeam = new Team(organization: organization,
                registrationNumber: registrationNumber);

            return new KeyValuePair<Team, ResearchTeam>(certainTeam, certainResearchTeam);
        }
    }
}
