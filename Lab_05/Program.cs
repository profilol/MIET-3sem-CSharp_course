namespace Lab_05
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

            ResearchTeam newTeam = certainTeam.DeepSerializeCopy();

            Console.WriteLine(certainTeam);
            Console.WriteLine(newTeam);
        }

        private static void Task2()
        {
            string inputFilename = null;
            Console.WriteLine("Input filename with file format!");
            try
            {
                inputFilename = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("I/O Error!");
                return;
            }
            if (!File.Exists(inputFilename))
            {
                Console.WriteLine("File not exist, creating file...");
                File.Create(inputFilename);
                return;
            }

            ResearchTeam team = new ResearchTeam();
            if (team.Load(inputFilename) == false)
            {
                Console.WriteLine("Fail with file loading");
                return;
            }
            Console.WriteLine("Successful load!");
            Console.WriteLine(team);

            team.AddPublicationFromConsole();

            if (team.Save(inputFilename) == false)
            {
                Console.WriteLine("Error with saving data in file!");
            }

            Console.WriteLine(team);

            if (ResearchTeam.Load(inputFilename, ref team) == false)
            {
                Console.WriteLine("Fail with loading data from file!");
                return;
            }
            team.AddPublicationFromConsole();

            if (ResearchTeam.Save(inputFilename, team) == false)
            {
                Console.WriteLine("Fail with saving data into file!");
                return;
            }

            Console.WriteLine(team);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1 - launch Task1");
            Console.WriteLine("2 - launch Task2");
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