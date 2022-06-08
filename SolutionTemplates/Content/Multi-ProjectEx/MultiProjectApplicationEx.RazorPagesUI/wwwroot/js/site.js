$(document).ready(function () {
    setActive();
});

function setActive() {
    document.querySelectorAll(".nav-link").forEach(link => {
        if (location.href === link.href || location.href.includes(link.href + "/")) {
            link.classList.add("active");
        }
    });
}