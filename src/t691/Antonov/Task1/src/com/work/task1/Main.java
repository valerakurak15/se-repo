package com.work.task1;
import java.util.Scanner;
import java.io.*;

public class Main {

    static void new_game(){
        String name;
        int choose;
        Scanner in = new Scanner(System.in);

        System.out.println("Выберите тип питомца: ");
        System.out.println("1. Кот \n2. Собака");
        choose = in.nextInt();

        switch (choose){
            case 1:
                System.out.println("Вы выбрали кота!");
                System.out.print("Дайте кличку Вашему питомцу: ");
                name = in.next();
                Cat c = new Cat(name);
                c.life();
                break;
            case 2:
                System.out.println("Вы выбрали собаку!");
                System.out.print("Дайте кличку Вашему питомцу: ");
                name = in.next();
                Dog d = new Dog(name);
                d.life();
                break;
            default:
                System.out.println("Ошибка!");
                break;
        }
    }

    static void continue_game(){

        String type, name;
        int health, eat;

        try(FileReader reader = new FileReader("LifeTime.txt")){
            Scanner in = new Scanner(reader);

            type = in.nextLine();
            name = in.nextLine();
            health = in.nextInt();
            eat = in.nextInt();

            if(health <= 0){
                System.out.println("Нет живых питомцев! Начните заново!");
            }
            else {
                switch (type){
                    case "Кот":
                        Cat c = new Cat(type, name, health, eat);
                        System.out.println("Ваш " + name + " очень Вас заждался!");
                        System.out.println();
                        c.life();
                        break;
                    case "Собака":
                        Dog d = new Dog(type, name, health, eat);
                        System.out.println("Ваш " + name + " очень Вас заждался!");
                        System.out.println();
                        d.life();

                }
                System.out.println(type);
            }
        }
        catch(IOException ex){
            System.out.println(ex.getMessage());
            System.out.println("Начните новою игру.\n");
            start();
        }
    }

    static void start(){
        int choose = 0;
        boolean repeat = true;
        Scanner in = new Scanner(System.in);

        System.out.println("Добро пожаловать в игру! \n1. Новая игра \n2. Продолжить игру \n3. Выход из игры");
        choose = in.nextInt();

        while (repeat == true) {
            switch (choose) {
                case 1:
                    new_game();
                    repeat = false;
                    break;
                case 2:
                    continue_game();
                    repeat = false;
                    break;
                case 3:
                    System.exit(0);
                    break;
                default:
                    System.out.println("Неверно сделан выбор!");
                    break;
            }
        }
    }

    public static void main(String[] args) {
        start();
    }
}
