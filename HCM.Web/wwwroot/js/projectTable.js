var projectId
var name
var description
var estimatedWorkHours
var finalWorkHours
var estimatedBudget
var finalBudget
var companyName
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

    projectId = $(e.relatedTarget).data('project-id');
    name = $(e.relatedTarget).data('project-name');
    description = $(e.relatedTarget).data('project-description');
    estimatedWorkHours = $(e.relatedTarget).data('project-estimatedworkhours');
    finalWorkHours = $(e.relatedTarget).data('project-finalworkhours');
    estimatedBudget = $(e.relatedTarget).data('project-estimatedbudget');
    finalBudget = $(e.relatedTarget).data('project-finalbudget');
    companyName = $(e.relatedTarget).data('project-companyname');
    deletedOn = $(e.relatedTarget).data('project-deletedon');

    $(e.currentTarget).find('input[name="Id"]').val(projectId);
    $(e.currentTarget).find('input[name="Name"]').val(name);
    $(e.currentTarget).find('textarea[name="Description"]').val(description);
    $(e.currentTarget).find('input[name="EstimatedWorkHours"]').val(estimatedWorkHours);
    $(e.currentTarget).find('input[name="FinalWorkHours"]').val(finalWorkHours);
    $(e.currentTarget).find('input[name="EstimatedBudget"]').val(estimatedBudget);
    $(e.currentTarget).find('input[name="FinalBudget"]').val(finalBudget);
    $(e.currentTarget).find('input[name="CompanyName"]').val(companyName);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});