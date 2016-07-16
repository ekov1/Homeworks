function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]), i,
        move = [],
        table = [],
        canMove = false;

    for (i = 0; i < rows; i += 1) {
        table[i] = params[2 + i].split('');
    }
    // ----------------------------------------------------------------------
    for (i = 0; i < tests; i += 1) { 

        move = params[rows + 3 + i].split(' ');

        var figRows = rows - +move[0][1],
            figCols = move[0].charCodeAt(0) - 97,

            toRows = rows - +move[1][1],
            toCols = move[1].charCodeAt(0) - 97,

            figureCell = table[figRows][figCols];

        if (figureCell === 'R' && (figRows !== toRows || figCols !== toCols)) {

            canMove = canMovePiece(figRows, figCols, toRows, toCols, figureCell);

        }
        else if (figureCell === 'B' && (figRows !== toRows || figCols !== toCols)) {

            if (Math.abs(figRows - toRows) === Math.abs(figCols - toCols)) {

                canMove = canMovePiece(figRows, figCols, toRows, toCols, figureCell);
            }
        }

        else if (figureCell === 'Q' && (figRows !== toRows || figCols !== toCols)) {

            canMove = canMovePiece(figRows, figCols, toRows, toCols, figureCell);
        }

        if (canMove) {
            console.log('yes');
            canMove = false;
        }
        else {
            console.log('no');
        }
    }

    function canMovePiece(figRows, figCols, toRows, toCols, figureCell) {
        var biggerRow = (figRows > toRows) ? -1 : 1,
            biggerCol = (figCols > toCols) ? -1 : 1;

        if (figureCell === 'R') {

            if (figRows === toRows) {

                while (figCols !== toCols) {
                    figCols += biggerCol;
                    if (table[figRows][figCols] !== '-') {
                        return false;
                    }
                }
                return true;
            }
            else if (figCols === toCols) {

                while (figRows !== toRows) {
                    figRows += biggerRow;
                    if (table[figRows][figCols] !== '-') {
                        return false;
                    }
                }
                return true;
            }
        }
        else if (figureCell === 'B') {

            while (figRows !== toRows && figCols !== toCols) {
                figRows += biggerRow;
                figCols += biggerCol;
                if (table[figRows][figCols] !== '-') {
                    return false;
                }
            }
            return true;
        }
        else if (figureCell === 'Q') {
            if (figRows === toRows) {

                while (figCols !== toCols) {
                    figCols += biggerCol;
                    if (table[figRows][figCols] !== '-') {
                        return false;
                    }
                }
                return true;
            }
            else if (figCols === toCols) {

                while (figRows !== toRows) {
                    figRows += biggerRow;
                    if (table[figRows][figCols] !== '-') {
                        return false;
                    }
                }
                return true;
            }
            else if (Math.abs(figRows - toRows) === Math.abs(figCols - toCols)) {
                while (figRows !== toRows && figCols !== toCols) {
                    figRows += biggerRow;
                    figCols += biggerCol;
                    if (table[figRows][figCols] !== '-') {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
solve(['3',
'4',
'--R-',
'B--B',
'Q--Q',
'12',
'd1 b3',
'a1 a3',
'c3 b2',
'a1 c1',
'a1 b2',
'a1 c3',
'a2 b3',
'd2 c1',
'b1 b2',
'c3 b1',
'a2 a3',
'd1 d3']);
