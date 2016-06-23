function printNumbers(args) {
    
    var number = +args[0];
var result = "";
    for(var i = 1; i <= number; i += 1) {
        result += i + " ";
    }
    console.log(result);
}