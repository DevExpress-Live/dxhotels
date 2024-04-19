let dotnetObjectReference = null;
let observer = null;
export function dxdrawerInitialize(dotnetRef, drawerElem, leftHamburgerSelector, rightHamburgerSelector, fullExpandWidth, leftSticky, rightSticky) {
    //debugger;
    dotnetObjectReference = dotnetRef;

    function isFullExpanded() { return fullExpandWidth == 0 || window.innerWidth >= fullExpandWidth; }
    function showDrawer(side) { drawerElem.classList.add(`show-drawer-${side}`); }
    function hideDrawer(side, sticky) { if (!sticky && !isFullExpanded()) drawerElem.classList.remove(`show-drawer-${side}`); }
    function toggleDrawer(side, sticky) {
        if (drawerElem.classList.contains(`show-drawer-${side}`))
            hideDrawer(side, sticky);
        else
            showDrawer(side);
    }

    if (leftHamburgerSelector) {
        document.querySelectorAll(":scope " + leftHamburgerSelector).forEach(t => {
            t.addEventListener('click', e => {
                e.preventDefault = true;
                toggleDrawer("left", leftSticky);
            });
        });
    }

    if (rightHamburgerSelector) {
        document.querySelectorAll(":scope " + rightHamburgerSelector).forEach(t => {
            t.addEventListener('click', e => {
                e.preventDefault = true;
                toggleDrawer("right", rightSticky);
            });
        });
    }

    if (isFullExpanded() || leftSticky)
        showDrawer("left");
    if (isFullExpanded() || rightSticky)
        showDrawer("right");
    if (dotnetObjectReference) {
        // doesn't work with Serverside statically rendered content
        var config = { attributes: true, attributeFilter: ['class'] };
        // Callback function to execute when mutations are observed
        var callback = function (mutationsList, observer) {
            for (let mutation of mutationsList) {
                if (mutation.type === 'attributes') {
                    dotnetObjectReference.invokeMethodAsync('JSDrawerAttributeChanged', mutation.attributeName, mutation.target.classList.value);
                }
            }
        };
        // Create an observer instance linked to the callback function
        observer = new MutationObserver(callback);
        // Start observing the target node for configured mutations
        observer.observe(drawerElem, config);
    }
    window.addEventListener('resize', e => {
        if (isFullExpanded()) {
            showDrawer("left");
            showDrawer("right");
        }
        else {
            hideDrawer("left", leftSticky);
            hideDrawer("right", rightSticky);
        }
    });
};

export function disposeDrawerObserver() {
    if (observer) {
        observer.disconnect();
        observer = null;
    }
}


