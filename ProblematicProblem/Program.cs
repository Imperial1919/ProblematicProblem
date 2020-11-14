
using System;
using System.Collections.Generic;
using System.Threading;


namespace ProblematicProblem
{
    class Program
    {


        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string replystart = Console.ReadLine().ToLower();

            switch (replystart)
            {
                case "yes":
                    cont = true;
                    break;

                case "no":
                    cont = false;
                    break;

            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            string userAge1 = Console.ReadLine();
            int userAge = Int32.Parse(userAge1);

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string seeList = Console.ReadLine();
            switch (seeList)
            {
                case "yes":
                    cont = true;


                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    break;

                case "no":
                    Console.WriteLine("Oki! Have a nice one pal!");
                    break;
            }

            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            string addToList = Console.ReadLine().ToLower();
            Console.WriteLine();

            while (addToList == "yes")
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();

                activities.Add(userAddition);

                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                string reply = Console.ReadLine();

                switch (reply)
                {
                    case "yes":
                        addToList = "yes";
                        break;
                    case "no":
                        addToList = "no";
                        break;

                }


            }






            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                string Continue = Console.ReadLine();
                switch (Continue)
                {
                    case "keep":
                        cont = false;
                        Console.WriteLine("Alright, Enjoy Yourself but don't do anything stupid. We don't want You to stain our \n beautiful tiled floor with Your bodily fluids.");
                        break;
                    case "redo":
                        cont = true;
                        break;


                }


            }
        }
    }
}

