//author gr0m_off/k4l1n0v5ky

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TamagotchiProgram
{
    class HoholAnimal
    {
        private int counter = 0;
        private bool alive = false;

        int HP = 75;
        int Hunger = 25;
        int Happiness = 80;
 
        public int giveHealth()
        {
            return HP;
        }
        public int giveFood()
        {
            return Hunger;
        }
        public int giveHappy()
        {
            return Happiness;
        }

            public void Heal()
            {
                alive = true;
                if(HP < 50)
                HP++;
            }
 
            public void Feed()
            {
                alive = true;
                if (HP < 50)
                Hunger++;
            }
 
            public void Play()
            {
                alive = true;
                if (HP < 50)
                Happiness++;
            }
                    public bool IsAlive()
                    {
                        return alive;
                    }
 
                    public void Died()
                    {                                            
                        alive = false;
                      //  Console.WriteLine(); Console.WriteLine(); Console.WriteLine("ПОКОЙСЯ С МИРОМб (Х...Х)");
                        Console.ReadKey(true);
                        HP = 65;
                        Hunger = 25;
                        Happiness = 70;                                     
                    }
 
                    public void MakeAlive()
                    {
                        alive = true;
                        ResetCounter();
                        Console.WriteLine(); Console.WriteLine(); Console.WriteLine("ЛЕТС СТАРТ! (*^*)/");                  
                    }                                                                                                                                                     

        public void DecCounter()
        {
            HP--;
            Hunger--;
            Happiness--;
           
           if (HP <= 0)
            {
                HP = 0;
                 Console.WriteLine(); Console.WriteLine("Помiраю хлопцi (Х...Х)");
                 Died();
                 Console.ReadKey(true);
            }
 
           if (Hunger <= 0)
           {
               Hunger = 0;
               Console.WriteLine(); Console.WriteLine("Я вмэр от голодухi (Х_о_Х)");
               Died();
               Console.ReadKey(true);
           }
 
           if (Happiness <= 0)
           {
               Happiness = 0;
               Console.WriteLine(); Console.WriteLine("Умер от скуки.. (>._.<)");
               Died();
               Console.ReadKey(true);
           }       
        }
        public void ResetCounter() 
        {
           //Console.ReadKey(true);
           counter = 15;
           HP = 75;
           Hunger = 25;
           Happiness = 80;
        }
        public void Update()
        {
            if (alive)
            {
                DecCounter();
            }   
        }
        public void Draw(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.WriteLine();
            Console.WriteLine("Здоровье = " + HP); Console.WriteLine();
            Console.WriteLine("Голод = " + Hunger); Console.WriteLine();
            Console.WriteLine("Настроение = " + Happiness); Console.WriteLine(); Console.WriteLine();
        }
                
    }
}
