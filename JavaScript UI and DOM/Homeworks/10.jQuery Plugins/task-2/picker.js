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
                $target.css('cursor', 'url(imgs/cursor.png) 0 28, auto');
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

    // Only runs with live-server/ otherwise error message 'canvas is tainted/cannot get data from canvas'

    image.src = 'imgs/color-picker.png';
    image.onload = function () {
        ctx.drawImage(image, 0, 0);
    };

    $('.canvas').click(function (e) {
        var data = ctx.getImageData(e.offsetX, e.offsetY, 1, 1).data,
            R = data[0],
            G = data[1],
            B = data[2],
            rgbString = R + ',' + G + ',' + B,
            hexString = rgbToHex(R, G, B);

        $hexInput.val('#' + hexString);
        $rgbInput.val(rgbString);
        $colorDiv.css({
            'background-color': '#' + hexString
        });

        $('.hexInput').select();
        document.execCommand('copy');
        document.getSelection().empty();
    });

    // Events for inputHex and inputRGB on enter to change color
    function rgbToHex(R, G, B) { return toHex(R) + toHex(G) + toHex(B); }
    function toHex(n) {
        n = parseInt(n, 10);
        if (isNaN(n)) return "00";
        n = Math.max(0, Math.min(n, 255)); return "0123456789ABCDEF".charAt((n - n % 16) / 16) + "0123456789ABCDEF".charAt(n % 16);
    }
    return $root;
};