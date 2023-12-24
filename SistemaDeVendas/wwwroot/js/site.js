// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    function fillCPF(campo) {
        var valor = campo.value.replace(/\D/g, '');
    var padrao = /(\d{3})(\d{3})(\d{3})(\d{2})/;

    if (padrao.test(valor)) {
        campo.value = valor.replace(padrao, '$1.$2.$3-$4');
        } else {
        campo.value = valor;
        }
    }