'use strict';

$(document).ready(function () {
    console.log("External User Create Script Funcions");

    $('#idUrlImage').on('change', function () {
        readURL(this);
    });


    function readURL(input) {
        console.log(input);
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#idExternalUserPickImage').attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }


});