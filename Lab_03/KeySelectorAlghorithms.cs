namespace Lab_03
{
    delegate TKey KeySelector<TKey>(ResearchTeam rt);

    static class KeySelectorAlghorithms
    {
        private static int rtNum = 0;
        public static int IntHash(ResearchTeam rt) => rt.GetHashCode();

        public static string StringKey(ResearchTeam rt)
        {
            return $"{(rtNum++)} {rt.organization}";
        }
    }
}
