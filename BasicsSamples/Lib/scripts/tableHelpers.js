function toggleColumn() {
    document.querySelectorAll("table th:nth-child(2), table td:nth-child(2)")
        .forEach(el => {
            el.style.display = el.style.display === "none" ? "" : "none";
        });
}


document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("toggleDataButton").addEventListener("click", function () {
        toggleColumn();
        // Toggle icon class between bi-toggle-on and bi-toggle-off
        if (this.classList.contains("bi-toggle-on")) {
            this.classList.replace("bi-toggle-on", "bi-toggle-off");
        } else {
            this.classList.replace("bi-toggle-off", "bi-toggle-on");
        }
    });

});