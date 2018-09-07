import java.io.*;
import java.util.Scanner;

public class Tamagotchi{

    File file = new File("food");
    boolean canEat = false;
    Pet pet = new Pet("");

    public void savePetInfo(){
        try(FileWriter fw = new FileWriter("pet.tamagotchi", false)){
            fw.write(pet.name+"\n");
            fw.write(""+pet.hp+"\n");
            fw.write(""+pet.food+"\b");
            fw.flush();
        }catch(IOException e){}
    }

    public Tamagotchi(){
        File petFile = new File("pet.tamagotchi");
        if(!petFile.exists()){
            try {
                petFile.createNewFile();
            }catch(IOException e){}
            Scanner scan = new Scanner(System.in);
            System.out.println("Pet's Name: ");
	    pet = new Pet(scan.nextLine());
        }else{
            loadPetInfo();
        }
        File foodDir = new File("food");
        if(!foodDir.exists()){
            foodDir.mkdir();
        }
    }

    public void loadPetInfo(){
        try{
            BufferedReader r = new BufferedReader(new InputStreamReader(new FileInputStream("pet.tamagotchi")));
            pet.name = r.readLine();
            pet.hp = Float.parseFloat(r.readLine());
            pet.food = Float.parseFloat(r.readLine());
        }catch(Exception ex){}
    }

    public void print(){
        for(int i=0;i<100;i++) System.out.println();
        System.out.println("Press ENTER to eat first file in 'FOOD' directory\n\n");

        System.out.println("Food: ");
        for(int i=0;i<file.list().length;i++)
            System.out.println("--"+file.list()[i]);
        System.out.print("\n\n");
        pet.printInfo();
    }

    public void start(){
        Thread printThread = new Thread(new Runnable(){
            public void run(){
                while(true){
                    //console clear
                    pet.tick();
                    if(canEat) {
                        canEat = false;
                        try {
                            File food = new File("food/" + file.list()[0]);
                            if (food.delete()) pet.food = 10;
                        } catch (Exception e) {
                        }
                    }
                    print();
                    savePetInfo();
                    try{
                        Thread.sleep(100);
                    }catch(Exception e){}
                }
            }
        });

        Thread inputThread = new Thread(new Runnable(){
            public void run(){
                while(true){
                    try{
                        System.in.read();
                        canEat = true;
                    }catch(Exception e){}
                }
            }
        });

        printThread.start();
        inputThread.start();
    }

    public static void main(String[] args){
        Tamagotchi tamagotchi = new Tamagotchi();
        tamagotchi.start();
    }
}
