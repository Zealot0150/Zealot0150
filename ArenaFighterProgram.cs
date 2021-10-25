using System;
using System.Collections.Generic;

namespace ArenaFighter
{

    public static class constants
    {
        public const int DefaultValue = 100;
    
    }

    class Gear
    {
        static Random r = new Random();
        int CombatValue = 0;
        string Name;
        string[] names = { "Svärd", "Yxa", "kniv" };


        public Gear()
        {
            CombatValue = r.Next() % constants.DefaultValue;
            Name = names[r.Next() % 3];

        }
        public int getCombatvalue()
        { 
            return CombatValue;
        }
        public override string ToString()
        {
            return Name + " stridsvärde " + CombatValue;
        }
    }
    class Character
    {
        static Random r = new Random();
        string name;
        int hälsa;   // max 100
        int styrka; // max 100
        int tur; // max 100
        int Money = 0;
        private List <Gear> gear = new List<Gear>();

        public int getScore()
        {
            int gearPoint = 0;
            for (int i = 0; i < gear.Count; i++)
            {
                gearPoint += gear[i].getCombatvalue();
            }

            return hälsa + styrka + tur + gearPoint;
        }

        public Character(string st)
        {
            name = st;
            hälsa = r.Next() % constants.DefaultValue;
            styrka = r.Next() % constants.DefaultValue;
            tur = r.Next() % constants.DefaultValue;
        }

        public void AddGear(Gear _gear)
        {
            gear.Add(_gear);
        }


        override public string ToString()
        {
            string gearsSum = "";
            for (int i = 0; i < gear.Count; i++)
            {
                gearsSum = gear[i].ToString()+"\n";
            }

            return name + "\nStyrka:" + styrka + "\nHälsa:" + hälsa + "\ntur:" + tur + "\n" + gearsSum;
        }

        public void getPaid(int reward)
        {
            Money += reward;
        }
        public int GetMoney()
        {
            return Money;
        }
        public void Pay(int toPay)
        { 
            Money -= toPay; 
        }
    }


    class Battle
    {
        string[] enemyNames = { "Spindelmannen", "Läderlappen", "Stålmannen", "Robin Hood", "Evil Ed", "Evil Dead", "Saouron", "Zlatan" };
        List<Log> battles = new List<Log>();
        Character user;
        Random r = new Random();


        string GetEnemyName()
        {
            return enemyNames[(new Random().Next()) % enemyNames.Length];
        }

        Boolean Round()
        {
            Character enemy = new Character(GetEnemyName());
            int playerDice = (r.Next() % 6) + 1;
            int enemyDice = (r.Next() % 6) + 1;
            int playerScore = playerDice * user.getScore();
            int enemyScore = enemyDice * enemy.getScore();

            Console.WriteLine("Du möter:" + enemy, ToString());
            Console.WriteLine("Tryck enter för att slaget skall börja");
            Console.ReadLine();
            // Utslag = hälsa, stryka, tur, vapen * dice
            Console.WriteLine("Du fick en:\n" + playerDice + " Med totalpoängen " + playerScore);
            Console.WriteLine("Motståndaren fick:\n" + playerDice + " Med totalpoängen " + enemyScore);
            if (playerScore > enemyScore)
                Console.WriteLine("Grattis Du Vann Slaget!");
            battles.Add(new Log(user, enemy, playerScore, enemyScore));
            return playerScore > enemyScore;
        }

        void BuyWeapon()
        {
            Console.WriteLine("Du har" + user.GetMoney() +"kr ett vapen kostar " + (int)constants.DefaultValue / 2 + " kr");
            if(user.GetMoney()> (int)constants.DefaultValue/2)
            { 
                Console.WriteLine("Du ha råd med ett vapen, vill du köpa ett? Bekräfta med y plus enter");
                if (Console.ReadLine() == "y")
                {
                    Gear g = new Gear();
                    Console.WriteLine(g.ToString());
                    user.AddGear(g);
                    user.Pay((int)(constants.DefaultValue/2));
                }
            }

        }

        void PrintStats()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Du deltog i " + battles.Count + " slag");
            Console.WriteLine("Dessa slag deltog du i:");

            for (int i = 0; i < battles.Count; i++)
            {
                Console.WriteLine("-------Slag " + (i + 1) + "-------");
                Console.WriteLine (battles[i].PrintLog());
            }
        }


        public void StartBattle()
        {
            int reward = 0;
            battles.Clear();
            Console.WriteLine("Hej, välkommen till slagfältet, vad heter du?");
            user = new Character(Console.ReadLine());
            Console.WriteLine("Hej dessa är dina stats:\n" + user.ToString());

            while (true)
            {
                if (!Round())
                {   // snubben dog
                    Console.WriteLine("Du dog tyvärr");
                    break;
                }
                Console.WriteLine("Vill du gå i pension och lämna spelet med livet i behåll? Tryck: y enter, annars bara enter");
                if (Console.ReadLine() == "y")
                    break;
                else
                {
                    reward = r.Next() % constants.DefaultValue;
                    Console.WriteLine("För vinsten fick du:"+ reward + "kr");
                    user.getPaid(reward);
                    BuyWeapon();
                    Console.WriteLine("");
                }
            }
            PrintStats(); 
        }
    }

    class Log
    {
        Character player1;
        Character player2;
        int p1Result;
        int p2Result;
        public Log(Character p1, Character p2, int _p1Result, int _p2Result)
        {
            player1 = p1;
            player2 = p2;
            p1Result = _p1Result;
            p2Result = _p2Result;
        }
      
        public  string PrintLog()
        {
            return
                player1.ToString() +
                "Score: " + p1Result +
                "\nVS\n" + player2.ToString() +
                "Score:" + p2Result;
        }
    }

    class ArenaFighterProgram
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Battle b = new Battle();
                b.StartBattle();
                Console.WriteLine("\n");
            }
        }
    }
}
