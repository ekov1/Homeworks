function solve(params) {
    var nk = params[0].split(' ').map(Number),
        sequence = params[1].split(' ').map(Number),
        result = 0,
        newSequence = [];


    for (var i = 0; i < nk[1]; i += 1) {
        for (var j = 0; j < sequence.length; j += 1) {

            if (j === 0) {
                if (sequence[j] === 0) {
                    newSequence[j] = Math.abs(sequence[j + 1] - sequence[sequence.length - 1]);
                }
                else if (sequence[j] === 1) {
                    newSequence[j] = sequence[j + 1] + sequence[sequence.length - 1];
                }
                else if (sequence[j] % 2 === 0 && sequence[j] !== 0) {
                    newSequence[j] = Math.max(sequence[j + 1], sequence[sequence.length - 1]);
                }
                else if (sequence[j] % 2 === 1 && sequence[j] !== 1) {
                    newSequence[j] = Math.min(sequence[j + 1], sequence[sequence.length - 1]);
                }
            }
            else if(j === sequence.length - 1) {

                if (sequence[j] === 0) {
                    newSequence[j] = Math.abs(sequence[0] - sequence[j - 1]);
                }
                else if (sequence[j] === 1) {
                    newSequence[j] = sequence[0] + sequence[j - 1];
                }
                else if (sequence[j] % 2 === 0 && sequence[j] !== 0) {
                    newSequence[j] = Math.max(sequence[0], sequence[j - 1]);
                }
                else if (sequence[j] % 2 === 1 && sequence[j] !== 1) {
                    newSequence[j] = Math.min(sequence[0], sequence[j - 1]);

                }
            }
            else {
                if (sequence[j] === 0) {
                    newSequence[j] = Math.abs(sequence[j + 1] - sequence[j - 1]);
                }
                else if (sequence[j] === 1) {
                    newSequence[j] = sequence[j + 1] + sequence[j - 1];
                }
                else if (sequence[j] % 2 === 0 && sequence[j] !== 0) {
                    newSequence[j] = Math.max(sequence[j + 1], sequence[j - 1]);
                }
                else if (sequence[j] % 2 === 1 && sequence[j] !== 1) {
                    newSequence[j] = Math.min(sequence[j + 1], sequence[j - 1]);

                }
            }
        }
        for(var k = 0; k < nk[0]; k += 1) {
            sequence[k] = newSequence[k];
        }
        newSequence = [];
    }
    for (var item in sequence) {
        result += sequence[item];
    }

    console.log(result);
}

solve(['10 3','1 9 1 9 1 9 1 9 1 9']);