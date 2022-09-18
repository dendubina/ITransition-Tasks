lcs = (arr) => {
    if (!arr.length) return '';

    let shortest = arr.reduce((a, b) => a.length <= b.length ? a : b),
        maxlen = shortest.length;
 
    for (let len = maxlen; len > 0; len--) {

        for (let start = 0; start <= maxlen - len; start++) {

            let substr = shortest.slice(start, start + len);

            if (arr.every(elem => elem.includes(substr)))
                return substr;
        }
    }
    return '';
}

console.log(lcs(process.argv.slice(2)));