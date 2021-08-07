var parentalStatusId;
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
    paymentIntervalId = $(e.relatedTarget).data('parentalstatus-id');
    type = $(e.relatedTarget).data('parentalstatus-type');
    deletedOn = $(e.relatedTarget).data('parentalstatus-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(paymentIntervalId);
    $(e.currentTarget).find('input[name="Type"]').val(type);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});