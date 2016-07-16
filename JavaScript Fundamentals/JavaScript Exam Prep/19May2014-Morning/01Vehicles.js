function solve(params) {
 var wheels = +params[0];
 var combinations = 0,
 currSum = 0,
 car = 4, truck = 10, tryke = 3;

 for(var i = 0; i <= wheels / truck; i += 1) {
     for(var j = 0; j <= wheels / car; j += 1) {
         for(var k = 0; k <= wheels / tryke; k += 1) {

             currSum = i * truck + j * car + k * tryke;

             if (currSum === wheels) {
                 combinations += 1;
             }
             else if(currSum > wheels){
                 break;
             }
         } 
     }
 }
 console.log(combinations);
}
solve(['7']);
solve(['10']);
solve(['40']);