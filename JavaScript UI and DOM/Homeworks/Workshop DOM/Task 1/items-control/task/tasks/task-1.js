/* globals module, document, HTMLElement, console */

function solve() {
    return function (selector, isCaseSensitive) {
        var root = document.querySelector(selector),

            // Add div
            addingDiv = document.createElement('div'),
            addingInput = document.createElement('input'),
            addingLabel = document.createElement('label'),
            addingButton = document.createElement('button'),
            searchElementDiv = document.createElement('div'),
            searchLabel = document.createElement('label'),
            searchInput = document.createElement('input'),
            resultDiv = document.createElement('div'),
            resultUl = document.createElement('ul');


        addingDiv.className = 'add-controls';
        isCaseSensitive = !!isCaseSensitive;

        addingDiv.appendChild(addingLabel);
        addingLabel.innerHTML = 'Enter text:';
        addingDiv.appendChild(addingInput);

        addingDiv.appendChild(addingButton);
        addingButton.className = 'button';
        addingButton.innerHTML = 'Add';
        root.appendChild(addingDiv);

        addingButton.addEventListener('click', function () {
            var li = document.createElement('li'),
                xButton = document.createElement('button');

            li.className = 'list-item';
            li.innerHTML = addingInput.value;

            xButton.className = 'button';
            xButton.innerHTML = 'X';

            li.appendChild(xButton);
            resultUl.appendChild(li);
        });

        // Search div

        searchElementDiv.className = 'search-controls';
        searchElementDiv.appendChild(searchLabel);
        searchLabel.innerHTML = 'Search';
        searchElementDiv.appendChild(searchInput);

        root.appendChild(searchElementDiv);

        searchInput.addEventListener('input', function () {
            var child = resultUl.getElementsByTagName('li'),
                len = child.length,
                search = searchInput.value, i;

            search = search.replace(/\s\s+/g, ' ');
            if (!isCaseSensitive) {
                search = search.toLowerCase();

                // TODO: Regex for Test A

                for (i = 0; i < len; i += 1) {
                    if (child[i].innerHTML.toLowerCase().includes(search)) {
                        child[i].style.display = '';
                    }
                    else {
                        child[i].style.display = 'none';
                    }
                }
            }
            else {
                for (i = 0; i < len; i += 1) {
                    if (child[i].innerHTML.includes(search)) {
                        child[i].style.display = '';
                    }
                    else {
                        child[i].style.display = 'none';
                    }
                }
            }

        }, false);

        // Result div
        resultDiv.className = 'result-controls';
        resultDiv.appendChild(resultUl);
        resultUl.className = 'items-list';

        root.appendChild(resultDiv);

        resultUl.addEventListener('click', function (ev) {
            var buttonClicked = ev.target,
                li = buttonClicked.parentElement;

            li.parentElement.removeChild(li);
        });
    };
}

