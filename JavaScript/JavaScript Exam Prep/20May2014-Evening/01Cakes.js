function solve(params) {
    var money = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
    var answer = 0,
        sum = 0;

    for (var i = 0; i < money / c1 + 1; i += 1) {
        for (var j = 0; j < money / c2 + 1; j += 1) {
            for (var k = 0; k < money / c3 + 1; k += 1) {

                sum = i * c1 + j * c2 + k * c3;
                
                if (sum <= money) {
                    answer = Math.max(sum, answer);
                }
            }
        }
    }
    console.log(answer);
}
