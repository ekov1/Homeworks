function matrix(args) {
    
    var number = +args[0];
var result = "";

    for(var i = 1; i <= number; i += 1) {
        for(var k = i; k <= i + number - 1; k += 1) {
            result += k + " ";
        }
        result += "\n";
    }

    console.log(result);
}