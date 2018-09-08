#include <iostream>
#include <conio.h>
#include <Windows.h>

using namespace std;

class Pet {
public:
	int health = 100,
		satiety = 100,
		mood = 100,
		points = 5;

	int healPet() {
		mood -= 5;
		points -= 5;
		return health += 10;
	}
	int feedPet() {
		mood += 3;
		health += 5;
		return satiety += 5;
	}
	int playPet() {
		points += 2;
		satiety -= 5;
		return mood += 6;
	}
	void menu() {
		int key;
		cout << "1. Feed\n" << "2. Heal\n" << "3. Play\n";
		cin >> key;
		switch(key){
		case 1:
			if (satiety >= 99) {
				cout << "Òhe pet is full" << endl;
				Sleep(2000);
			}
			else
				satiety = feedPet();
			break;
		case 2:
			if (health >= 90) {
				cout << "Your pet is healthy" << endl;
				Sleep(2000);
			}
			else if (points < 5) {
				cout << "You do not have enough points" << endl;
				Sleep(2000);
			}
			else
				healPet();
			break;
		case 3:
			if (mood < 89)
				playPet();
			else

			break;
		}
	}
	bool chekStatus(int _health, int _satiety, int _mood) {
		bool h = true, s = true, m = true, hsm = false; // h - health, s - satiety, m - mood
		if (_health < 20)
			h = false;
		if (_satiety < 30)
			s = false;
		if (_mood < 30)
			m = false;
		if ((h && s && m) == false)
			hsm = false;
		else
			hsm = true;
		return hsm;
	}
	
};

int main() {
	Pet pet;
	while(pet.health > 0) {
		system("cls");
		cout << "Health: " << pet.health << endl;
		cout << "Satiety: " << pet.satiety << endl;
		cout << "Mood: " << pet.mood << endl;
		cout << "Points: " << pet.points << endl;
		cout << "To access the menu, press ESC" << endl;
		if (pet.satiety  == 0) {
			pet.satiety = 0;
			pet.mood -= 3;
			pet.health -= 4;
		}
		else if (pet.mood == 0) {
			pet.mood = 0;
			pet.satiety -= 4;
			pet.health -= 4;
		}
		else if ((pet.satiety && pet.mood) == 0) {
			pet.health -= 10;
		}
		else {
			pet.health -= 3;
			pet.satiety -= 4;
			pet.mood -= 2;
		}
		Sleep(1500);
		if (pet.chekStatus(pet.health, pet.satiety, pet.points) == true) {
			cout << "Your pet is very ill." << endl;
			Sleep(1500);
		}
		if (GetAsyncKeyState(VK_ESCAPE))
			pet.menu();
		
	}
	cout << "Your pet has died." << endl;

	system("pause");
	return 0;
}

