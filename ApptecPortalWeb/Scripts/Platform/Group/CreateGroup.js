$(document).ready(function () {
    Insertar();
});

var nombre = "";
function Insertar() {
    var accion;
    var error;
    var msj;
    $('#saveGroup').click(function () {
        nombre = document.getElementById("nombreGrupo").value;
        if (nombre == "") {
            swal("Ingresa todos los campos");
            $('#nombreGrupo').focus();

        }
        else {
            var oModel = {
                "Nombre": $("#nombreGrupo").val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://192.168.99.130:59538/Api/Group/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                swal("Grupo guardado", "El grupo fue guardado exitosamente", "success");
                $("#nombreGrupo").val("");
                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de un grupo";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                swal("Existio un problema al guardar el grupo", "Reintentelo más tarde");
                    $("#nombreGrupo").val("");
                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un grupo";
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




