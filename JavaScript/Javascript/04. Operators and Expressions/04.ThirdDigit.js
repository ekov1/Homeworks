function solve(args) {
	var a = +args[0] + "";

var digit = a[a.length - 3];

if (digit === "7") {
    console.log("true");
}
else if(a.length < 3){
    console.log("false 0");
}	
else{
    console.log("false " + digit);
}
}