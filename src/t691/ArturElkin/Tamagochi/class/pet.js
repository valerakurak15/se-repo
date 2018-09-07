class Pet {
	constructor(petname) {
		this.petname = petname;
		this.lifes = 50;
		this.mood = 50;
		this.phrases = [
			'Hello, I am ' + this.petname,
			'Go programming!',
			'Did you pass the task?',
			'I am tamagochi',
			'Do you smoke?',
			'Sometimes you can play with me', 
			'You can feed me'
		];
	}

	upLife() {
		if(this.lifes < 100) {
			this.lifes++;
		} else {
			return;
		}
	}

	upMood() {
		if(this.mood < 100) {
			this.mood++;
		} else {
			return;
		}
	}

	sayHello() {
		let randIndex = Math.floor(Math.random() * this.phrases.length);
		alert(this.phrases[randIndex]);
	}
};
