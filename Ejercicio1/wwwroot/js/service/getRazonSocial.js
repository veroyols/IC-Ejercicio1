// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import { API_BASE_URL } from "../config.js";

const getRazonSocial = async (cuit) => {
    console.log(cuit);

    const backendUrl = `${API_BASE_URL}/GetNombreByCuit?cuit=`;

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
