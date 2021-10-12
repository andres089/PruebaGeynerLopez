$(function () {
    $("#div_message_error").hide();
    $("#lnkAdd").click(function () {
        EjecutarAjax(urlBase + "Vehiculo/VentanaCrear", "GET", null, "printPartialModal", { title: "Crear Vehiculo", url: urlBase + "Vehiculo/Insertar", metod: "GET", func: "InsercionCorrecta", modalLarge: true });
    });
    setEventEdit();
});
function Inicializar() {
    asignarSelect2();
    loadCalendar();
}
function setEventEdit() {
    EstablecerToolTipIconos();
    $(".lnkEdit").click(function () {
        EjecutarAjax(urlBase + "Vehiculo/Obtener", "GET", { id: $(this).data("id") }, "printPartialModal", { title: "Editar Vehiculo", url: urlBase + "Vehiculo/Actualizar", metod: "GET", func: "ActualizacionCorrecta", modalLarge: true });
    });
}
function InsercionCorrecta(rta) {
    $("#div_message_error").hide();
    if (rta.Correcto) {
        EjecutarAjax(urlBase + "Vehiculo/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
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
        EjecutarAjax(urlBase + "Vehiculo/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
        cerrarModal("modalCRUD");
        MostrarMensaje('Importante', 'Edición exitosa.', 'success');
    }
    else {
        MostrarMensaje('Importante', rta.Mensaje, 'error');
    }
}