// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import { validateCUIT } from "../validation/validationsForm.js";
import { clearForm } from "../utils/clearForm.js";
import { inputFormRazonSocial } from "../service/inputFormRazonSocial.js";

document.addEventListener("DOMContentLoaded", () => {

    const inputCUIT = document.getElementById("inputCuit");
    const inputRazonSocial = document.getElementById("inputRazonSocial");
    const inputTelefono = document.getElementById("inputTelefono");
    const inputDireccion = document.getElementById("inputDireccion"); 
    
    const buttonGetRazonSocial = document.getElementById("buttonGetRazonSocial");
    const spinnerGetRazonSocial = document.getElementById("spinner-validate-cuit");
        
    // limpiar formulario
    const buttonClearForm = document.getElementById("buttonClearForm");
    buttonClearForm.addEventListener("click", () => clearForm(inputCUIT, inputRazonSocial, inputTelefono, inputDireccion));
    
    // validaciones
    inputCUIT.addEventListener("input", () => validateCUIT(inputCUIT));

    // get
    buttonGetRazonSocial.addEventListener("click", () => {
        inputFormRazonSocial(inputCUIT, inputRazonSocial, buttonGetRazonSocial, spinnerGetRazonSocial);
    });
});
