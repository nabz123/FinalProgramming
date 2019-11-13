using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Millionare
{
    public struct names
    {
        public string fname;
        public string lname;
        public string inter;
    }
    public struct questionare
    {
        public string questions;
        public string a;
        public string b;
        public string c;
        public string d;
        public string ans;
    }
    public struct money
    {
        public string main;
    }
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(160, 40);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            questionare[] answers = new questionare[12];
            money[] rewards = new money[16];
            string[] Chosen = new string[1];
            string[] Finalists = new string[10];
            string[] Finaly = new string[10];
            names[] People = new names[30];
            welcome();
            read(People);
            sort(People);
            readingquestions(answers);
            readingmoney(rewards);
            options();
            menu(People, Finalists, Chosen, answers,rewards);
            Top10(People);
            Console.ReadLine();
        }
        public static void welcome()
        {
            Console.Clear();
            Console.WriteLine("                            ___  _                       _____      _       _            _           _      ");
            Console.WriteLine("                           / __\\ | |                    |  __ \\    | |     | |          | |         (_)     ");
            Console.WriteLine("                          | |  | | |_ __ _  __ _  ___   | |__) |__ | |_   _| |_ ___  ___| |__  _ __  _  ___ ");
            Console.WriteLine("                          | |  | | __/ _` |/ _` |/ _ \\  |  ___/ _ \\| | | | | __/ _ \\/ __| '_ \\| '_ \\| |/ __|");
            Console.WriteLine("                          | |__| | || (_| | (_| | (_) | | |  | (_) | | |_| | ||  __/ (__| | | | | | | | (__ ");
            Console.WriteLine("                           \\____/ \\__\\__,_|\\__, |\\___/  |_|   \\___/|_|\\__, |\\__\\___|\\___|_| |_|_| |_|_|\\___|");
            Console.WriteLine("                                            __/ |                      __/ |                                ");
            Console.WriteLine("                                           |___/                      |___/                                 ");
            Console.WriteLine("");
            Console.WriteLine("                   _____ _   _ _____ __  ___                                     _                                  _   ");
            Console.WriteLine("                  |_   _| \\ | | ____/_ |/ _ \\                      /\\           (_)                                | |  ");
            Console.WriteLine("                    | | |  \\| | |__  | | | | |                    /  \\   ___ ___ _  __ _ _ __  _ __ ___   ___ _ __ | |_ ");
            Console.WriteLine("                    | | | . ` |___ \\ | | | | |                   / /\\ \\ / __/ __| |/ _` | '_ \\| '_ ` _ \\ / _ \\ '_ \\| __|");
            Console.WriteLine("                   _| |_| |\\  |___) || | |_| |                  / ____ \\__ \\__ \\ | (_| | | | | | | | | |  __/| | | |_ ");
            Console.WriteLine("                  |_____|_| \\_|____/ |_|\\___/                  /_/    \\_\\___/___/_|\\__, |_| |_|_| |_| |_|\\___|_| |_|\\__|");
            Console.WriteLine("                                                                                      __/ |                               ");
            Console.WriteLine("                                                                                     |___/                                ");
            Console.WriteLine("");
            Console.WriteLine(" __          ___                                 _         _          _                    __  __ _ _ _ _                   _            ___  ");
            Console.WriteLine(" \\ \\        / / |                               | |       | |        | |                  |  \\/  (_) | (_)                 (_)          |__ \\ ");
            Console.WriteLine("  \\ \\  /\\  / /| |__   ___   __      ____ _ _ __ | |_ ___  | |_ ___   | |__   ___    __ _  | \\  / |_| | |_  ___  _ __   __ _ _ _ __ ___     ) |");
            Console.WriteLine("   \\ \\/  \\/ / | '_ \\ / _ \\  \\ \\ /\\ / / _` | '_ \\| __/ __| | __/ _ \\  | '_ \\ / _ \\  / _` | | |\\/| | | | | |/ _ \\| '_ \\ / _` | | '__/ _ \\   / / ");
            Console.WriteLine("    \\  /\\  /  | | | | (_) |  \\ V  V / (_| | | | | |_\\__ \\ | || (_) | | |_) |  __/ | (_| | | |  | | | | | | (_) | | | | (_| | | | |  __/  |_|  ");
            Console.WriteLine("     \\/  \\/   |_| |_|\\___/    \\_/\\_/ \\__,_|_| |_|\\__|___/  \\__\\___/  |_.__/ \\___|  \\__,_| |_|  |_|_|_|_|_|\\___/|_| |_|\\__,_|_|_|  \\___|  (_)  ");
            Thread.Sleep(1);
            Console.Clear();
        }
        public static void read(names[] People)
        {
            StreamReader sr = new StreamReader(@"millionaire.txt");
            int count = 0;
            while (!sr.EndOfStream)
            {
                People[count].fname = sr.ReadLine();
                People[count].lname = sr.ReadLine();
                People[count].inter = sr.ReadLine();
                count++;
            }
            sr.Close();
        }
        public static void sort(names[] People)
        {
            for (int i = 0; i < People.Length - 1; i++)
            {
                for (int pos = 0; pos < People.Length - 1; pos++)
                {
                    if (People[pos + 1].lname.CompareTo(People[pos].lname) < 0)
                    {
                        names temp = People[pos + 1];
                        People[pos + 1] = People[pos];
                        People[pos] = temp;
                    }
                }
            }
        }
        public static void display(names[] People)
        {
            for (int i = 0; i < People.Length; i++)
            {
                Console.Write($" {People[i].lname.PadRight(30)}");
                Console.Write($"{People[i].fname.PadRight(20)}");
                Console.WriteLine($"{People[i].inter}");
            }
        }
        public static void edit(names[] People)
        {
            bool found = false;
            while (found == false)
            {
                Console.Clear();
                Console.WriteLine("");
                display(People);

                Console.WriteLine("\n Who's interests would you like to change?\n");
                Console.Write(":");
                string edit = Console.ReadLine();
                for (int i = 0; i < People.Length; i++)
                {
                    if (People[i].lname == edit)
                    {
                        Console.WriteLine(" What would you like to change it to?:");
                        People[i].inter = Console.ReadLine();
                        found = true;
                    }
                }
                if (found == false)
                {
                    Console.WriteLine(" Person not found");
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }
        public static void display2(names[] People)
        {
            for (int i = 0; i < People.Length; i++)
            {
                Console.Write($" {People[i].lname.PadRight(30)}");
                Console.Write($"{People[i].fname.PadRight(20)}");
                Console.WriteLine($"{People[i].inter}");
            }
        }
        
        public static void Contestants(names[] People)
        {
            Console.WriteLine("\n These are all your contestants\n");
            display(People);
            Console.WriteLine("\n Press Enter to Exit");
            Console.ReadLine();
        }
        public static void Edit(names[] People)
        {
            Console.WriteLine(" Edit Contestants");
            display(People);
            edit(People);
            display2(People);

            Console.ReadLine();
        }
        public static void Insructions()
        {
            Instructions();
            Console.ReadLine();
        }
        public static void Game(names[] People, string[] Finalists, string[] Chosen, questionare[] answers, money[] rewards)
        {
            //Top1(People, Finalists);
            Console.WriteLine("\n\tThese are your top 10 finalists");
            Top10(People);
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("\n\tAnd your finalist is");
            Top1(People, Finalists);
            //Questions(People, Finalists, Chosen);
            game(People, Finalists, Chosen, answers,rewards);
            Console.ReadLine();
        }
        
        public static void options()
        {
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t\t   1)  Contestants\n");
            Console.WriteLine("\t\t\t\t\t\t   2)  Edit Contestants");
            Console.WriteLine("");       
            Console.WriteLine("\t\t\t\t\t\t   3)  Generate Finalists");
            Console.WriteLine("");       
            Console.WriteLine("\t\t\t\t\t\t   4)  Instructions");
            Console.WriteLine("");       
            Console.WriteLine("\t\t\t\t\t\t   5)  Play Game");
            Console.WriteLine("");       
            Console.WriteLine("\t\t\t\t\t\t   0)  Exit Game");
            Console.Write("\n\t\t\t\t\t\t  :");
        }
        public static void menu(names[] People, string[] Finalists, string[] Chosen, questionare[] answers, money[] rewards)
        {
            int intt, count = 0;
            string temp;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("      __          ___                                 _         _          _                    __  __ _ _ _ _                   _            ___  ");
                Console.WriteLine("      \\ \\        / / |                               | |       | |        | |                  |  \\/  (_) | (_)                 (_)          |__ \\ ");
                Console.WriteLine("       \\ \\  /\\  / /| |__   ___   __      ____ _ _ __ | |_ ___  | |_ ___   | |__   ___    __ _  | \\  / |_| | |_  ___  _ __   __ _ _ _ __ ___     ) |");
                Console.WriteLine("        \\ \\/  \\/ / | '_ \\ / _ \\  \\ \\ /\\ / / _` | '_ \\| __/ __| | __/ _ \\  | '_ \\ / _ \\  / _` | | |\\/| | | | | |/ _ \\| '_ \\ / _` | | '__/ _ \\   / / ");
                Console.WriteLine("         \\  /\\  /  | | | | (_) |  \\ V  V / (_| | | | | |_\\__ \\ | || (_) | | |_) |  __/ | (_| | | |  | | | | | | (_) | | | | (_| | | | |  __/  |_|  ");
                Console.WriteLine("          \\/  \\/   |_| |_|\\___/    \\_/\\_/ \\__,_|_| |_|\\__|___/  \\__\\___/  |_.__/ \\___|  \\__,_| |_|  |_|_|_|_|_|\\___/|_| |_|\\__,_|_|_|  \\___|  (_)  \n\n");
                options();
                temp = Console.ReadLine();
                intt = Convert.ToInt32(temp);
                Console.Clear();
                switch (intt)
                {
                    case 1:
                        Contestants(People);
                        break;
                    case 2:
                        Edit(People);
                        break;
                    case 4:
                        Insructions();
                        break;
                    case 5:
                        game(People, Finalists, Chosen, answers,rewards);
                        break;
                    case 3:
                        GenerateFinalists(People,Finalists);
                        break;
                    case 0:
                        Console.WriteLine("Thank you for playing");
                        Thread.Sleep(2500);
                        Environment.Exit(-1);
                        break;
                    default:
                        break;
                }
            } while (count != 1);
            Console.ReadLine();
        }
        public static void Top1(names[] People, string[] Finalists)
        {
            Random Rand = new Random();
            int[] finalists = new int[1];
            for (int i = 0; i < finalists.Length; i++)
            {
                finalists[i] = -1;
            }
            int lot;
            for (int i = 0; i < finalists.Length; i++)
            {
                lot = Rand.Next(0, 30);
                while (finalists.Contains(lot))
                {
                    lot = Rand.Next(0, 30);
                }
                finalists[i] = lot;
            }
            for (int i = 0; i < finalists.Length; i++)
            {
                Console.WriteLine($"\t{People[finalists[i]].fname} {People[finalists[i]].lname} ");
            }
        }
        public static void Top10(names[] People)
        {
            Random Rand = new Random();
            int[] finalists = new int[10];
            for (int i = 0; i < finalists.Length; i++)
            {
                finalists[i] = -1;
            }
            int lot;
            for (int i = 0; i < finalists.Length; i++)
            {
                lot = Rand.Next(0, 30);
                while (finalists.Contains(lot))
                {
                    lot = Rand.Next(0, 30);
                }
                finalists[i] = lot;
            }
            for (int i = 0; i < finalists.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"\t{People[finalists[i]].fname} {People[finalists[i]].lname} ");
            }
        }
        public static void Instructions()
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("*\tThe rules for this game are simple                                           *");
            Console.WriteLine("*\tTo earn the million dollars you must answer 12 questions.                    *");
            Console.WriteLine("*\tYou will be given a choice to either continue the game or take the money     *");
            Console.WriteLine("*\tthat you have won at the end of question 7                                   *");
            Console.WriteLine("*\tGoodluck                                                                     *");
            Console.WriteLine("**************************************************************************************");
        }

        public static void readingquestions(questionare[] answers)
        {
            StreamReader sr = new StreamReader(@"ques.txt");

            for (int i = 0; i < 12; i++)
            {
                answers[i].questions = sr.ReadLine();
                answers[i].a = sr.ReadLine();
                answers[i].b = sr.ReadLine();
                answers[i].c = sr.ReadLine();
                answers[i].d = sr.ReadLine();
                answers[i].ans = sr.ReadLine();
            }
            sr.Close();
        }
        public static void readingmoney(money[] rewards)
        {
            StreamReader sr = new StreamReader(@"money.txt");
            int count = 0;
            while (!sr.EndOfStream)
            {
                rewards[count].main = sr.ReadLine();
                count++;
            }
            sr.Close();
        }
        public static void GenerateFinalists(names[] People, string[] Finalists)
        {
            Console.WriteLine("\n\tYour top 10 finalists are");
            Top10(People);
            Thread.Sleep(2500);
            Console.Clear();
            Top1(People, Finalists);
            Thread.Sleep(2500);
            Console.Clear();
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
        
        public static void game(names[] People, string[] Finalists, string[] Chosen, questionare[] answers, money[] rewards)
        {
            int count = 0;
            for (int i = 0; i < answers.Length; i++)
            {

                Thread.Sleep(100);
                

                string Uinput;
                Console.Clear();
                //Console.WriteLine(" ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine($" {answers[count].questions}\n ");
                Console.WriteLine($" {answers[count].a}");
                Console.WriteLine($" {answers[count].b}");
                Console.WriteLine($" {answers[count].c}");
                Console.WriteLine($" {answers[count].d}");
                //Console.WriteLine(" └──────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
                Console.Write("\n:");
                Uinput=Console.ReadLine();
                if (Uinput == answers[count].ans)
                {
                    Console.Clear();
                    Console.WriteLine("Correct");
                    Thread.Sleep(1000);
                    count++;
                }
                else
                {
                    Console.WriteLine("That is the wrong answer");
                    Console.WriteLine($"The correct answer was {answers[count].ans}");
                    Console.WriteLine($"You are going home with $ {rewards[i].main}");
                    Thread.Sleep(3000);
                    menu(People, Finalists, Chosen, answers,rewards);
                }
                
            }
        }
    }
}

