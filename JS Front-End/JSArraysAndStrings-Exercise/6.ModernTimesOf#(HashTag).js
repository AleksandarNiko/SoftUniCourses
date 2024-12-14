
function solve(sentence){
    const regex = /#[A-z]+/g;

    let matches = sentence.match(regex);

    for (const word of matches) {
        console.log(word.substring(1));
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia')