// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const clearForm = (inputCUIT, inputRazonSocial, inputTelefono, inputDireccion) => {
    inputCUIT.value = "";
    inputRazonSocial.value = "";
    inputTelefono.value = "";
    inputDireccion.value = "";
    
    //
    inputCUIT.removeAttribute("readonly"); 
    document.getElementById("buttonGetRazonSocial").removeAttribute("disabled");
    document.querySelectorAll(".text-danger").forEach(el => el.innerHTML = ""); 
    document.querySelectorAll(".is-invalid").forEach(el => el.classList.remove("is-invalid"));
    
};

export { clearForm };
