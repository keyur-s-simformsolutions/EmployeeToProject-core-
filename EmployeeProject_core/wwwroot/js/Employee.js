AddData();
function AddData() {




    $.ajax({
        url: "/EmployeeToProject/EmployeeToProjectList/",
        data: {
            Search: $('#Search').val(),
            Sdate: $('#Sdate').val(),
            Edate: $('#Edate').val(),
            cPage: $('#curpageidx').val()
        },
        type: "POST",
     
        success: function (result) {
            //alert("success");
            $('.result').html(result);
            // window.location.href = "/Employee/Index";
        },
        error: function (errormessage) {
            //toastr.error("Oops!Something gone Wrong,data is not inserted", { timeOut: 3000 });
            //$('#myModal').modal('hide');

             alert(errormessage.responsetext);
        }
    });
}
$("#Submit").click(function () {
    AddData();
});
function Goto(index) {
    document.getElementById("curpageidx").value = index;
    AddData();

}
$(".clear-btn").on("click", function () {
    $("#Search").val('');
    $("#Sdate").val('');
    $("#Edate").val('');
    $("#curpageidx").val('');
    AddData();
});