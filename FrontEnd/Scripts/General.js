$(function () {
    setNumeric();
    setDecimal();
    $("#btnSaveGeneric").click(function () {
        if (validarFormulario("modalCRUD .modal-body")) {
            EjecutarAjax($(this).data("url"), $(this).data("metod"), ObtenerObjeto("modalCRUD .modal-body form"), $(this).data("function"));
        }
    });
    ValidarEstadoPantalla();
});

function asignarSelect2() {
    $(".setSelect2").select2();
}

var Math1 = {
    min: function (values) {
        if (values.length == 0) {
            return NaN;
        } else if (values.length == 1) {
            var val = values.pop();
            if (typeof val == "number") {
                return val;
            } else {
                return NaN;
            }
        } else {
            var ss = values;
            var val = ss.pop();
            return Math.min(val, this.min(values))
        }
    },
    max: function (values) {
        if (values.length == 0) {
            return NaN;
        } else if (values.length == 1) {
            var val = values.pop();
            if (typeof val == "number") {
                return val;
            } else {
                return NaN;
            }
        } else {
            var ss = values;
            var val = ss.pop();
            return Math.min(val, this.max(values))
        }
    }
}
function setNumeric() {
    $(".numerico").keypress(function () {
        return EsNumero(event);
    });
}
function loadCalendar() {
    $(".calendario").datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $(".CalendarDateTime").datetimepicker({
        format: 'DD/MM/YYYY hh:mm A'
    });
}
function voidFunction() {

}
function setDecimal() {
    $(".decimal").keypress(function () {
        var valor = this.value;
        return decimalValidation(this, event)
        //return EsNumeroDecimal(event);
    });
    $(".decimal").focusout(function () {
        this.value = ValorDecimal(this.value);
    });
}
function formatNumber(num) {
    var numero = num.toString().replace('.', ',');
    return numero.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
}
function EsNumero(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function EsNumeroDecimal(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //Deja usar punto.
        if (charCode == 46) {
            return true;
        } else {
            return false;
        }
    }
    return true;
}
function EsTexto(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (!((charCode == 35) || (charCode == 8) || (charCode == 32) || (charCode == 45) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)))
        return false;
    return true;
}
function ObtenerObjeto(formulario) {
    return $("#" + formulario).serializeArray();
}
function mostrarAlerta(titulo, descripcion) {
    $(".alert-notification h4").html(titulo)
    $(".alert-notification p").html(descripcion)
    $(".alert-notification").show("fade", {}, 500, callbackShow);
    setTimeout(function () {
        $(".alert-notification").hide("fade", {}, 1000, callbackHide);
    }, 5000);
}
function callbackHide(div) {
    setTimeout(function () {
        $("#" + div).hide().fadeIn();
    }, 1000);
};
function callbackShow(div) {
    setTimeout(function () {
        $("#" + div).hide().fadeIn();
    }, 1000);
};
function printPartialModal(data, obj) {
    $("#btnCancelGeneric").show();
    $("#btnSaveGeneric").show();    
    $("#btnSaveGeneric").data("url", obj.url);
    $("#btnSaveGeneric").data("metod", obj.metod);
    $("#btnSaveGeneric").data("function", obj.func);
    $("#btnCancelGeneric").click(function () {
        cerrarModal('modalCRUD');
    });
    $("#modalCRUD .modal-dialog").removeClass("modal-lg");
    if (obj.modalLarge)
        $("#modalCRUD .modal-dialog").addClass("modal-lg");
    $("#modalCRUD .modal-title").html(obj.title);
    $("#modalCRUD .modal-body").html(data);
    if (obj.Table) {
        $("#datatable-responsive_1").DataTable();
        $("#modalCRUD .modal-dialog").css("width", 940);
    }
    if (obj.func2) {
        window[obj.func2](obj.param);
    }
    if (obj.DatePicker) {
        loadCalendar();
    }
    if (obj.TimePicker) {
        setTimePicker();
    }
    setNumeric();
    setDecimal();    
    abrirModal("modalCRUD");
}
function printPartial(data, values) {
    $(values.div).html(data);
    $(values.div).find("table").DataTable();
    $(values.div).find("table").on('draw.dt', function () {
        setEventEdit();
    });
    window[values.func]();
}
function abrirModal(nombre) {
    $("#" + nombre).modal({
        backdrop: "static",
        keyboard: false
    });
}
function iniciarProceso() {
    $(".loader-wrapper").css("display", "block");
    $("#div_message_error").hide();
}
function finalizarProceso() {
    $(".loader-wrapper").css("display", "none");
}
function cerrarModal(nombre) {
    $("#" + nombre).modal("hide");
    $("body").removeClass("modal-open");
    $(".modal-backdrop").remove();
}
function formatoMoneda(input) {
    var num = input.value.replace(/\./g, '');
    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        input.value = num;
    }
    else {
        alert('Solo se permiten numeros');
        input.value = input.value.replace(/[^\d\.]*/g, '');
    }
}
function validarObligatorios(formulario) {
    var requeridos = $("#" + formulario).find(".required");
    var correcto = true;
    var registros = 0;
    $("#" + formulario + " .errorValidate").removeClass("errorValidate");
    $.each(requeridos, function (index, value) {

        var grupo = $(this)[0].tagName;
        var tipo = $(this)[0].type;
        switch (grupo) {
            case "SELECT":
                if ($(this).val() === "") {
                    if ($(this).hasClass("setSelect2")) {
                        $(this).next().attr("data-mensajeerror", "Este campo es obligatorio");
                        $(this).next().addClass("errorValidate");
                        $(this).next().find(".select2-selection").addClass("errorValidate");
                    }
                    else {
                        $(this).attr("data-mensajeerror", "Este campo es obligatorio");
                        $(this).addClass("errorValidate");
                    }
                    correcto = false;
                }
                break;
            case "INPUT":
                switch (tipo) {
                    case "text":
                        if ($(this).val() === "") {
                            $(this).attr("data-mensajeerror", "Este campo es obligatorio");
                            $(this).addClass("errorValidate");
                            correcto = false;
                        }
                        break;
                }
                break;
            case "TEXTAREA":
                if ($(this).val() === "") {
                    $(this).attr("data-mensajeerror", "Este campo es obligatorio");
                    $(this).addClass("errorValidate");
                    correcto = false;
                }
                break;
        }
    });

    //Check-group
    var _listCheck = $("#" + formulario).find(".grpCheckBox");
    if (_listCheck.length > 0) {

        var obj = _listCheck.children().find("input:checkbox");
        if (obj.length > 0) {
            if (_listCheck.children().find("input:checkbox:checked").length == 0) {
                correcto = false;
                $(this).addClass("errorValidate");
            }
        }
    }


    return correcto;
}

