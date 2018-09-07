let pet = new Pet('Tom');

let talkBth = document.getElementById('talk');
talkBth.addEventListener('click', () => pet.sayHello());

let feedBtn = document.getElementById('feed');
feedBtn.addEventListener('click', () => pet.upLife())

let playBtn = document.getElementById('play');
playBtn.addEventListener('click', () => pet.upMood());

let interval = setInterval(function() {
	if(pet.lifes !== 0) {
		pet.lifes--;
		pet.mood--;
		document.getElementById('life').value = pet.lifes;
		document.getElementById('mood').value = pet.mood;
	} else {
		talkBth.style.display = 'none';
		feedBtn.style.display = 'none';
		playBtn.style.display = 'none';
		clearInterval(interval);
		alert('You are bad owner! I died');
	}
}, 1000);