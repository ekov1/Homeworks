$.fn.tabs = function () {
    var $container = $(this).addClass('tabs-container');

    showCurrentTab();

    $container.on('click', '.tab-item-title', function () {
        var $tabItem = $(this);

        showCurrentTab();

        $container.find('.tab-item').removeClass('current');
        $tabItem.next().show();
        $tabItem.parent().addClass('current');

    });

    function showCurrentTab() {
        $container.find('.tab-item-content').hide();
    }

    return $container;
};