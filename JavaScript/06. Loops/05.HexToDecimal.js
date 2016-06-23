function hexToDec(args) {

    var symbols = '0123456789ABCDEF';
    var hex = String(args[0]);
    var result = 0;
    var digit = 0;

    for(var i = 0; i < hex.length; i += 1) {
        
        result += symbols.indexOf(hex[i]) * Math.pow(16, hex.length - 1 - i);
    }
    console.log(result);
}