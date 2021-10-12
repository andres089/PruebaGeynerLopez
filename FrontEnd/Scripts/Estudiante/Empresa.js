$(function () {
    $("#div_message_error").hide();
    $("#lnkAdd").click(function () {
        EjecutarAjax(urlBase + "Empresa/VentanaCrear", "GET", null, "printPartialModal", { title: "Crear Empresa", url: urlBase + "Empresa/Insertar", metod: "GET", func: "InsercionCorrecta", modalLarge: true });
    });
    setEventEdit();
});
function Inicializar() {
    asignarSelect2();
    setCambioPais();
    setCambioDepartamento();
}
function setCambioPais() {
    $("#IdPais").change(function () {
        ConsultarDepartamentos($(this).val());
    });    
}
function setCambioDepartamento() {
    $("#IdDepartamento").change(function () {
        ConsultarMunicipios($(this).val());
    });
}
//Consulta los departamentos cuando el combo de pais cambia de opcion.
function ConsultarDepartamentos(IdPais) {
    if (IdPais != '') {
        EjecutarAjax(urlBase + "Empresa/ObtenerDepartamentos", "GET", { Id: IdPais }, "CargarDepartamentos", null);
    } else {
        $('#IdDepartamento').find('option').remove().end().append('<option value="">Seleccione...</option>').val('');
        $('#IdCiudad').find('option').remove().end().append('<option value="">Seleccione...</option>').val('');
    }
}
//Carga los departamentos cuando el combo de pais cambia de opcion.
function CargarDepartamentos(data) {
    //Se remueven todos los items de la lista de ubicacion y se deja solo la opcion todas.
    $('#IdDepartamento').find('option').remove().end().append('<option value="">Seleccione...</option>').val('');

    //Se agregan los items que vienen en la variable data.
    var listitems = "";
    $.each(data, function (key, value) {
        listitems += '<option value=' + value.IdValorDiccionario + '>' + value.Valor + '</option>';
    });
    $('#IdDepartamento').append(listitems);
}
function ConsultarMunicipios(IdDepartamento) {
    if (IdDepartamento != '') {
        EjecutarAjax(urlBase + "Empresa/ObtenerMunicipios", "GET", { Id: IdDepartamento }, "CargarMunicipios", null);
    } else {
        $('#IdCiudad').find('option').remove().end().append('<option value="">Seleccione...</option>').val('');
    }
}
//Carga los departamentos cuando el combo de pais cambia de opcion.
function CargarMunicipios(data) {
    //Se remueven todos los items de la lista de ubicacion y se deja solo la opcion todas.
    $('#IdCiudad').find('option').remove().end().append('<option value="">Seleccione...</option>').val('');

    //Se agregan los items que vienen en la variable data.
    var listitems = "";
    $.each(data, function (key, value) {
        listitems += '<option value=' + value.IdValorDiccionario + '>' + value.Valor + '</option>';
    });
    $('#IdCiudad').append(listitems);
}
function setEventEdit() {
    EstablecerToolTipIconos();
    $(".lnkEdit").click(function () {
        EjecutarAjax(urlBase + "Empresa/Obtener", "GET", { id: $(this).data("id") }, "printPartialModal", { title: "Editar Empresa", url: urlBase + "Empresa/Actualizar", metod: "GET", func: "ActualizacionCorrecta", modalLarge: true });
    });
}
function InsercionCorrecta(rta) {

    $("#div_message_error").hide();
    if (rta.Correcto) {
        EjecutarAjax(urlBase + "Empresa/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
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
        EjecutarAjax(urlBase + "Empresa/CargarGrilla", "GET", null, "printPartial", { div: "#listView", func: "setEventEdit" });
        cerrarModal("modalCRUD");
        MostrarMensaje('Importante', 'Edición exitosa.', 'success');
    }
    else {
        MostrarMensaje('Importante', rta.Mensaje, 'error');
    }
}