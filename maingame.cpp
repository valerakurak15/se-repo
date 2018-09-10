#include "logic.h"

int main()
{
	setlocale(0, "");
	int choice;
	do {
		system("cls");
		cout << "Для начала игры выберите одного питомца:" << endl;
		cout << "1 - Кролик" << endl;
		cout << "2 - Пиво" << endl;
		cout << "3 - КотЕк" << endl;
		cin >> choice;
	} while (choice != 1 && choice != 2 && choice != 3);

	if (choice == 1)
	{
		Pet.setname("Кролик");
	}
	if (choice == 2)
	{
		Pet.setname("Пиво");
	}
	if (choice == 3)
	{
		Pet.setname("КотЕк");
	}

	system("cls");
	thread MyThred(Thread);
	for (;;)
	{
		Pet.MainGame();
		Sleep(500);
		system("cls");
	}
	return 0;
}
