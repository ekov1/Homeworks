function replaceTags(args) {
    var text = args[0];

    text = text.replace(/<a href="/g, '[URL=');
    text = text.replace(/">/g, ']');
    text = text.replace(/<\/a>/g, '[/URL]');

    console.log(text);
}