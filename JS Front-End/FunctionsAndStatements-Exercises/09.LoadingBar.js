
function loading(number) {
    let result = '';
    for (let i = 0; i < 10; i++) {
        if (i < number / 10) {
            result += '%';
        } else {
            result += '.';
        }      
    }
    if (number < 100) {
        console.log(`${number}% [${result}]`);
        console.log('Still loading...');
    } else {
        console.log('100% Complete!');
        console.log(`[${result}]`);
    }   
}

loading(30);