(() => {
    var getLocation = new Promise(function (resolve, reject) {
        navigator.geolocation.getCurrentPosition(position => {
            resolve(position);
        });
    });

    function drawImage(position) {
        let lat = position.coords.latitude,
            long = position.coords.longitude;

        let imageSrc = 'https://maps.googleapis.com/maps/api/staticmap?center=' +
            lat + ',' + long + '&zoom=18&size=500x500&sensor=false';

        container = new google.maps.Map(document.getElementById('container'), {
                    center: { lat: lat, lng: long },
                    zoom: 18
                });
    }

    getLocation
        .then(drawImage);

})();