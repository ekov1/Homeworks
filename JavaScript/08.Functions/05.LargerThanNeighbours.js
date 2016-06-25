function largerThanNeightbours(input) {
    var arr = input[0].split('\n'),
    n = +arr[0],
    number = arr[1].split(' ').map(Number),
    count = 0;

    for(var i = 1; i < n - 1; i += 1) {
        if (number[i] > number[i - 1] && number[i] > number[i + 1]) {
            count += 1;
        }
    }
    return count;
}