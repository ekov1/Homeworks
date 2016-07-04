function GetMax(nums) {
    
    var numbers = nums[0].split(' ');

    return compare(+numbers[0], compare(+numbers[1], +numbers[2]));
    
    function compare(a, b) {
        if (a > b) {
            return a;
        }
        else if (b > a) {
            return b;
        }
        else{
            return a;
        }
    }
}