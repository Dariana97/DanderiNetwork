// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function formatInputPhoneNumber(input) {
    var value = input.value.replace(/[^0-9]/g, '');

    if (value.length > 0) {
        value = value.replace(/^(\d{3})/, '$1-');
    }
    if (value.length > 4) {
        value = value.replace(/^(\d{3})-(\d{3})/, '$1-$2-');
    }
    if (value.length > 8) {
        value = value.replace(/^(\d{3})-(\d{3})-(\d{4})/, '$1-$2-$3');
    }

    input.value = value;
}