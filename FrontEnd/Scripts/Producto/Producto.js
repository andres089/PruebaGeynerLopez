$(function () {
    $("#div_message_error").hide();
    $("#lnkAdd").click(function () {
        EjecutarAjax(urlBase + "Producto/VentanaCrear", "GET", null, "printPartialModal", { title: "Crear Producto", url: urlBase + "Producto/Insertar", metod: "GET", func: "InsercionCorrecta", modalLarge: true });
    });
    setEventEdit();
});


function setEventEdit() {
    EstablecerToolTipIconos();
    $(".lnkEdit").click(function () {
        EjecutarAjax(urlBase + "Producto/Obtener", "GET", { id: $(this).data("id") }, "printPartialModal", { title: "Editar Producto", url: urlBase + "Producto/Actualizar", metod: "GET", func: "ActualizacionCorrecta", modalLarge: true });
    });
}
function InsercionCorrecta(rta) {

    $("#div_message_error").hide();
    if (rta.Correcto) {
        EjecutarAjax(urlBase + "Producto/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
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
        EjecutarAjax(urlBase + "Producto/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
        cerrarModal("modalCRUD");
        MostrarMensaje('Importante', 'Edición exitosa.', 'success');
    }
    else {
        MostrarMensaje('Importante', rta.Mensaje, 'error');
    }
}