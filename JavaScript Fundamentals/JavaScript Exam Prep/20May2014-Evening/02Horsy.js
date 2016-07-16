function solve(params) {

    var rc = params[0].split(' ').map(Number),
        table = [],
        jumpsNum = 0;

    for (var i = 0; i < rc[0]; i += 1) {
        table[i] = params[i + 1].split('').map(Number);
    }

    var rows = rc[0] - 1,
        cols = rc[1] - 1,
        sum = 0;


    while (true) {

        if (rows >= 0 && rows < rc[0] && cols >= 0 && cols < rc[1]) {
            sum += Math.pow(2, rows) - cols;
            jumpsNum += 1;
        }
        else {
            console.log('Go go Horsy! Collected ' + sum + ' weeds');
            break;
        }


        if (table[rows][cols] === 1) {
            table[rows][cols] = 0;
            rows -= 2;
            cols += 1;
        }
        else if (table[rows][cols] === 2) {
            table[rows][cols] = 0;
            rows -= 1;
            cols += 2;
        }

        else if (table[rows][cols] === 3) {
            table[rows][cols] = 0;
            rows += 1;
            cols += 2;
        }

        else if (table[rows][cols] === 4) {
            table[rows][cols] = 0;
            rows += 2;
            cols += 1;
        }

        else if (table[rows][cols] === 5) {
            table[rows][cols] = 0;
            rows += 2;
            cols -= 1;
        }

        else if (table[rows][cols] === 6) {
            table[rows][cols] = 0;
            rows += 1;
            cols -= 2;
        }

        else if (table[rows][cols] === 7) {
            table[rows][cols] = 0;
            rows -= 1;
            cols -= 2;
        }

        else if (table[rows][cols] === 8) {
            table[rows][cols] = 0;
            rows -= 2;
            cols -= 1;
        }
        else if (table[rows][cols] === 0) {
            jumpsNum -= 1;
            console.log('Sadly the horse is doomed in ' + jumpsNum + ' jumps');
            break;
        }

    }

}

