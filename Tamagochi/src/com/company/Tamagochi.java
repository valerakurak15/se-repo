package com.company;
import java.util.Scanner;

class Tamagochi{
     int Year;
     int Life;
     boolean Death;
     int Food;
     int Energy;
     int Mood;
     Tamagochi(){
         Year = 0;
         Life = 80;
         Death = false;
         Food = 50;
         Energy = 60;
         Mood = 70;
     }
     int eat(){
         Food += 15;
         Energy += 2;
         if (Life <= 95) {
             Life += 5;
         }
         Mood -=5;
         check();
         return menu();
     }
     int sleep(){
         Energy += 30;
         Food -=42;
         if (Life <= 80){
             Life +=20;
         }
         else if(Life > 80 && Life <100)
             Life = 100;

         Mood +=5;
         check();
         Year++;
         return menu();
     }
     int play(){
         Energy -= 30;
         Food -=20;
         Life -=5;
         if (Mood < 70){
             Mood +=30;
         }
         else if(Mood > 70 && Mood < 100)
             Mood = 100;
         check();
         return menu();
     }
     void pause(){
         try {
             Thread.sleep(4000);
         } catch (InterruptedException e) {
             System.err.println(e.getMessage());
         }
     }
     void check(){
         if(Food > 100){
             System.out.println("Too much food");
             badPrint();
             Life -= 10;
             Mood -= 20;
             Food = 50;
             pause();
         }
         else if(Food < 0){
             System.out.println("I'm very HUNGRY!");
             badPrint();
             Life -= 50;
             Mood -= 30;
             pause();
         }

         if(Energy >100){
             System.out.println("Too much energy");
             badPrint();
             Life -= 10;
             Mood -= 10;
             Energy = 70;
             pause();
         }
         else if(Energy < 0){
             System.out.println("*Can't even say something*");
             badPrint();
             Life -= 30;
             Mood -= 20;
             pause();
         }

         if(Mood < 0){
             System.out.println("*Very sad*");
             badPrint();
             Life -= 10;
             Food -= 15;
             Energy -= 20;
             pause();
         }

         if(Life < 0){
             badEnd();
             Death = true;
             menu();
         }
         if(Year > 25) {
             goodEnd();
             Death = true;
             menu();
         }
     }
     void badEnd(){
         System.out.println("\tR.I.P.");
         System.out.println("/)__/)\n" + "(x.x)\n" + "(> <)");

     }
     void goodEnd(){
         System.out.println("\t\t\tHe die in old age");
         System.out.println("\t  --------------------------\n" + "\t|\t\t\t\t\t\t\t |\n" + "   | \t\t\t\t\t\t\t  |");
         System.out.println("  | \t\t\t\t\t\t\t   |\n" + " | \t\t\t\tR.I.P.\t\t\t\t|\n" + " | \t\t\t\t\t\t\t\t\t|");
         System.out.println(" | \t\t\t\t\t\t\t\t\t|\n" + " | \t\tHave i been a good boy?\t\t|");
         System.out.println(" | \t\t\t\t\t\t\t\t\t|\n" + " | \t\t\tYou were the best\t\t|");
         System.out.println(" | \t\t\t\t\t\t\t\t\t|\n" + " | \t\t\t\t\t\t\t\t\t|\n" + " ------------------------------------");
         System.out.println(" &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\n" + " &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\n");
     }
     void badPrint(){
         System.out.println("/)__/)\n" + "(O.o)\n" + "(> <)");
         System.out.println("\n\n");
     }
     void print(){

         System.out.println("Life: " + Life + "\t" + "Food: " + Food + "\t" + "Energy: " + Energy + "\t" + "Mood: " + Mood);
         System.out.println("\t  /)/) \n" + "\t (':'.) \n" + "\t('')('').)");
         System.out.println("1)Eat \t 2)Sleep \t 3)Play");
     }
     int menu(){
         if(Death == true)
             return 1;
         int control;
         print();

         Scanner in = new Scanner(System.in);
         control = in.nextInt();

         System.out.println("\n\n");
         switch (control){
             case 1: eat();
                 break;
             case 2: sleep();
                 break;
             case 3: play();
                 break;
         }
         return 0;
     }

}
