function solve() {
    return function (fileContentsByName) {
        var $root = $('.file-explorer').addClass('file-explorer'),
            $fileContent = $('.file-content');

        // Removing items
        $('.items').on('click', '.item', function (ev) {
            var target = $(ev.target);
            if (target.hasClass('del-btn')) {
                $(this).remove();
            }
        });

        // Add element
        $('input').keydown(function (ev) {

            if (ev.keyCode == 13)  // the enter key code
            {
                var inputValue = $(this).val(),
                    directories = $('.dir-item');

                if (inputValue.indexOf('/') > 0) {
                    var dirAndFile = inputValue.split('/'),
                        dirToAdd = dirAndFile[0],
                        len = directories.length;

                    for (var i = 0; i < len; i += 1) {

                        var itemsList = directories.eq(i).find('.items').eq(0),
                            directoryName = directories.eq(i).children().first().text();

                        if (directoryName === dirToAdd) {

                            setupLiElement(itemsList, dirAndFile[1]);
                            break;
                        }
                    }
                }
                else {
                    var ul = $('.add-wrapper').next();

                    setupLiElement(ul, inputValue);
                }

                $(this).val('');
                $('.add-wrapper').children().first().addClass('visible');
                $(this).hide();
            }
        });

        // Show input field
        $('.add-wrapper').on('click', function (ev) {
            var target = $(ev.target);

            target.removeClass('visible');
            target.next().show();
            target.next().addClass('visible');
        });

        // Show message
        $('.items').on('click', function (ev) {
            var target = $(ev.target);

            if (target.hasClass('item-name')) {
                $('.file-content').text(fileContentsByName[target.text()]);
            }
        });

        //Collapse dir
        $('.dir-item').on('click', function (ev) {
            var target = $(ev.target);

            if (target.parents('.dir-item').length > 0 && target.parents('.dir-item').hasClass('collapsed')) {
                target.parents('.dir-item').removeClass('collapsed');
            }
            else {
                $(this).addClass('collapsed');
            }
        });

        function setupLiElement(elementToAppendTo, text) {
            if(text){
                var liToAdd = $('<li />').addClass('file-item item'),
                aToAdd = $('<a />').addClass('item-name').appendTo(liToAdd),
                delButton = $('<a />').addClass('del-btn').appendTo(liToAdd);

            aToAdd.text(text);
            liToAdd.appendTo(elementToAppendTo);
            }
        }
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}