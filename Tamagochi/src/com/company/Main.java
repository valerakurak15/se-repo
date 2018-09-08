package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        int willPlay = 0;
        Tamagochi Tam = new Tamagochi();
        Tam.menu();
        System.out.println("Would you like to play again?\n" + "1-Yes\t 2-No");
        Scanner in = new Scanner(System.in);
        if ((willPlay = in.nextInt()) == 1) {
            Tam.menu();
        }
    }
}
