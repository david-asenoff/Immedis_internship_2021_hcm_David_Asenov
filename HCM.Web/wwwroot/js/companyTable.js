var companyId;
var name;
var email;
var phoneNumber;
var logo;
var aboutUs;
var deletedOn;

$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollX": true,
        "scrollCollapse": true,
        "paging": true,
        dom: 'frtipP',
        responsive: true,
    });
});

$('#deleteModal,#restoreModal').on('show.bs.modal', function (e) {
    companyId = $(e.relatedTarget).data('company-id');
    name = $(e.relatedTarget).data('company-name');
    email = $(e.relatedTarget).data('company-email');
    phoneNumber = $(e.relatedTarget).data('company-phonenumber');
    logo = $(e.relatedTarget).data('company-logo');
    aboutUs = $(e.relatedTarget).data('company-aboutus');
    deletedOn = $(e.relatedTarget).data('company-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(companyId);
    $(e.currentTarget).find('input[name="Name"]').val(name);
    $(e.currentTarget).find('input[name="Email"]').val(email);
    $(e.currentTarget).find('input[name="PhoneNumber"]').val(phoneNumber);
    $(e.currentTarget).find('input[name="Logo"]').val(logo);
    $(e.currentTarget).find('textarea[name="AboutUs"]').val(aboutUs);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});

function changeImg(e) {
    var logoString = document.querySelector('input[name="Logo"]').value;
    var img = document.getElementById('companylogo');
    img.src = logoString;
}