package com.company;
import java.lang.String;
import java.util.Scanner;
import java.util.Timer;

public class Main {

    public static boolean state (boolean life, Pet cat) {
        Scanner num = new Scanner(System.in);




        System.out.println("Состояние вашего питомца: ");
        System.out.println("Энергия - " + cat.Energy);
        System.out.println("Голод - " + cat.Hunger);
        System.out.println("Радость - " + cat.Joy);
        System.out.println("Жажда - " + cat.Thirst);
        System.out.println("Что вы хотите сделать с питомцем ? \n 1)Уложить спать \n 2)Покармить \n 3)Выгулять \n 4)Напоить");
        int variant = num.nextInt();
        cat.Var(variant);
        if (cat.Thirst == 0 || cat.Joy == 0 || cat.Hunger == 0 || cat.Energy == 0) {
            System.out.println("Ваш питомец пал на поле брани(");
            life = false;
        }
        return life;
    }

    public static void main(String[] args) {
        boolean life = true;
        Pet cat = new Pet(10, 10, 10, 10);
        while (life == true) {

            state(life, cat);
        }
    }
}
