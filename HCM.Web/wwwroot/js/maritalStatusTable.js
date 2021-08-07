var maritalStatusId;
var type;
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

$('#editModal,#deleteModal,#restoreModal,#addModal').on('show.bs.modal', function (e) {
    maritalStatusId = $(e.relatedTarget).data('maritalstatus-id');
    type = $(e.relatedTarget).data('maritalstatus-type');
    deletedOn = $(e.relatedTarget).data('maritalstatus-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(maritalStatusId);
    $(e.currentTarget).find('input[name="Type"]').val(type);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});