/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        selector = document.querySelector(selector);
        initialSuggestions = initialSuggestions || 0;

        var suggestionList = document.getElementsByClassName('suggestions-list')[0],
            inputField = document.getElementsByClassName('tb-pattern')[0],
            addBtn = document.getElementsByClassName('btn-add')[0],
            suggestions = suggestionList.children;

        // Adding initial suggestions
        for (var i = 0; i < initialSuggestions.length; i += 1) {

            addToSuggestionList(suggestionList, initialSuggestions[i]);
        }

        //Adding suggestions
        addBtn.addEventListener('click', function (ev) {
            var target = ev.target,
                len = suggestions.length,
                inputText = inputField.value.trim().toLowerCase();

            if (target.className === 'btn-add') {
                for (var i = 0; i < len; i += 1) {
                    if (suggestions[i].firstElementChild.innerHTML.toLowerCase() === inputText) {
                        inputField.value = '';
                        return;
                    }
                }
                addToSuggestionList(suggestionList, inputField.value);
                inputField.value = '';
            }
        });

        // Show suggestions for autocomplete
        inputField.addEventListener('input', function (ev) {
            var searchText = ev.target.value.toLowerCase().trim();

            for (var i = 0; i < suggestions.length; i += 1) {
                var title = suggestions[i].firstElementChild.innerHTML.toLowerCase();

                if (inputField.value === '') {
                    suggestions[i].style.display = 'none';
                }
                else if (title.includes(searchText)) {
                    suggestions[i].style.display = '';
                }
                else {
                    suggestions[i].style.display = 'none';
                }
            }
        });

        // Click on suggestion for autocomplete
        suggestionList.addEventListener('click', function (ev) {
            var target = ev.target;

            if (target.className === 'suggestion-link') {
                inputField.value = target.innerHTML;
            }
        });

        function addToSuggestionList(suggestionList, suggestion) {

            var li = document.createElement('li'),
                link = document.createElement('a'),
                element;

            // See if suggestion is contained within suggestionList
            for (var i = 0; i < suggestions.length; i += 1) {
                element = suggestions[i].firstElementChild.innerHTML.toLowerCase();

                if (element === suggestion.toLowerCase()) {
                    return;
                }
            }

            li.className = 'suggestion';
            li.style.display = 'none';
            link.href = '#';
            link.className = 'suggestion-link';
            link.innerHTML = suggestion;

            li.appendChild(link);
            suggestionList.appendChild(li);
        }
    };
}

module.exports = solve;