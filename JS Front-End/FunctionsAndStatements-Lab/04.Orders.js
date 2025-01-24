
function solve(foodType,quant) {
    let price=0;
    if (foodType=="water") {
        price=1.00;
    }
    else if(foodType=="coffee"){
        price=1.50;
    }
    else if(foodType=="coke"){
        price=1.40;
    }
    else if(foodType=="snacks"){
        price=2.00;
    }
    console.log(`${(price*quant).toFixed(2)}`);    
}

solve("water", 5)