let ServiceBox = document.querySelectorAll(".ServiceBox ");
window.onload = setAnimation();
function setAnimation() {
    window.onscroll = function () {
        if (window.scrollY > 50) {
            ServiceBox.forEach(function (e) {
                e.classList.add("goDownAnimation");
            })
        }
    }
}