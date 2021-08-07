var addressId;
var locationstring;
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
    addressId = $(e.relatedTarget).data('address-id');
    locationstring = $(e.relatedTarget).data('address-location');
    deletedOn = $(e.relatedTarget).data('address-deletedon');
    $(e.currentTarget).find('input[name="Id"]').val(addressId);
    $(e.currentTarget).find('input[name="Location"]').val(locationstring);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});