var pX = 0,
	pY = 0,
	navAppName = navigator.appName,
	addScroll = false,
	theLayer,
	navigator,
	event,
	NETSCAPE = 'Netscape';

if (navigator.userAgent.indexOf('MSIE 5') > 0 ||
	navigator.userAgent.indexOf('MSIE 6') > 0) {
    addScroll = true;
}

document.onmousemove = mouseMove;

// Not sure which event this line is using
if (navAppName === NETSCAPE) {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(ev) {
    if (navAppName === NETSCAPE) {
        pX = ev.pageX - 5;
        pY = ev.pageY;

    } else {
        pX = event.x - 5;
        pY = event.y;
    }

	if (document.layers.ToolTip.visibility === 'show' ||
		document.all.ToolTip.style.visibility === 'visible') {
		PopTip();
	}
}

function ShowToolTip() {

	var layerLeft,
		layerTop,
		offsetLeft = 10,
		offsetTop = 15,
		offsetWidth = 150,
		documentWidth;

	theLayer = document.layers.ToolTip || document.all.ToolTip;
	documentWidth = window.innerWidth || document.body.clientWidth;

	if (!theLayer) {
		return;
	}


	//----------------------------------------------------------------------------
    if (navAppName === NETSCAPE) {

        if ((pX + 120) > documentWidth) {
            pX = window.innerWidth - offsetWidth;
        }

        theLayer.left = pX + offsetLeft;
        theLayer.top = pY + offsetTop;
        theLayer.visibility = 'show';

    } else {

		pX = event.x - 5;
		pY = event.y;

		if (addScroll) {
			pX = pX + document.body.scrollLeft;
			pY = pY + document.body.scrollTop;
		}
		if ((pX + 120) > documentWidth) {
			pX = pX - offsetWidth;
		}

		theLayer.style.pixelLeft = pX + offsetLeft;
		theLayer.style.pixelTop = pY + offsetTop;
		theLayer.style.visibility = 'visible';
    }
	//----------------------------------------------------------------------------
}

// ToolTip, menu1 or menu2 can be hidden with command
function Hide(obj) {
    if (navAppName === NETSCAPE) {
        document.layers[obj].visibility = 'hide';
    } else {
        document.all[obj].style.visibility = 'hidden';
    }
}

// Can show either menu1 or menu2
function ShowMenu(menu) {
    if (navAppName === NETSCAPE) {

        theLayer = document.layers[menu];
        theLayer.visibility = 'show';
    } else {

        theLayer = document.all[menu];
        theLayer.style.visibility = 'visible';
    }
}