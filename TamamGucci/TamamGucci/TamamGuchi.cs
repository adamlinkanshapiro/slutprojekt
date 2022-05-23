using System;
using System.Collections.Generic;

namespace TamamGucci
{
    public class TamamGuchi
    {
        private int hunger = 0;
        private int boredom = 0;
        private List<string> words = new List<string>();
        private bool isAlive = true;
        private Random generator = new Random();
        public string name = "";


        public void Feed()
        {
            hunger -= 2;
        }

        public void Hi()
        {
            ReduceBoredom();
            Console.WriteLine(words[generator.Next(words.Count)]);
        }

        public void Teach(string word)
        {
            words.Add(word);
            ReduceBoredom();
        }

        public void Tick()
        {
            //Den här koden är skriven så att man ska kunna "förlora"
            if (hunger >= 10 || boredom >= 10) { isAlive = false; return; }
            hunger += 1;
            boredom += 1;
        }

        public void PrintStats()
        {
            //De här gör så att texten är under varandra och inte efter varandra
            Console.WriteLine(
                "Boredom: " + boredom +
                "\nHunger: " + hunger
            );

        }

        public bool GetAlive()
        {
            return this.isAlive;
        }

        private void ReduceBoredom()
        {
            //Här har jag 2 istället för 1 eftersom den inte ska fastna då tick lägger till 1 
            //även om man tar bort 1
            boredom -= 2;
        }



    }
}