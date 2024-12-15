
function repeatingsCount(text,word){
    let count=0;
    let arr=text.split(' ');
    for(let i=0;i<arr.length;i++){
        if(arr[i]==word){
            count+=1;
        }
    }
    console.log(count);
}

repeatingsCount('This is a word and it also is a sentence','is')