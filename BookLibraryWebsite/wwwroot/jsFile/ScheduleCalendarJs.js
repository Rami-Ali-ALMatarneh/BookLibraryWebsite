let DaysOfWeek = document.querySelector(".DaysOfWeek");
let DaysOfMonth = document.querySelector(".DaysOfMonth");
let MonthYear = document.querySelector(".MonthYear");
let span = document.querySelectorAll(".groupDay span");

let countDay = setInterval(() => {
    let date = new Date();
    let numberDayOfMonth = date.getDate();
    let month = setNameMonth(date.getMonth());
    let year = date.getFullYear();
    /////////////////////////////
    let nameOfDay = setDayOfWeek(date.getDay());
    DaysOfWeek.innerHTML = nameOfDay;
    DaysOfMonth.innerHTML = numberDayOfMonth;
    MonthYear.innerHTML = month + " " + year;
    span.forEach((e) => {
        if (parseInt(e.innerHTML) == numberDayOfMonth) {
            e.classList.add("Check");
        }
    })
}, 1000);


function setDayOfWeek(num) {
    let name = "";
    switch (num) {
        case 0:
            name ="Sunday";
            break;
        case 1:
            name ="Monday";
            break;
        case 2:
            name ="Tuesday";
            break;
        case 3:
            name ="Wednesday";
            break;
        case 4:
            name ="Thursday";
            break;
        case 5:
            name ="Friday";
            break;
        case 6:
            name ="Saturday";
            break;
    }
    return name;
}
function setNameMonth(currentMonth) {
    var monthName = "";
    switch (currentMonth) {
        case 0:
            monthName = "January";
            break;
        case 1:
            monthName = "February";
            break;
        case 2:
            monthName = "March";
            break;
        case 3:
            monthName = "April";
            break;
        case 4:
            monthName = "May";
            break;
        case 5:
            monthName = "June";
            break;
        case 6:
            monthName = "July";
            break;
        case 7:
            monthName = "August";
            break;
        case 8:
            monthName = "September";
            break;
        case 9:
            monthName = "October";
            break;
        case 10:
            monthName = "November";
            break;
        case 11:
            monthName = "December";
            break;
    }
            return monthName;
}