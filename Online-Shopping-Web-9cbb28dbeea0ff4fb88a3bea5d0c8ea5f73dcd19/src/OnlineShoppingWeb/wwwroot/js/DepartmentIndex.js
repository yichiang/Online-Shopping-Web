$(document).ready(function () {
    $(".editFormForDepartment").addClass("hideAction");
    $(".editButtonForDepartment").click(function () {
        if ($(this).next().hasClass("hideAction")) {
            $(this).next().removeClass("hideAction");

        } else {
            $(this).next().addClass("hideAction");
        }
    });
});