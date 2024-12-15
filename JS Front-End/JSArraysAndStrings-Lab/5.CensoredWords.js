function solve(text, word) {
    console.log(text.replace(new RegExp(word, 'g'), '*'.repeat(word.length)));
}

solve('Find the hidden word', 'hidden')