
function solve(names){
    let orderedNames=names.sort((a, b) => a.localeCompare(b));
    for(let i=0;i<orderedNames.length;i++){
        console.log(i+1+'.'+orderedNames[i]);
    }
}

solve(['John','Bob','Christina','Ema',])