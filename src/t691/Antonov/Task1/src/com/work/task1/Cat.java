package com.work.task1;

import java.util.Scanner;
import java.util.Timer;

class Cat extends Pet{

    Cat(String name){
        type = "Кот";
        this.name = name;
        health = 9;
        eat = 90;
        in = new Scanner(System.in);
        write(type, name, health, eat);
        timer = new Timer();
        timer.scheduleAtFixedRate(task, 1000, 2000);
    }

    Cat(String type, String name, int health, int eat){
        this.type = type;
        this.name = name;
        this.health = health;
        this.eat = eat;
        in = new Scanner(System.in);
        timer = new Timer();
        timer.scheduleAtFixedRate(task, 1000, 2000);
    }

    public void life(){
        while(health != 0){

            int temp = 0;

            System.out.println("Здоровье: " + health + "  " + "Сытость: " + eat);
            System.out.println("Выберите что требуется сделать с Вашим питомцом: ");
            System.out.println("1. Кормить 2.Выход");

            temp = in.nextInt();

            switch (temp){
                case 1: eat();
                    break;
                case 2:
                    System.exit(0);
                default:
                    System.out.println("Ошибка!");
                    break;
            }
        }
    }
}