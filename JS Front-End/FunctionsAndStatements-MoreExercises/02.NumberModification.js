
function modifyNumber(num) {
    let numStr = num.toString();

    function getAverageOfDigits(number) {
        let sum = 0;
        for (let digit of number) {
            sum += Number(digit);
        }
        return sum / number.length;
    }

    while (getAverageOfDigits(numStr) <= 5) {
        numStr += '9';
    }

    console.log(numStr);
}

modifyNumber(5835); 
modifyNumber(123);  