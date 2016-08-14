$.fn.colorpicker = function () {


    var $root = $(this),

        $picker = $('<div />')
            .addClass('picker')
            .appendTo($root),

        $pickerButton = $('#thumbnail')
            .on('click', function () {
                $pickerButton.css('display', 'none');
                $picker.show();
            }),

        $xButton = $('<img />')
            .attr('src', 'imgs/close.png')
            .addClass('xButton')
            .appendTo($picker)
            .on('click', function () {
                $pickerButton.show();
                $picker.css('display', 'none');
            }),


        $canvas = $('<canvas />')
            .addClass('canvas')
            .attr('width', 256)
            .attr('height', 256)
            .appendTo($picker)
            .on('mouseover', function (ev) {
                var $target = $(ev.target);
                $target.css('cursor', 'url(imgs/cursor.png), auto');
            }),

        $hexInput = $('<input />')
            .addClass('hexInput')
            .attr('placeholder', 'HEX')
            .appendTo($picker),

        $rgbInput = $('<input />')
            .addClass('rgbInput')
            .attr('placeholder', 'RGB')
            .appendTo($picker),

        $colorDiv = $('<div />')
            .addClass('colorDiv')
            .appendTo($picker);

    // Canvas color picking 

    var ctx = $('.canvas').get(0).getContext('2d');
    var image = new Image();

    image.src = "https://photos-3.dropbox.com/t/2/AADYFX_7GCfDQwLjwHw0RlqqTXOgv1eehy0GNHg8M3N87Q/12/353837826/png/32x32/1/_/1/2/color-picker.png/EL2D1OMCGEMgBygH/MNSqWrrDpaIlp5MYIablbUIpyanZ7gB39jEdpgyIvKM?dl=0&size=1280x960&size_mode=3";

    image.onload = function () {
        ctx.drawImage(image, 0, 0);
    };

    $('.canvas').click(function (e) {
        var data = ctx.getImageData(e.offsetX, e.offsetY, 1, 1).data;
        alert('rgb: ' + [].slice.call(data, 0, 3).join());
    });
    return $root;
};