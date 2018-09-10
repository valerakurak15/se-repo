package com.work.task1;

import java.util.Timer;
import java.util.Scanner;

class Dog extends Pet{

    Dog(String name){
        type = "Собака";
        this.name = name;
        health = 9;
        eat = 90;
        in = new Scanner(System.in);
        write(type, this.name, health, eat);
        timer = new Timer();
        timer.scheduleAtFixedRate(task, 1000, 2000);
    }

    Dog(String type, String name, int health, int eat){
        this.type = "Собака";
        this.name = name;
        this.health = health;
        this.eat = eat;
        in = new Scanner(System.in);
        timer = new Timer();
        timer.scheduleAtFixedRate(task, 1000, 2000);
    }

    public void life(){
        while(health != 0){

            int choose = 0;

            System.out.println("Здоровье: " + health + "  " + "Сытость: " + eat);
            System.out.println("Выберите что требуется сделать с Вашим питомцом: ");
            System.out.println("1. Кормить 2.Выход");
            choose = in.nextInt();

            switch (choose){
                case 1:
                    eat();
                    break;
                case 2:
                    System.exit(0);
                    break;
                default:
                    System.out.println("Выбирите из предложенного!");
            }
        }
    }
}