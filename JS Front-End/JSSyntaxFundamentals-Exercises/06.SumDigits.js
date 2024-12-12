
function solve(number) {
    const numStr = Math.abs(number).toString();
    let sum = 0;

    for (let i = 0; i < numStr.length; i++) {
        sum += Number(numStr[i]);
    }
    console.log(sum)
}


solve(543)