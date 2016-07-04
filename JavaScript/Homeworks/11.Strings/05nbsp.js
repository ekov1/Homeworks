function replaceSpace(args) {
    
    var string = args[0],
    expr = / /g,
    replaced = string.replace(expr, '&nbsp;');

    console.log(replaced);
}

