var currencyId;
var abbreviation;
var description;
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
    currencyId = $(e.relatedTarget).data('currency-id');
    abbreviation = $(e.relatedTarget).data('currency-abbreviation');
    description = $(e.relatedTarget).data('currency-description');
    deletedOn = $(e.relatedTarget).data('currency-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(currencyId);
    $(e.currentTarget).find('input[name="Abbreviation"]').val(abbreviation);
    $(e.currentTarget).find('input[name="Description"]').val(description);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});