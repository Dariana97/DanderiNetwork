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

$(document).ready(function () {
    // Manejar el evento de clic en el elemento1
    $("#photo").click(function () {
        // Verificar si el elemento2 está oculto
        if ($("#video").is(":hidden")) {
            // Mostrar el elemento2 y ocultar el elemento1
            $("#video").show();
            $("#photo").show();
        } else {
            // Ocultar el elemento2 y mostrar el elemento1
            $("#video").hide();
            $("#photo").show();
        }
    });

    // Manejar el evento de clic en el elemento2
    $("#video").click(function () {
        // Verificar si el elemento1 está oculto
        if ($("#photo").is(":hidden")) {
            // Mostrar el elemento1 y ocultar el elemento2
            $("#photo").show();
            $("#video").show();
        } else {
            // Ocultar el elemento1 y mostrar el elemento2
            $("#photo").hide();
            $("#video").show();
        }
    });
});

function validarInputs(inputIds) {
    let cumpleRequisitos = true;

    inputIds.forEach(function (inputId) {
        const input = document.getElementById(inputId);
        const valor = input.value;

        const regexMayuscula = /[A-Z]/;
        const regexMinuscula = /[a-z]/;
        const regexDigito = /[0-9]/;
        const regexNoAlfanumerico = /[^a-zA-Z0-9]/;

        const cumpleRequisitosInput = valor.length >= 6 && regexMayuscula.test(valor) && regexMinuscula.test(valor) && regexDigito.test(valor) && regexNoAlfanumerico.test(valor);

        input.style.border = cumpleRequisitosInput ? '1px solid green' : '1px solid red';

        if (!cumpleRequisitosInput) {
            cumpleRequisitos = false;
        }
    });
}

const inputIds = ['passwordSign', 'ConfirmPassword']; // IDs de los inputs a validar

inputIds.forEach(function (inputId) {
    const input = document.getElementById(inputId);
    input.addEventListener('input', function () {
        validarInputs(inputIds);
    });
});

const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))