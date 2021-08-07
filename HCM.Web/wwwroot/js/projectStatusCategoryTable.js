var projectStatusCategoryId;
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
    projectStatusCategoryId = $(e.relatedTarget).data('projectstatuscategory-id');
    type = $(e.relatedTarget).data('projectstatuscategory-type');
    deletedOn = $(e.relatedTarget).data('projectstatuscategory-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(projectStatusCategoryId);
    $(e.currentTarget).find('input[name="Type"]').val(type);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});