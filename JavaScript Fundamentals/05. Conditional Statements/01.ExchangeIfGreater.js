function exchange(args) {
    
    var a = +args[0];
    var b = +args[1];
    var temp;    

    if (a > b) {
        temp = b;
        b = a;
        a = temp;
    }

    console.log(a + " " + b);
}