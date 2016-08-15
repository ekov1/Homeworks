function createCalendar(selector, events) {

    var container = document.querySelector(selector), i,
        daysInMonth = 30,
        date = new Date(2014, 5, 1),
        weekDays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];

    container.style.width = '930px';
    container.style.height = '660px';

    for (i = 0; i < daysInMonth; i += 1) {
        var dateContainer = document.createElement('div'),
            dateTitle = document.createElement('strong'),
            dateInfo = document.createElement('input'),
            dateText = weekDays[date.getDay()] + ' ' + date.getDate() + ' June 2014';

        dateContainer.appendChild(dateTitle);
        dateContainer.appendChild(dateInfo);

        dateInfo.style.width = '120px';
        dateInfo.readOnly = true;

        dateContainer.style.width = '130px';
        dateContainer.style.height = '130px';
        dateContainer.style.float = 'left';
        dateContainer.style.border = '1px solid black';

        dateContainer.className += 'dateContainer';
        dateTitle.className += 'dateTitle';
        dateInfo.className += 'dateInfo';

        dateTitle.innerHTML = dateText;

        for (var j = 0; j < events.length; j += 1) {
            if (events[j].date == date.getDate()) {
                dateInfo.value = events[j].hour + ' ' + events[j].title;
            }

        }

        container.appendChild(dateContainer);
        date.setDate(date.getDate() + 1);
    }

    container.addEventListener('mouseover', function (ev) {
        var target = ev.target;

        if (target.className === 'dateTitle') {
            target.style.backgroundColor = '#B6E3F2';
        }

    });
var prevClickedElement;
    container.addEventListener('mouseout', function (ev) {
        var target = ev.target;

        if (target.className === 'dateTitle') {
            target.style.backgroundColor = 'white';
        }

    });

    container.addEventListener('click', function (ev) {
        var target = ev.target;
        if(prevClickedElement) {
            prevClickedElement.style.backgroundColor = 'white';
        }
        prevClickedElement = target;

        if (target.className === 'dateContainer') {
            target.style.backgroundColor = '#B6E3F2';
        }

    });

}