function solve(params) {
	var N = parseInt(params[0]),
	answer = 1,
    numbers = params.slice(1).map(Number),
    counter = 1,
    current = numbers[0];

    for(var i = 0; i < numbers.length - 1; i += 1) {
        
        if (current <= numbers[i + 1]) {
            counter += 1;
        }
        else{
                answer +=1;
                counter = 1;
        }
        current = numbers[i + 1];
    }


	console.log(answer);
}

solve(['9',
'1',
'8',
'8',
'7',
'6',
'5',
'7',
'7',
'6']);
