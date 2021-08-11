var id;
var startDate;
var endDate;
var isApproved;
var isPaidLeave;
var createdOn;
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
    id = $(e.relatedTarget).data('requestedleave-id');
    startDate = $(e.relatedTarget).data('requestedleave-startdate');
    endDate = $(e.relatedTarget).data('requestedleave-enddate');
    isApproved = $(e.relatedTarget).data('requestedleave-isapproved');
    isPaidLeave = $(e.relatedTarget).data('requestedleave-ispaidleave');
    createdOn = $(e.relatedTarget).data('requestedleave-createdon');
    deletedOn = $(e.relatedTarget).data('requestedleave-deletedon');

    $(e.currentTarget).find('input[name="Id"]').val(id);
    $(e.currentTarget).find('input[name="StartDate"]').val(startDate);
    $(e.currentTarget).find('input[name="EndDate"]').val(endDate);
    $(e.currentTarget).find('input[name="IsApproved"]').val(isApproved);
    document.getElementsByName('IsPaidLeave')[1].checked = isPaidLeave == "True" ? true : false;
    $(e.currentTarget).find('input[name="CreatedOn"]').val(createdOn);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});