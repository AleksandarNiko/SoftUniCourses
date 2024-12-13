
function solve(startingYield) {
    let totalSpice = 0;
    let days = 0;
    let currentYield = startingYield;

    while (currentYield >= 100) {
        totalSpice += currentYield;  
        days++;                      
        totalSpice -= 26;            
        currentYield -= 10;          
    }

    if (totalSpice >= 26) {
        totalSpice -= 26;
    }

    console.log(days);
    console.log(totalSpice);
}

solve(111)