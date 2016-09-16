(() => {
    var getLocation = new Promise(function (resolve, reject) {
        navigator.geolocation.getCurrentPosition(position => {
            resolve(position);
        });
    });

    function drawImage(position) {
        let lat = position.coords.latitude,
            long = position.coords.longitude,
            container = document.getElementById('container');

        let imageSrc = 'https://maps.googleapis.com/maps/api/staticmap?center=' +
            lat + ',' + long + '&zoom=18&size=500x500&sensor=false';

        container.src = imageSrc;
    }

    getLocation
        .then(drawImage);

})();