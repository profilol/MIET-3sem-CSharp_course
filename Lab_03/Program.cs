namespace Lab_03
{
    internal class Program
    { 

        private static void Task1()
        {
            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2022, 10, 17));
            Paper paper2 = new Paper("Гайд на Витч Доктора", person2, new DateTime(2021, 10, 18));
            Paper paper3 = new Paper("Гайд на Морфа", person1, new DateTime(2002, 10, 18));
            Paper paper4 = new Paper("Гайд на Бару", person2, new DateTime(2021, 10, 15));

            Paper[] newPapers = { paper1, paper2, paper3, paper4 };
            Person[] newPerson = { person1, person2 };

            certainTeam.AddPapers(newPapers);
            certainTeam.AddMembers(newPerson);

            Console.WriteLine("Task 1\n");

            Console.WriteLine("Sorted by publication date:");
            certainTeam.SortPublicationsByDate();
            Console.WriteLine(certainTeam);

            Console.WriteLine("Sorted by publication title:");
            certainTeam.SortPublicationsByTitle();
            Console.WriteLine(certainTeam);

            Console.WriteLine("Sorted by author's surname:");
            certainTeam.SortPublicationsByAuthorSurname();
            Console.WriteLine(certainTeam);
        }

        private static void Task2()
        {
            KeySelector<string> stringSelector = new KeySelector<string>(KeySelectorAlghorithms.StringKey);
            ResearchTeamCollection<string> teamCollection = new ResearchTeamCollection<string>(stringSelector);

            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2022, 10, 17));
            Paper paper2 = new Paper("Гайд на Витч Доктора", person2, new DateTime(2021, 10, 18));
            Paper paper3 = new Paper("Гайд на Морфа", person1, new DateTime(2002, 10, 18));
            Paper paper4 = new Paper("Гайд на Бару", person2, new DateTime(2021, 10, 15));

            Paper[] newPapers = { paper1, paper2, paper3, paper4 };
            Person[] newPerson = { person1, person2 };

            certainTeam.AddPapers(newPapers);
            certainTeam.AddMembers(newPerson);

            ResearchTeam cloneTeam1 = (ResearchTeam)certainTeam.DeepCopy();
            cloneTeam1.organization = "Google";

            ResearchTeam cloneTeam2 = (ResearchTeam)certainTeam.DeepCopy();
            cloneTeam2.organization = "Apple";

            teamCollection.AddResearchTeams(certainTeam, cloneTeam1, cloneTeam2);

            Console.WriteLine("Task 2\n");
            Console.WriteLine(teamCollection);
        }

        private static void Task3()
        {
            KeySelector<string> stringSelector = new KeySelector<string>(KeySelectorAlghorithms.StringKey);
            ResearchTeamCollection<string> teamCollection = new ResearchTeamCollection<string>(stringSelector);

            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2022, 10, 17));
            Paper paper2 = new Paper("Гайд на Витч Доктора", person2, new DateTime(2021, 10, 18));
            Paper paper3 = new Paper("Гайд на Морфа", person1, new DateTime(2002, 10, 18));
            Paper paper4 = new Paper("Гайд на Бару", person2, new DateTime(2021, 10, 15));

            Paper[] newPapers = { paper1, paper2, paper3, paper4 };
            Person[] newPerson = { person1, person2 };

            certainTeam.AddPapers(newPapers);
            certainTeam.AddMembers(newPerson);

            ResearchTeam cloneTeam1 = (ResearchTeam)certainTeam.DeepCopy();
            cloneTeam1.organization = "Google";
            cloneTeam1.researchDuration = TimeFrame.Year;

            ResearchTeam cloneTeam2 = (ResearchTeam)certainTeam.DeepCopy();
            cloneTeam2.organization = "Apple";
            cloneTeam2.researchDuration = TimeFrame.Year;

            teamCollection.AddResearchTeams(certainTeam, cloneTeam1, cloneTeam2);

            Console.WriteLine("Task 3\n");

            Console.WriteLine($"Date of last publication = {teamCollection.lastPublication}");

            var yearTeams = teamCollection.TimeFrameGroup(TimeFrame.Year);
            var twoYearTeams = teamCollection.TimeFrameGroup(TimeFrame.TwoYears);
            var longTeams = teamCollection.TimeFrameGroup(TimeFrame.Long);

            Console.WriteLine("\n\nResearch time Year:\n");

            foreach( var team in yearTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("\n\nResearch time Two Years:\n");

            foreach (var team in twoYearTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("\n\nResearch time Long:\n");

            foreach (var team in longTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("\n\nGroupped teams:\n");

            var grouppedTeams = teamCollection.groupTeamByDuration;

            foreach (var teamDuration in grouppedTeams)
            {
                Console.WriteLine(teamDuration.Key);

                foreach (var team in teamDuration)
                {
                    Console.WriteLine(team);
                }
            }


        }

        private static void Task4()
        {
            bool flag = false;
            int generateSize = -1;
            while (flag != true)
            {
                Console.Write("Input count for generated elements: ");
                string inputMenu = Console.ReadLine();
                try
                {
                    generateSize = Int32.Parse(inputMenu);
                    flag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong generator count input! Try again");
                    flag = false;
                }
                if (generateSize <= 0 && flag == true)
                {
                    Console.WriteLine("Wrong generator count input! Try again");
                    flag = false;
                }
            }
            GenerateElement<Team, ResearchTeam> teamGenerator = new GenerateElement<Team, ResearchTeam>(GenerateElementAlghorithms.GenerateResearchTeam);

            var testCollection = new TestCollections<Team, ResearchTeam>(generateSize, teamGenerator);

            testCollection.MeasureListKeyTime();
            testCollection.MeasureListStringTime();
            testCollection.MeasureDictionaryKeyTime();
            testCollection.MeasureDictionaryStringTime();
            testCollection.MeasureDictionaryStringValueTime();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1 - launch Task1");
            Console.WriteLine("2 - launch Task2");
            Console.WriteLine("3 - launch Task3");
            Console.WriteLine("4 - launch Task4");
            Console.WriteLine("0 - finish program");
        }

        private static void Main(string[] args)
        {
         
            PrintMenu();
            string inputMenu = Console.ReadLine();

            int command = Int32.Parse(inputMenu);
            while(command != 0) {
                switch (command)
                {
                    case 0:
                        break;
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }
                PrintMenu();
                inputMenu = Console.ReadLine();

                command = Int32.Parse(inputMenu);
            
            }
        }
    }
}