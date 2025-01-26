function processCrystals(input) {
    const targetThickness = input[0];
    const crystals = input.slice(1);

    crystals.forEach(crystal => {
        console.log(`Processing chunk ${crystal} microns`);

        crystal = executeOperation(crystal, 'Cut', (x) => x / 4, targetThickness);
        crystal = executeOperation(crystal, 'Lap', (x) => x * 0.8, targetThickness);
        crystal = executeOperation(crystal, 'Grind', (x) => x - 20, targetThickness);
        crystal = executeOperation(crystal, 'Etch', (x) => x - 2, targetThickness);

        if (crystal + 1 === targetThickness) {
            crystal = executeOperation(crystal, 'X-ray', (x) => x + 1, targetThickness);
        }

        console.log(`Finished crystal ${crystal} microns`);
    });

    function executeOperation(crystal, operation, operationFunc, targetThickness) {
        let count = 0;
        while (operationFunc(crystal) >= targetThickness || (operation === 'Etch' && operationFunc(crystal) + 1 >= targetThickness)) {
            crystal = operationFunc(crystal);
            count++;
        }
        if (count > 0) {
            console.log(`${operation} x${count}`);
            console.log('Transporting and washing');
            crystal = Math.floor(crystal);
        }
        return crystal;
    }
}

// Example usage:
processCrystals([1375, 50000]);