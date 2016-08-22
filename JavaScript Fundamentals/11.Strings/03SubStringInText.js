function substringIn(args) {

    var string = args[1],
        searchWord = args[0],
        index = 0,
        counter = 0;

    string = string.toLowerCase();
    searchWord = searchWord.toLowerCase();
    index = string.indexOf(searchWord);

    while (index >= 0) {

        if (index >= 0) {
            counter += 1;
        }
        index = string.indexOf(searchWord, index + 1);
    }

    console.log(counter);
}
