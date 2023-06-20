﻿let dropDown = document.getElementById("dropListIcon");
let dropSpan = document.querySelectorAll(".dropListIcon span");
let flag = false;
dropDown.onclick = function () {
    if (flag == false) {
        dropSpan[0].classList.add("goDown");
        dropSpan[1].classList.add("dropHide");
        dropSpan[2].classList.add("goUp");
        /////////////////////////////////////
        dropSpan[0].classList.remove("backUp");
        dropSpan[1].classList.remove("dropView");
        dropSpan[2].classList.remove("backDown");
        flag = true;
    }
    else {
        dropSpan[0].classList.remove("goDown");
        dropSpan[1].classList.remove("dropHide");
        dropSpan[2].classList.remove("goUp");
        /////////////////////////////////////
        dropSpan[0].classList.add("backUp");
        dropSpan[1].classList.add("dropView");
        dropSpan[2].classList.add("backDown");
        flag = false;
    }
}