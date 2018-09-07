using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace tamagotchi
{

    abstract class Pet
    {
        public enum LifeState { dead, alive, sleep }

        string name;
        double vivacity;
        double mood;
        double satiety;

        public static LifeState lifeState;

        public Pet()
        {
            vivacity = 100.9;
            mood = 100.9;
            satiety = 100.9;
            lifeState = LifeState.alive;
        }

        public string Name { get => name; set => name = value; }
        public double Vivacity { get => vivacity; set => vivacity = value; }
        public double Mood { get => mood; set => mood = value; }
        public double Satiety { get => satiety; set => satiety = value; }




        public abstract void Feed();
        public abstract void Walk();
        public abstract void Life(DateTime time);
        public abstract void Update(TimeSpan time);

        public void Sleep()
        {
            if (lifeState != LifeState.dead)
                if (lifeState == LifeState.alive)
                    lifeState = LifeState.sleep;
                else
                    lifeState = LifeState.alive;
        }
    }
    
    class Cat : Pet
    {

        public Cat(string _name)
        {
            Name = _name;
        }

        public override void Walk()
        {
            Console.WriteLine("Walking");
            Console.Write($"{Name}: ");

            for (int i = 0; i < 15; ++i)
            {
                Console.Write("meow ");
                Thread.Sleep(300);
            }

            Satiety -= 10;
            Mood += 20;
            if (Mood >= 101) Mood = 100.9;
            Vivacity -= 15;
        }

        public override void Feed()
        {
            Console.WriteLine("Feeding");
            Console.Write($"{Name}: ");

            for (int i = 0; i < 15; ++i)
            {
                Console.Write("nyam ");
                Thread.Sleep(300);
            }

            Console.WriteLine();

            Satiety += 15;
            if (Satiety >= 101) Satiety = 100.9;
            Mood += 3;
            if (Mood >= 101) Mood = 100.9;    
        }

        public override void Life(DateTime time)
        {
            Console.WriteLine($"Vivacity: {(int)Vivacity}  Mood: {(int)Mood}  Satiety: {(int)Satiety}");
            if(lifeState != LifeState.sleep)
                Vivacity -= 0.01d * DateTime.Now.Subtract(time).TotalSeconds;
            else
                Vivacity += 0.01d * DateTime.Now.Subtract(time).TotalSeconds;
            if (lifeState != LifeState.sleep)
                Mood -= 0.005d * DateTime.Now.Subtract(time).TotalSeconds;
            Satiety -= 0.02d * DateTime.Now.Subtract(time).TotalSeconds;

            FileStream file = new FileStream("StatSave.txt", FileMode.OpenOrCreate, FileAccess.Write);
            FileStream file2 = new FileStream("PatType.txt", FileMode.OpenOrCreate, FileAccess.Write);
            file.Close();
            file2.Close();

            StreamWriter WriteFiel = new StreamWriter(@"StatSave.txt", false);
            WriteFiel.WriteLine(Vivacity);
            WriteFiel.WriteLine(Mood);
            WriteFiel.WriteLine(Satiety);
            WriteFiel.WriteLine((int)lifeState);
            WriteFiel.Close();

            StreamWriter WriteFiel2 = new StreamWriter(@"PatType.txt", false);
            WriteFiel2.WriteLine("Cat");
            WriteFiel2.Close();


            if (Vivacity < 0 || Mood < 0 || Satiety < 0) lifeState = LifeState.dead;

        }

        public override void Update(TimeSpan time)
        {
            StreamReader read = new StreamReader(@"StatSave.txt");
            Vivacity = Convert.ToDouble(read.ReadLine());
            Mood = Convert.ToDouble(read.ReadLine());
            Satiety = Convert.ToDouble(read.ReadLine());
            switch (Convert.ToInt32(read.ReadLine()))
            {
                case 0: lifeState = LifeState.dead;
                    break;
                case 2: lifeState = LifeState.sleep;
                    break;
            }

            read.Close();

            Vivacity -= 0.01d * time.TotalSeconds;
            Mood -= 0.005d * time.TotalSeconds;
            Satiety -= 0.02d * time.TotalSeconds;
        }

        
    }

    class Program
    {

        static void Time()
        {
            FileStream file = new FileStream("TimeSave.txt", FileMode.OpenOrCreate,FileAccess.Write);
            file.Close();

            while (true)
            {
                DateTime ThDay = DateTime.Now;
                StreamWriter WriteFiel = new StreamWriter(@"TimeSave.txt", false);
       
                WriteFiel.WriteLine(ThDay.Ticks);
                WriteFiel.Close();
                Thread.Sleep(1000);
            }
        }

        static void KeyPress()
        {
           
            while (true)
            {
                if(enabel)
                    action = Console.ReadKey().KeyChar;
            }
        }

        static void NewGameStart(out Pet pet)
        {
            FileStream file = new FileStream("TimeSave.txt", FileMode.Create);
            FileStream file2 = new FileStream("StatSave.txt", FileMode.Create);
            file.Close();
            file2.Close();

            Console.WriteLine("enter your pet's name: ");
            pet = new Cat(Console.ReadLine());

        }

        static void ContinueGame(out Pet pet)
        {
            StreamReader readFile = new StreamReader(@"TimeSave.txt");
            DateTime temp = new DateTime(Convert.ToInt64(readFile.ReadLine()));

            TimeSpan a = DateTime.Now.Subtract(temp);
            readFile.Close();

            FileStream file = new FileStream("PatType.txt", FileMode.OpenOrCreate, FileAccess.Read);
            file.Close();

            StreamReader reader = new StreamReader(@"PatType.txt");
            string temp2 = reader.ReadLine();
            switch (temp2)
            {
                case "Cat": pet = new Cat("1");
                    break;
                default: pet = new Cat("1");
                    break;
            }
            reader.Close();

            pet.Update(a);
        }

        static char action;
        static bool enabel = true;

        static void Main(string[] args)
        {
            Pet cat;

            while (true)
            {

                FileInfo file = new FileInfo(@"StatSave.txt");
                FileInfo file2 = new FileInfo(@"TimeSave.txt");
                if (file.Exists && file2.Exists)
                    ContinueGame(out cat);
                else
                    NewGameStart(out cat);


                Thread TimeThr = new Thread(Time);
                TimeThr.Start();

                Thread KeyThr = new Thread(KeyPress);
                KeyThr.Start();

                DateTime currentTime = DateTime.Now;
                while (Pet.lifeState == Pet.LifeState.alive || Pet.lifeState == Pet.LifeState.sleep)
                {
                    cat.Life(currentTime);
                    if (Pet.lifeState != Pet.LifeState.sleep)
                    {
                        Console.WriteLine("pess 'f' to Feed.");
                        Console.WriteLine("pess 'w' to Walk.");
                        Console.WriteLine("pess 's' to Sleep.");

                        switch (action)
                        {
                            case 'f':
                                enabel = false;
                                cat.Feed();
                                enabel = true;
                                action = 'l';
                                break;
                            case 'w':
                                enabel = false;
                                cat.Walk();
                                enabel = true;
                                action = 'l';
                                break;
                            case 's':
                                cat.Sleep();
                                action = 'l';
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("pess 'a' to awaken.");
                        if (action == 'a') cat.Sleep();
                    }

                    currentTime = DateTime.Now;
                    Thread.Sleep(1000);
                    Console.Clear();

                }

                TimeThr.Abort();
                KeyThr.Abort();
                Console.WriteLine("Your pet is dead");
                if (file.Exists)
                {
                    file.Delete();

                }
                if (file2.Exists)
                {
                    file2.Delete();
                }
                Console.WriteLine("Press any key to start new game");

                Console.ReadKey(false);

                Console.Clear();

            }
        }
    }
}
