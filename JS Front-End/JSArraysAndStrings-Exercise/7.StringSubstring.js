
function solve(word, sentence) {
    let wordsArr = sentence.toLowerCase().split(' ');
    let output = `${word} not found!`;

    for (let i = 0; i < wordsArr.length; i++) {
        let currWord = wordsArr[i];
        
        if (currWord === word) {
            output = currWord;
        }
    }

    console.log(output);
}

solve('js','js is the best')