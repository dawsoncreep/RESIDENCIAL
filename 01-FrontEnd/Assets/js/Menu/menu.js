'use strict';
$(document).ready(function () {
    $('.dropdown-submenu a.toggle-submenu').on("click", function (e) {
        $(this).next('ul').toggle();
        e.stopPropagation();
        e.preventDefault();
    });
});