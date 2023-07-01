let toUp = document.querySelector(".toUp");
window.onload = setAnimation();
function setAnimation() {

    window.onscroll = function () {

        if (window.scrollY > 200) {
            toUp.classList.add("toLeft");
            toUp.classList.remove("toRight");

        }
        else {
            toUp.classList.add("toRight");
            toUp.classList.remove("toLeft");

        }

    }
}

toUp.onclick = function () {
    window.scrollTo(0, 0, 0);    
}