function ValidarExprRegulares(formulario) {
    //valida la estructura del Email
    var _listEmail = $("#" + formulario).find(".email");
    var correcto = true;

    $.each(_listEmail, function (i, item) {

        $(this).removeClass("errorValidate");
        var grupo = $(this)[0].tagName;
        var tipo = $(this)[0].type;

        switch (grupo) {
            case "INPUT":
                switch (tipo) {
                    case "text":
                        if ($(this).val().length > 0) {
                            if (!validarEmail($(this).val())) {
                                $(this).attr("data-mensajeerror", "El Email es invalido");
                                $(this).addClass("errorValidate");
                                correcto = false;
                            }
                        } else {
                            if (this.classList.contains("required")) {

                                $(this).attr("data-mensajeerror", "Este campo es obligatorio");
                                $(this).addClass("errorValidate");
                                correcto = false;
                            }
                        }
                        break;
                }
                break;
        }

    });
    //validacion estructura Email  fin

    return correcto;
}

function validarFormulario(formulario, mostrarAdvertencia = true) {
    QuitarTooltip();
    var respuestas = [];
    respuestas.push(validarObligatorios(formulario));        
    respuestas.push(ValidarExprRegulares(formulario));
    respuestas.push(validarlongitud(formulario));
    mostrarTooltip();
    if ($.inArray(false, respuestas) !== -1 && mostrarAdvertencia) {
        MostrarMensaje("Importante", "Hay inconsistencias en el formulario, revise los campos demarcados con color rojo.", "error");
    }
    return $.inArray(false, respuestas) === -1;
}

