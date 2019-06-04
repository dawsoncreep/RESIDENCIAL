'use strict'

$(document).ready(function () {
    console.log("Permission Create Script Funcions");

    $('.deletePermissionButton').on('click', function (event) {
        console.log(event);
        event.preventDefault();
        setIdToDelete($(this).attr('iddelete'));
        showDeleteModal();
    });

});