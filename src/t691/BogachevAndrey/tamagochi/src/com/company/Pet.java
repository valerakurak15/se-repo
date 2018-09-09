package com.company;

import java.util.Timer;
import java.util.TimerTask;

public class Pet {
   public int Hunger , Thirst, Joy, Energy;

    Pet(int a, int b, int c, int d){
        Hunger = a;
        Thirst = b;
        Joy = c;
        Energy = d;
        Timer timer = new Timer();
        timer.scheduleAtFixedRate(task, 1000, 1000);
    }

   public void Var (int variant){
       switch (variant) {
           case 1:
               Energy++;
               System.out.println(Energy);
               break;
           case 2:
               ++Hunger;
               break;
           case 3:
               Joy++;
               break;
           case 4:
               Thirst++;
               break;
           default:
               System.out.println("Выберете из предложенных вариантов!");
               break;
       }

   }

    TimerTask task = new TimerTask() {
        @Override
        public void run() {
            if(Hunger >= 0) {
                Hunger -= 10;
                Energy -= 1;
            }
            else{
                System.out.println("Питомец мертв!");
            }

        };
    };
}
