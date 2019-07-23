$(document).ready(function () {
    Insertar();
});
    
    var nombre="";
function Insertar() {
    var accion;
    var error;
    var msj;
        $('#SaveDegree').click(function () {
            nombre = document.getElementById("nombreGrado").value;
            if (nombre == "") {
                swal("Ingresa todos los campos");
                $('#nombreGrado').focus();

            }
            else{
                var oModel = {
                    "Nombre": $("#nombreGrado").val()
                }
                $.ajax({
                    "async": true,
                    "crossDomain": true,
                    "cache": false,
                    "method": "POST",
                    "url": "http://192.168.99.130:59538/Api/Degree/Create",
                    "data": JSON.stringify(oModel),
                    "contentType": "application/json"
                }).done(function (response) {
                    console.log(response);
                    swal("Grado guardado", "El grado fue guardado exitosamente", "success");
                    $("#nombreGrado").val("");
                    error = "Ninguno";
                    msj = "Funcionamiento correcto";
                    accion = "Registro de un nuevo grado";
                    Information(accion, error, msj);
                }).fail(function (jqXHR, textStatus, err) {
                    console.log(textStatus);
                    error = err + " " + textStatus + " " + jqXHR;
                    msj = "Administrador revisa el funcionamiento del portal";
                    Information(accion, error, msj);
                    swal("Existio un problema al guardar el grado", "Reintentelo más tarde");
                    $("#nombreGrado").val("");
                    accion = "Fallo Registro de un nuevo grado";
                });
            }

           
    });
   
 }

function Information(accion, error, msj) {
            var oModel = {
                "Accion": accion,
                "Error": error,
                "Msj":msj
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
   




