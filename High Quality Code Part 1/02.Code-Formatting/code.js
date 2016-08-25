var pX = 0,
	pY = 0,
	navAppName = navigator.appName,
	addScroll = false,
	theLayer,
	navigator,
	event;

if (navigator.userAgent.indexOf('MSIE 5') > 0 ||
	navigator.userAgent.indexOf('MSIE 6') > 0) {
    addScroll = true;
}

// Not sure which event this line is using
if (navAppName === 'Netscape') {
    document.captureEvents(Event.MOUSEMOVE);
}

document.onmousemove(function mouseMove(ev) {
	pX = ev.pageX - 5;
	pY = ev.pageY;

	ShowToolTip();
});

function ShowToolTip() {
    if (navAppName === 'Netscape') {

        theLayer = document.layers.ToolTip;

        if ((pX + 120) > window.innerWidth) {
            pX = window.innerWidth - 150;
        }

        theLayer.left = pX + 10;
        theLayer.top = pY + 15;
        theLayer.visibility = 'show';

    } else {
        theLayer = document.all.ToolTip;

        if (theLayer) {
            pX = event.x - 5;
            pY = event.y;

            if (addScroll) {
                pX = pX + document.body.scrollLeft;
                pY = pY + document.body.scrollTop;
            }
            if ((pX + 120) > document.body.clientWidth) {
                pX = pX - 150;
            }

            theLayer.style.pixelLeft = pX + 10;
            theLayer.style.pixelTop = pY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

// ToolTip, menu1 or menu2 can be hidden with command
function Hide(obj) {
    if (navAppName === 'Netscape') {
        document.layers[obj].visibility = 'hide';
    } else {
        document.all[obj].style.visibility = 'hidden';
    }
}

// Can show either menu1 or menu2
function ShowMenu(menu) {
    if (navAppName === 'Netscape') {

        theLayer = document.layers[menu];
        theLayer.visibility = 'show';
    } else {
		
        theLayer = document.all[menu];
        theLayer.style.visibility = 'visible';
    }
}