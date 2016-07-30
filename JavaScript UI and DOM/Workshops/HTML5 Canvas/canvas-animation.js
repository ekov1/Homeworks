(function () {
    var theCanvas = document.getElementById("the-canvas-animation");
    var ctx = theCanvas.getContext("2d");

    ctx.lineWidth = 1;
    ctx.fillStyle = 'rgba(102, 25, 77, 0.7)';

    function quadraticCurve(ctx, s1, s2, c) {

        ctx.beginPath();
        ctx.moveTo(s1.x, s1.y);
        ctx.quadraticCurveTo(c.x, c.y, s2.x, s2.y);
        ctx.stroke();
    }

    var s1 = {
        x: 10,
        y: 10
    },
        s2 = {
            x: 500,
            y: 10
        },
        i = 0;

    function animation() {
        if (i >= 50) {
            ctx.clearRect(0, 0, theCanvas.width, theCanvas.height);
            ctx.moveTo(0, 0);
            i = 0;
        }

        var c = {
            x: i * 25,
            y: 200
        };
        i += 1;
        quadraticCurve(ctx, s1, s2, c);

        requestAnimationFrame(animation);

    }
    animation();
} ());