#include <iostream>
#include <conio.h>
#include <thread>
#include <windows.h>

using namespace std;

class Tamagochi
{
private:
	string name;
	int health;
	int satiation;
	int mood;

public:
	Tamagochi()
	{
		health = 80;
		satiation = 70;
		mood = 90;
	}
	void death()
	{
		cout << "Âàø ïèòîìåö óìåð\n";
	}
	void feed()
	{
		if (satiation < 100)
		{
			satiation += 5;
			if (satiation > 100)
			{
				satiation = 100;
			}
		}
	}
	void play()
	{
		if (mood < 100)
		{
			mood += 5;
			if (mood > 100)
			{
				mood = 100;
			}
		}
	}
	void heal()
	{
		if (health < 100)
		{
			health += 5;
			if (health > 100)
			{
				health = 100;
			}
		}
	}

	void cheklife()
	{
		if (satiation <= 0 || health <= 0 || mood <= 0)
		{
			death();
			system("pause");
			exit(0);
		}
	}

	void cycle()
	{
		if (name == "Êðîëèê")
		{
			satiation -= 2;
			mood--;
			health--;
		}

		else if (name == "Ïèâî")
		{
			satiation--;
			mood--;
			health -= 2;
		}

		else if (name == "ÊîòÅê")
		{
			satiation--;
			mood--;
			health -= 2;
		}

	}
	void setname(string name1)
	{
		name = name1;
	}
	void condition()
	{
		cout << "Ïîëå÷èòü - q, Ïîèãðàòü - w, Íàêîðìèòü - e (ÈÃÐÀ ÏÐÎÕÎÄÈÒ Â ÁÛÑÒÐÎÌ ÒÅÌÏÅ ÄËß ÍÀÃËßÄÍÎÑÒÈ)\n\n";
		cout << "Çäîðîâüå - " << health << endl;
		cout << "Ñûòîñòü - " << satiation << endl;
		cout << "Íàñòðîåíèå - " << mood << endl;
	}

	void showpet()
	{
		if (name == "Êðîëèê")
		{
			cout << "\n(\\__/)\n(='.'=)\n(')_(')\n";
		}
		if (name == "Ïèâî")
		{
			cout << "\n         ___\n        (...)\n        |...|\n        |...|\n        |...|\n       /....\\ \n      /......\\ \n     |....... |\n     |....... |\n     |  ïèâî  |\n     |....... |\n     (________)\n";
		}
		if (name == "ÊîòÅê")
		{
			cout << "\n/ \_ / \ \n| °s°|\n|""""\_____/|\n|_ | _ | ______)\n| _ | _ | ... | _ | _ |";
		}
	}

	void MainGame()
	{
		condition();
		showpet();
		cycle();
		cheklife();
	}

}Pet;

void Thread()
{
	char temp = 0;
	for (;;)
	{
		temp = _getch();
		if (temp == 'e')
		{
			Pet.feed();
		}
		if (temp == 'q')
		{
			Pet.heal();
		}
		if (temp == 'w')
		{
			Pet.play();
		}
	}
}
