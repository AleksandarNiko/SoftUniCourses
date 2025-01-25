function pyramidResources(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;
    let gold = 0;
    let height = 0;

    let currentBase = base;
    let step = 1;

    while (currentBase > 2) {
        let outerLayer = (currentBase * 4) - 4;
        let innerLayer = (currentBase - 2) * (currentBase - 2);

        if (step % 5 === 0) {
            lapisLazuli += outerLayer * increment;
        } else {
            marble += outerLayer * increment;
        }

        stone += innerLayer * increment;
        currentBase -= 2;
        height += increment;
        step++;
    }

    gold = (currentBase * currentBase) * increment;
    height += increment;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(height)}`);
}

// Example usage:
pyramidResources(11, 1);
//pyramidResources(11, 0.75);
//pyramidResources(12, 1);
//pyramidResources(23, 0.5);