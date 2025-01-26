
function wash(commands){
    let soap = 0;

    for (let i = 0; i < commands.length; i++) {
        if(commands[i] === 'soap'){
            soap += 10;
        } else if(commands[i] === 'water'){
            soap =soap+(soap*0.20);
        } else if(commands[i] === 'vacuum cleaner'){
            soap =soap+(soap*0.25);
        } else if(commands[i] === 'mud'){
            soap =soap-(soap*0.10);
        }
    }
    console.log(`The car is ${soap.toFixed(2)}% clean.`);
}

wash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']); // The car is 39.00% clean.