$(function () {
    $("#tblDepartmanlar").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinizden eöinmisiniz?", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    URL: "Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }


                });
            }

        })



    });
});


function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value == "") {
        $.ajax(dateElement).valid("false");
    }
    else {
        $.ajax(dateElement).valid();
    }
}