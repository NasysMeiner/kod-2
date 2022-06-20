using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = "";
            string post1 = "";
            bool isWork = true;
            string userInput = "";
            string[] nameSurName = new string[0];
            string[] post = new string[0];

            while (isWork)
            {
                Console.WriteLine("Выберите пункт.\n1 - добавить досье.\n2 - вывести все досье.\n3 - удалить досье.\n4 - поиск по фамилии.\n5 - выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.D1:     
                        Console.Write("Введите ФИО:");
                        name1 = Console.ReadLine();
                        Console.Clear();

                        Console.Write("Введите должность:");
                        post1 = Console.ReadLine();
                        Console.Clear();

                        addFile(ref nameSurName, ref post, name1, post1);
                        Console.WriteLine($"Вы ввели.\nФио: {name1} и должность: {post1}.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                        SummonFile(nameSurName, post);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D3:
                        DelFile(ref nameSurName, ref post);
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                        Search(nameSurName, post);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.D5:
                        isWork = false;
                        break;
                }
            }
        }

        static void addFile(ref string[] nameSurName, ref string[] post, string name1, string post1)
        {
            string[] newArray = new string[nameSurName.Length + 1];

            for (int i = 0; i < nameSurName.Length; i++)
            {
                newArray[i] = nameSurName[i];
            }

            newArray[newArray.Length - 1] = name1;
            nameSurName = newArray;

            newArray = new string[post.Length + 1];

            for (int i = 0; i < post.Length; i++)
            {
                newArray[i] = post[i];
            }

            newArray[newArray.Length - 1] = post1;
            post = newArray;
        }

        static void SummonFile(string[] nameSurName, string[] post)
        {
            for (int i = 0; i < nameSurName.Length; i++)
            {
                Console.WriteLine($"{nameSurName[i]} - {post[i]}");
            }
        }

        static void DelFile(ref string[] nameSurName, ref string[] post)
        {
            Console.WriteLine("Введите фамилию в досье, которое хотите удалить:");
            string userInput = Console.ReadLine();
            string[] newArray = new string[nameSurName.Length - 1];
            int number = 0;
            int del = 0;

            for(int i = 0; i < nameSurName.Length; i++)
            {
                string[] surName = nameSurName[i].Split(' ');

                for (int j = 0; j < surName.Length; j++)
                {
                    if (surName[j] == userInput)
                    {
                        number = i;
                    }
                }
            }

            for (int i = 0; i < nameSurName.Length; i++)
            {
                if (i == number)
                {
                    continue;
                }                            
                newArray[del] = nameSurName[i];
                del++;
            }

            nameSurName = newArray;
            newArray = new string[post.Length - 1];
            del = 0;

            for (int i = 0; i < post.Length; i++)
            {
                if (i == number)
                {
                    continue;
                }            
                newArray[del] = post[i];
                del++;
            }

            post = newArray;
        }

        static void Search(string[] nameSurName, string[] post)
        {
            Console.WriteLine("Введите фамилию в досье, которое хотите найти:");
            string userInput = Console.ReadLine();
            Console.Clear();
            int number = 0;

            for(int i = 0; i < nameSurName.Length; i++)
            {
                string[] surName = nameSurName[i].Split(' ');

                for (int j = 0; j < surName.Length; j++)
                {
                    if (surName[j] == userInput)
                    {
                        number = i;
                    }
                }
            }

            Console.WriteLine($"Досье которое вы искали:");
            Console.WriteLine($"{nameSurName[number]} - {post[number]}");
        }
    }
}
