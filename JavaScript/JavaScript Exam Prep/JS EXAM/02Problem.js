function solve(params) {

    var rc = params[0].split(' '),
        debrisCoord = params[1].split(';'),
        movesNum = +params[2],
        moves = [],
        table = [],
        koceTanks = 4,
        cukiTanks = 4,
        tanksKoceAndCuki = [[0, 0], [0, 1], [0, 2], [0, 3],
            [rc[0] - 1, rc[1] - 1], [rc[0] - 1, rc[1] - 2], [rc[0] - 1, rc[1] - 3], [rc[0] - 1, rc[1] - 4]];

    for (var i = 0; i < rc[0]; i += 1) {
        table[i] = [];
        for (var j = 0; j < rc[1]; j += 1) {

            table[i][j] = '-';
        }
    }

    for (i = 0; i < tanksKoceAndCuki.length; i += 1) {
        var rows = +tanksKoceAndCuki[i][0],
            cols = +tanksKoceAndCuki[i][1];

        table[rows][cols] = i;
    }

    for (i = 0; i < debrisCoord.length; i += 1) {
        var data = debrisCoord[i].split(' '),
            rowsD = data[0],
            colsD = data[1];

        table[rowsD][colsD] = 'x';
    }

    for (i = 0; i < movesNum; i += 1) {
        moves[i] = params[3 + i];
    }
    // ----------------------------------------------------------------
    for (k = 0; k < movesNum; k += 1) {

        var formattedMoves = moves[k].split(' '),
            command = formattedMoves[0],
            id = +formattedMoves[1],
            moveTimes = 0,

            tankRows = tanksKoceAndCuki[id][0],
            tankCols = tanksKoceAndCuki[id][1];

        if (formattedMoves.length === 4) {
            moveTimes = +formattedMoves[2],
                moveDir = formattedMoves[3];
        }
        else if (formattedMoves.length === 3) {
            moveDir = formattedMoves[2];
        }
        // --------------------------------------------------------------------
        var newRows = tanksKoceAndCuki[id][0], newCols = tanksKoceAndCuki[id][1];

        if (command === 'mv') { //Move


            if (moveDir === 'u') {  //Move up

                for (i = 0; i < moveTimes; i += 1) {
                    if (table[newRows - 1][newCols] === '-') {
                        newRows -= 1;
                        tanksKoceAndCuki[id][0] = newRows;

                    }
                    else if (table[newRows - 1][newCols] !== '-') {

                        table[tankRows][tankCols] = '-';
                        table[newRows][newCols] = id;
                        tanksKoceAndCuki[id][0] = newRows;
                        break;
                    }
                }
                table[tanksKoceAndCuki[id][0]][newCols] = id;
                if (tankRows !== tanksKoceAndCuki[id][0] || tankCols !== newCols) {
                    table[tankRows][tankCols] = '-';
                }

            }
            else if (moveDir === 'd') {    //Move down

                for (i = 0; i < moveTimes; i += 1) {
                    if (table[newRows + 1][newCols] === '-') {
                        newRows += 1;
                        tanksKoceAndCuki[id][0] = newRows;
                    }
                    else if (table[newRows + 1][newCols] !== '-') {

                        table[tankRows][tankCols] = '-';
                        table[newRows][newCols] = id;
                        tanksKoceAndCuki[id][0] = newRows;
                        break;
                    }
                }
                table[tanksKoceAndCuki[id][0]][newCols] = id;
                if (tankRows !== tanksKoceAndCuki[id][0] || tankCols !== newCols) {
                    table[tankRows][tankCols] = '-';
                }
            }
            else if (moveDir === 'l') {
                for (i = 0; i < moveTimes; i += 1) {
                    if (table[newRows][newCols - 1] === '-') {
                        newCols -= 1;
                        tanksKoceAndCuki[id][1] = newCols;
                    }
                    else if (table[newRows][newCols - 1] !== '-') {

                        table[tankRows][tankCols] = '-';
                        table[newRows][newCols] = id;
                        tanksKoceAndCuki[id][1] = newCols;
                        break;
                    }
                }
                table[newRows][tanksKoceAndCuki[id][1]] = id;
                if (tankRows !== newRows || tankCols !== tanksKoceAndCuki[id][1]) {
                    table[tankRows][tankCols] = '-';
                }

            }
            else if (moveDir === 'r') {
                for (i = 0; i < moveTimes; i += 1) {
                    if (table[newRows][newCols + 1] === '-') {
                        newCols += 1;
                        tanksKoceAndCuki[id][1] = newCols;
                    }
                    else if (table[newRows][newCols + 1] !== '-') {

                        table[tankRows][tankCols] = '-';
                        table[newRows][newCols] = id;
                        tanksKoceAndCuki[id][1] = newCols;
                        break;
                    }
                }
                table[newRows][tanksKoceAndCuki[id][1]] = id;
                if (tankRows !== newRows || tankCols !== tanksKoceAndCuki[id][1]) {
                    table[tankRows][tankCols] = '-';
                }

            }
        }

        else if (command === 'x') {  //======================================================================= SHOOT
            newRows = tanksKoceAndCuki[id][0], newCols = tanksKoceAndCuki[id][1];

            if (moveDir === 'u') {  //Shoot up

                while (true) {
                    var cellChar = table[newRows - 1][newCols];

                    if (cellChar === '-') {
                        newRows -= 1;
                        if (newRows === 0) {
                            break;
                        }
                    }
                    else if (cellChar === 'x') {

                        table[newRows - 1][newCols] = '-';
                        break;
                    }
                    else if (cellChar >= 0 && cellChar < 4) {
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows - 1][newCols] = '-';
                        koceTanks -= 1;

                        break;
                    }
                    else if(cellChar >= 4 && cellChar <= 7){
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows - 1][newCols] = '-';
                        cukiTanks -= 1;
                        break;
                    }
                    else{
                        break;
                    }
                }
            }



            else if (moveDir === 'd') {    //Shoot down

                while (true) {
                    var cellChar = table[newRows + 1][newCols];

                    if (cellChar === '-') {
                        newRows += 1;
                        if (newRows >= rc[0] - 1) {
                            break;
                        }
                    }
                    else if (cellChar === 'x') {

                        table[newRows + 1][newCols] = '-';
                        break;
                    }
                    else if (cellChar >= 0 && cellChar < 4) {
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows + 1][newCols] = '-';
                        koceTanks -= 1;
                        break;
                    }
                    else if(cellChar >= 4 && cellChar <= 7) {
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows + 1][newCols] = '-';
                        cukiTanks -= 1;
                        break;
                    }
                    else{
                        break;
                    }
                }
            }
            else if (moveDir === 'l') {
                //Shoot  left
                while (true) {
                    var cellChar = table[newRows][newCols - 1];

                    if (cellChar === '-') {
                        newCols -= 1;
                        if (newCols === 0) {
                            break;
                        }
                    }
                    else if (cellChar === 'x') {

                        table[newRows][newCols - 1] = '-';
                        break;
                    }
                    else if (cellChar >= 0 && cellChar < 4) {
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows][newCols - 1] = '-';
                        koceTanks -= 1;
                        break;
                    }
                    else if(cellChar >= 4 && cellChar <= 7){
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows][newCols - 1] = '-';
                        cukiTanks -= 1;
                        break;
                    }
                    else{
                        break;
                    }
                }
            }
            else if (moveDir === 'r') {    //Shoot right
                while (true) {
                    var cellChar = table[newRows][newCols + 1];

                    if (cellChar === '-') {
                        newCols += 1;
                        if (newCols >= rc[1] - 1) {
                            
                        }
                    }
                    else if (cellChar === 'x') {

                        table[newRows][newCols + 1] = '-';
                        break;
                    }
                    else if (cellChar >= 0 && cellChar < 4) {
                        console.log('Tank ' + cellChar + ' is gg');
                        table[newRows][newCols + 1] = '-';
                        koceTanks -= 1;
                        break;
                    }
                    else if(cellChar >= 4 && cellChar <= 7){
                        table[newRows][newCols + 1] = '-';
                        console.log('Tank ' + cellChar + ' is gg');
                        cukiTanks -= 1;
                        break;
                    }
                    else{
                        break;
                    }
                }
            }

        }



    }

    if (cukiTanks === 0) {
        console.log("Cuki is gg");
        return;
    }
    else if (koceTanks === 0) {
        console.log("Koceto is gg");
        return;
    }
    //After the elses but in the cycle





}

solve([
    '10 5',
    '1 0;1 1;1 2;1 3;1 4;3 1;3 3;4 0;4 2;4 4',
    '43',
    'mv 6 5 r',
    'mv 0 6 d',
    'x 0 d',
    'x 0 d',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 0 r',
    'mv 0 6 d',
    'mv 0 9 r',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d'
]);