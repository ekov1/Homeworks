function extract(args) {
    var result = "";

    for(var i = 0; i < args.length; i += 1) {
        var replaced = args[i].replace(/<(?:.|\n)*?>/gm, '').trim();
        result += replaced;
    }

    console.log(result);
}