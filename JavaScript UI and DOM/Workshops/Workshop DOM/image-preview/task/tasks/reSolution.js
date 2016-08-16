function solve() {
    return function (selector, items) {
        selector = document.querySelector(selector);

        var rightContainer = document.createElement('ul'),
            filterTitle = document.createElement('label'),
            filterInput = document.createElement('input'),
            filterContainer = document.createElement('div'),
            previewContainer = document.createElement('div'),
            previewTitle = document.createElement('strong'),
            previewImage = document.createElement('img');
            len = items.length;

        // Preview image

        previewImage.style.width = '350px';
        previewImage.style.height = '250px';
        previewImage.src = items[0].url;

        previewTitle.innerHTML = items[0].title;

        previewContainer.className += ' image-preview';
        previewContainer.appendChild(previewTitle);
        previewContainer.appendChild(previewImage);

        // Filter box
        filterTitle.innerHTML = 'Filter';

        filterContainer.appendChild(filterTitle);
        filterContainer.appendChild(filterInput);

        rightContainer.style.listStyleType = 'none';

        // Items collection
        for (var i = 0; i < len; i += 1) {
            var item = document.createElement('li'),
                title = document.createElement('strong'),
                image = document.createElement('img');

            title.innerHTML = items[i].title;
            title.display = 'table-cell';
            title.style.verticalAlign = 'top';

            item.className += 'image-container';
            item.style.width = '250px';
            item.style.height = '120px';
            item.style.border = '1px solid black';
            item.style.marginBottom = '10px';

            image.style.width = '200px';
            image.style.height = '100px';
            image.src = items[i].url;
            image.style.display = 'table-cell';
            image.style.borderRadius = '12px';

            item.appendChild(title);
            item.appendChild(image);

            rightContainer.appendChild(item);
        }
        selector.appendChild(rightContainer);
        selector.appendChild(previewContainer);
        selector.appendChild(filterContainer);

        filterInput.addEventListener('input', function(ev){
            var searchText = ev.target.value.toLowerCase().trim(),
                imageDivs = rightContainer.childNodes;

            for(var i = 0; i < items.length; i += 1) {
                var title = imageDivs[i].firstElementChild.innerHTML.toLowerCase();

                if(title.includes(searchText)){
                    imageDivs[i].style.display = '';
                }
                else{
                    imageDivs[i].style.display = 'none';
                }
            }
        });

        rightContainer.addEventListener('click', function(ev) {
            var hoveredItem = ev.target;

            if(hoveredItem.parentElement.className.includes('image-container')){
                previewImage.src = hoveredItem.parentElement.lastElementChild.src;
                previewTitle.innerHTML = hoveredItem.parentElement.firstElementChild.innerHTML;
            }
        });

        rightContainer.addEventListener('mouseover', function(ev) {
            var hoveredItem = ev.target;

            if(hoveredItem.parentElement.className.indexOf('image-container') >= 0){
                hoveredItem.parentElement.style.backgroundColor = 'gray';
            }
        });

        rightContainer.addEventListener('mouseout', function(ev) {
            var hoveredItem = ev.target;

            if(hoveredItem.parentElement.className.indexOf('image-container') >= 0){
                hoveredItem.parentElement.style.backgroundColor = 'white';
            }
        });
    };
}