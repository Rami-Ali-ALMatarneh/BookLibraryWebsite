let ServiceBox = document.querySelectorAll(".ServiceBox ");
let toUp = document.querySelector(".toUp");
//////////////////////////////////////////
let CountNumber = document.getElementById("CountNumbers");
let countN = document.querySelectorAll(".numbers");
let flagCount = false;
window.onload = setAnimation();
function setAnimation() {
    window.onscroll = function () {
        if (window.scrollY > 50) {
            ServiceBox.forEach(function (e) {
                e.classList.add("goDownAnimation");
            })
        }
        if (window.scrollY > 200) {
            toUp.classList.add("toLeft");
            toUp.classList.remove("toRight");

        }
        else
        {
            toUp.classList.add("toRight");
            toUp.classList.remove("toLeft");

        }
        if (window.scrollY >= CountNumber.offsetTop -400) {
            if (!flagCount) {
                countN.forEach((e) => {
                    countingNumber(e);
                    flagCount = true;
                });
            }
        }
    }
}
function countingNumber(e) {
    let goal = e.dataset.numbers;
    let InitialNum = 0;
    let count = setInterval(() => {
        if (InitialNum != goal) {
            e.innerHTML = InitialNum++;
        }
        else {
            clearInterval(count);
        }
    }, 2*0.10/goal);
}
toUp.onclick = function () {
    window.scrollTo(0,0);
}