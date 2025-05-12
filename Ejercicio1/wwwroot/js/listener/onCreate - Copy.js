// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import { getRazonSocial } from "../service/getRazonSocial.js";
import { validateCUIT } from "../validation/validationsForm.js";

document.addEventListener("DOMContentLoaded", () => {
    
    const buttonClearForm = document.getElementById("buttonClearForm");

    const inputRazonSocial = document.getElementById("inputRazonSocial");
    const buttonGetRazonSocial = document.getElementById("buttonGetRazonSocial");
    const spinnerGetRazonSocial = document.getElementById("spinner-validate-cuit");
    
    const inputCUIT = document.getElementById("inputCuit");
    //const errorCuit = document.getElementById("errorCuit"); 
    const inputTelefono = document.getElementById("inputTelefono");
    const inputDireccion = document.getElementById("inputDireccion"); 

    buttonClearForm.addEventListener("click", () => {
        inputCUIT.value = "";
        inputRazonSocial.value = "";
        inputTelefono.value = "";
        inputDireccion.value = "";

        inputCUIT.removeAttribute("readonly"); 
        buttonGetRazonSocial.removeAttribute("disabled");

        document.querySelectorAll(".text-danger").forEach(el => el.innerHTML = "");
    });


    buttonGetRazonSocial.addEventListener("click", async () => {
        
        if (!validateCUIT(inputCUIT)) {
            return;
        }
        //cargando
        inputCUIT.setAttribute("readonly", "true");
        spinnerGetRazonSocial.classList.remove("d-none");
        buttonGetRazonSocial.setAttribute("disabled", "true");

        let razonSocial = await getRazonSocial(inputCUIT.value.trim());

        if (razonSocial && razonSocial.nombre) {
            inputRazonSocial.value = razonSocial.nombre;
            spinnerGetRazonSocial.classList.add("d-none");
        } else {
            console.log("no se encuentra razon social--------------");
            inputCUIT.removeAttribute("readonly"); 
            buttonGetRazonSocial.removeAttribute("disabled"); 
            spinnerGetRazonSocial.classList.add("d-none"); 
        }
    });
});
