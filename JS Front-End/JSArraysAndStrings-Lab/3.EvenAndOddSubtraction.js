
function solve(array){
    let evenSum=0;
    let oddSum=0;

    for(let i=0;i<array.length;i++){
        array[i]=Number(array[i]);
        if(array[i]%2==0){
            evenSum+=array[i];
        }
        else{
            oddSum+=array[i];
        }
    }

    console.log(evenSum-oddSum);
}