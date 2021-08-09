var Id;
var addressLocation;
var departmentName;
var companyName;
var deletedOn;

$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true,
        dom: 'frtipP',
        responsive: true,
    });
});

$('#deleteModal,#restoreModal').on('show.bs.modal', function (e) {

    Id = $(e.relatedTarget).data('departmentaddress-id');;
    addressLocation = $(e.relatedTarget).data('departmentaddress-addresslocation');
    departmentName = $(e.relatedTarget).data('departmentaddress-departmentname');
    companyName = $(e.relatedTarget).data('departmentaddress-companyname');
    deletedOn = $(e.relatedTarget).data('departmentaddress-deletedon');

    $(e.currentTarget).find('input[name="Id"]').val(Id);
    $(e.currentTarget).find('input[name="AddressLocation"]').val(addressLocation);
    $(e.currentTarget).find('input[name="DepartmentName"]').val(departmentName);
    $(e.currentTarget).find('input[name="CompanyName"]').val(companyName);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});