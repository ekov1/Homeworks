$.fn.lists = function (lists) {

    var $container = $(this),
        $dragged,
        graphs = lists.length,
        $listsWrapper = $('<section />').addClass('lists-wrapper').appendTo($container);


    for (var i = 0; i < graphs; i += 1) {
        var $article = $('<article />').addClass('items-section'),
            $list = lists[i],

            $title = $('<strong />')
                .html($list[0])
                .appendTo($article),

            $addItemWrapper = $('<div />')
                .addClass('add-item-wrapper')
                .appendTo($article),

            $addBtn = $('<a />')
                .addClass('add-btn visible')
                .appendTo($addItemWrapper),

            $addInput = $('<input />')
                .addClass('add-input')
                .attr('type', 'text')
                .appendTo($addItemWrapper),


            $itemsUl = $('<ul />')
                .appendTo($article);

        for (var j = 1; j < $list.length; j += 1) {

            setupLi($itemsUl, $list[j]);
        }
        $article.appendTo($listsWrapper);
    }

    $('.add-btn').on('click', function (ev) {
        var $button = $(this);

        $button.removeClass('visible');
        $button.next().addClass('visible');
    });

    $('.add-input').keypress(function (ev) {

        if (ev.keyCode == '13') {

            var $input = $(this),
                $articleUl = $input.parent().next();

            setupLi($articleUl, $input.val());

            $input.removeClass('visible');
            $input.prev().addClass('visible');
            $input.val('');
        }
    });

    // Drag and drop

    $listsWrapper.on('dragstart', 'li', function () {
        $dragged = $(this);
    });

    $listsWrapper.on("dragenter", function (ev) {
        ev.preventDefault();
        ev.stopPropagation();
    });

    $listsWrapper.on('dragover', function (ev) {
        ev.preventDefault();
        ev.stopPropagation();

    });

    $listsWrapper.on('drop', function (ev) {

        var $target = $(ev.target);

console.log($target);
        if ($target.is('ul')) {

        }
        else if ($target.parents('ul').length > 0) {
            $target = $target.parents('ul').first();
        }
        else {
            return;
        }

        $dragged.remove();
        $dragged.appendTo($target);
    });

    function setupLi($itemsUl, text) {
        var $li = $('<li />')
            .attr('draggable', true)
            .appendTo($itemsUl),

            $liAnchor = $('<a />')
                .attr('target', '_blank')
                .html(text)
                .appendTo($li);
    }

    return $container;
};