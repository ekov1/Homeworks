function createCalendar(selector, events) {

    var container = document.querySelector(selector), i,
        daysInMonth = 30,
        date = new Date(2014, 5, 1),
        weekDays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
        prevClickedElement;

    container.style.width = '930px';
    container.style.height = '660px';

    for (i = 0; i < daysInMonth; i += 1) {
        var dateContainer = document.createElement('div'),
            dateTitle = document.createElement('h4'),
            dateInfo = document.createElement('div'),
            dateText = weekDays[date.getDay()] + ' ' + date.getDate() + ' June 2014';

        dateContainer.appendChild(dateTitle);
        dateContainer.appendChild(dateInfo);

        dateTitle.style.width = '130px';
        dateTitle.style.borderBottom = '1px solid black';
        dateTitle.style.backgroundColor = 'gray';
        dateTitle.style.margin = '0';

        dateInfo.style.width = '128px';
        dateInfo.style.height = '110px';
        dateInfo.style.margin = '0';

        dateContainer.style.width = '130px';
        dateContainer.style.height = '130px';
        dateContainer.style.float = 'left';
        dateContainer.style.border = '1px solid black';

        dateContainer.className += 'dateContainer';
        dateTitle.className += 'dateTitle';

        dateTitle.innerHTML = dateText;

        for (var j = 0; j < events.length; j += 1) {
            if (events[j].date == date.getDate()) {
                dateInfo.innerHTML = events[j].hour + ' ' + events[j].title;
            }
        }

        container.appendChild(dateContainer);
        date.setDate(date.getDate() + 1);
    }

    container.addEventListener('mouseover', function (ev) {
        var target = ev.target;

        if (target.parentElement.className === 'dateContainer') {
            if (target.className !=='dateTitle') {
                target.previousElementSibling.style.backgroundColor = '#B6E3F2';
                return;
            }
            target.style.backgroundColor = '#B6E3F2';
        }
    });
    container.addEventListener('mouseout', function (ev) {
        var target = ev.target;

        if (target.parentElement.className === 'dateContainer') {
            if (target.className !== 'dateTitle') {
                target.previousElementSibling.style.backgroundColor = 'gray';
                return;
            }
            target.style.backgroundColor = 'gray';
        }
    });

    container.addEventListener('click', function (ev) {
        var target = ev.target;
        if (prevClickedElement) {
            prevClickedElement.parentElement.style.backgroundColor = 'white';
        }
        prevClickedElement = target;

        if (target.parentElement.className === 'dateContainer') {
            target.parentElement.style.backgroundColor = '#B6E3F2';
        }
    });
}