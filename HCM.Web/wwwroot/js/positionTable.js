var possitionId;
var name;
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
    possitionId = $(e.relatedTarget).data('position-id');
    name = $(e.relatedTarget).data('position-name');
    deletedOn = $(e.relatedTarget).data('position-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(possitionId);
    $(e.currentTarget).find('input[name="Name"]').val(name);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});