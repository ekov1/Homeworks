function solve() {
    $.fn.datepicker = function () {
        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };
        
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
            WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
            $inputMain = $('#date').addClass('datepicker'),
            date = new Date(),
            $controlsBtnLeft = $('<button/>').addClass('btn leftBtn').text('<'),
            $controlsBtnRight = $('<button/>').addClass('btn rightBtn').text('>'),
            $curentDateLink = $('<a/>').attr('href', '#').addClass('current-date-link').text(date.getDate() + ' ' + MONTH_NAMES[date.getMonth()] + ' ' + date.getFullYear()),
            $curentMonthAndYear = $('<div/>').addClass('current-month').text(date.getMonthName() + ' ' + date.getFullYear()),
            $tableHead = $('<thead/>'),
            $tbody = $('<tbody/>'),
            $curentDateDiv = $('<div/>').addClass('current-date').append($curentDateLink),
            $calendar = $('<table/>').addClass('calendar').append($tableHead).append($tbody),
            $controlsMenu = $('<div/>').addClass('controls').append($controlsBtnLeft).append($curentMonthAndYear).append($controlsBtnRight),
            $picker = $('<div/>').addClass('picker').append($controlsMenu).append($calendar).append($curentDateDiv),
            $container = $('<div/>').addClass('datepicker-wrapper'),
            currentDay = date.getDay(),
            currentMonth = date.getMonth(),
            currentYear = date.getFullYear();

        $('#date').parent().append($container);
        $container.append($inputMain).append($picker);

        addTableWeekDays();
        generateMonthDays();
        printMonthDays(currentYear, currentMonth);


        function generateMonthDays() {
            for (var i = 0; i < 6; i += 1) {
                var $tr = $('<tr/>');

                for (var j = 0; j < 7; j += 1) {

                    $tr.append($('<td/>'));
                }
                $tbody.append($tr);
            }
        }

        function addTableWeekDays() {
            var $trTh = $('<tr/>');
            for (var i = 0; i < 7; i += 1) {
                $trTh.append($('<th/>').text(WEEK_DAY_NAMES[i]));
            }
            $tableHead.append($trTh);
        }

        function printMonthDays(currentYear, currentMonth) {
            var firstDay = new Date(currentYear, currentMonth, 1).getDay(),
                $monthCells = $('.calendar').find('td'),
                len = $monthCells.length,
                newDate;

            for (i = 0; i < len; i += 1) {
                newDate = new Date(currentYear, currentMonth, 1 - firstDay + i);

                if (newDate.getMonth() === currentMonth) {
                    $monthCells.eq(i).removeClass().addClass('current-month').text(newDate.getDate());
                }
                else {
                    $monthCells.eq(i).removeClass().addClass('another-month').text(newDate.getDate());
                }
            }
        }

        $('#date').on('focus', function () {
            $picker.addClass('picker-visible');
        });

        $(document).on('click', function (ev) {
            var $target = $(ev.target);

            if ($target.parents('.datepicker-wrapper').length !== 1) {
                $picker.removeClass('picker-visible');
            }
        });

        $('.btn').on('click', function (ev) {
            var $target = $(ev.target);
            if ($target.hasClass('rightBtn')) {
                currentMonth += 1;
                if (currentMonth % 12 === 0) {
                    currentMonth = 0;
                    currentYear += 1;
                }
            }
            else {
                currentMonth -= 1;
                if (currentMonth < 0) {
                    currentMonth = 11;
                    currentYear -= 1;
                }
            }
            $curentMonthAndYear.text(MONTH_NAMES[currentMonth] + ' ' + currentYear);
            printMonthDays(currentYear, currentMonth);
        });

        $('.current-date-link, tbody').on('click', function (ev) {
            var $target = $(ev.target);

            if ($target.hasClass('current-month')) {
                $('#date').val($target.text() + '/' + (currentMonth + 1) + '/' + currentYear);
                $('.picker').removeClass('picker-visible');
            }

            else if ($target.hasClass('current-date-link')) {
                $('#date').val(date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
                $('.picker').removeClass('picker-visible');
            }
        });
        return $(this);
    };
}

// if (typeof module !== 'undefined') {
//     module.exports = solve;
// }