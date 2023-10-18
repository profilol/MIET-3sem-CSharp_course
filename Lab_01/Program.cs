using System;
using System.Diagnostics;

namespace Lab_01
{
    internal class Program
    { 

        private static void Task1()
        {
            ResearchTeam anotherTeam = new ResearchTeam();

            Console.WriteLine("Task 1");
            Console.WriteLine(anotherTeam.ToShortString());
        }

        private static void Task2()
        {
            ResearchTeam anotherTeam = new ResearchTeam();

            Console.WriteLine("\nTask 2");
            Console.WriteLine("Is time frame = year? : " + anotherTeam[TimeFrame.Year]);
            Console.WriteLine("Is time frame = two years? : " + anotherTeam[TimeFrame.TwoYears]);
            Console.WriteLine("Is time frame = long? : " + anotherTeam[TimeFrame.Long]);
        }

        private static void Task3()
        {
            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );


            Console.WriteLine("\nTask 3");
            Console.WriteLine(certainTeam.ToString());
        }

        private static void Task4()
        {
            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );

            Paper anotherPaper = new Paper();
            Person certainPerson = new Person();
            Paper certainPaper = new Paper(
                title: "Пособие по HOMM3",
                author: certainPerson,
                publicationDate: DateTime.Now
                );
            Paper[] newPapers = new Paper[] { anotherPaper, certainPaper };
            certainTeam.AddPapers(newPapers);


            Console.WriteLine("\nTask 4");
            Console.WriteLine(certainTeam.ToString());
        }

        private static void Task5()
        {
            ResearchTeam certainTeam = new ResearchTeam(
                researchTitle: "Распознование зданий свёрточными сетями",
                organization: "Yandex",
                registrationNumber: 12345,
                researchDuration: TimeFrame.Long
                );
            Paper anotherPaper = new Paper();
            Person certainPerson = new Person();
            Paper certainPaper = new Paper(
                title: "Пособие по HOMM3",
                author: certainPerson,
                publicationDate: DateTime.Now
                );
            Paper[] newPapers = new Paper[] { anotherPaper, certainPaper };
            certainTeam.AddPapers(newPapers);

            Console.WriteLine("\nTask 5");
            Console.WriteLine(certainTeam.lastPublication);
        }

        private static void Task6()
        {
            Console.WriteLine("\nTask 6");
            Console.WriteLine("\nInput nrow and ncolumn, separated by ',', ';', ' '");

            string inputString = Console.ReadLine();


            string[] inputValues = inputString.Split(',', ';', ' ');

            int nrow = Int32.Parse(inputValues[0]);
            int ncolumn = Int32.Parse(inputValues[1]);
            Paper[] ordinaryArray = new Paper[nrow * ncolumn];
            Paper[,] rectangleArray = new Paper[nrow, ncolumn];
            Paper[][] jaggedArray = ArrayFuncs.createJaggedArray(nrow * ncolumn);

            ArrayFuncs.fillOrdinaryArray(ref ordinaryArray);
            ArrayFuncs.fillRectangleArray(ref rectangleArray, nrow, ncolumn);
            ArrayFuncs.fillJaggedArray(ref jaggedArray);

            Console.WriteLine($"Input nrow: {nrow}  Input ncolumn: {ncolumn}");

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            ArrayFuncs.changeTitleOrdinary(ref ordinaryArray);
            sw.Stop();

            Console.WriteLine($"Ordinary array = {sw.ElapsedTicks}");

            sw.Start();
            ArrayFuncs.changeTitleRectangle(ref rectangleArray, nrow, ncolumn);
            sw.Stop();

            Console.WriteLine($"Rectangle array = {sw.ElapsedTicks}");

            sw.Start();
            ArrayFuncs.changeTitleJagged(ref jaggedArray);
            sw.Stop();

            Console.WriteLine($"Jagged array = {sw.ElapsedTicks}");
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n MENU");
            Console.WriteLine("1 - launch Task1");
            Console.WriteLine("2 - launch Task2");
            Console.WriteLine("3 - launch Task3");
            Console.WriteLine("4 - launch Task4");
            Console.WriteLine("5 - launch Task5");
            Console.WriteLine("6 - launch Task6");
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