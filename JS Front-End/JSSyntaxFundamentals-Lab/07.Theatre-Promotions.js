function ticketPrice(typeOfDay, age) {
    let ticketPrices = {
        'Weekday': [12, 18, 12],
        'Weekend': [15, 20, 15],
        'Holiday': [5, 12, 10]
    };

    if (age >= 0 && age <= 18) {
        console.log(ticketPrices[typeOfDay][0] + '$');
    }
    else if (age > 18 && age <= 64) {
        console.log(ticketPrices[typeOfDay][1] + '$');
    }
    else if (age > 64 && age <= 122) {
        console.log(ticketPrices[typeOfDay][2] + '$');
    }
    else {
        console.log('Error!');
    };
}