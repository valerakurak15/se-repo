package com.company;
import java.util.Scanner;
import java.util.Timer;
import java.util.TimerTask;

public class Main {

    static class Pets{
        protected String name;
        protected int hungry = 100;
        protected int energy = 100;
        Scanner in;
        Timer time;
        TimerTask task = new TimerTask() {
            @Override
            public void run() {
                if (hungry>0){
                    hungry-=5;
                    if (hungry<=20){
                        if (energy>0){
                            energy-=5;
                        }
                    }
                }
                else {
                    if (energy>0){
                        energy-=5;
                    }
                    else{
                        System.out.println("ПОТРАЧЕНО \n (Умер от голода и потери сил) \n Начните заново!");
                        general();
                    }
                }
            }
        };

        public void eatkorm(){

            if (hungry >= 100){
                System.out.println("Корм сейчас не к месту! ");
            }
            else {
                hungry+=20;
                if (hungry>100){
                    int tempp = hungry - 100;
                    hungry -= tempp;
                }
                System.out.println("Питомец доволен! \n" +
                        "Сытость: " + hungry );
            }
        }

        public void sleap(){
            int prov = energy+40;
            if (prov>100){
                System.out.println("Ваш(а) " + name + " не хочет спать");
            }
            else{
                energy+=40;
                System.out.println(name + " поспал(a) \n" +
                        "Энергия: " + energy);
            }
        }

        public void eatSalo(){
            int temp = 100 - energy;
            int temp1 = 100 - hungry;
            if (hungry >= 100){
                System.out.println("Сало сейчас не к месту! ");
            }
            else {
                hungry+=temp1;
                energy+=temp;
                System.out.println("Питомец доволен! \n" +
                        "Сытость: " + hungry );
                System.out.println("Запасы сил: " + energy);
            }
        }

        public void eatKapusta(){
            if (hungry>=100){
                System.out.println("Ваш питомец явно не голоден сейчас!");
            }
            else {
                hungry+=10;
                System.out.println(name + " покушал(a) \n" +
                        "Сытость: " + hungry);
            }
        }

        public void datLuley(){

            energy-=10;
            if (energy<=0){
                System.out.println("ПОТРАЧЕНО  \n  Начните заново! \n ");
                general();
            }
            else{
                System.out.println(name + " осознал(a) свою вину :с \n"+
                        "Силы питомца: " + energy);
            }
        }
    }

    static class Cat extends Pets {
        Cat(String name) {
            hungry = 100;
            energy = 100;
        this.name = name;
        in = new Scanner(System.in);
            time = new Timer();
            time.scheduleAtFixedRate(task,1000,2000);
        }

        public void lifecat(){
            boolean catty = true;
            while (catty == true){
                System.out.println("Выберите действие с вашим питомцем: \n 1 - Покормить кормом \n 2 - Покормить капустой \n 3 - Наказать за обоссаные тапки! \n 4 - положить спать \n 5 - Показать состояние питомца (Подсказака: проверяйте чаще) \n 6 - Выход из игры");
                int nyam;
                nyam = in.nextInt();
                switch(nyam){
                    case 1 :
                        eatkorm();
                        break;
                    case 2 :
                        eatKapusta();
                        break;
                    case 3 :
                        datLuley();
                        break;
                    case 4 :
                        sleap();
                        break;
                    case 5 :
                        System.out.println("Энергия " + name + ":  " + energy);
                        System.out.println("Сытость " + name + ":  " + hungry);
                        break;
                    case 6 :
                        System.exit(0);
                        break;
                    default :
                        System.out.println("Ошибка!");
                        break;
                }
            }
        }
    }
    static class Dog extends Pets {
        Dog(String name){
            hungry = 100;
            energy = 100;
            this.name = name;
            in = new Scanner(System.in);
            time = new Timer();
            time.scheduleAtFixedRate(task,1000,2000);
        }
        public void lifedog(){
            boolean sik = true;
            while(sik == true){
                System.out.println("Выберите действие с вашим питомцем: \n 1 - Покормить салом \n 2 - Покормить кормом \n 3 - Дать люлей \n 4 - положить спать \n" + " 5 - Показать состояние питомца (Подсказака: проверяйте чаще) \n 6 - Выход из игры");
                int njam;
                njam = in.nextInt();
                switch(njam){
                    case 1 :
                        eatSalo();
                        break;
                    case 2 :
                        eatkorm();
                        break;
                    case 3 :
                        datLuley();
                        break;
                    case 4 :
                        sleap();
                        break;
                    case 5 :
                        System.out.println("Энергия " + name + ":  " + energy);
                        System.out.println("Сытость " + name + ":  " + hungry);
                        break;
                    case 6 :
                        System.exit(0);
                        break;
                    default:
                        System.out.println("Ошибка!");
                        break;
                }
            }
        }
    }
    public static void general(){
        System.out.println("Добро пожаловать в игру!");
        String name;
        Scanner in = new Scanner(System.in);
        boolean cik = true;
        while(cik == true){
            System.out.println("Сделайте свой выбор: \n 1 - КОТ \n 2 - СОБАКА \n 3 - Выход из игры!" );
            int choose;
            choose = in.nextInt();
            switch(choose){
                case 1 :
                    System.out.println("Введите имя питомца: ");
                    name = in.next();
                    Cat obj = new Cat(name);
                    obj.lifecat();
                    cik = false;
                    break;
                case 2 :
                    System.out.println("Введите имя питомца: ");
                    name = in.next();
                    Dog obje = new Dog(name);
                    obje.lifedog();
                    cik = false;
                    break;
                case 3 :
                    System.exit(0);
                    break;
                default:
                    System.out.println("Ошибка!");
                    break;
            }
        }
    }
    public static void main(String[] args) {
        general();
    }
}
