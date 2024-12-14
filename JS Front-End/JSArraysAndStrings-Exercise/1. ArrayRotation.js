
function rotation(arr,num){
    const length = arr.length;
    num = num % length; 

    for (let i = 0; i < num; i++) {
        const firstElement = arr[0];
        for (let j = 0; j < length - 1; j++) {
            arr[j] = arr[j + 1];
        }
        arr[length - 1] = firstElement;
    }
    console.log(arr.join(' '));
}

rotation([51, 47, 32, 61, 21], 2);
