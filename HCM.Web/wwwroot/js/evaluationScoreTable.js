var evaluationScoreId;
var rate;
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

$('#editModal,#deleteModal,#restoreModal,#addModal').on('show.bs.modal', function (e) {
    evaluationScoreId = $(e.relatedTarget).data('evaluationscore-id');
    rate = $(e.relatedTarget).data('evaluationscore-rate');
    description = $(e.relatedTarget).data('evaluationscore-description');
    deletedOn = $(e.relatedTarget).data('evaluationscore-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(evaluationScoreId);
    $(e.currentTarget).find('input[name="Rate"]').val(rate);
    $(e.currentTarget).find('input[name="Description"]').val(description);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});