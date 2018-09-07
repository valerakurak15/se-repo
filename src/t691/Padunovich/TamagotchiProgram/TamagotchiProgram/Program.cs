//author gr0m_off/k4l1n0v5ky

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TamagotchiProgram
{
    class Program
    {
        public static HoholAnimal create = new HoholAnimal();
 
        public static Thread updateLoop = new Thread(Update);
 
        public static Thread drawLoop = new Thread(Draw);
 
        public static Thread updateMenu = new Thread(UpdateMenu);
 
        static ConsoleKeyInfo MenCho;

        static double Step1 = 0.5d;
     //   static int Step2 = 2;
   //     static int Step3 = 3;
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
                
                if (!create.IsAlive())
                {
                    Console.WriteLine(" Привет, ты запустил приложение, которое является самым упрощенным представлением Тамагочи, которое только могло быть. \n Однако я всё равно повторю для тебя правила, точнее одно-единственное: \n Если хотя бы один из трех показателей достигнет отметки равной нулю - ты проиграл и игра начинается сначала. \n Приятного времяпровождения! (Работает (!) через жопу) \n");
                    Console.WriteLine("C - НАЧАТЬ ИГРУ");
                    Console.WriteLine("Q - ЗАКРЫТЬ ИГРУ");
                }
                else
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("|            H - Вылечить                     |");
                    Console.WriteLine("|            F - Покормить                    |");
                    Console.WriteLine("|            С - Сыграть                      |");
                    Console.WriteLine("|            K - Усыпить (вернуться в меню)   |");
                    Console.WriteLine("|            Q - ЗАКРЫТЬ ИГРУ                 |");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                
            } 
            #endregion

            #region UpdateMenu
            static void UpdateMenu()
            {
                DrawMenu();
                do
                {
                    MenCho = Console.ReadKey(true);
 
                    if (MenCho.Key == ConsoleKey.K && create.IsAlive() == true)
                    {
                        create.Died();
                    }
                    if (MenCho.Key == ConsoleKey.H && create.IsAlive() == true)
                    {
                        create.Heal();
                    }
                    if (MenCho.Key == ConsoleKey.F && create.IsAlive() == true)
                    {
                        create.Feed();
                    }                                                                                                                                                
                    if (MenCho.Key == ConsoleKey.C && create.IsAlive() == true)
                    {
                        create.Play();                                                        
                    }
                    if (MenCho.Key == ConsoleKey.C && create.IsAlive() == false)
                    {
                        create.MakeAlive();
                    }
 
                } while (MenCho.Key != ConsoleKey.Q);
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
                create.Update();
                Thread.Sleep(TimeSpan.FromSeconds(Step1));
               // Thread.Sleep(TimeSpan.FromSeconds(Step2));
               // Thread.Sleep(TimeSpan.FromSeconds(Step3));
            }
        }

        static void Draw()
        {
            while (true)
            {
                Console.Clear();
                DrawMenu();
                if (create.IsAlive())
                {
                    SetCursorColor(ConsoleColor.Blue);
                }
               
       //Блок состояния Здоровья 
            if (create.giveHealth() < 10)
            {
                Console.WriteLine("HP: Кажется, у меня волчанка '(o_0) ");                              
            }
            else if (create.giveHealth() < 5)                                 
            {
                Console.WriteLine("Помогите! ＼(O_ｏ)／");                                
            }
            else if (create.IsAlive())
            {
                Console.WriteLine("HP: Все нормально (＾-＾)");
            }
       //Блок состояния Голода                      
            if (create.giveFood() < 10)
            {
                Console.WriteLine("Голод: Я проголодался (^-OОО-^)_/");
            }
            else  if (create.giveFood() < 5)
            {
                Console.WriteLine("Помогите! ＼(O_ｏ)／");
            }
            else if (create.IsAlive())
            {
                Console.WriteLine("Голод: Поiв пельменiв (＾-＾)");
            }
        //Блок состояния Настроения
            if (create.giveHappy() < 10)
            {
                Console.WriteLine("Счастье: Может, ты поиграешь со мной?(*-_-)");
            }
            else  if (create.giveHappy() < 5)
            {
                Console.WriteLine("Кажется, я умираю от скуки.. (*-_-) ");
            }
            else if (create.IsAlive())
            {
                Console.WriteLine("Счастье: Весело живем (＾-＾)");
            }
                Thread.Sleep(TimeSpan.FromSeconds(Step1));
            }
        }
 
        //Отдельная отрисовка панели состояния Тамагочи
        private static void SetCursorColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            create.Draw(10, 9); 
        }
    }
}
    
