'use strict';

var commonObj = {
    _idToDelete: 0
};


function setIdToDelete(id) {
    console.log(id);
    commonObj._idToDelete = id;
}

function getIdToDelete() {
    return commonObj._idToDelete;
}

function showDeleteModal(questionText) {
    $('#DeleteItemModal').modal('show');
}

function hideDeleteModal() {
    $('#DeleteItemModal').modal('hide');
}


$(document).ready(function () {
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

    $('.deleteButton').on('click', function (event) {
        console.log(event);
        event.preventDefault();
        setIdToDelete($(this).attr('iddelete'));
        showDeleteModal();
    });

});