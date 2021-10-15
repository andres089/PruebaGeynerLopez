$(function () {
    $("#div_message_error").hide();
    $("#lnkAdd").click(function () {
        EjecutarAjax(urlBase + "Factura/VentanaCrear", "GET", null, "printPartialModal", { title: "Crear Factura", url: urlBase + "Factura/Insertar", metod: "GET", func: "InsercionCorrecta", modalLarge: true });
    });
    setEventEdit();
});


function setEventEdit() {
    EstablecerToolTipIconos();
    $(".lnkEdit").click(function () {
        EjecutarAjax(urlBase + "Factura/Obtener", "GET", { id: $(this).data("id") }, "printPartialModal", { title: "Editar Factura", url: urlBase + "Factura/Actualizar", metod: "GET", func: "ActualizacionCorrecta", modalLarge: true });
    });
}
function InsercionCorrecta(rta) {

    $("#div_message_error").hide();
    if (rta.Correcto) {
        EjecutarAjax(urlBase + "Factura/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
        cerrarModal("modalCRUD");
        MostrarMensaje('Importante', 'Creación exitosa.', 'success');
    }
    else {
        MostrarMensaje('Importante', rta.Mensaje, 'error');
    }
}
function ActualizacionCorrecta(rta) {
    $("#div_message_error").hide();
    if (rta.Correcto) {
        EjecutarAjax(urlBase + "Factura/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
        cerrarModal("modalCRUD");
        MostrarMensaje('Importante', 'Edición exitosa.', 'success');
    }
    else {
        MostrarMensaje('Importante', rta.Mensaje, 'error');
    }
}