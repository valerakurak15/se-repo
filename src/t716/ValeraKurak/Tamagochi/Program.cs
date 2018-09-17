using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tamagochi
{
    
    class Program
    {

        public static Pet creature = new Pet();

        public static Thread updateLoop = new Thread(Update);

        public static Thread drawLoop = new Thread(Draw);

        public static Thread updateMenu = new Thread(UpdateMenu);


        static ConsoleKeyInfo menuChoice;
        static int Tick = 1;






        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            updateMenu.Start();
            updateLoop.Start();
            drawLoop.Start();


            Console.ReadKey(true);
        }

        #region Menu

        static void DrawMenu()
        {
            if (!creature.IsAlive())
            {
                Console.WriteLine("   P: Играть");
            }
               
            else
            {
                
                Console.WriteLine("   R key: Возродить");
                Console.WriteLine("   K key: Убить");
                Console.WriteLine("   H key: Полечить");
                Console.WriteLine("   F key: Кормить");
                Console.WriteLine("   P key: Играть");
       




            }
                Console.WriteLine("   Q: Выход");
        }
        #endregion

        #region UpdateMenu
        static void UpdateMenu()
        {
            DrawMenu();
            do
            {
                menuChoice = Console.ReadKey(true);

                if (menuChoice.Key == ConsoleKey.R && creature.IsAlive() == true)
                {
                    creature.ResetCounter();
                }
                if (menuChoice.Key == ConsoleKey.K && creature.IsAlive() == true)
                {
                    creature.Died();
                }
                if (menuChoice.Key == ConsoleKey.H && creature.IsAlive() == true)
                {
                    creature.Heal();
                }
                if (menuChoice.Key == ConsoleKey.F && creature.IsAlive() == true)
                {
                    creature.Feed();
                }
                if (menuChoice.Key == ConsoleKey.P && creature.IsAlive() == true)
                {
                    creature.Play();
                }

                if (menuChoice.Key == ConsoleKey.P && creature.IsAlive() == false)
                {
                    creature.MakeAlive();
                }

            } while (menuChoice.Key != ConsoleKey.Q);


            Exit();
        }
        #endregion

        private static void Exit()
        {
            updateLoop.Abort();
            drawLoop.Abort();
        }

        static void Update()
        {
            while (true)
            {
                creature.Update();
                Thread.Sleep(TimeSpan.FromSeconds(Tick));
            }
        }






        static void Draw()
        {
            while (true)
            {
                Console.Clear();
                DrawMenu();
                if (creature.IsAlive())
                {
                    SetCursorColor(ConsoleColor.White);
                }

                


                if (creature.getHealth() < 60)
                {
                    Console.WriteLine("Я болен (");
                }
                else if (creature.getHealth() < 30)
                {
                    Console.WriteLine("Помоги мне!! :(");
                }
                else if (creature.IsAlive())
                {
                    Console.WriteLine("");
                }



                if (creature.getFeed() < 60)
                {
                    Console.WriteLine("Я голодный!");
                }
                else if (creature.getFeed() < 30)
                {
                    Console.WriteLine("Помоги мне! :(");
                }
                else if (creature.IsAlive())
                {
                    Console.WriteLine("");
                }



                if (creature.getPlay() < 60)
                {
                    Console.WriteLine("Я скучаю, давай играть!");
                }
                else if (creature.getPlay() < 20)
                {
                    Console.WriteLine("Ты меня избегаешь? Давай играть!");
                }
                else if (creature.IsAlive())
                {
                    Console.WriteLine("");
                }




                Thread.Sleep(TimeSpan.FromSeconds(Tick));
            }
        }






        private static void SetCursorColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            creature.Draw(20, 15);
        }



        private static void ResetCursorColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}