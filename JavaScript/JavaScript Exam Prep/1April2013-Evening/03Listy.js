function solve(params) {
    var answer = 0,
        lines = [],
        data = {}, j, k;

    for (var i = 0; i < params.length; i += 1) {
        lines.push(params[i]
            .trim()
            .replace(/\s+/g, ' ')
            .replace(/-(.*?)([1-9])/g, '-$2')
            .replace(/(\w+)\s(.*?)\s\[(.*?)\]/g, '$1 $2[$3]')
            .replace(/(\w+)\s\[(.*?)\]/g, '$1[$2]')
        );
    }

    for (i = 0; i < lines.length; i += 1) {

        var hasDef = lines[i].indexOf('def'),
            dataCount = findDataCount(lines[i]),

            name = findName(lines[i]),
            array = findArray(lines[i]),
            func = "",
            min = 0, max = 0, sum = 0, avg = 0,
            newArray = [];

        if (dataCount >= 1) {
            func = findFunc(lines[i], dataCount);
        }
        else {
            var result = returnData(lines[i]);
            return result;
        }

        for (j = 0; j < array.length; j += 1) {
            if (!isNumber(array[j])) {   // If its not a number
                if (Array.isArray(data[array[j]])) { //If its an array
                    for (k = 0; k < data[array[j]].length; k += 1) {
                        newArray.push(+data[array[j]][k]);
                    }
                }
                else { //If its calling a variable
                    newArray.push(+data[array[j]]);
                }
            }
            else { //If its a normal number
                newArray.push(+array[j]);
            }
        }

        if (func === 'sum') {
            sum = newArray.reduce(function (a, b) { return +a + +b; });
            data[name] = sum;
        }
        else if (func === 'min') {
            min = Math.min.apply(Math, newArray);
            data[name] = min;
        }
        else if (func === 'max') {
            max = Math.max.apply(Math, newArray);
            data[name] = max;
        }
        else if (func === 'avg') {
            sum = newArray.reduce(function (a, b) { return +a + +b; });
            avg = (sum / newArray.length) | 0;
            data[name] = avg;
        }
        else {
            data[name] = newArray;
        }
    }

    function isNumber(str) {
        return /^-?[0-9]\d*(\.\d+)?$/.test(str);
    }
    function findName(line) {

        var data = line.split('['),
            name = data[0].split(' ');
        return name[1];
    }

    function findFunc(line, dataCount) {
        var data = [], name = "";

        if (dataCount === 1) {
            data = line.split('['),
                name = data[0];
            return name;
        }
        else if (dataCount === 2) {
            data = line.split('['),
                name = data[0].split(' ');
            return name[1];
        }
        else if (dataCount === 3) {
            data = line.split('['),
                name = data[0].split(' ');
            return name[2];
        }
    }
    // Output
    answer = data[Object.keys(data).sort().pop()],
        output = Array.isArray(answer) ? answer[0] : answer;

    console.log(output);

    function returnData(line) {

        var info = line.slice(1, line.length - 1),
            result = data[info] * 1;
        return result;
    }

    function findArray(line) {
        var formatLine = line.split('['),
            array = formatLine[1].substring(0, formatLine[1].length - 1);
        var arrayTwo = array.split(/[, ]/).filter(function (v) { return v !== '' });

        return arrayTwo;
    }

    function findDataCount(line) {
        var data = line.split('['),
            name = data[0].split(' ');
        return name.length;
    }
}

solve(['def maxy max[100]',
    'def summary [0]',
    'combo [maxy, maxy,maxy,maxy, 5,6]',
    'summary sum[combo, maxy, -18000]',
    'def pe6o avg[summary,maxy]',
    'sum[7, pe6o]']
);

