$(document).ready(function () {
    Insertar();
});

var clave = "";
var nombre = "";
var descripcion = "";
var institucion = "";
var tipoAula = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#SaveClassroom').click(function () {
        clave = document.getElementById("claveAula").value;
        nombre = document.getElementById("nombreAula").value;
        descripcion = document.getElementById("descripcionAula").value;
        institucion = document.getElementById("institucionId").value;
        tipoAula = document.getElementById("aulaId").value;
        if (clave == "") {
            swal("Ingresa todos los campos");
            $('#claveAula').focus();

        } else if (nombre == "") {
            swal("Ingresa todos los campos");
            $('#nombreAula').focus();

        } else if (descripcion == "") {
            swal("Ingresa todos los campos");
            $('#descripcionAula').focus();

        } else if (institucion == "Seleccionar") {
            swal("Ingresa todos los campos");
            $('#institucionId').focus();

        } else if (tipoAula == "Seleccionar") {
            swal("Ingresa todos los campos");
            $('#aulaId').focus();
        }
        else {
            var oModel = {
                "Clave":$("#claveAula").val(),
                "Nombre": $("#nombreAula").val(),
                "Descripcion": $("#descripcionAula").val(),
                "Institucion": $("#institucionId").attr("selected", true).val(),
                "TipoAula": $("#aulaId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://192.168.99.130:59538/Api/Classroom/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                //console.log(response);
                swal("Aula guardada", "El aula fue guardada exitosamente", "success");
                $("#claveAula").val("");
                $("#nombreAula").val("");
                $("#descripcionAula").val("");
                $("#institucionId").val("Seleccionar");
                $("#aulaId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de un aula";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                //console.log(textStatus);
                swal("Existio un problema al guardar el aula", "Reintentelo más tarde");
                $("#claveAula").val("");
                $("#nombreAula").val("");
                $("#descripcionAula").val("");
                $("#institucionId").val("Seleccionar");
                $("#aulaId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un aula";
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
        //console.log(response);
    }).fail(function (jqXHR, textStatus, err) {
        //console.log(textStatus);
    });
}







