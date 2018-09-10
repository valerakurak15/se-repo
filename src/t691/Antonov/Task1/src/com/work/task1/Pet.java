package com.work.task1;

import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;
import java.util.Timer;
import java.util.TimerTask;

abstract class Pet {
    protected String type;
    protected String name;
    protected int health;
    protected int eat;
    Scanner in;
    Timer timer;

    public void write(String type, String name, int health, int eat){
        try(FileWriter writer = new FileWriter("LifeTime.txt"))
        {
            writer.write(type + "\n" + name + "\n" + health + "\n" + eat);

            writer.close();
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
    }

    public void eat(){
        if(eat >= 100){
            System.out.println(name + " сыт!");
            System.out.println();
        }
        else{
            int temp;
            eat += 10;
            if(eat > 100){
                temp = eat - 100;
                eat -= temp;
            }
            System.out.println("Ему было очень вкусно!)");
            System.out.println();
            write(type, name, health, eat);
        }
    }

    TimerTask task = new TimerTask() {
        @Override
        public void run() {
            if(eat > 0){
                eat -= 1;
                write(type, name, health, eat);
            }
            else{
                System.out.println(name + " хочет кушать!");
                health -= 1;
                write(type, name, health, eat);
                if(health <= 0){
                    System.out.println("Питомец мертв!(");
                    write(type, name, health, eat);
                    System.exit(0);
                }
            }
        }
    };
}