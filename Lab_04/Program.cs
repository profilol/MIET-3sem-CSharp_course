using Lab_04.model;

namespace Lab_04
{
    internal class Program
    { 
        private static void Task1()
        {
            KeySelector<string> stringSelector = new KeySelector<string>(KeySelectorAlghorithms.StringKey);
            ResearchTeamCollection<string> teamCollection = new ResearchTeamCollection<string>(stringSelector);
            ResearchTeamCollection<string> teamCollection2 = new ResearchTeamCollection<string>(stringSelector);
            teamCollection.collectionTitle = "Дурачки";
            teamCollection2.collectionTitle = "Приколисты";

            TeamsJournal<string> teamsJournal = new TeamsJournal<string>();
            teamCollection.researchTeamsChanged += teamsJournal.newEntryForCollection;
            teamCollection2.researchTeamsChanged += teamsJournal.newEntryForCollection;

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
            teamCollection2.AddResearchTeams(certainTeam, cloneTeam1, cloneTeam2);

            certainTeam.researchDuration = TimeFrame.Year;

            teamCollection.Remove(certainTeam);

            certainTeam.researchDuration = TimeFrame.TwoYears;

            teamCollection.Replace(cloneTeam1, certainTeam);

            cloneTeam1.researchDuration = TimeFrame.Year;
            cloneTeam1.researchDuration = TimeFrame.TwoYears;

            Console.WriteLine("Task 1\n");
            Console.WriteLine(teamsJournal);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1 - launch Task1");
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
                    //case 2:
                        //Task2();
                      //  break;
                    //case 3:
                       // Task3();
                       // break;
                   // case 4:
                     //   Task4();
                       // break;
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