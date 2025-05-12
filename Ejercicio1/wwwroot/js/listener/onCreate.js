// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import { getRazonSocial } from "../service/getRazonSocial.js";

document.addEventListener("DOMContentLoaded", () => {
    
    const buttonClearForm = document.getElementById("buttonClearForm");
    buttonClearForm.addEventListener("click", () => {
        location.reload();
    });

    const buttonGetRazonSocial = document.getElementById("buttonGetRazonSocial");
    const inputRazonSocial = document.getElementById("inputRazonSocial");
    
    const inputCUIT = document.getElementById("inputCuit");
    
    const buttonCreateFormSubmit = document.getElementById("buttonCreateFormSubmit");

    buttonGetRazonSocial.addEventListener("click", async () => {
        const cuit = inputCUIT.value.trim();
        const spinnerGetRazonSocial = document.getElementById("spinner-validate-cuit");

        buttonGetRazonSocial.setAttribute("disabled", "true");
        spinnerGetRazonSocial.classList.remove("d-none");

        const razonSocial = await getRazonSocial(cuit);

        if (razonSocial) {
            inputCUIT.setAttribute("readonly", "true");
            inputRazonSocial.value = razonSocial.nombre;
            spinnerGetRazonSocial.classList.add("d-none");
            buttonGetRazonSocial.setAttribute("disabled", "true");
        }
    });
});
