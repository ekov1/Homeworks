(() => {
    let promise = new Promise(function (resolve, reject) {
        let redirectWebsite = 'http://www.staggeringbeauty.com';

        setTimeout(function () {
            resolve(redirectWebsite);
        }, 2000);
    });

    promise
        .then(website => window.location.href = website);

})();