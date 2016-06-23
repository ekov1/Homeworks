function solve(params) {
    
    var min = +params[0];
    var max = +params[0];
    var sum = 0;
    var avg = 0;
    var elementCount = 0;
    for(var i = 0; i < params.length ; i += 1) {

        var element = +params[i];
        if (element > max) {
            max = element;
        }

        if (element < min) {
            min = element;
        }
        sum += element;
        elementCount += 1;
    }
    avg = sum / elementCount;

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + avg.toFixed(2));
}