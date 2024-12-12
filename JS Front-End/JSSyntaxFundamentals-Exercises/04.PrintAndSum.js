
function solve(start,end){
    let sum=0;
    let nums='';
    for(let i=start;i<=end;i++){
        nums += i + ' ';
        sum+=i;       
    }
    console.log(nums);
    console.log('Sum: '+sum);
}
solve(5,10);