var employeeContractId;
var dmployeeFullName;
var departmentCompanyName;
var departmentName;
var startDate;
var endDate;

$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollX": true, 
        "scrollCollapse": true,
        "paging": true,
        dom: 'frtipP',
        responsive: true,
    });
});

$('#endModal').on('show.bs.modal', function (e) {
    employeeContractId = $(e.relatedTarget).data('employeecontract-id');
    dmployeeFullName = $(e.relatedTarget).data('employeecontract-employeefullname');
    departmentCompanyName = $(e.relatedTarget).data('employeecontract-company');
    departmentName = $(e.relatedTarget).data('employeecontract-department');
    startDate = $(e.relatedTarget).data('employeecontract-startdate');
    endDate = $(e.relatedTarget).data('employeecontract-enddate');

    $(e.currentTarget).find('input[name="contractId"]').val(employeeContractId);
    $(e.currentTarget).find('input[name="EmployeeFullName"]').val(dmployeeFullName);
    $(e.currentTarget).find('input[name="DepartmentCompanyName"]').val(departmentCompanyName);
    $(e.currentTarget).find('input[name="DepartmentName"]').val(departmentName);
    $(e.currentTarget).find('input[name="StartDate"]').val(startDate);
    $(e.currentTarget).find('input[name="EndDate"]')?.val(endDate === "" ? `It does not have an end date` : endDate);
});