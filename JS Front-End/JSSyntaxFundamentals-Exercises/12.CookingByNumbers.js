//the number is a string
function solve(inputNumber,op1,op2,op3,op4,op5){
    let number=Number(inputNumber)
    operator(op1);
    operator(op2);
    operator(op3);
    operator(op4);
    operator(op5);

    function operator(operator){
        if(operator=='chop'){
            number/=2;
        }
        else if(operator=='dice'){
            number=Math.sqrt(number);
        }
        else if(operator=='spice'){
            number+=1;
        }
        else if(operator=='bake'){
            number*=3;
        }
        else if(operator=='fillet'){
            number=number-0.2*number;
        }
        console.log(number);
    }

    //console.log(number);
}

solve(32,'chop','chop','chop','chop','chop')