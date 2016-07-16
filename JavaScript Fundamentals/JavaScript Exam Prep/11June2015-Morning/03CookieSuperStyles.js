function solve(params) {

    var lines = [],
        result = "",
        selector = {},
        isInSelector = false,
        selectorNames = [];

    for (var i = 0; i < params.length; i += 1) {
        lines.push(params[i]
            .replace(/\s/g, ''));

        if (lines[i] === '}') {
            lines[i - 1] = lines[i - 1].replace(';', '');
        }
    }

    for (i = 0; i < lines.length; i += 1) {

        if (lines[i][lines[i].length - 1] === '{') {
            isInSelector = true;
            selectorNames.push(lines[i]);
        }
        else if (lines[i] === '}') {
            isInSelector = false;
        }
        else if (isInSelector) {
            if (!selector.hasOwnProperty(selectorNames[selectorNames.length - 1])) { 

                selector[selectorNames[selectorNames.length - 1]] = lines[i];
            }
            else { //Make function to see if there is a property with the same name!! If yes-replace if //if no just add
                selector[selectorNames[selectorNames.length - 1]] += ' ' + lines[i];
            }
        }
    }



    console.log(selector);
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