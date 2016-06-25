function sort(input) {
    var arr = input[0].split('\n'),
    n = +arr[0],
    numbers = arr[1].split(' ').map(Number);
    
    if (numbers.length > 1) {
        console.log(numbers.sort(function (x ,y)
        { return x - y;}
        ).join(' '));
    }
}
  