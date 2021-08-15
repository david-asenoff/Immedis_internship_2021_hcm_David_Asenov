var trainingId;
var name;
var description;
var deletedOn;
var startdate;
var enddate;
var totalhours;

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
    trainingId = $(e.relatedTarget).data('training-id');
    name = $(e.relatedTarget).data('training-name');
    description = $(e.relatedTarget).data('training-description');
    startdate = $(e.relatedTarget).data('training-startdate');
    enddate = $(e.relatedTarget).data('training-enddate');
    totalhours = $(e.relatedTarget).data('training-totalhours');
    deletedOn = $(e.relatedTarget).data('training-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(trainingId);
    $(e.currentTarget).find('input[name="Name"]').val(name);
    $(e.currentTarget).find('input[name="StartDate"]').val(startdate);
    $(e.currentTarget).find('input[name="EndDate"]').val(enddate);
    $(e.currentTarget).find('input[name="TotalHours"]').val(totalhours);
    $(e.currentTarget).find('textarea[name="Description"]').val(description);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});