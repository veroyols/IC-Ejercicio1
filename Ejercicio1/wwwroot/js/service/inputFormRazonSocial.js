// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import { validateCUIT } from "../validation/validationsForm.js";
import { getRazonSocial } from "./getRazonSocial.js";

const inputFormRazonSocial = async (inputCUIT, inputRazonSocial, buttonGetRazonSocial, spinnerGetRazonSocial) => {
        
        if (!validateCUIT(inputCUIT)) {
            return;
        }
        //cargando
        inputCUIT.setAttribute("readonly", "true");
        spinnerGetRazonSocial.classList.remove("d-none");
        buttonGetRazonSocial.setAttribute("disabled", "true");

        // devuelve "Razon Social"
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
    };

export { inputFormRazonSocial };
