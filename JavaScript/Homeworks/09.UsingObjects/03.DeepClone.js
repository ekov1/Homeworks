var object = [2, 3, 5, [2, 4, { name: john, age: 30 }, false], true];

function deepClone(object) {

    if (typeof object === 'object') {
        var obj = Array.isArray(object) ? [] : {};

        for (var i in object) {
            obj[i] = deepClone(obj[i]);
        }
        return obj;
    }
    else {
        return object;
    }
}