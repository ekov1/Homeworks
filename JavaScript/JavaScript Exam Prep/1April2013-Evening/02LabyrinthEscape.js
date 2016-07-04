function solve(args) {
    
    var rc = args[0].split(' ').map(Number),
    startingRC = args[1].split(' ').map(Number),
    table = [],
    winMsg = "",
    movesCount = 0;

    for(var i = 0; i < rc[0]; i += 1) {
        table[i] = args[2 + i].split('');
    } 

    var rows = startingRC[0],
        cols = startingRC[1],
    	sumCell = rows * rc[1] + cols + 1;

    while (true) {
        
        if (table[rows][cols] === 'l') {
            table[rows][cols] = '-';
            cols -= 1;
        }
        else if (table[rows][cols] === 'r') {
            table[rows][cols] = '-';
            cols += 1;
        }
        else if (table[rows][cols] === 'u') {
            table[rows][cols] = '-';
            rows -= 1;
        }
        else if (table[rows][cols] === 'd') {
            table[rows][cols] = '-';
            rows += 1;
        }
        else if(table[rows][cols] === '-'){
            winMsg = 'lost ' + movesCount;
            return winMsg;
        }

        if (rows >= rc[0] || rows < 0 || cols >= rc[1] || cols < 0) {
            winMsg = 'out ' + sumCell;
            return winMsg;
        }
        sumCell +=  rows * rc[1] + cols + 1;
        movesCount += 1;
    }
}

solve([
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"]

);