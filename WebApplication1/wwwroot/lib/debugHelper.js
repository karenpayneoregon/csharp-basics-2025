var $debugHelper = $debugHelper || {};
$debugHelper = function () {

    /*
     * Location for styles to outline all elements on the page
     */
    var href = "css/debugger.css";

    const debugStyleId = "debugger-inline-style";

    function addCss() {
        if (document.getElementById(debugStyleId)) return; // prevent duplicates

        const style = document.createElement("style");
        style.id = debugStyleId;
        style.textContent = `
        * {
            outline: 1px solid red !important;
        }
        *:hover {
            outline: 2px solid blue !important;
        }
    `;
        document.head.appendChild(style);
        console.log("Debug CSS added inline.");
    }

    function removeCss() {
        const style = document.getElementById(debugStyleId);
        if (style) {
            style.remove();
            console.log("Debug CSS removed.");
        } else {
            console.log("Debug CSS not found.");
        }
    }

    /*
     * If development environment is true, then determine if debugger.css should be added or removed
     * for the current page.
     */
    var toggle = function (isDevelopmentEnvironment) {
        
        if (Boolean(isDevelopmentEnvironment)) {
            if (styleStyleIsLoaded(href) === true) {
                console.log("Remove");
                removeCss();
            } else {
                console.log("Add");
                addCss();
            }
        }
    }

    /*
     * Determines if debugger.css is loaded on the current page.
     */
    var styleStyleIsLoaded = function () {
        for (var index = 0, count = document.styleSheets.length; index < count; index++) {
            const sheet = document.styleSheets[index];
            if (!sheet.href) {
                continue;
            }
            if (sheet.href.includes(href)) {
                return true;
            }
        }

        return false;
    }

    /*
     * Exposed functions
     */
    return {
        addCss: addCss,
        removeCss: removeCss,
        isCSSLinkLoaded: styleStyleIsLoaded,
        toggle: toggle
    };
}();