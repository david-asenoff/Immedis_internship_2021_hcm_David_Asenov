function checkMailDublicate(event) {

    var emailString = event.value;
    var errorMessage = document.getElementById(`emailSpan`);


    if (emailString.includes('@')) {
        //const token = document.querySelector('input[name=__RequestVerificationToken]').value;
        $.ajax({
            url: "/Home/DoesUserEmailExist",
            data: { email: emailString },
            datatype: "json",
            //headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {

                if (response == false) {
                    errorMessage.innerText = 'Email is free';
                } else {
                    errorMessage.innerText = 'Email is already taken';
                }
            },
        })
    }
}
function checkUserNameDublicate(event) {

    var userNameString = event.value;
    var errorMessage = document.getElementById(`userNameSpan`);


    if (userNameString.length != 0) {
        //const token = document.querySelector('input[name=__RequestVerificationToken]').value;
        $.ajax({
            url: "/Home/DoesUserNameExist",
            data: { userName: userNameString },
            datatype: "json",
            //headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {

                if (response == false) {
                    errorMessage.innerText = 'Username is free';
                } else {
                    errorMessage.innerText = 'Username is already taken';
                }
            },
        })
    }
}
$(function () {
    $("time").each(function (i, e) {
        const dateTimeValue = $(e).attr("datetime");
        if (!dateTimeValue) {
            return;
        }

        const time = moment.utc(dateTimeValue).local();
        $(e).html(time.format('llll'));
        $(e).attr("title", $(e).attr("datetime"));
    });
});
// Add active class to the current "<a>" tag.
// Example: <a class="nav-link me-2 active" href="/Administrator/Currency">
(function () {
    var currentPage = document.URL.split("/").slice(-1).pop();
    var pages = document.querySelectorAll('#sidenav-main > ul > li.nav-item > a');
    for (var i = 0; i < pages.length; i++)
    {
        if (pages[i].href.split("/").slice(-1).pop() == currentPage) {
            pages[i].className += " active";
            break;
        }
    }
})();
