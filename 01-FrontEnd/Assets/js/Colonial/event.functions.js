'use strict';

$(document).ready(function () {
    console.log("Event Script Funcions");

    ExternalUserAttachmentRequired();
    $("#EventTypeId").on('change', function (event) {
        console.log($("#EventTypeId").val());
        ExternalUserAttachmentRequired();
    });


    function ExternalUserAttachmentRequired() {

        var url = $("#EventTypeId").attr('eventTypeCheck') + '/?eventTypeId=' + $("#EventTypeId").val();
        console.log(url);
        $.ajax({
            type: "GET",
            contentType: 'application/json;charset=utf-8',
            url: url,
            dataType: "json",
            success: function (result) {
                console.log("Eventttype result ");
                console.log(result);
                console.log("Success!");

                if (result === false) {
                    $("#externalUserDiv").hide();

                } else {

                    console.log(JSON.parse($("#lstJSONExternalsHidden").val()));

                    $('#lstJSONExternals').ddslick({
                        data: JSON.parse($("#lstJSONExternalsHidden").val()),
                        selectText: "Select an External User",
                        onSelected: function (selectedData) {
                            console.log(selectedData);
                            console.log(selectedData.selectedData.value);
                            $("#ExternalId").val(selectedData.selectedData.value);
                        }
                    });

                    $("lstJSONExternals").addClass("form-control btn btn-default dropdown-toggle");

                    $("#externalUserDiv").show();
                }

            },
            error: function (err) {
                console.log("Error !");
                console.log(err);

            }
        });

       


    }

});