function solve() {
    return function () {
        $.fn.listview = function (data) {
            var target = this.attr('data-template'),
                li = $('#' + target).html(),
                template = handlebars.compile(li),
                len = data.length, i;

            for ( i = 0; i < len; i += 1) {
                this.append(template(data[i]));
            }

            return this;
        };
    };
}