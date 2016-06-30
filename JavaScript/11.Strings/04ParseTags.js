function parseTags(args) {

    var stringText = args[0],
        lowcaseExpr = /<lowcase>(.*?)<\/lowcase>/gi,
        upcaseExpr = /<upcase>(.*?)<\/upcase>/gi;

    var lowCaseArr = stringText.match(lowcaseExpr),
        upCaseArr = stringText.match(upcaseExpr);

    for (i = 0; i < upCaseArr.length; i += 1) {
        stringText = stringText.replace(upCaseArr[i], upCaseArr[i].toUpperCase());
    }

    for (var i = 0; i < lowCaseArr.length; i += 1) {
        stringText = stringText.replace(lowCaseArr[i], lowCaseArr[i].toLowerCase());
    }

    stringText = stringText.replace(/<lowcase>/ig, '');
    stringText = stringText.replace(/<\/lowcase>/ig, '');


    stringText = stringText.replace(/<upcase>/ig, '');
    stringText = stringText.replace(/<\/upcase>/ig, '');

    stringText = stringText.replace(/<orgcase>/ig, '');
    stringText = stringText.replace(/<\/orgcase>/ig, '');

    console.log(stringText);
}

parseTags(['<upcase>text<lowcase>Text</lowcase></upcase>']);