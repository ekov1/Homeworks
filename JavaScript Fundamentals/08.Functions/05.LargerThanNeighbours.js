function largerThanNeightbours(input) {
    var n = +input[0],
    number = input[1].split(' ').map(Number),
    count = 0;

    for(var i = 1; i < n - 1; i += 1) {
        if (number[i] > number[i - 1] && number[i] > number[i + 1]) {
            count += 1;
        }
    }
    return count;
}