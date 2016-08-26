var event = (function () {
    function clickedButton() {
        var browserName = window.navigator.appCodeName,
            isMozilla = (browserName === 'Mozilla');

        if (isMozilla) {
            alert('You are running this script in Mozilla!');
        } else {
            alert('You are NOT running this script in Mozilla!');
        }
    }

    return {
        buttonClick: clickedButton
    };
} ());


