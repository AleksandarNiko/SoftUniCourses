
function solve(words, sentence){
    const text = words.split(', ');
    const templates = sentence.split(' ');

    for (let i = 0; i < text.length; i++) {
        for (let j = 0; j < templates.length; j++) {
            if (templates[j].includes('*') &&
                templates[j].length === text[i].length) {
                templates[j] = text[i];
            }
        }
    }

    console.log(templates.join(' '));
}