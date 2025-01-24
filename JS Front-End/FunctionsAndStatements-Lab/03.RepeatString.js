
function repeatString(word,rep) {
    let newString='';
    for (let i = 0; i < rep; i++) {
           newString+=word;
    }
    console.log(newString);
}

repeatString("abc", 3);