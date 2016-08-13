/* globals module */
function solve() {
    return function (selector, items) {

        selector = document.querySelector(selector);

        var rightDiv = document.createElement('div'),
            leftDiv = document.createElement('div'),
            filterDiv = document.createElement('div');

        // Right div

        for (var i = 0; i < items.length; i += 1) {
            var li = formatImage(items[i]);
            rightDiv.appendChild(li);
        }

        function formatImage(item) {
            var title = document.createElement('strong'),
                image = document.createElement('img'),
                container = document.createElement('div');
            container.className = 'image-container';

            image.setAttribute('src', item.url);
            title.innerHTML = item.title;

            container.appendChild(title);
            container.appendChild(image);

            return container;
        }

        rightDiv.addEventListener('mouseover', function (ev) {
            var target = ev.target;

            if (target.parentNode.className === 'image-container') {
                target.parentElement.style.backgroundColor = 'gray';
            }
        });

        rightDiv.addEventListener('mouseout', function (ev) {
            var target = ev.target.parentElement;

            target.style.backgroundColor = '';
        });

        rightDiv.addEventListener('click', function (ev) {
            var li = ev.target.parentElement,
                title = li.firstElementChild.innerHTML,
                img = li.lastElementChild.src;

            leftDiv.firstElementChild.innerHTML = title;
            leftDiv.lastElementChild.src = img;
        });

        // Left div
        leftDiv.className = 'image-preview';

        var titleLeft = document.createElement('strong'),
            imageLeft = document.createElement('img');

        titleLeft.innerHTML = items[0].title;
        imageLeft.setAttribute('src', items[0].url);

        leftDiv.appendChild(titleLeft);
        leftDiv.appendChild(imageLeft);


        // Filter div

        var titleFilter = document.createElement('strong'),
            inputFilter = document.createElement('input');

        titleFilter.innerHTML = 'Filter';

        filterDiv.appendChild(titleFilter);
        filterDiv.appendChild(inputFilter);

        inputFilter.addEventListener('input', function (ev) {

            var searchText = ev.target.value;
            imageDivs = rightDiv.childNodes;

            searchText = searchText.replace(/\s\s+/g, ' ').toLowerCase().trim();

            for (var i = 0; i < items.length; i += 1) {

                if (searchText === ' ') {
                    imageDivs[i].style.display = '';
                }
                else {
                    var title = imageDivs[i].firstElementChild.innerText.toLowerCase();

                    if (title.includes(searchText)) {
                        imageDivs[i].style.display = '';
                    }
                    else {
                        imageDivs[i].style.display = 'none';
                    }
                }
            }
        }, false);

        // Appending all elements to root element
        selector.appendChild(rightDiv);
        selector.appendChild(leftDiv);
        selector.appendChild(filterDiv);
    };
}

module.exports = solve;