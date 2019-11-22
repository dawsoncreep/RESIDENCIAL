'use strict';

$(document).ready(function () {
    console.log("ExternalBinnacle Script Funcions");

    $('.binnacleDetails').on('click', function (event) {
        event.preventDefault();
        var BinnacleUrl = $(this).attr('href');
        console.log("Details Binnacle El id");
        console.log(BinnacleUrl);

        $.ajax({
            type: "GET",
            contentType: 'application/json;charset=utf-8',
            url: BinnacleUrl,
            dataType: "json",
            success: function (result) {
                //hideDeleteModal();
                console.log("Result binnacle details partial view");
                console.log(result);
                //if (!res.Response) {
                //    console.log("Error!");
                //} else {
                    console.log("Success!");
                $('#DetailsBinnacleModalBody').html(result);
                showBinnacleDetailsModal();
                //}
            },
            error: function (err) {
                console.log("Error !");
                console.log(err);

            }
        });

    });
 

});