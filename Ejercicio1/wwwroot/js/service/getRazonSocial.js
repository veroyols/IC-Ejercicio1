// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//const backend = "/Client/GetNombreByCuit?cuit=";

const getRazonSocial = async (cuit) => {
    console.log(cuit);

    const backendUrl = "https://localhost:7109/Client/GetNombreByCuit?cuit=";

    let init = {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Permissions-Policy': 'interest-cohort=()' // Agregar el encabezado Permissions-Policy
        }
    }
    const response = await fetch(`${backendUrl}${cuit}`, init);
    console.log(response);

    const data = await response.json();
    return data;
};

export { getRazonSocial };
