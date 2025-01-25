
function bitcoinMining(goldMined) {
    const bitcoinPrice = 11949.16;
    const goldPricePerGram = 67.51;
    let totalMoney = 0;
    let totalBitcoins = 0;
    let firstBitcoinDay = 0;

    for (let day = 0; day < goldMined.length; day++) {
        let gold = goldMined[day];

        if ((day + 1) % 3 === 0) {
            gold *= 0.7;
        }

        totalMoney += gold * goldPricePerGram;

        // Check if we can buy bitcoins
        while (totalMoney >= bitcoinPrice) {
            if (totalBitcoins === 0) {
                firstBitcoinDay = day + 1;
            }
            totalBitcoins++;
            totalMoney -= bitcoinPrice;
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoins}`);
    if (totalBitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}

// Example usage:
bitcoinMining([50, 100]);