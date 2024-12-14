
function solve(arr,number){
    let finalArr=[];
    for(let i=0;i<arr.length;i+=number)
        {
            finalArr.push(arr[i])
    }
    return finalArr
}

solve(['5','20','31','4','20'],2)


