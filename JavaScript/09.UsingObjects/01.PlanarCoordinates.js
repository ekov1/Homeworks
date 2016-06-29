function coords(args) {
    var lines = [];

    for (var i = 0; i < 3; i += 1) {

        var x = Math.sqrt(Math.pow(+args[i * 4] - +args[i * 4 + 2], 2) + Math.pow(+args[i * 4 + 1] - +args[i * 4 + 3], 2));

        lines[i] = x.toFixed(2);
        console.log(lines[i]);
    }
    lines = lines.map(Number);

    if (lines[0] + lines[1] > lines[2] && lines[2] + lines[1] > lines[0] && lines[0] + lines[2] > lines[1]) {
        console.log('Triangle can be built');
    }
    else {
        console.log('Triangle can not be built');
    }
}