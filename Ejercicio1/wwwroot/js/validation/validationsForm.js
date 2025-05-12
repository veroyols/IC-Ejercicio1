// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const validateCUIT = (inputCUIT) => {
    const cuit = inputCUIT.value.trim();

    if (cuit.length !== 11 || isNaN(cuit)) {
        alert("Por favor, ingrese un CUIT antes de buscar la Razón Social.");
        inputCUIT.classList.add("is-invalid");
        return false;
    } else {
        inputCUIT.classList.remove("is-invalid");
        return true;
    }
}

export { validateCUIT };
