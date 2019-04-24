'use strict'

$(document).ready(function () {
    console.log("Permission Create Script Funcions");

    $('.deletePermissionButton').on('click', function (event) {
        event.preventDefault();
        setIdToDelete($(this).attr('iddelete'));
        showDeleteModal();
    });


    $('#deleteItemButton').on('click', function (event) {
        event.preventDefault();
        console.log("El id");
        console.log(getIdToDelete());
        var obj = new Object();
        obj.id = getIdToDelete();

        $.ajax({
            type: "POST",
            contentType: 'application/json;charset=utf-8',
            url: $(this).attr('href'),
            data: JSON.stringify(obj),
            dataType: "json",
            success: function (res, stat) {
                hideDeleteModal();
                if (!res.Response) {
                    console.log("Error!");
                } else {
                    console.log("Success!");
                    location.reload();
                }
            },
            error: function (err) {
                console.log(err);

            }
        });
    });

});