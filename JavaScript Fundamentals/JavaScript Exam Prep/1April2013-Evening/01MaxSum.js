function solve(params) {
    var N = parseInt(params[0]);
    var answer = -2000001,
        curSum = 0,
        numArr = params.slice(1).map(Number);

    for (var i = 0; i < N; i += 1) {
        for (var j = i; j < N; j += 1) {
            curSum += numArr[j];
            if (curSum > answer) {
                answer = curSum;
            }
        }
        curSum = 0;
    }

    console.log(answer);
}

solve(['9',
    '-9',
    '-8',
    '-8',
    '-7',
    '-6',
    '-5',
    '-1',
    '-7',
    '-6'
]);