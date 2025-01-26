
function printDNAHelix(length) {
    const sequence = 'ATCGTTAGGG';
    const patterns = [
        '**{0}{1}**',
        '*{0}--{1}*',
        '{0}----{1}',
        '*{0}--{1}*'
    ];

    for (let i = 0; i < length; i++) {
        const pattern = patterns[i % 4];
        const char1 = sequence[(i * 2) % sequence.length];
        const char2 = sequence[(i * 2 + 1) % sequence.length];
        console.log(pattern.replace('{0}', char1).replace('{1}', char2));
    }
}

// Example usage:
printDNAHelix(10);