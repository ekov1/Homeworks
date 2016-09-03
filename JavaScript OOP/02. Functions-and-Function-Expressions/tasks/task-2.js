/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(...values) {
	let [startRange, endRange] = values.map(Number);
	let areConvertibleToNumber = isFinite(startRange) && isFinite(endRange);

	if (arguments.length < 2 || !areConvertibleToNumber) {
		throw new Error('Cannot parse numbers correctly!');
	}

	let primeNumbers = [];

	for (let i = startRange; i <= endRange; i += 1) {
		if (isPrime(i)) {
			primeNumbers.push(i);
		}
	}

	function isPrime(number) {
		if (number < 2) {
			return false;
		}
		for (var i = 2; i < number; i++) {
			if (number % i === 0) {
				return false;
			}
		}
		return true;
	}

	return primeNumbers;
}


module.exports = findPrimes;
