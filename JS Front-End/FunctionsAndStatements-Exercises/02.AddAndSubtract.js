function subtract(a, b, c) {
    function sum(a, b) {
        return a + b;
    }

    let sumResult = sum(a, b);
    return sumResult - c;
}

let result = subtract(5, 3, 2); 
console.log(result);