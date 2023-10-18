using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class ArrayFuncs
    {

        public static void fillOrdinaryArray(ref Paper[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Paper();
            }
        }

        public static void changeTitleOrdinary(ref Paper[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
                arr[i].title = "Ходячий Замок";
        }

        public static void fillRectangleArray(ref Paper[,] arr, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = new Paper();
                }
            }
        }

        public static void changeTitleRectangle(ref Paper[,] arr, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    arr[i,j].title = "Ходячий Замок";
            }
                
        }

        public static Paper[][] createJaggedArray(int size)
        {
            int length = size;
            Random rnd = new Random();
            int arrCount = rnd.Next(1, length);

            Paper[][] resultArray = new Paper[arrCount][];

            for (int i = 0; i < arrCount - 1; i++)
            {
                int curSize = rnd.Next(1, length - (arrCount - i));
                resultArray[i] = new Paper[curSize];
                length -= curSize;
            }

            resultArray[arrCount - 1] = new Paper[length];

            return resultArray;
        }

        public static void fillJaggedArray(ref Paper[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    arr[i][j] = new Paper();
            }
        }

        public static void changeTitleJagged(ref Paper[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    arr[i][j].title = "Ходячий Замок";
            }    
        }

        public static void printJaggedArray(Paper[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i + 1} length: {arr[i].Length}");
                for (int j = 0; j < arr[i].Length; j++)
                    Console.WriteLine(arr[i][j].ToString());
            }
        }
    }
}
