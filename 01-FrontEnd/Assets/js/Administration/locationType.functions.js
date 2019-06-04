'use strict'

$(document).ready(function () {
    console.log("EventType Create Script Funcions");

    $('.deleteLocationTypeButton').on('click', function (event) {
        console.log(event);
        event.preventDefault();
        setIdToDelete($(this).attr('iddelete'));
        showDeleteModal();
    });

});