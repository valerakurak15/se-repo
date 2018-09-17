using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tamagochi
{
    
       
    class Pet
    {
        private int counter = 0;
        private bool alive = false;


        int Health = 100;
        int Satiety = 100;
        int Happiness = 100;




        public int getHealth()
        {
            return Health;
        }
        public int getFeed()
        {
            return Satiety;
        }
        public int getPlay()
        {
            return Happiness;
        }



        
        public void Heal()
        {
            alive = true;
            if (Health < 100)
                Health++;
            else if (Health >= 101)
                Health--;
        }

        public void Feed()
        {
            alive = true;
            if (Satiety < 100)
                Satiety++;
            else if (Satiety >= 101)
                Satiety--;
        }

        public void Play()
        {
            alive = true;
            if (Happiness < 100)
                Happiness++;
            else if (Happiness >= 101)
                Happiness--;
        }

        public bool IsAlive()
        {
            return alive;
        }

        public void Died()
        {
            alive = false;
            Console.WriteLine("Я умер!!!");
            Console.ReadKey(true);
        }

        public void MakeAlive()
        {

            alive = true;
            ResetCounter();
            Console.WriteLine("Давай играть!");

        }

        
        public void IncCounter()
        {


            Health--;
            Satiety--;
            Happiness--;

            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine("Я умер!!!");

            }

            if (Satiety <= 0)
            {
                Satiety = 0;
                Console.WriteLine("Я умер!!!");

            }

            if (Happiness <= 0)
            {
                Happiness = 0;
                Console.WriteLine("Я умер от скуки(");

            }
        }

        public void ResetCounter()
        {
            counter = 10;
        }


        public void Update()
        {
            if (alive)
            {
                IncCounter();
            }
        }

        public void Draw(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.WriteLine("Жизни = " + Health);
            Console.WriteLine("Сытость = " + Satiety);
            Console.WriteLine("Настроение = " + Happiness);
        }






    }
}