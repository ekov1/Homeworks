function solve(params) {
    var heights = params[0].split(' ').map(Number),
        maxRockNum = -1, i,
        peaks = [0];

    for (i = 1; i < heights.length - 1; i += 1) {
        if (biggerThanNeighbours(i, heights)) {
            peaks.push(i);
        }
    }
    peaks.push(heights.length - 1);

    for( i = 1; i < peaks.length; i += 1) {
        maxRockNum = Math.max(maxRockNum, peaks[i] - peaks[i - 1]);
    }
    console.log(maxRockNum);

    function biggerThanNeighbours(i, array) {

        return array[i] > array[i + 1] &&
            array[i] > array[i - 1];
    }
}
    solve(['10 9 8 7 5 7 8 9 10']);