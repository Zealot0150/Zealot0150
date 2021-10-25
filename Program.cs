using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lexicon
{

    


    interface ITask
    {
        public void Run();
    }

    class Task1 : ITask
    {
        public void Run()
        {
            Console.WriteLine("Hello brave new world");
        }
    }
    class Task2 : ITask
    { 
        public void Run()
        {
            try
            {
                string lastName = "";
                string sureName = "";
                Int16 age = 0;
                Console.WriteLine("Ange förnamn");
                sureName = Console.ReadLine();
                Console.WriteLine("Ange efternamn");
                lastName = Console.ReadLine();
                Console.WriteLine("Ange ålder");
                age = Int16.Parse(Console.ReadLine());
                Console.WriteLine(sureName + " " + lastName + " ålder:" +age);
            }
            catch { Console.WriteLine("Felaktigt värde"); }
        }
    }

    class Task3: ITask 
    {
        public void Run()
        {
            if (Console.ForegroundColor == ConsoleColor.Red)
                Console.ResetColor();
            else
                Console.ForegroundColor = ConsoleColor.Red;
        }
    }
    class Task4 : ITask
    {
        public void Run()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy - MM - dd"));
        
        }
    }


    class Task5 : ITask 
    {
        public void Run()
        {
            try
            {
                Int64 tal1, tal2;
                Console.WriteLine("Ange första talet");
                tal1 = Int64.Parse(Console.ReadLine());
                Console.WriteLine("Ange andra talet");
                tal2 = Int64.Parse(Console.ReadLine());
                if (tal1 < tal2)
                    Console.WriteLine("Tal 2 med värde " + tal2 + " var högst");
                else
                    Console.WriteLine("Tal 1 med värde " + tal1 + " var högst");
            }
            catch { Console.WriteLine("Felaktigt värde angivet"); }
        }
    }


    class Task6 : ITask
    {
        public void Run()
        {

            Int64 num = (new Random()).Next(101);
            Int64 tries = 0;
            Int64 guess = 0;
            try
            {
                while (true)
                {
                    Console.WriteLine("Gissa talet, ange värde mellan noll och hundra");
                    guess =Int64.Parse(Console.ReadLine());
                    tries++;
                    if (num == guess)
                    {
                        Console.WriteLine("Rätt gissat, det tog " + tries + " försök.");
                        break;
                    }
                    else if (num < guess)
                        Console.WriteLine("För högt gissat");
                    else
                        Console.WriteLine("För lågt gissat");
                }
            }
            catch { Console.WriteLine("Felaktigt värde"); }
        }
    }

    
    class Task7 : ITask
    {
        
        public void Run()
        {
            Console.WriteLine("Skriv text som skall sparas på hårddisk!");
            string st = Console.ReadLine();
            System.IO.File.WriteAllTextAsync("WriteText.txt", st);

        }
    }

    class Task8 : ITask
    {

        public void Run()
        {
            try
            {
                Console.WriteLine(System.IO.File.ReadAllText("WriteText.txt"));
            }
            catch { Console.WriteLine("Filen hittades inte, kör val 7 först"); }
        }
    }

    class Task9 : ITask
    {
        public void Run()
        {
            try
            {
                Console.WriteLine("Ange decimaltal");
                double num01 = Convert.ToDouble(Console.ReadLine());
                // num01 = Math.Sqrt(num01); onödligt
                // num01 = Math.Pow(num01, 2); onödigt
                num01 = Math.Pow(num01, 10);
                Console.WriteLine("Det blev "+ num01);
            }
            catch { Console.WriteLine("fel värde"); }
        }
    }

    class Task10 : ITask
    {
        public void Run()
        {
            try
            {
                for (int a = 1; a < 11; a++)
                {
                    for (int b = 1; b < 11; b++)
                    {
                        Console.Write(a * b + "\t"); 
                    }
                    Console.WriteLine("");
                }
            }
            catch { Console.WriteLine("Oväntat fel"); }
        }
    }

    class Task11 : ITask
    {
        int[] bubbelSort(int [] arr)
        {
            int temp;
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            return arr;
        }
        public void Run()
        {
            int[] unsort = new int[10];
            int[] sort = new int[10];

            Random r = new Random(1000);
            for (int i = 0; i < 10; i++)
            {
                int y = r.Next();
                unsort[i] = y;
                sort[i] = y;
            
            }
            sort = bubbelSort(sort);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(unsort[i] + " \t" + sort[i]);
            }
        }
    }

    class Task12 : ITask
    {
        public void Run()
        {
            Console.WriteLine("Ange sträng för att kontrollera Palindrom : ");
            string st = Console.ReadLine();
            string st2 = st;
            string reverse = string.Empty;

            for (int i = st.Length - 1; i >= 0; i--)
            {
                reverse += st[i];
            }
            st = st.ToLower();
            reverse = reverse.ToLower();
            if (st == reverse)
            {
                Console.WriteLine(st2 +  " är ett palidrom");
            }
            else
            {
                Console.WriteLine(st2 +" är inte palidrom");
            }
        }
    }


    class Task13 : ITask
    {
        public void Run()
        {
            Int64 a, b, c;
            try
            {
                Console.WriteLine("Ange det första talet");
                a = Int64.Parse(Console.ReadLine());
                Console.WriteLine("Ange det andra talet");
                b = Int64.Parse(Console.ReadLine());
                
                if (a > b)
                {
                    c = b;
                    b = a;
                    a = c;
                }
                a++;
                while (a < b)
                {
                    Console.WriteLine(a + "");
                    a++;
                }

            }
            catch
            {
                Console.WriteLine("Felaktig inmating");
            }
        }
    }

    class Task14 : ITask
    {
        
        public void Run()
        {
        try
            {
                Console.WriteLine("Ange CSV sträng");
                string st = Console.ReadLine();
                string temp = "";
                List<Int64> lst = new List<Int64>();

                foreach (char s in st)
                {
                    if (Char.IsPunctuation(s))
                    {
                        lst.Add(Int64.Parse(temp));
                        temp = "";
                        continue;
                    }
                    else
                        temp += s;

                }
                lst.Add(Int64.Parse(temp));
                lst.Sort();

                Console.WriteLine("Udda");
                foreach (int i in lst)
                {
                    if (i % 2 != 0)
                        Console.WriteLine(i);
                }
                Console.WriteLine("Jämna");
                foreach (int i in lst)
                {
                    if(i % 2 == 0)
                        Console.WriteLine(i);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Felaktig inmatning");
            }
        }
    }


    class Task15 : ITask
    {

        public void Run()
        {
            try
            {
                Console.WriteLine("Ange CSV sträng");
                string st = Console.ReadLine();
                string temp = "";
                Int64 result = 0;

                foreach (char s in st)
                {
                    if (Char.IsPunctuation(s))
                    {
                        result += Int64.Parse(temp);
                        temp = "";
                        continue;
                    }
                    else
                        temp += s;

                }
                result += Int64.Parse(temp);

                Console.WriteLine("Summan blev:" + result); 
            }
            catch { Console.WriteLine("Felaktig inmating"); 
            }


        }
    }


    class Person 
    {
        static Random r = new Random(100);
        string name;
        int hälsa;   // max 100
        int styrka; // max 100
        int tur; // max 100
        


        public Person(string st) 
        {
            name = st;
            hälsa = r.Next()%100;
            styrka = r.Next()%100;
            tur = r.Next()%100;
        
        }

        override public string ToString()
        {
            return "Namnet är:" + name + "\nStyrkan är:" + styrka + "\nHälsan är:" + hälsa + "\tturen är:" + tur; 
        
        }



    }

    class Task16 : ITask
    {

        public void Run()
        {
            Person motståndare;
            Person Spelare;
            try
            {
                Console.WriteLine("Ange namn på spelare");
                Spelare = new Person(Console.ReadLine());
                Console.WriteLine("Ange namn på motståndare");
                motståndare = new Person(Console.ReadLine());


                Console.WriteLine("\n\nSpelare:\n" + Spelare + "\n\nMotståndare" + motståndare);

            }
            catch{ Console.WriteLine("Felaktig inmating"); }

        }
    }


    class Program
    {
        const string WelcomeText = "Ange vilken uppgift du vill köra";
        const string ErrorMessage = "Ange siffra mellan 1-13 ";


        static void Main(string[] args)

        {
            while(true)
            {
                Console.WriteLine(WelcomeText);
                try
                {
                    object task = Activator.CreateInstance(Type.GetType("Lexicon.Task" + Console.ReadLine()));
                    ((ITask)task).Run();
                }
                catch (Exception e)
                {
                    Console.WriteLine(ErrorMessage);
                }
            }
        }
    }
}
