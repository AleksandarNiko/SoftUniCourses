
function solve(arr){
    let resultArr=[];
    let sortedArr=arr.sort((a,b)=>a-b);

    while(sortedArr.length!==0){
        resultArr.push(sortedArr.shift());
        resultArr.push(sortedArr.pop());
    }

    return resultArr
}