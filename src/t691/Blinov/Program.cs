using System;
using Game;

public class main
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
            Console.WriteLine("Please enter arguments. '<prg_name> -h' for view help list");
        else
        {
            if (args[0] == "-h")
                Console.WriteLine("<prg_name> [-option] or <prg_name> <name_your_pet> <kind_of_your_pet(cat, parrot, dog)> <funcs(eat, walk)>\n~~~~~~~~~OPTIONS~~~~~~~~\n-h - show help list\n");
            else
            {
                ////
                ConfSys.sendHWID();
                Console.WriteLine("Welcome, " + args[0] + ". Kind of your pet: " + args[1]);
                switch (args[1])
                {
                    case "cat":
                        pet Cat = new cat();
                        Console.WriteLine("Last seen: " + Cat.getTimeBetween(Convert.ToDateTime(ConfSys.responseHWIDstring)) + "mins ago.");
                        Cat.checkState(Convert.ToDateTime(ConfSys.responseHWIDstring), args[2]);
                        Console.Write("Health: " + Convert.ToString((Convert.ToInt32(ConfSys.responseHealthString) - Convert.ToInt32(Cat.getTimeBetween(Convert.ToDateTime(ConfSys.responseHWIDstring))))));
                        break;
                    case "dog":
                        pet Dog = new dog();
                        Console.WriteLine("Last seen: " + Dog.getTimeBetween(Convert.ToDateTime(ConfSys.responseHWIDstring)) + "mins ago.");
                        Dog.checkState(Convert.ToDateTime(ConfSys.responseHWIDstring), args[2]);
                        Console.Write("Health: " + Convert.ToString((Convert.ToInt32(ConfSys.responseHealthString) - Convert.ToInt32(Dog.getTimeBetween(Convert.ToDateTime(ConfSys.responseHWIDstring))))));
                        break;
                    case "parrot":
                        pet Parrot = new parrot();
                        Console.WriteLine("Last seen: " + Parrot.getTimeBetween(Convert.ToDateTime(ConfSys.responseHWIDstring)) + "mins ago.");
                        Parrot.checkState(Convert.ToDateTime(ConfSys.responseHWIDstring), args[2]);
                        Console.Write("Health: " + Convert.ToString((Convert.ToInt32(ConfSys.responseHealthString) - Convert.ToInt32(Parrot.getTimeBetween(Convert.ToDateTime(ConfSys.responseHWIDstring))))));
                        break;
                    default: Console.WriteLine("Error choice!."); break;
                }
            }
        }
    }
}