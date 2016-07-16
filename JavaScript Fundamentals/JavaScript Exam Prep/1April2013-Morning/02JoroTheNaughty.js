function sovle(params) {
    var rcj = params[0].split(' ').map(Number),
        startRC = params[1].split(' '),
        jumps = [],
        rows = +startRC[0], cols = +startRC[1],
        output = "",
        table = [], i, j;

    for (i = 0; i < rcj[0]; i += 1) {
        for (j = 0; j < rcj[1]; j += 1) {
            table[i] = [];
        }
    }

    var sum = rows * rcj[1] + cols + 1;

    while (true) {
        for (i = 0; i < rcj[2]; i += 1) {
            jumps[i] = params[2 + i].split(' ');

            rows += +jumps[i][0];
            cols += +jumps[i][1];
            if (rows < 0 || cols < 0 || rows >= rcj[0] || cols >= rcj[1]) {
                output = 'escaped ' + sum;
                return output;
            }
            else if (table[rows][cols]) {
                output = 'caught ' + (i + 1);
                return output;
            }

            sum += (rows * rcj[1]) + cols + 1;
            table[rows][cols] = true;
        }
    }
}

sovle(['6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1']);

