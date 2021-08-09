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

    var searchInput = 'search_input';
    $(document).ready(function () {
        var autocomplete;
        autocomplete = new google.maps.places.Autocomplete((document.getElementById(searchInput)), {
            types: ['geocode'],
            /*componentRestrictions: {
             country: "USA"
            }*/
        });
        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            var near_place = autocomplete.getPlace();
        });
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