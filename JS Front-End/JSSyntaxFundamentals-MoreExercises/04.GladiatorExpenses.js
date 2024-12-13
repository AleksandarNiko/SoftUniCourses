
function solve(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let helmetCount = 0;
    let swordCount = 0;
    let shieldCount = 0;
    let armorCount = 0;

    for (let i = 1; i <= lostFights; i++) {
        if (i % 2 === 0) {
            helmetCount++;  
        }
         if (i % 3 === 0) {
            swordCount++;   
        }
         if (i % 6 === 0) {
            shieldCount++;  
        }
    }

    armorCount = Math.floor(shieldCount / 2);

    let totalExpenses = (helmetCount * helmetPrice) + (swordCount * swordPrice) + 
                        (shieldCount * shieldPrice) + (armorCount * armorPrice);

    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);
}

solve(7,
    2,
    3,
    4,
    5
    )