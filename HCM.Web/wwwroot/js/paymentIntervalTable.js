var paymentIntervalId;
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
    paymentIntervalId = $(e.relatedTarget).data('paymentinterval-id');
    type = $(e.relatedTarget).data('paymentinterval-type');
    deletedOn = $(e.relatedTarget).data('paymentinterval-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(paymentIntervalId);
    $(e.currentTarget).find('input[name="Type"]').val(type);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});