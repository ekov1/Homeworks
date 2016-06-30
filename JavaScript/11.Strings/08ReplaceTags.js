function replaceTags(args) {
    var text = args[0],
        content = /">(.*?)<\/a>/g;

    var contArr = text.match(content),
        contSubstr = "",
        toPut = "",
        aIndex = 0,
        beforeTag = "";

    for (var i = 0; i < contArr.length; i += 1) {

        aIndex = text.indexOf('<a');

        contSubstr = contArr[i].substring(2, contArr[i].length - 4);
        toPut = '[' + contSubstr + '](';

        beforeTag = text.substring(aIndex, aIndex + 9);
        text = text.replace(beforeTag, toPut);
        
        aIndex = text.indexOf('<a', aIndex + 9);
    }

    text = text.replace(content, ')');
    text = text.replace(/<\/a>/g, '');

    console.log(text);
}

replaceTags(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);