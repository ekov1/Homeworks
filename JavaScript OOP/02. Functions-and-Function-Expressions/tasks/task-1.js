/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(values) {

	let numberSum = null;

	if (!values) {
		throw new Error('Arguments must be provided!');
	}


	for (let item of values) {
		if (isFinite(item)) {
			numberSum += item | 0;
		}
		else {
			throw new Error('Item is not a number!');
		}
	}
	return numberSum;
}

module.exports = sum;