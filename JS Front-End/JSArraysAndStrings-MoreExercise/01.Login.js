function login(input) {
    let username = input[0];
    let correctPassword = username.split('').reverse().join('');
    let attempts = 0;

    for (let i = 1; i < input.length; i++) {
        let password = input[i];
        attempts++;

        if (password === correctPassword) {
            console.log(`User ${username} logged in.`);
            return;
        } else {
            if (attempts === 4) {
                console.log(`User ${username} blocked!`);
                return;
            } else {
                console.log("Incorrect password. Try again.");
            }
        }
    }
}


login(['Acer', 'login', 'go', 'let me in', 'recA']);