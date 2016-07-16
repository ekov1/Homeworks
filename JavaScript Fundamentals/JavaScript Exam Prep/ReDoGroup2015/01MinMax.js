function solve(params) {
    var n = parseInt(params[0]),
        k = parseInt(params[1]),
        numbersAsString = params[2].split(' ').map(Number),
        sum = 0,
        newArray = [],
        min = 0,
        max = 0,
        part = [];

    for (var i = 0; i < numbersAsString.length - k + 1; i += 1) {
        part = numbersAsString.slice(i, i + k).map(Number);
        max = Math.max.apply(null, part);
        min = Math.min.apply(null, part);
        newArray[i] = +max + +min;
        sum = 0;
    }

    console.log(newArray.join(','));
}

