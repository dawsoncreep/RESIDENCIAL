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