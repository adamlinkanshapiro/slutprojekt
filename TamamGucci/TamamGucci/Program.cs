using System;
using System.Collections.Generic;

namespace TamamGucci
{
    class Program
    {
        static TamamGuchi pet = new TamamGuchi();

        //Här är början av självaste spelet, här skriver man in namnet på sin TamamGuchi och hur gammal den ska vara.
        static void Main(string[] args)
        {



            Console.WriteLine("Hello this is your TamamGucci what name do you have for it?");

            //Här används även pet.name för att framkalla det namnet användaren skrivit in.
            pet.name = Console.ReadLine();

            Console.WriteLine($"the name is {pet.name}, write teach to teach it a word but dont forget to feed and play with it");

            Console.WriteLine($"how old to you want it to be age 1-50");

            //Här används int age = GetAge för att hämta den åldern användaren skrivit in, om 
            //det inte är inom värderna som angivit kommer det upp ett felmeddelande on användaren måste skriva ett nytt.
            //vi gör de här för att det ska vara en rimlig ålder
            int age = GetAge();

            Run();

        }

        static int GetAge()
        {
            //Variabler
            bool success = false;
            bool valid = false;
            int result = 58008;

            while (!success || !valid)
            {
                // Ask the player for a number between 1-50
                string input = Console.ReadLine();

                // Convert string to int. Annars funkar inte koden.
                success = int.TryParse(input, out result);
                if (success) valid = ValidateAge(result);
            }

            // Call the ValidateAge to see if it is in range.
            return result;
        }
        //Validerar ålder mellan 0-50, beroende på det så retunerar vi sant eller falskt.
        //Utan de här kan användaren skriva in en orimlig ålder som 51.
        static bool ValidateAge(int age)
        {

            if (age > 0 && age <= 50)
            {
                Console.WriteLine($"its {age} years old");
                return true;
            }
            else
            {
                Console.WriteLine("that is not a valid age");
                return false;
            }
        }
        //Den här koden innehåller delarna där man interagerar med sin TamamGuchi. När man lär, matar och leker med den.
        static void Run()
        {
            //Den här raden är en whileloop som är ingång när TamamGuchi är levande
            while (pet.GetAlive())
            {
                pet.PrintStats();

                //Det här "state managment" vilket betyder att det är här vi hanterar vad TamamGucci ska göra
                //Switch tar kommandot som motsvarar metoden i tamamguccin.
                switch (Console.ReadLine().ToLower())
                {
                    //Teach är där man lär den nya ord.
                    case "teach":
                        Console.WriteLine("What word?");
                        pet.Teach(Console.ReadLine());
                        break;
                    //Hi är då den säger de nya orden.
                    case "hi":
                        pet.Hi();
                        break;
                    //Feed är när man matar den.
                    case "feed":
                        pet.Feed();
                        break;
                    //De här gör att användaren måste skriva in något som är legitimt.
                    default:
                        Console.WriteLine("Enter a valid command!");
                        break;
                        //Alla dessa gör så att boredom inte går upp så den har ingen speciell kod.
                }
                //Efter varje aktion så tickar vi ner hunger och glädjen.
                pet.Tick();
            }
        }

    }
}
