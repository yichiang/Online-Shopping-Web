
        $(document).ready(function () {
            //window.scrollTo(0, parseInt($("#windowPostiton").val()));
            $(".own-btn-action").click(function (e) {
                e.preventDefault();
                $("#EventCommand").val($(this).val());
                $("form.SearchForm").submit();
            });

            $(".pageButton").click(function () {
                var pageRange = $(this).text();
                console.log(pageRange);
                if (pageRange === "All") {
                    console.log("All");

                    $("#TakeDisplayList").val($("#AllProductsCount").val());
                    $("#SkipDisplayList").val("0");

                } else {
                    var tempArray = pageRange.split("-");
                    console.log(tempArray);
                    $("#TakeDisplayList").val("5");
                    $("#SkipDisplayList").val(parseInt(tempArray) - 1);
                }
                $("form.addMoretoListForm").submit();

            });
        });