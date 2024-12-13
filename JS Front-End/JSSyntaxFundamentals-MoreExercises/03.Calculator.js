//'+', '-', '/', '*'

function solve(number,operator,number2){
    switch (operator) {
        case '+':
            console.log((number+number2).toFixed(2));           
            break;
            case '-':
                console.log((number-number2).toFixed(2));
                break;
                case '/':
                    console.log((number/number2).toFixed(2));
                    break;
                    case'*':
                    console.log((number*number2).toFixed(2));
        default:
            break;
    }
}

solve(5,'+',10)