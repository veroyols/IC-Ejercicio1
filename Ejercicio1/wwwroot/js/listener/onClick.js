// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const backend = "https://localhost:7109/Client/GetNombreByCuit?cuit=";

let init = {
    method: 'GET',
    headers: {
        'Content-Type': 'application/json',
        'Permissions-Policy': 'interest-cohort=()' // Agregar el encabezado Permissions-Policy
    }
}
const getRazonSocial = async (cuit) => {

    const response = await fetch(`https://localhost:7109/Client/GetNombreByCuit?cuit=${cuit}`, init);

    const data = await response.json();
    return data;
};

document.addEventListener("DOMContentLoaded", () => {
    const btnGetRazonSocial = document.getElementById("buttonValidarCuit");
    const btnSaveInBd = document.getElementById("buttonCreateFormSubmit");


    const inputRazonSocial = document.getElementById("inputRazonSocial");
    const inputCUIT = document.getElementById("inputCuit");
    const inputTelefono = document.getElementById("inputTelefono");
    const inputDireccion = document.getElementById("inputDireccion");
    const inputActive = document.getElementById("inputActive");



    btnGetRazonSocial.addEventListener("click", async () => {
        const cuit = document.getElementById("inputCuit").value.trim();

        if (!/^\d{11}$/.test(cuit)) {
            alert("El CUIT debe contener exactamente 11 dígitos.");
            return;
        }

        const razonSocial = await getRazonSocial(cuit);
        inputRazonSocial.value = razonSocial.nombre;
        inputCUIT.setAttribute("readonly", "true");

        inputTelefono.removeAttribute("readonly");
        inputDireccion.removeAttribute("readonly");
        inputActive.removeAttribute("disabled");

        btnSaveInBd.disabled = false;
    });


    btnSaveInBd.addEventListener("click", async () => {
        
    });
});
