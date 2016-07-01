function replaceTags(args) {
    var text = args[0],
        searchFor = /<a href="(.*?)">(.*?)<\/a>/g;

        text = text.replace(searchFor, '[$2]($1)');
    
    console.log(text);
}


