function solve(params) {
    
    var rc = params[0].split(' '),
    table = [], 
    endMessage = "";

    for(var i = 0; i < rc[0]; i += 1) {
        table[i] = params[1 + i].split(' ');
    }

    var rows = 0,
        cols = 0,
        sum = Math.pow(2, rows) + cols;

        while(true){

            if (table[rows][cols] === 'dr') {
                table[rows][cols] = '-';
                rows += 1;
                cols += 1;
            }
            else if (table[rows][cols] === 'ur') {
                table[rows][cols] = '-';
                rows -= 1;
                cols += 1;
            }
            else if (table[rows][cols] === 'dl') {
                table[rows][cols] = '-';
                rows += 1;
                cols -= 1;
            }
            else if (table[rows][cols] === 'ul') {
                table[rows][cols] = '-';
                rows -= 1;
                cols -= 1;
            }
            else if(table[rows][cols] === '-'){
                endMessage = 'failed at (' + rows + ', ' + cols + ')';
                console.log(endMessage);
                break;
            }

            if (rows < 0 || rows < 0 || rows >= rc[0] || cols >= rc[1]) {
                endMessage = 'successed with ' + sum;
                 console.log(endMessage);
                 break;
            }
            sum += Math.pow(2, rows) + cols;
        }
}

solve([
 '3 5',
 'dr dl dr ur ul',
 'dr dr ul ur ur',
 'dl dr ur dl ur'
])