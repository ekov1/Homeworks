function appearanceCount(input) {
    var nums = input[0].split('\n'),
    numbers = nums[1].split(' ').map(Number),
    x = +nums[2],
    position = 0,
    appCount = 0;

        position = numbers.indexOf(x);

    for(var i = 0; i < numbers.length; i += 1) {

        if (position >= 0) {
            appCount += 1;
        }
        else{
            return appCount;
        }
        position = numbers.indexOf(x ,position + 1);
    }
}


