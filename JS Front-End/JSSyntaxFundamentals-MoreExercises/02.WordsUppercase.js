
function solve(input) {
    const words = input.match(/\b\w+\b/g);

    if (words) {
        const result = words.map(word => word.toUpperCase()).join(", ");
        console.log(result);
    } else {
        console.log(""); 
    }
}
