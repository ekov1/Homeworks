function equasion(args) {
    
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    var x1;
    var x2;
    var d = (b * b) - (4 * a * c);
    var sqrD = Math.sqrt(d);

    if (d > 0) {
        
        x1 = (-b - sqrD) / (2 * a);
        x2 = (-b + sqrD) / (2 * a); 
        if (x1 > x2) {
            var temp = x1;
            x1 = x2;
            x2 = temp;
        }
        console.log('x1=' + x1.toFixed(2) + "; x2=" + x2.toFixed(2));
    }
    else if (d === 0) {
        x1 = -b / (2 * a);
        console.log('x1=x2='+ x1.toFixed(2));
    }
    else if(d < 0){
        console.log('no real roots');
    }
}