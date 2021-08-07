var salaryId;
var paymentInterval;
var currencyDescription;
var grossSalary;
var netSalary;
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
    salaryId = $(e.relatedTarget).data('salary-id');
    paymentInterval = $(e.relatedTarget).data('salary-paymentinterval');
    currencyDescription = $(e.relatedTarget).data('salary-currencydescription');
    grossSalary = $(e.relatedTarget).data('salary-grosssalary');
    netSalary = $(e.relatedTarget).data('salary-netsalary');
    deletedOn = $(e.relatedTarget).data('salary-deletedon');

    $(e.currentTarget).find('input[name="Id"]').val(salaryId);
    $(e.currentTarget).find('input[name="PaymentIntervalType"]').val(paymentInterval);
    $(e.currentTarget).find('input[name="CurrencyDescription"]').val(currencyDescription);
    $(e.currentTarget).find('input[name="GrossSalary"]').val(grossSalary);
    $(e.currentTarget).find('input[name="NetSalary"]').val(netSalary);
    $(e.currentTarget).find('input[name="DeletedOn"]')?.val(deletedOn);
});