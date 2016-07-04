function solve(args) {

    var line = "",
        result = "",
        wrongSelectors = /\w+[.|#].+?{/g,
        wrongSelectorArr = [],
        fixedSelector = [];



    for (var i = 0; i < args.length; i += 1) {
        line = args[i].replace(/\s+/g, '');
        result += line;
        result = result.replace(/;}/g, '}');
    }
    wrongSelectorArr = result.match(wrongSelectors);

    for (i = 0; i < wrongSelectorArr.length; i += 1) {

        if (wrongSelectorArr[i].indexOf('.') >= 0) {
            fixedSelector[i] = wrongSelectorArr[i].replace('.', ' .');
        }
        else{
            fixedSelector[i] = wrongSelectorArr[i].replace('#', ' #');
        }
        
        result = result.replace(wrongSelectorArr[i], fixedSelector[i]);
    }
    console.log(result);
}

solve(['#the-big-b{',
    'color: yellow;',
    'size: big;',
    '}',
    '.muppet{',
    ' powers: all;',
    'skin: fluffy;',
    '}',
    '.water-spirit {',
    'powers: water;',
    'alignment : not-good;',
    '}',
    'all{',
    ' meant-for: nerdy-children;',
    '}',
    '.muppet {',
    'powers: everything;',
    '}',
    'all .muppet {',
    'alignment : good ;',
    '}',
    ' .muppet+ .water-spirit{',
    ' power: everything-a-muppet-can-do-and-water;',
    '}']);