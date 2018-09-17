using System;
using System.Management;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        PerformanceCounter cpu = new PerformanceCounter();
        cpu.CategoryName = "Сведения о процессоре";
        cpu.CounterName = "% загруженности процессора";
        cpu.InstanceName = "_Total";


        PerformanceCounter ram = new PerformanceCounter();
        ram.CategoryName = "Память";
        ram.CounterName = "% использования выделенной памяти";

        PerformanceCounter ram2 = new PerformanceCounter();
        ram2.CategoryName = "Память";
        ram2.CounterName = "Доступно МБ";

        PerformanceCounter disk = new PerformanceCounter();
        disk.CategoryName = "Физический диск";
        disk.CounterName = "Процент времени бездействия";
        disk.InstanceName = "_Total";

       

       Console.WriteLine(cpu.NextValue());
        
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Загрузка ЦП: " + cpu.NextValue() + "%");
        Console.WriteLine("Используется ОЗУ: " + ram.NextValue() + " %");
        Console.WriteLine("Доступно ОЗУ: " + ram2.NextValue() + " МБ");
        Console.WriteLine("Процент времени бездействия физического диска: " + disk.NextValue() + " %");
        Console.WriteLine("\nНажмите Enter,чтобы увидеть список запущенных процессов");
        Console.ReadKey();

        
        Console.WriteLine("Список запущенных процессов:");
        System.Diagnostics.Process[] proc;
        proc = System.Diagnostics.Process.GetProcesses();
        foreach (System.Diagnostics.Process i in proc)
            Console.WriteLine(i.ProcessName);

        Console.WriteLine("\nНажмите Enter для запуска progressBar");
        Thread flow = Thread.CurrentThread;
        Console.ReadLine();
        

        Console.CursorVisible = false;

        Console.WriteLine("Loading... ");
        
        int pos = Console.CursorTop;
        Console.SetCursorPosition(11, 0);
        
        Console.SetCursorPosition(0, pos);

        var rand = new Random();

        for (int i = 0; i <= 100; i++)
        {
            if (i < 25)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (i < 50)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (i < 75)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (i < 100)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            string pct = string.Format("{0,-30} {1,3}%", new string((char)0x2592, i * 30 / 100), i);
            Console.CursorLeft = 0;
            Console.Write(pct);
            Thread.Sleep(rand.Next(0, 500));
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    static void Print(string message, int delay)
    {
        Thread.Sleep(delay);
        Console.WriteLine(message);
}

        
    
    }
