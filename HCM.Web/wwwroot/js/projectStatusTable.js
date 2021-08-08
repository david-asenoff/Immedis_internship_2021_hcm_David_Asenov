var projectStatusId;
var projectName;
var projectStatusCategoryType;
var startDate;
var endDate;
var deletedOn;


$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true,
        dom: 'frtipP',
        responsive: true,
    });
});

$('#deleteModal,#restoreModal').on('show.bs.modal', function (e) {

    projectStatusId = $(e.relatedTarget).data('projectstatus-id');
    projectName = $(e.relatedTarget).data('projectstatus-projectname');
    projectId = $(e.relatedTarget).data('projectstatus-projectid');
    projectStatusCategoryType = $(e.relatedTarget).data('projectstatus-projectstatuscategorytype');
    projectStatusCategoryId = $(e.relatedTarget).data('projectstatus-projectstatuscategoryid');
    startDate = $(e.relatedTarget).data('projectstatus-startdate');
    endDate = $(e.relatedTarget).data('projectstatus-enddate');
    deletedOn = $(e.relatedTarget).data('projectstatus-deletedon');

    $(e.currentTarget).find('input[name="Id"]').val(projectStatusId);
    $(e.currentTarget).find('input[name="ProjectName"]').val(projectName);
    $(e.currentTarget).find('input[name="ProjectId"]').val(projectId);
    $(e.currentTarget).find('input[name="ProjectStatusCategoryType"]').val(projectStatusCategoryType);
    $(e.currentTarget).find('input[name="ProjectStatusCategoryId"]').val(projectStatusCategoryId);
    $(e.currentTarget).find('input[name="StartDate"]').val(startDate);
    $(e.currentTarget).find('input[name="EndDate"]').val(endDate);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});