
function palindrome(nums) {
    let result = '';
    for (let num of nums) {
        let numStr = num.toString();
        let reversedNum = numStr.split('').reverse().join('');
        if (numStr === reversedNum) {
            result += 'true\n';
        } else {
            result += 'false\n';
        }
    }
    return result;
    
}