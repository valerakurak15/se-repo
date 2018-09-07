public class Pet{
  String name = "";
	
  float hp = 0, food = 0;

	public Pet(String name){
		this.name = name;
		this.hp = 10.999f;
		this.food = 10.999f;
	}

	public void tick(){
		if(food<=0) hp-=0.05;
		else food-=0.02;
	}

	public void printInfo(){
		if(hp<=0) System.out.println(name+" is dead :(");
		else if(food>8) System.out.println(name);
		else if(food>5) System.out.println("Maybe feed "+name+"?");
		else if(food>1) System.out.println("MAYBE FEED "+name.toUpperCase()+"!?");
		else System.out.println("QUIKLY FEED FILES TO "+name.toUpperCase()+"!!1");
		System.out.print("  HP: ");
		for(int i=0;i<(int)hp;i++) System.out.print("|");
		System.out.print("\nFood: ");
		for(int i=0;i<(int)food;i++) System.out.print("|");
		System.out.println("\n  ___z__z");
		if((int)hp>7)
		System.out.println(" L  o  o\\");
		else if((int)hp>3)
		System.out.println(" L  *  *\\");
		else if((int)hp>0)
		System.out.println(" L  _  _\\");
		else
		System.out.println(" L  x  x\\");
		System.out.println("/|    U  |\\");
		if((int)food>7)
		System.out.println(" |       |");
		else if((int)food>3) 
		System.out.println("  |     | ");
		else
		System.out.println("   \\   / ");
		System.out.println("    / \\");
	}
}
