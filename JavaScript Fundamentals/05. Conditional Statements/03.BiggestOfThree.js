function biggest(args) {
    
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    if (a > b && a > c) {
        console.log(a);
    }
    else if (b > a && b > c) {
        console.log(b);
    }
    else if( c > a && c > b){
       console.log(c);
    }
    else{
        console.log(a);
    }
}