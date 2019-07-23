
$(document).ready(function () {
    LoadEducationLevel();
});

var valor;

function LoadEducationLevel() {
    $.ajax({
        url: "http://192.168.99.130:59538/Api/Institution/ShowEducationLevel",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {

            for (var i = 0; i < data.length; i++) {
               
                $("#nivelEdInstitucion").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");


            }


        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');
        }
    });
}