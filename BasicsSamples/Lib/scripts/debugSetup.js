document.addEventListener("DOMContentLoaded", () => {

    document.addEventListener('keydown', function (event) {

        if (event.key === '1' && event.altKey && event.ctrlKey) {
            $debugHelper.toggle(true);
        }

    });


});