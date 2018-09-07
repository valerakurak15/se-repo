#include <iostream>
#include <stdlib.h>
#include <conio.h>
#include <string>

using namespace std;

class pet
{
protected:
	string name;
	int health;
	int hunger;
	int depression;
	int fatigue;
public:
	pet()
	{
		health = 100;
		hunger = depression = fatigue = 50;
	}
	void setname(string _name)
	{
		name = _name;
	}
	int gethealth()
	{
		return health;
	}

	void feed()
	{
		if (hunger >= 0)
		{
			hunger -= 5;
			depression += 3;
			fatigue += 3;
		}
		if (depression > 100)
		{
			depression = 0;
			health -= 5;
		}
		if (fatigue > 100)
		{
			fatigue = 100;
			health -= 5;
		}
	}
	void play()
	{
		if (depression >= 0)
		{
			hunger += 3;
			depression -= 5;
			fatigue += 3;
		}
		if (hunger > 100)
		{
			hunger = 100;
			health -= 5;
		}
		if (fatigue > 100)
		{
			fatigue = 100;
			health -= 5;
		}
	}
	void putToSleep()
	{
		if (fatigue >= 0)
		{
			hunger += 3;
			depression += 3;
			fatigue -= 5;
		}
		if (hunger > 100)
		{
			hunger = 100;
			health -= 5;
		}
		if (depression > 100)
		{
			depression = 100;
			health -= 5;
		}
	}
	void showStatus()
	{
		cout << "Hunger =" << hunger << endl;
		cout << "Depression = " << depression << endl;
		cout << "Fatigue = " << fatigue << endl;;
	}
};

pet tamagochi;
void main()
{
	system("color F0");
	int choice;
	
	string name;
	cout << "instructions: to feed press z, to play press x, to put to sleep press c, to wait press any key" << endl << "press any key to continue" << endl;
	_getch();
	system("cls");
	cout << "enter name of your pet: ";
	cin >> name;
	bool dead = false;
	int action = 0;
	while (dead = true)
	{
		system("cls");
		if (action == 'z')
		{
			tamagochi.feed();
		}
		if (action == 'x')
		{
			tamagochi.play();
		}
		if (action == 'c')
		{
			tamagochi.putToSleep();
		}
		cout << "Health =" << tamagochi.gethealth() << endl;
		tamagochi.showStatus();
		if (tamagochi.gethealth() <= 0)
		{
			system("cls");
			cout << name << " pogib" << endl;
			system("pause");
			return;
		}
		action = _getch();
	}
	system("pause");
}