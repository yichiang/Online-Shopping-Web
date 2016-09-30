$(document).ready(function () {
    $(".editFormForDepartment").addClass("hideAction");
    $(".editButtonForDepartment").click(function () {
        if ($(".editFormForDepartment").hasClass("hideAction")) {
            $(".editFormForDepartment").removeClass("hideAction");

        } else {
            $(".editFormForDepartment").addClass("hideAction");
        }
    });
});