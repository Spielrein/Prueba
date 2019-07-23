$(document).ready(function () {
    LoadDatatable();
});

function LoadDatatable() {
    var table = $('#Admins').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página.",
            "zeroRecords": "Lo sentimos. No se encontraron registros.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros aún.",
            "infoFiltered": "(filtrados de un total de _MAX_ registros)",
            "search": "Búsqueda",
            "LoadingRecords": "Cargando ...",
            "Processing": "Procesando...",
            "SearchPlaceholder": "Comience a teclear...",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente",
            }
        },
        "scrollY": 300,
        "scrollX": true,
        "ajax": {
            "method": "POST",
            "url": "http://192.168.99.130:59538/Api/Admin/Show",
            dataSrc: ''
        },
        "columns": [
            {
                'aTargets': [0],
                'bSortable': true,
                'mData': "name",
                "width": "20%"
            },
            {
                'aTargets': [1],
                'bSortable': true,
                'mData': "lastNameP",
                "width": "20%"
            },
            {
                'aTargets': [2],
                'bSortable': true,
                'mData': "lastNameM",
                "width": "20%"
            },
            {
                'aTargets': [3],
                'bSortable': true,
                'mData': "users",
                "width": "20%"
            },
            {
                'aTargets': [4],
                'bSortable': true,
                'mData': "pass",
                "width": "20%"
            },
            {
                'aTargets': [5],
                'bSortable': true,
                'mData': "institutionName",
                "width": "20%"
            },
            {
                "mRender": function (param, type, full) {
                    return "<center><a class='btn btn-warning' role='button' aria-pressed='true' id='Editar' alt='Editar'><i class='fa fa-pencil-square-o'></i></a>";
                }
            }
        ]
    });

    table.on('click', '#Editar', function () {
        var objecDtos = table.row($(this).parents('tr')).data();
        var id = objecDtos.adminsID;
        localStorage.setItem("id", id);
        var a = localStorage.getItem("id");
        window.location.href = "ShowProfile?id=" + a;
       
    });
}



