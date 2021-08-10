function uploadAvatar(e) {
    var logoString = document.querySelector('input[name="ProfileAvatar"]').value;
    var img = document.getElementById('profileAvatar');
    img.src = logoString;
}