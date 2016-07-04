function solve(params) {
    var r = parseInt(params[0]),
        c = parseInt(params[1]),
        table = [],
        tests = parseInt(params[r + 2]),
        parsedMoves = [],
        figure = '',
        figureRows = 0, figureCols = 0,
        toRows = 0, toCols = 0,
        knightMoves = [[-2, 1], [-1, 2], [1, 2], [2, 1],
            [2, -1], [1, -2], [-1, -2], [-2, -1]], i, move,
        isValidMove = false;

    for (i = 0; i < r; i += 1) {
        table[i] = params[2 + i].split('');
    }
    // ------------------------------------------------------------------------
    for (i = 0; i < tests; i++) {

        move = params[r + 3 + i],
            parsedMoves = parseMoves(move);
        figureRows = r - +parsedMoves[0][1],
            figureCols = parsedMoves[0].charCodeAt(0) - 97,
            toRows = r - +parsedMoves[1][1],
            toCols = parsedMoves[1].charCodeAt(0) - 97;
        figure = table[figureRows][figureCols];

        var biggerR = figureRows > toRows ? -1 : 1,
            biggerC = figureCols > toCols ? -1 : 1;

        if (figure === 'K') {
            while (figureRows !== toRows || figureCols !== toCols) {
                if (table[toRows][toCols] === '-') {
                    isValidMove = validKnightMove(knightMoves, figureRows, figureCols,
                        toRows, toCols);
                    break;
                }
                else {
                    break;
                }
            }
        }
        else if (figure === 'Q' && (figureRows !== toRows || figureCols !== toCols)) {

            if (figureRows === toRows) {
                while (figureCols !== toCols) {
                    figureCols += biggerC;
                    if (table[figureRows][figureCols] !== '-') {
                        isValidMove = false;
                        break;
                    }
                    else {
                        isValidMove = true;
                    }
                }

            }
            else if (figureCols === toCols) {
                while (figureRows !== toRows) {
                    figureRows += biggerR;
                    if (table[figureRows][figureCols] !== '-') {
                        isValidMove = false;
                        break;
                    }
                    else {
                        isValidMove = true;
                    }
                }
            }
            else if(Math.abs(figureRows - toRows) === Math.abs(figureCols - toCols)) {
                while (figureRows !== toRows || figureCols !== toCols) {
                    figureRows += biggerR;
                    figureCols += biggerC;
                    if (table[figureRows][figureCols] === '-') {
                        isValidMove = true;
                    }
                    else {
                        isValidMove = false;
                        break;
                    }
                }
            }

        }

        var output = isValidMove === true ? 'yes' : 'no';
        console.log(output);
        isValidMove = false;
    }


    function validKnightMove(knightMoves, figR, figC, toR, toC) {
        for (var i = 0; i < knightMoves.length; i += 1) {

            if (figR + knightMoves[i][0] === toR && figC + knightMoves[i][1] === toC) {
                return true;
            }
        }
        return false;
    }

    function parseMoves(move) {
        var moves = move.split(' ');
        return moves;
    }
}


solve(['9',
'9',
'---Q-----',
'------Q--',
'---------',
'---------',
'----Q----',
'---------',
'---------',
'-------Q-',
'-Q-------',
'7',
'b1 i1',
'b1 c3',
'e5 d3',
'e5 a1',
'd9 e7',
'g8 b3',
'g8 h6']
);
