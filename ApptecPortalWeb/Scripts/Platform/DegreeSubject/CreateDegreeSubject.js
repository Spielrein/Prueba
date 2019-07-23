$(document).ready(function () {
    Insertar();
});

var materia = "";
var grado = "";
function Insertar() {
    var accion;
    var error;
    var msj;

    $('#saveSubjectDegree').click(function () {
        materia = document.getElementById("materiaId").value;
        grado = document.getElementById("gradoId").value;
        if (materia=="Seleccionar") {
            swal("Ingresa todos los campos");
            $('#materiaId').focus();

        } else if (grado == "Seleccionar") {
            swal("Ingresa todos los campos");
            $('#gradoId').focus();
        }
        else {
            var oModel = {
                "DegreeId": $("#gradoId").attr("selected", true).val(),
                "SubjectId": $("#materiaId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://192.168.99.130:59538/Api/DegreeSubject/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                swal("Asignación guardada", "La asignación fue guardada exitosamente", "success");
                $("#materiaId").val("Seleccionar");
                $("#gradoId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "asignacion de grado a una materia";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                swal("Existio un problema al guardar la asignación", "Reintentelo más tarde");
                $("#materiaId").val("Seleccionar");
                $("#gradoId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo asignacion de grado a materia";
                Information(accion, error, msj);
            });
        }
    });
}

function Information(accion, error, msj) {
    var oModel = {
        "Accion": accion,
        "Error": error,
        "Msj": msj
    }
    $.ajax({
        "async": true,
        "crossDomain": true,
        "cache": false,
        "method": "POST",
        "url": "http://192.168.99.130:59538/Api/Binnacle/Info",
        "data": JSON.stringify(oModel),
        "contentType": "application/json"
    }).done(function (response) {
        console.log(response);
    }).fail(function (jqXHR, textStatus, err) {
        console.log(textStatus);
    });
}




