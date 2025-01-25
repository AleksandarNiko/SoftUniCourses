
function factorialDiv(num1, num2) {
    function factorial(n) {
        let result = 1;
        for (let i = 1; i <= n; i++) {
            result *= i;
        }
        return result;
    }

    let result = factorial(num1) / factorial(num2);
    return result.toFixed(2);
    
}