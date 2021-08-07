var departmentId
var name
var companyname
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

    departmentId = $(e.relatedTarget).data('department-id');
    name = $(e.relatedTarget).data('department-name');
    companyname = $(e.relatedTarget).data('department-companyname');
    deletedOn = $(e.relatedTarget).data('department-deletedon');

    $(e.currentTarget).find('input[name="Id"]').val(departmentId);
    $(e.currentTarget).find('input[name="Name"]').val(name);
    $(e.currentTarget).find('input[name="CompanyName"]').val(companyname);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});