function solve(args) {
    var heights = args[0].split(' ').map(Number),
        result = 0,
        peaks = [0],
        sum = 0;

    for (var i = 1; i < heights.length - 1; i += 1) {
        if (biggerThanNeighbours(i, heights)) {
            peaks.push(i);
        }
    }
    peaks.push(heights.length - 1);

    for (var i = 1; i < peaks.length; i += 1) {

        for (var j = peaks[i]; j >= peaks[i - 1]; j -= 1) {
            sum += heights[j];

        }
        if (sum > result) {
            result = sum;
        }
            sum = 0;
    }
    if (sum > result) {
        result = sum;
        sum = 0;
    }

    console.log(result);

    function biggerThanNeighbours(i, array) {

        return array[i] > array[i + 1] &&
            array[i] > array[i - 1];
    }


}





solve([
    "5 1 7 6 5 6 4 2 3 8"
]);