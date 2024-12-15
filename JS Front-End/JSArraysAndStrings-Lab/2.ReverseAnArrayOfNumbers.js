
function reverse(n,inputArray){
    let array=[];
    for(let i=0;i<n;i++){
        array[i]=inputArray[i]
    }

    let output='';
    for(let i=array.length-1;i>=0;i--){
        output+=array[i]+' ';
    }
    console.log(output)
}

reverse(3, [10, 20, 30, 40, 50]);