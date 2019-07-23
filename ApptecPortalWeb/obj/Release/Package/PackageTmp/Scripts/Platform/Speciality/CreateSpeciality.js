$(document).ready(function () {
    Insertar();
});

var especialidad = "";
var institucion = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#saveSpeciality').click(function () {
        especialidad = document.getElementById("nombreEspecialidad").value;
        institucion = document.getElementById("institucionId").value;
        if (especialidad == "") {
            swal("Ingresa todos los campos");
            $('#nombreEspecialidad').focus();

        } else if (institucion == "Seleccionar") {
            swal("Ingresa todos los campos");
            $('#institucionId').focus();

        }
        else {
            var oModel = {
                "Nombre": $("#nombreEspecialidad").val(),
                "InstitucionId": $("#institucionId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://192.168.99.130:59538/Api/Speciality/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                swal("Especialidad guardada", "La especialidad fue guardada exitosamente", "success");
                $("#nombreEspecialidad").val("");
                $("#institucionId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de una especialidad";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                swal("Existio un problema al guardar la especialidad", "Reintentelo más tarde");
                $("#nombreEspecialidad").val("");
                $("#institucionId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de una especialidad";
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



