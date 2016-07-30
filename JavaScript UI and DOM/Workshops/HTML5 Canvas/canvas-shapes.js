(function () {
    var canvas = document.getElementById('the-canvas-shapes'),
        ctx = canvas.getContext('2d');

    ctx.strokeStyle = '#22545F';
    ctx.fillStyle = '#90CAD7';
    ctx.lineWidth = 2;

    ctx.beginPath();
    ctx.moveTo(270, 220);
    ctx.arc(200, 220, 70, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();


    ctx.fillStyle = '#396693';
    ctx.strokeStyle = '#262626';
    ctx.save();

    ctx.beginPath();
    ctx.scale(2, 0.5);
    ctx.moveTo(150, 350);
    ctx.arc(100, 350, 50, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.restore();
    ctx.beginPath();
    ctx.moveTo(150, 160);
    ctx.lineTo(150, 30);
    ctx.lineTo(250, 30);
    ctx.lineTo(250, 160);
    ctx.fill();
    ctx.stroke();

    ctx.moveTo(150, 160);
    ctx.quadraticCurveTo(200, 180, 250, 160);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.scale(2, 0.5);

    ctx.moveTo(125, 60);
    ctx.arc(100, 60, 25, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    $('#wrapper').hover(function () {
        
        $('#the-canvas-shapes').toggle();
    });
} ());