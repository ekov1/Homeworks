function solve() {

    return function (element, contents) {

        var after,
            toAppend = '';

        if (typeof element === 'string') {
            after = document.getElementById(element);
        }
        else if (element instanceof HTMLElement) {
            after = element;
        }
        else {
            throw Error('no');
        }

        if(!contents || contents.some(function (contElement) {
            return typeof contElement !== 'string' && typeof contElement !== 'number';
        })){
            throw Error('no');
        }

        after.innerHTML = '';

        var divElement;

        for (var i = 0; i < contents.length; i += 1) {
            divElement = document.createElement('div');
            divElement.innerHTML = contents[i];
            after.appendChild(divElement);
        }
    };
}