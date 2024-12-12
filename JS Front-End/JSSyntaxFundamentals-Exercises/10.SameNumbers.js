
function solve(number){
    const numStr = Math.abs(number).toString();
    let result = true;
    let firstDigit = numStr[0];
    for (let i=0;i<numStr.length;i++){
        if (numStr[i] !== firstDigit) {
            result = false;}
    }

    let sum = 0;

    for (let i = 0; i < numStr.length; i++) {
        sum += Number(numStr[i]);
    }
    console.log(result);
    console.log(sum);
}

solve(2222222)