function mostrarTooltip() {
    $(".errorValidate").mouseover(function () {
        if ($(this).attr("data-mensajeerror") !== undefined) {
            if ($(this).attr("data-mensajeerror").length > 0) {
                $(this).parent().append("<div class='tooltipError'>" + $(this).attr("data-mensajeerror") + "</div>");
                if ($(this).parent().prop("tagName") == "TD") {
                    $('.tooltipError').css('right', 'auto');
                    $('.tooltipError').css('top', 'auto');
                }
            }
        }
    });
    $(".errorValidate").mouseout(function () {
        $(this).parent().find(".tooltipError").remove();
    });
}
function QuitarTooltip() {
    $(".errorValidate").off("mouseover");
    $(".errorValidate").off("mouseout");

}
function EstablecerToolTipIconos() {
    var Add = $("#lnkAdd");
    var Edit = $(".lnkEdit");
    if (Add != null) {
        Add.attr("title", "Adicionar");
    }
    if (Edit != null) {
        Edit.attr("title", "Editar");
    }
}
function MostrarConfirm(Titulo, Mensaje, FuncionAceptar, value) {
    swal({
        title: Titulo,
        text: Mensaje,
        showCancelButton: true,
        closeOnConfirm: true,
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then(function () {
        window[FuncionAceptar](value);
    }).catch(swal.noop);
}

function MostrarMensaje(Titulo, Mensaje, Tipo) {
    var Type = "";

    if (Tipo != undefined) {
        Type = Tipo;
    }

    swal({
        title: Titulo,
        text: Mensaje,
        type: Type,
        allowOutsideClick: false,
        allowEscapeKey: false
    }).catch(swal.noop);
}
function validarlongitud(formulario) {
    var correcto = true;
    var rangos = $("#" + formulario).find(".longitud");
    $.each(rangos, function (index, value) {

        if ($(value).val().length <= parseInt($(value).data("minlong"))) {
            $(this).attr("data-mensajeerror", $(this).attr("data-mensaje"));
            $(this).addClass("errorValidate");
            correcto = false;
        }

    });
    return correcto;
}
//Funcion para validar letras y numeros.
function EsAlfaNumerico(inputtxt) {

    if ((event.charCode >= 48 && event.charCode <= 57) || // 0-9
        (event.charCode >= 65 && event.charCode <= 90) || // A-Z
        (event.charCode >= 97 && event.charCode <= 122))  // a-z
        return true;

    return false;
}
//Para formaterar a moneda.
function FormatoParaMoneda(Valor, ponersimbolopesos = true) {
    var decimals = 0;
    var decimal_sep = ",";
    var thousands_sep = ".";
    var n = Valor,
        c = isNaN(decimals) ? 2 : Math.abs(decimals), //if decimal is zero we must take it, it means user does not want to show any decimal
        d = decimal_sep || '.', //if no decimal separator is passed we use the dot as default decimal separator (we MUST use a decimal separator)

        t = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep, //if you don't want to use a thousands separator you can pass empty string as thousands_sep value

        sign = (n < 0) ? '-' : '',
        i = parseInt(n = Math.abs(n).toFixed(c)) + '',

        j = ((j = i.length) > 3) ? j % 3 : 0;

    if (ponersimbolopesos)
        return sign + '$ ' + (j ? i.substr(0, j) + t : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : '');
    else
        return sign + (j ? i.substr(0, j) + t : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : '');
}
function MostrarMensajeRedireccion(Titulo, Mensaje, UrlRedireccion, Tipo) {

    var Type = "";

    if (Tipo != undefined) {
        Type = Tipo;
    }

    swal({
        title: Titulo,
        text: Mensaje,
        showCancelButton: false,
        closeOnConfirm: true,
        type: Type,
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then(function () {
        if (UrlRedireccion != null) {
            if (urlBase.length > 1) {
                window.location = urlBase + UrlRedireccion;
            } else if (UrlRedireccion.substr(0, 1) == "/") {
                window.location = UrlRedireccion;
            } else {
                window.location = "/" + UrlRedireccion;
            }
        }

    }).catch(swal.noop);
}
//Validacion para dos decimales.
function decimalValidation(el, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var number = el.value.split('.');
    if (charCode == 8) {
        return true;
    }
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    //just one dot
    if (number.length > 1 && charCode == 46) {
        return false;
    }
    //get the carat position
    var caratPos = getSelectionStart(el);
    var dotPos = el.value.indexOf(".");
    if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
        return false;
    }
    return true;
}

function getSelectionStart(o) {
    return o.selectionStart
}

function ValorDecimal(valor) {
    var strResultado = "";
    if (valor.length > 0) {
        var number = valor.split('.');
        if (number.length > 1) {
            var partedecimal = number[1];
            if (partedecimal.length == 0) {
                strResultado = number[0] + '.00';
            } else if (partedecimal.length == 1) {
                strResultado = number[0] + '.' + partedecimal + '0';
            } else {
                strResultado = valor;
            }
        } else {
            strResultado = number;
        }
    }
    return strResultado;
}

//Funcion para validar letras, numeros y Espacio.
function EsAlfaNumericoEspacio(inputtxt) {

    if ((event.charCode >= 48 && event.charCode <= 57) || // 0-9
        (event.charCode >= 65 && event.charCode <= 90) || // A-Z
        (event.charCode >= 97 && event.charCode <= 122) ||
        (event.charCode == 32))   // a-z
        return true;

    return false;
}
function ReplaceAll(str, find, replace) {
    return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
}
function escapeRegExp(str) {
    return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
}
function EjecutarAjax(url, type, values, funcionSuccess, parameter) {
    iniciarProceso();
    $.ajaxSetup({ cache: false });

    $.ajax({
        ContentType: "application/json",
        url: url,
        type: type,
        data: values,
        success: function (data) {
            window[funcionSuccess](data, parameter);
            finalizarProceso()
        },
        error: function (jqXHR, exception) {
            finalizarProceso();
        }
    });
}
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
function ValidarEstadoPantalla() {
    var IdEstado = getCookie("EstadoPantalla");
    if (IdEstado.length > 0) {
        if (IdEstado == "1" && typeof $BODY != 'undefined') {
            if ($BODY.hasClass('nav-md')) {
                $SIDEBAR_MENU.find('li.active ul').hide();
                $SIDEBAR_MENU.find('li.active').addClass('active-sm').removeClass('active');
                $BODY.toggleClass('nav-md nav-sm');
            }
        }
    }
}
//Retorna la pagina anterior del navegador.
function Retroceder() {
    window.history.back();
}
function CaracterValido(control) {
    var caracteresInvalidos = ["<", ">", "*", "-", "{", "}", "'", "/"];
    for (var i = 0; i < caracteresInvalidos.length; i++) {
        $(control).val(ReplaceAll($(control).val(), caracteresInvalidos[i], ""));
    }
}
function SoloNumeros(control) {
    var self = $(control);
    var removedText = self.val().replace(/[^0-9]+/, '');
    self.val(removedText);
}