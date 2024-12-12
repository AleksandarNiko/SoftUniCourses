
function solve(peopleCount,personType,dayType){
    let price=0;

    if(personType=='Students'&& dayType=='Friday'){
    price=8.45;
    }
    if(personType=='Students'&& dayType=='Saturday'){
    price=9.80;
    }
    if(personType=='Students'&& dayType=='Sunday'){
        price=10.46;
    }if(personType=='Business'&& dayType=='Friday'){
        price=10.90;
    }if(personType=='Business'&& dayType=='Saturday'){
        price=15.60;
    }if(personType=='Business'&& dayType=='Sunday'){
        price=16;
    }if(personType=='Regular'&& dayType=='Friday'){
        price=15;
    }if(personType=='Regular'&& dayType=='Saturday'){
        price=20;
    }if(personType=='Regular'&& dayType=='Sunday'){
        price=22.50;
    }

    let finalPrice=peopleCount*price;

    if(personType=='Students' && peopleCount>=30){
        finalPrice=finalPrice-(0.15*finalPrice);
    }
    if(personType=='Business'&& peopleCount>=100){
        finalPrice-=(10*price);
    }
    if(personType=='Regular' && peopleCount>=10 && peopleCount<=20){
        finalPrice=finalPrice-(0.05*finalPrice);
    }

    console.log('Total price: '+ finalPrice.toFixed(2));
}

solve(30,'Students','Sunday')