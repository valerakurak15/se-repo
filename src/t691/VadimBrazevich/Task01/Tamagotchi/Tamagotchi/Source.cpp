#include <iostream>
#include <ctime>
#include <string>
#include <conio.h>
using namespace std;


class Pet {
public:
	string name;
	time_t lastTime;

	int hunger, sleepy;

	Pet() {
		cout << "Name ";
		cin >> name;
		hunger = 100;
		sleepy = 100;
		lastTime = time(NULL);
	}

	~Pet() {
	}
	
	void updateParameters() {
		time_t currentTime = time(NULL);
		int value = currentTime - lastTime;
		if (value == 0) return ;
		updateHunger(value);
		updateSleep(value);
		lastTime = currentTime;
	}

	void updateHunger(int val) {
		hunger -= val / 5;
	}

	void updateSleep(int val) {
		sleepy -= val / 10;
	}

	void printStatus(int val) {
		int roundVal = val / 10;
		for (int i = 0; i < roundVal; i++) {
			cout << "#";
		}
		roundVal = 10 - roundVal;
		for (int i = 0; i < roundVal; i++) {
			cout << "_";
		}

		cout << " " << val << "%\n";
	}

	void feed() { 
		hunger += 30;
		if (hunger > 100) hunger = 100;

	}
	void sleep() {
		sleepy += 30;
		if (sleepy > 100) sleepy = 100;
	}

	bool isAlive() {
		return (sleepy > 0 && hunger > 0);
	}
};




int main() {
	cout << "Welcome!\n";
	Pet pet;
	system("cls");
	while (pet.isAlive()){

		pet.updateParameters();
		cout << "hungry: \t";
		pet.printStatus(pet.hunger);
		cout << "sleepy: \t";
		pet.printStatus(pet.sleepy);
		if (pet.sleepy < 30) cout << "I want to sleep! \n";
		if (pet.hunger < 30) cout << "Feed me! \n";
		cout << "feed: \"q\"\tsleep: \"w\"\nUpdate: \"any key\"\n";
		char a = _getch();
		switch (a) {
		case 'q':
			pet.feed();
			break;
		case 'w':
			pet.sleep();
			break;
		default:
			break;
		}
		

		system("cls");
	}
	cout << "I'm dead!\n";


	system("pause");
	return 0;
}



