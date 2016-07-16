function solve(params) {
    var heights = params[0].split(' ').map(Number),
        sum = 0, i,
        peaks = [0],
        result = -1;

    for (i = 1; i < heights.length - 1; i += 1) {
        if (biggerThanNeighbours(i, heights)) {
            peaks.push(i);
        }
    }
    peaks.push(heights.length - 1);

    for (i = 1; i < peaks.length; i += 1) {
        if (peaks[i] - peaks[i - 1] >= 2) {
            for (var j = peaks[i - 1]; j <= peaks[i]; j += 1) {
                sum += heights[j];
            }
            if (sum > result) {
                result = sum;
            }
                sum = 0;
        }

    }

    if (sum > result) {
        result = sum;
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