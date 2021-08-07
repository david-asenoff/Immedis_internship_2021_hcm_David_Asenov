var genderId;
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
    genderId = $(e.relatedTarget).data('gender-id');
    type = $(e.relatedTarget).data('gender-type');
    deletedOn = $(e.relatedTarget).data('gender-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(genderId);
    $(e.currentTarget).find('input[name="Type"]').val(type);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});