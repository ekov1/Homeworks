var off = 0,
	txt = '',
	pX = 0,
	pY = 0,
	b = navigator.appName,
	addScroll = false;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
	(navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

// Not sure which event this line is using
if (b === 'Netscape') {
    document.captureEvents(Event.MOUSEMOVE);
}

document.onmousemove(function mouseMove(evn) {
    if (b === 'Netscape') {
        pX = evn.pageX - 5;
        pY = evn.pageY;

		if (document.layers.ToolTip.visibility === 'show') {
            PopTip();
        }
    } else {
        pX = event.x - 5;
        pY = event.y;

		if (document.all.ToolTip.style.visibility === 'visible') {
            PopTip();
        }
    }
});

function PopTip() {
    if (b === 'Netscape') {
        theLayer = eval('document.layers[\'ToolTip\']');
        if ((pX + 120) > window.innerWidth) {
            pX = window.innerWidth - 150;
        }
        theLayer.left = pX + 10;
        theLayer.top = pY + 15;
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'ToolTip\']');
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
    if (b === 'Netscape') {
        document.layers[obj].visibility = 'hide';
    } else {
        document.all[obj].style.visibility = 'hidden';
    }
}

function ShowMenu(menu) {
    if (b === 'Netscape') {
        theLayer = eval('document.layers[\'' + menu + '\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'' + menu + '\']');
        theLayer.style.visibility = 'visible';
    }
}