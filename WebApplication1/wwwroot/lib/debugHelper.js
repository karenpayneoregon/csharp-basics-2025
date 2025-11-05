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
    }

    function removeCss() {
        const style = document.getElementById(debugStyleId);
        if (style) {
            style.remove();
        } else {
        }
    }

    /*
     * Exposed functions
     */
    return {
        addCss: addCss,
        removeCss: removeCss
    };
}();