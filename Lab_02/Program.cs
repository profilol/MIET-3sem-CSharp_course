namespace Lab_02
{
    internal class Program
    { 

        private static void Task1()
        {
            unsafe
            {
                Team* team1Addr;
                Team* team2Addr;
                Team team1 = new Team("ABCD", 123);
                Team team2 = new Team("ABCD", 123);

                team1Addr = &team1;
                team2Addr = &team2;


                Console.WriteLine("\nTask 1");
                Console.WriteLine("Team 1 addr : " + (ulong)team1Addr);
                Console.WriteLine("Team 1 hashCode : " + team1.GetHashCode());
                Console.WriteLine("Team 1 content : " + team1.ToString());
                Console.WriteLine("Team 2 addr : " + (ulong)team2Addr);
                Console.WriteLine("Team 2 hashCode : " + team2.GetHashCode());
                Console.WriteLine("Team 2 content : " + team2.ToString());
            }
        }

        private static void Task2()
        {
            Console.WriteLine("\nTask 2");
            try
            {
                Team team = new Team("ABCD", -123);
            } catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void Task3()
        {
            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );

            Person person1 = new Person();
            Person person2 = new Person();
            Paper paper1 = new Paper();
            Paper paper2 = new Paper();

            Paper[] newPapers = { paper1, paper2 };
            Person[] newPerson = { person1, person2 };

            certainTeam.AddPapers(newPapers);
            certainTeam.AddMembers(newPerson);


            Console.WriteLine("\nTask 3");
            Console.WriteLine(certainTeam.ToString());
        }

        private static void Task4()
        {
            ResearchTeam researchTeam = new ResearchTeam();

            Console.WriteLine("\nTask 4");
            Console.WriteLine($"registration number = {researchTeam.registrationNumber},\norganization = {researchTeam.organization}");
        }

        private static void Task5()
        {
            ResearchTeam originalTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );
            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2022, 10, 17));
            Paper paper2 = new Paper("Гайд на Брюмастера", person1, new DateTime(2021, 10, 18));
            Paper paper3 = new Paper("Гайд на Брюмастера", person1, new DateTime(2002, 10, 18));
            Paper paper4 = new Paper("Гайд на Брюмастера", person1, new DateTime(2021, 10, 15));

            Person[] newPersons = new Person[] { person1, person2 };
            Paper[] newPapers = new Paper[] { paper1, paper2, paper3 };

            originalTeam.AddMembers(newPersons);
            originalTeam.AddPapers(newPapers);
            ResearchTeam cloneTeam = (ResearchTeam)originalTeam.DeepCopy();

            cloneTeam.organization = "Google";

            Console.WriteLine("\nTask 5");
            Console.WriteLine($"Original team: {originalTeam.ToString()}\nClone Team: {cloneTeam.ToString()}");
        }

        private static void Task6()
        {
            Console.WriteLine("\nTask 6");

            ResearchTeam team = new ResearchTeam();

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper = new Paper("Гайд на Брюмастера", person1, new DateTime(2077, 11, 11));

            Person[] newPersons = new Person[] { person1, person2 };
            Paper[] newPapers = new Paper[] { paper };

            team.AddMembers(newPersons);
            team.AddPapers(newPapers);

            Console.WriteLine("This persons haven't publications:\n");
            foreach (Person p in team.GetResearchersWithoutPublications())
            {
                Console.WriteLine(p.ToString());
            }
        }

        private static void Task7()
        {
            Console.WriteLine("\nTask 7");

            ResearchTeam team = new ResearchTeam();

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2022, 10, 17));
            Paper paper2 = new Paper("Гайд на Брюмастера", person1, new DateTime(2021, 10, 18));
            Paper paper3 = new Paper("Гайд на Брюмастера", person1, new DateTime(2002, 10, 18));
            Paper paper4 = new Paper("Гайд на Брюмастера", person1, new DateTime(2021, 10, 15));

            Person[] newPersons = new Person[] { person1, person2 };
            Paper[] newPapers = new Paper[] { paper1, paper2, paper3 };

            team.AddMembers(newPersons);
            team.AddPapers(newPapers);
            int yearsOfPublications = 2;

            Console.WriteLine($"This persons have publications for last {yearsOfPublications} years:\n");
            foreach (Paper p in team.GetRecentPapers(yearsOfPublications))
            {
                Console.WriteLine(p.ToString());
            }
        }
        private static void Task8()
        {
            Console.WriteLine("\nTask 8");

            ResearchTeam team = new ResearchTeam();

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper = new Paper("Гайд на Брюмастера", person1, new DateTime(2077, 11, 11));

            Person[] newPersons = new Person[] { person1, person2 };
            Paper[] newPapers = new Paper[] { paper };

            team.AddMembers(newPersons);
            team.AddPapers(newPapers);

            Console.WriteLine("This persons have publications:\n");
            foreach (Person p in team)
            {
                if (p is null)
                {

                }
                else
                    Console.WriteLine(p.ToString());
            }
        }

        private static void Task9()
        {
            Console.WriteLine("\nTask 9");

            ResearchTeam team = new ResearchTeam();

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();
            Person person3 = new Person("Егор", "Сурков", new DateTime(1990, 10, 07));


            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2077, 11, 11));
            Paper paper2 = new Paper("Гайд на рапиру", person3, new DateTime(2077, 11, 11));
            Paper paper3 = new Paper("Гайд на эгиду", person3, new DateTime(2077, 11, 11));

            Person[] newPersons = new Person[] { person1, person2, person3 };
            Paper[] newPapers = new Paper[] { paper1, paper2, paper3 };

            team.AddMembers(newPersons);
            team.AddPapers(newPapers);

            Console.WriteLine("This persons have more than one publications:\n");
            foreach (Person p in team.GetPersonWithMoreThanOnePublication())
            {
                Console.WriteLine(p.ToString());
            }
        }

        private static void Task10()
        {
            Console.WriteLine("\nTask 10");

            ResearchTeam team = new ResearchTeam();

            Person person1 = new Person("Ярослав", "Кузнецов", new DateTime(1990, 10, 07));
            Person person2 = new Person();

            Paper paper1 = new Paper("Гайд на Брюмастера", person1, new DateTime(2022, 10, 19));
            Paper paper2 = new Paper("Гайд на Брюмастера", person1, new DateTime(2021, 10, 18));
            Paper paper3 = new Paper("Гайд на Брюмастера", person1, new DateTime(2002, 10, 18));
            Paper paper4 = new Paper("Гайд на Брюмастера", person1, new DateTime(2021, 10, 15));

            Person[] newPersons = new Person[] { person1, person2 };
            Paper[] newPapers = new Paper[] { paper1, paper2, paper3, paper4 };

            team.AddMembers(newPersons);
            team.AddPapers(newPapers);

            Console.WriteLine($"This persons have publications for last year:\n");
            foreach (Paper p in team.GetLastYearPapers())
            {
                Console.WriteLine(p.ToString());
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1 - launch Task1");
            Console.WriteLine("2 - launch Task2");
            Console.WriteLine("3 - launch Task3");
            Console.WriteLine("4 - launch Task4");
            Console.WriteLine("5 - launch Task5");
            Console.WriteLine("6 - launch Task6");
            Console.WriteLine("7 - launch Task7");
            Console.WriteLine("8 - launch Task8");
            Console.WriteLine("9 - launch Task9");
            Console.WriteLine("10 - launch Task10");
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
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    case 8:
                        Task8();
                        break;
                    case 9:
                        Task9();
                        break;
                    case 10:
                        Task10();
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