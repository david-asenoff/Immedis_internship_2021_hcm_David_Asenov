function uploadAvatar(e) {
    var logoString = document.querySelector('input[name="ProfileAvatar"]').value;
    var img = document.getElementById('profileAvatar');
    img.src = logoString;
    var logoString = document.querySelector('input[name="ProfileAvatar"]');
    var fReader = new FileReader();
    fReader.readAsDataURL(logoString.files[0]);
    fReader.onloadend = function (event) {
        var img = document.getElementById('profileAvatar');
        img.src = event.target.result;
    }
}