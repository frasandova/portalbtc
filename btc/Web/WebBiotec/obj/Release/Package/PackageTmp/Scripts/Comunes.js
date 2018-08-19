//$(document).ready(function () {
//$("#linkResultadosLocales").click(function () {
//    alert('hola');

//    var oldData = $("#comboboxClientes").data('kendoDropDownList').dataSource.data();
//    var tamanocomboboxClientes = oldData.length;
//    while (tamanocomboboxClientes > 0) {
//        for (var i = 0; i < oldData.length; i++) {
//            $("#comboboxClientes").data('kendoDropDownList').dataSource.remove(oldData[i]);
//        }
//        oldData = $("#comboboxClientes").data('kendoDropDownList').dataSource.data();
//        tamanocomboboxClientes = oldData.length;
//    }
    
//});

//});


function eliminarItems (oldData) {

    $.each(oldData, function (i) {
        console.log(oldData[i]);
        $("#comboboxClientes").data('kendoDropDownList').dataSource.remove(oldData[i]);
    });

}

function MakeLoadClientes(codCanal,perfil,seleccion) {
   
    $.ajax({
        url: '/TradeMarketing/cargarCadenasClientesJSON',
        type: 'POST',
        dataType: 'json',
        data: {
            codCanal: codCanal,
            perfil: perfil
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        var oldData = $("#comboboxClientes").data('kendoComboBox').dataSource.data();
        var tamanocomboboxClientes = oldData.length;
        while (tamanocomboboxClientes > 0) {
            for (var i = 0; i < oldData.length; i++) {
                $("#comboboxClientes").data('kendoComboBox').dataSource.remove(oldData[i]);
            }
            oldData = $("#comboboxClientes").data('kendoComboBox').dataSource.data();
            tamanocomboboxClientes = oldData.length;
        }        if (seleccion=="TODOS") {
            $("#comboboxClientes").data('kendoComboBox').dataSource.add({ valor: '0', texto: 'TODOS' });
        } else {
            $("#comboboxClientes").data('kendoComboBox').dataSource.add({ valor: '0', texto: 'SELECCIONAR' });
        }
        
        $.each(data, function (i) {
            $("#comboboxClientes").data('kendoComboBox').dataSource.add({ valor: data[i].valor, texto: data[i].texto });
        });

        $("#comboboxClientes").data('kendoComboBox').value('0');

    });
}

function MakeLoadFacturas(CODCANAL, RUTCLIENTE) {

    $.ajax({
        url: '/TradeMarketing/LoadFacturasJson',
        type: 'POST',
        dataType: 'json',
        data: {
            CODCANAL: CODCANAL,
            RUTCLIENTE: RUTCLIENTE
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        var oldData = $("#comboboxNumeroDocumento").data('kendoComboBox').dataSource.data();
        var tamanocomboboxClientes = oldData.length;
        while (tamanocomboboxClientes > 0) {
            for (var i = 0; i < oldData.length; i++) {
                $("#comboboxNumeroDocumento").data('kendoComboBox').dataSource.remove(oldData[i]);
            }
            oldData = $("#comboboxNumeroDocumento").data('kendoComboBox').dataSource.data();
            tamanocomboboxClientes = oldData.length;
        }
        $("#comboboxNumeroDocumento").data('kendoComboBox').dataSource.add({ valor: '0', texto: 'SELECCIONAR' });
        $.each(data, function (i) {
            $("#comboboxNumeroDocumento").data('kendoComboBox').dataSource.add({ valor: data[i].numero_factura, texto: data[i].numero_factura });
        });

        $("#comboboxNumeroDocumento").data('kendoComboBox').value('0');
    });
}

function MakeGraficoVentas(CODCANAL, RUTCLIENTE, MES) {
    $.ajax({
        url: '/TradeMarketing/LoadGraficoVentas',
        type: 'POST',
        dataType: 'json',
        data: {
            CODCANAL: CODCANAL,
            RUTCLIENTE: RUTCLIENTE,
            MES: MES
        },
    })
    .fail(function (request, status, error) {
        alert("error:" + request.status);
    })
    .always(function (data) {

        var chart = AmCharts.makeChart("chartdivVentasMM",
                   {
                       "type": "serial",
                       "categoryField": "MES",
                       "thousandsSeparator": ".",
                       "colors": [
                           "#69B4DB",
                           "#D5DBDB",
                           "#B0DE09",
                           "#0D8ECF",
                           "#2A0CD0",
                           "#CD0D74",
                           "#CC0000",
                           "#00CC00",
                           "#0000CC",
                           "#DDDDDD",
                           "#999999",
                           "#333333",
                           "#990000"
                       ],
                       "startDuration": 1,
                       "categoryAxis": {
                           "gridPosition": "start"
                       },
                       "trendLines": [],
                       "graphs": [
                           {
                               "balloonText": "[[title]] of [[category]]:[[value]]",
                               "fillAlphas": 1,
                               "id": "AmGraph-1",
                               "title": data[0].ANO,
                               "type": "column",
                               "valueField": "VALOR",
                               "labelText": "[[value]]"
                           },
                           {
                               "balloonText": "[[title]] of [[category]]:[[value]]",
                               "fillAlphas": 1,
                               "id": "AmGraph-2",
                               "title": data[0].ANO_ANTERIOR,
                               "type": "column",
                               "valueField": "VALOR2",
                               "labelText": "[[value]]"
                           }
                       ],
                       "guides": [],
                       "valueAxes": [
                           {
                               "id": "ValueAxis-1",
                               //"title": "Axis title"
                           }
                       ],
                       "allLabels": [],
                       "balloon": {},
                       "legend": {
                           "enabled": true,
                           "useGraphSettings": true
                       },
                       "export": {
                           "enabled": true
                       },
                       "titles": [
                           {
                               "id": "Title-1",
                               "size": 15,
                               "text": ""
                           }
                       ],
                       "dataProvider": data
                   });


        //var chart = AmCharts.makeChart("chartdivVentasMM", {
        //    "theme": "light",
        //    "type": "serial",
        //    "categoryField": "MES",
        //    "dataDateFormat": "YYYYMM",
        //    "startDuration": 2,
        //    "thousandsSeparator": ".",
        //    "dataProvider": data,
        //    "valueAxes": [{
        //        "position": "left",                
        //    }],
        //    "graphs": [{
        //        "balloonText": "[[category]]: <b>[[value]]</b>",
        //        "fillColorsField": "color",
        //        "fillAlphas": 1,
        //        "lineAlpha": 0.1,
        //        "type": "column",
        //        "valueField": "VALOR",
        //        "labelText" : "[[value]]"                
        //    }],
        //    "depth3D": 20,
        //    "angle": 30,
        //    "chartCursor": {
        //        "categoryBalloonEnabled": false,
        //        "cursorAlpha": 0,
        //        "zoomable": false
        //    },
        //    "categoryField": "MES",
        //    "categoryAxis": {
        //        "gridPosition": "start",
        //        "labelRotation": 0
        //    },
        //    "export": {
        //        "enabled": true
        //    }

        //});


    });

}

function MakeGraficoProvisionFacturas(CODCANAL, RUTCLIENTE, MES) {
 
    $.ajax({
        url: '/TradeMarketing/LoadGraficoProvisionFacturas',
        type: 'POST',
        dataType: 'json',
        data: {
            CODCANAL: CODCANAL,
            RUTCLIENTE: RUTCLIENTE,
            MES: MES
        },
    })
    .fail(function (request, status, error) {
        alert("error:" + request.status);
    })
    .always(function (data) {
        var chart = AmCharts.makeChart("chartdivRelacionProvision",
                    {
                        "type": "serial",
                        "categoryField": "MES",
                        "thousandsSeparator": ".",
                        "colors": [
                            "#69B4DB",
                            "#D5DBDB",
                            "#B0DE09",
                            "#0D8ECF",
                            "#2A0CD0",
                            "#CD0D74",
                            "#CC0000",
                            "#00CC00",
                            "#0000CC",
                            "#DDDDDD",
                            "#999999",
                            "#333333",
                            "#990000"
                        ],
                        "startDuration": 1,
                        "categoryAxis": {
                            "gridPosition": "start"
                        },
                        "trendLines": [],
                        "graphs": [
                            {
                                "balloonText": "[[title]] of [[category]]:[[value]]",
                                "fillAlphas": 1,
                                "id": "AmGraph-1",
                                "title": "Presupuestado",
                                "type": "column",
                                "valueField": "PROVISION",
                                "labelText" : "[[value]]" 
                            },
                            {
                                "balloonText": "[[title]] of [[category]]:[[value]]",
                                "fillAlphas": 1,
                                "id": "AmGraph-2",
                                "title": "Gasto real",
                                "type": "column",
                                "valueField": "FACTURADO",
                                "labelText": "[[value]]"
                            }
                        ],
                        "guides": [],
                        "valueAxes": [
                            {
                                "id": "ValueAxis-1",
                                //"title": "Axis title"
                            }
                        ],
                        "allLabels": [],
                        "balloon": {},
                        "legend": {
                            "enabled": true,
                            "useGraphSettings": true
                        },
                        "export": {
                            "enabled": true
                        },
                        "titles": [
                            {
                                "id": "Title-1",
                                "size": 15,
                                "text": ""
                            }
                        ],
                        "dataProvider": data
                    });


    });

}
   
function MakeGraficoPresupuestoVsGasto(CODCANAL, RUTCLIENTE, MES) {

    $.ajax({
        url: '/TradeMarketing/LoadGraficoDetalleCuenta',
        type: 'POST',
        dataType: 'json',
        data: {
            CODCANAL: CODCANAL,
            RUTCLIENTE: RUTCLIENTE,
            MES: MES
        },
    })
    .fail(function (request, status, error) {
        alert("error:" + request.status);
    })
    .always(function (data) {
        var chart = AmCharts.makeChart("chartdivPresupuestoEjecucion",
                    {
                        "type": "serial",
                        "categoryField": "CONCEPTO",
                        "thousandsSeparator": ".",
                        "columnSpacing": 8,
                        "dataDateFormat": "",
                        "rotate": true,
                        "angle": 30,
                        "depth3D": 30,
                        "colors": [
                            "#298A08",
                            "#FFFF00",
                            "#B0DE09",
                            "#0D8ECF",
                            "#2A0CD0",
                            "#CD0D74",
                            "#CC0000",
                            "#00CC00",
                            "#0000CC",
                            "#DDDDDD",
                            "#999999",
                            "#333333",
                            "#990000"
                        ],
                        "startDuration": 1,
                        "categoryAxis": {
                            "gridPosition": "start"
                        },
                        "trendLines": [],
                        "graphs": [
                            {
                                "balloonText": "[[title]] of [[category]]:[[value]]",
                                "fillAlphas": 1,
                                "id": "AmGraph-1",
                                "title": "Monto Disponible",
                                "type": "column",
                                "valueField": "MONTO_DISPONIBLE",
                                "labelText": "[[value]]"
                            },
                            {
                                "balloonText": "[[title]] of [[category]]:[[value]]",
                                "fillAlphas": 1,
                                "id": "AmGraph-2",
                                "title": "Gtos Facturados",
                                "type": "column",
                                "valueField": "FACTURADO",
                                "labelText": "[[value]]"
                            }
                        ],
                        "guides": [],
                        "valueAxes": [
                            {
                                "id": "ValueAxis-1",
                                "stackType": "regular",
                                "title": ""
                            }
                        ],
                        "allLabels": [],
                        "balloon": {},
                        "legend": {
                            "enabled": true,
                            "useGraphSettings": true
                        },
                        "export": {
                            "enabled": true
                        },
                        "titles": [
                            {
                                "id": "Title-1",
                                "size": 15,
                                "text": ""
                            }
                        ],
                        "dataProvider": data
                    });


    });

}


function MakeLoadDetalleFactura(CODCANAL, RUTCLIENTE, FACTURA) {
    $.ajax({
        url: '/TradeMarketing/LoadDetalleFacturasJson',
        type: 'POST',
        dataType: 'json',
        data: {
            CODCANAL: CODCANAL,
            RUTCLIENTE: RUTCLIENTE,
            FACTURA: FACTURA
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {
        //$("h3#EncuestasAnual").text(data[0].ENCUESTA);

        //$('#txtFechaEmision').val(data[0].FECHA_EMISION);
        //$('#txtFechaGasto').val(data[0].FECHA_GASTO);
        $('#txtFechaEmision').val(data[0].FECHA_GASTO);
        $('#txtFechaGasto').val(data[0].FECHA_EMISION);
        $('#txtCuentaContable').val(data[0].CUENTA + ' ' + data[0].CONCEPTO);

        $('#inputAno').val(data[0].ANO);
        $('#inputCarpeta').val(data[0].CARPETA);
        $('#inputRut').val(data[0].RUT);
    });

}

function LoadCuentasClientes(RUTCLIENTE) {
    $.ajax({
        url: '/TradeMarketing/LoadCuentasClientes',
        type: 'POST',
        dataType: 'json',
        data: {
            RUTCLIENTE: RUTCLIENTE
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        var oldData = $("#comboboxCuentaContableNueva").data('kendoComboBox').dataSource.data();
        var tamanocomboboxClientesCuenta = oldData.length;
        while (tamanocomboboxClientesCuenta > 0) {
            for (var i = 0; i < oldData.length; i++) {
                $("#comboboxCuentaContableNueva").data('kendoComboBox').dataSource.remove(oldData[i]);
            }
            oldData = $("#comboboxCuentaContableNueva").data('kendoComboBox').dataSource.data();
            tamanocomboboxClientesCuenta = oldData.length;
        }
        $("#comboboxCuentaContableNueva").data('kendoComboBox').dataSource.add({ valor: '0', texto: 'SELECCIONAR' });
        $.each(data, function (i) {
            $("#comboboxCuentaContableNueva").data('kendoComboBox').dataSource.add({ valor: data[i].VALOR, texto: data[i].TEXTO });
        });

        $("#comboboxCuentaContableNueva").data('kendoComboBox').value('0');
    });

}


function LimpiarEstadoFactura(RUTCLIENTE, FACTURA, FECHAEMISION, FECHAGASTO) {

    $.ajax({
        url: '/TradeMarketing/LimpiarEstadoFactura',
        type: 'POST',
        dataType: 'json',
        data: {
            RUTCLIENTE: RUTCLIENTE,
            FACTURA: FACTURA,
            FECHAEMISION: FECHAEMISION,
            FECHAGASTO: FECHAGASTO
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {
        console.log(data);
        
    });

}


function LoadDetalleDocumentoPorCuenta(CODCANAL, RUTCLIENTE, MES, CUENTA) {

    $.ajax({
        url: '/TradeMarketing/getDetallesDocumentosCuenta',
        type: 'GET',
        dataType: 'json',
        data: {
            CODCANAL: CODCANAL,
            RUTCLIENTE: RUTCLIENTE,
            MES: MES,
            CUENTA: CUENTA
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        console.log(data);

        //$('#datatable').DataTable( {
        //    data: data,
        //    columns: [
        //        { title: "Número Factura" },
        //        { title: "Cuenta Contable" },
        //        { title: "Mes" },
        //        { title: "Fecha Gasto" },
        //        { title: "Glosa" },
        //        { title: "Monto" },
        //        { title: "Estado" },
        //        { title: "Monto" }
        //    ]
        //} );


        //$('.datatable-1').dataTable({
        //    data: init() //NB!
        //})

        //$("#datatable tbody tr").remove();


        //console.log(data[0]);
        //console.log(data[1]);
        //var table = $('#datatable').DataTable();  
        //table.clear();

        //$.each(data, function (idx, obj) {
        //    table.row.add(data[idx]);
        //});
        //table.draw();





       
        //$("#detalle_documento").remove();
        //$("#datatable tbody tr").remove();
        
        //var contenidoTable = $("#detalle_documento_content");
        ////var tbody = $("#datatable tbody");

        ////Crate table html tag
        //var divDetalle_Documento = $(" <div id='detalle_documento' class='table-responsive'></div>").appendTo("#detalle_documento_content");
        //var table = $("<table id='datatable' class='table table-striped jambo_table bulk_action'></table>").appendTo(divDetalle_Documento);

        ////Create table header row
        //var rowHeader = $("<thead><tr class='headings'></tr></thead>").appendTo(table);               
        //$("<th class='column-title'></th>").text("Número Factura").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("Cuenta Contable").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("Mes").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("Fecha Gasto").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("Glosa").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("Monto").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("Estado").appendTo(rowHeader);
        //$("<th class='column-title'></th>").text("").appendTo(rowHeader);      
        //var rowBody = $("<tbody></tbody>").appendTo(table);
        
       
        //alert('1');
        //console.log(data);
        //$.each(data, function (i) {

        //    var monto = formatNumber.new(data[i].MONTO);
        //    var row = $('<tr class="even pointer"></tr>').appendTo(rowBody);
        //    $("<td></td>").text(data[i].N_FACTURA).appendTo(row);
        //    $("<td></td>").text(data[i].CONCEPTO).appendTo(row);
        //    $("<td></td>").text(data[i].FECHA_EMISION).appendTo(row);
        //    $("<td></td>").text(data[i].FECHA_GASTO).appendTo(row);
        //    $("<td></td>").text(data[i].GLOSA).appendTo(row);
        //    $("<td></td>").text(monto).appendTo(row);
        //    $("<td></td>").text(data[i].ESTADO).appendTo(row);
        //    $("<td><a onClick=VerFactura(" + "'" + data[i].CARPETA.substring(0, 4) + "','" + data[i].CARPETA + "','" + data[i].RUT + "','" + data[i].N_FACTURA + "')>" + "<i class='fa fa-file'></i></a></td>").appendTo(row);




            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //var monto = formatNumber.new(data[i].MONTO);
            //var row = $('<tr class="even pointer"></tr>').appendTo(tbody);
            //$("<td></td>").text(data[i].N_FACTURA).appendTo(row);
            //$("<td></td>").text(data[i].CONCEPTO).appendTo(row);
            //$("<td></td>").text(data[i].FECHA_EMISION).appendTo(row);
            //$("<td></td>").text(data[i].FECHA_GASTO).appendTo(row);
            //$("<td></td>").text(data[i].GLOSA).appendTo(row);
            //$("<td></td>").text(monto).appendTo(row);
            //$("<td></td>").text(data[i].ESTADO).appendTo(row);           
            //$("<td><a onClick=VerFactura(" + "'" + data[i].CARPETA.substring(0, 4) + "','" + data[i].CARPETA + "','" + data[i].RUT + "','" + data[i].N_FACTURA + "')>" + "<i class='fa fa-file'></i></a></td>").appendTo(row);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //});



        //Fin Function
        /////////////////////////
    });
}

var formatNumber = {
    separador: ".", // separador para los miles
    sepDecimal: ',', // separador para los decimales
    formatear: function (num) {
        num += '';
        var splitStr = num.split('.');
        var splitLeft = splitStr[0];
        var splitRight = splitStr.length > 1 ? this.sepDecimal + splitStr[1] : '';
        var regx = /(\d+)(\d{3})/;
        while (regx.test(splitLeft)) {
            splitLeft = splitLeft.replace(regx, '$1' + this.separador + '$2');
        }
        return this.simbol + splitLeft + splitRight;
    },
    new: function (num, simbol) {
        this.simbol = simbol || '';
        return this.formatear(num);
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


function MakeLoadSubgerentes(ID_PK_PLATAFORMA)
{
    $("#subgerente option").remove();

    $.ajax({
        url: '/Home/LoadSubgerentes',
        type: 'POST',
        dataType: 'json',
        data: { ID_PK_PLATAFORMA: ID_PK_PLATAFORMA },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        $("#subgerente").append('<option value="0">Todos</option>');
        $.each(data, function (i) {
            $("#subgerente").append("<option value=\"" + data[i].Valor + "\">" + data[i].Texto + "<\/option>");
        });

    });
}


function MakeLoadJefeZona(ID_PK_PLATAFORMA, ID_PK_SUBGERENTE)
{
    $("#jefezona option").remove();

    $.ajax({
        url: '/Home/LoadJefesZona',
        type: 'POST',
        dataType: 'json',
        data: { ID_PK_PLATAFORMA: ID_PK_PLATAFORMA, ID_PK_SUBGERENTE: ID_PK_SUBGERENTE },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        $("#jefezona").append('<option value="0">Todos</option>');
        $.each(data, function (i) {
            $("#jefezona").append("<option value=\"" + data[i].Valor + "\">" + data[i].Texto + "<\/option>");
        });

    });

}

function MakeLoadComunas(ID_PK_REGION)
{
    $("#comuna option").remove();

    $.ajax({
        url: '/Home/LoadComunas',
        type: 'POST',
        dataType: 'json',
        data: { ID_PK_REGION: ID_PK_REGION },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        $("#comuna").append('<option value="0">Todos</option>');
        $.each(data, function (i) {
            $("#comuna").append("<option value=\"" + data[i].Valor + "\">" + data[i].Texto + "<\/option>");
        });

    });
}

/*Graficos*/
function MakeDashboardEncuestas(ID_PK_ESTUDIO, MES, ANO, PLATAFORMA, SUBGERENTE, JEFE, COMUNA)
{
    $.ajax({
        url: '/Home/LoadDashboardEncuestas',
        type: 'POST',
        dataType: 'json',
        data: {
            ID_PK_ESTUDIO: ID_PK_ESTUDIO,
            MES: MES,
            ANO: ANO,
            PLATAFORMA:PLATAFORMA,
            SUBGERENTE:SUBGERENTE,
            JEFE:JEFE,
            COMUNA:COMUNA
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {
        $("h3#Total_Encuestas-" + ID_PK_ESTUDIO).text(data[0].ENCUESTA);
    });

}


function MakeDashboardEncuestasAnual(ID_PK_ESTUDIO, ANO) {
    $.ajax({
        url: '/Home/LoadDashboardEncuestasAnual',
        type: 'POST',
        dataType: 'json',
        data: {
            ID_PK_ESTUDIO: ID_PK_ESTUDIO, ANO: ANO
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {
        $("h3#EncuestasAnual").text(data[0].ENCUESTA);
    });

}



function MakeDashboardAvance(ID_PK_ESTUDIO, YEAR, MES) {
    $.ajax({
        url: '/Home/LoadDashboardAvance',
        type: 'POST',
        dataType: 'json',
        data: { ID_PK_ESTUDIO: ID_PK_ESTUDIO, YEAR: YEAR, MES: MES },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {
        $("h3#Total_Avance-" + ID_PK_ESTUDIO).text(data[0].AVANCE + "%");
    });

}

function MakeCumplimiento(ID_PK_ESTUDIO, MES, ANO, PLATAFORMA, SUBGERENTE, JEFEZONA, REGION, COMUNA)
{

    $.ajax({
        url: '/Home/LoadDashboardCumplimiento',
        type: 'POST',
        dataType: 'json',
        data: {
            ID_PK_ESTUDIO: ID_PK_ESTUDIO, MES: MES, ANO: ANO,
            PLATAFORMA: PLATAFORMA, SUBGERENTE: SUBGERENTE,
            JEFEZONA:JEFEZONA, REGION:REGION, COMUNA: COMUNA
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

        //asignar color grafico
        if (ID_PK_ESTUDIO == 1)
        {
            var color = "#fc3e3e";
        }
        else if (ID_PK_ESTUDIO == 2) {
            var color = "#e8cb05";
        } else {
            var color = "#78b92b";
        }

        var chart = AmCharts.makeChart("chartdiv-cumplimiento-"+ID_PK_ESTUDIO, {
            "type": "pie",
            "theme": "light",
            "allLabels": [{
                "text": "Desempeño",
                "align": "center",
                "bold": true,
                "y": 100
            },
            {
                "text": data[0].TOTAL + "%",
                "align": "center",
                "bold": false,
                "y": 120
            }],
            "dataProvider": [{
                "title": "",
                "value": 100 - data[0].TOTAL,
                "color": "#edebec"
            },
            {
                "title": "",
                "value": data[0].TOTAL,
                "color": color
            }],
            "titleField": "title",
            "valueField": "value",
            "labelRadius": 5,
            "colorField": "color",

            "radius": "42%",
            "innerRadius": "60%",
            "labelText": "[[title]]",
            "export": {
                "enabled": true
            }
        });

    });

}


function MakeDashboardEvolutivo(ID_PK_ESTUDIO, ANO, PLATAFORMA, SUBGERENTE, JEFEZONA, REGION, COMUNA)
{
    $.ajax({
        url: '/Home/LoadDashboardEvolutivo',
        type: 'POST',
        dataType: 'json',
        data: {
            ID_PK_ESTUDIO: ID_PK_ESTUDIO,ANO: ANO,
            PLATAFORMA: PLATAFORMA, SUBGERENTE: SUBGERENTE,
            JEFEZONA: JEFEZONA, REGION: REGION, COMUNA: COMUNA
        },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {

            var chart = AmCharts.makeChart("chartdivLine", {
                "type": "serial",
                "marginRight": 0,
                "marginLeft": 0,
                "autoMarginOffset": 0,
                "mouseWheelZoomEnabled": false,
                "valueAxes": [{
                    "id": "v1",
                    "axisAlpha": 0.04,
                    "position": "left",
                    "ignoreAxisWidth": true,
                    "gridAlpha": 0.24,
                }],
                "balloon": {
                    "borderThickness": 1,
                    "shadowAlpha": 0
                },
                "graphs": [{
                    "id": "g1",
                    "balloon": {
                        "drop": true,
                        "adjustBorderColor": false,
                        "color": "#ffffff"
                    },
                    "lineColor": "#2196F3",
                    "bullet": "round",
                    "bulletBorderAlpha": 1,
                    "bulletColor": "#FFFFFF",
                    "bulletSize": 2,
                    "hideBulletsCount": 50,
                    "lineThickness": 2,
                    "title": "red line",
                    "useLineColorForBulletBorder": true,
                    "valueField": "TOTAL",
                    "balloonText": "<span style='font-size:18px;'>[[value]]</span>"
                }],
                "categoryField": "MEDICION",
                "categoryAxis": {
                    "parseDates": false,
                    "dashLength": 1,
                    "minorGridEnabled": true
                },
                "export": {
                    "enabled": true
                },
                "dataProvider": data
            });

    });
}

function MakeDashboardAcumuladoAnual(ID_PK_ESTUDIO, YEAR) {

    $.ajax({
        url: '/Home/LoadDashboardAcumuladoAnual',
        type: 'POST',
        dataType: 'json',
        data: { ID_PK_ESTUDIO: ID_PK_ESTUDIO, YEAR: YEAR },
    })
    .fail(function (xhr, status, error) {
        console.log("error:" + status + "-" + error);
    })
    .always(function (data) {
        $("h3#AcumuladoAnual").text(data[0].TOTAL + "%");
    });

}

function MakeDashboardPilares(ID_PK_ESTUDIO,MES,YEAR)
{
    $.ajax({
        url: '/Home/LoadDashboardPilares',
        type: 'POST',
        dataType: 'json',
        data: { ID_PK_ESTUDIO: ID_PK_ESTUDIO, MES:MES, YEAR: YEAR },
    })
   .fail(function (xhr, status, error) {
       console.log("error:" + status + "-" + error);
   })
   .always(function (data) {

       var chart = AmCharts.makeChart("chartdivPilares", {
          "type": "serial",
          //"theme": "light",
          "dataProvider": data,
          "valueAxes": [ {
            "gridColor": "#FFFFFF",
            "gridAlpha": 0.2,
            "dashLength": 0
          } ],
          "gridAboveGraphs": true,
          "startDuration": 1,
          "graphs": [ {
            "balloonText": "[[category]]: <b>[[value]]</b>",
            "fillAlphas": 0.8,
            "lineAlpha": 0.2,
            "type": "column",
            "valueField": "TOTAL",
            "fillColors": "#2196F3"
          } ],
          "chartCursor": {
            "categoryBalloonEnabled": false,
            "cursorAlpha": 0,
            "zoomable": false
          },
          "categoryField": "PILAR",
          "categoryAxis": {
            "gridPosition": "start",
            "gridAlpha": 0,
            "tickPosition": "start",
            "tickLength": 20
          },
          "export": {
            "enabled": true
          }

        });
       
   });
}

/*End graficos*/

/*Plataforma*/
function MakePlataformasBarra(ID_PK_ESTUDIO, MES, ANO, PLATAFORMA, SUBGERENTE, JEFE, REGION, COMUNA) {

    $.ajax({
        url: '/ReportePlataforma/LoadPlataformasBarra',
        type: 'POST',
        dataType: 'json',
        data: {
            ID_PK_ESTUDIO: ID_PK_ESTUDIO,
            MES: MES,
            ANO: ANO,
            PLATAFORMA: PLATAFORMA,
            SUBGERENTE: SUBGERENTE,
            JEFE:JEFE,
            REGION: REGION,
            COMUNA: COMUNA
        },
    })
   .fail(function (xhr, status, error) {
       console.log("error:" + status + "-" + error);
   })
   .always(function (data) {

       var chart = AmCharts.makeChart("chartdivBarras", {
           "type": "serial",
           "dataProvider": data,
           "valueAxes": [{
               "gridColor": "#FFFFFF",
               "gridAlpha": 0.2,
               "dashLength": 0
           }],
           "gridAboveGraphs": true,
           "startDuration": 1,
           "graphs": [{
               "balloonText": "[[category]]: <b>[[value]]</b>",
               "fillAlphas": 0.8,
               "lineAlpha": 0.2,
               "type": "column",
               "valueField": "TOTAL",
               "fillColors": "#2196F3"
           }],
           "chartCursor": {
               "categoryBalloonEnabled": false,
               "cursorAlpha": 0,
               "zoomable": false
           },
           "categoryField": "PLATAFORMA",
           "categoryAxis": {
               "gridPosition": "start",
               "gridAlpha": 0,
               "tickPosition": "start",
               "tickLength": 20
           },
           "export": {
               "enabled": true
           }

       });

   });
}

function MakeEvolutivoPlataformas(ID_PK_ESTUDIO,MES,ANO,PLATAFORMA,SUBGERENTE,JEFE,REGION,COMUNA)
{
    $.ajax({
        url: '/ReportePlataforma/LoadPlataformasEvo',
        type: 'POST',
        dataType: 'json',
        data: {
            ID_PK_ESTUDIO: ID_PK_ESTUDIO,
            MES: MES,
            ANO: ANO,
            PLATAFORMA: PLATAFORMA,
            SUBGERENTE: SUBGERENTE,
            JEFE:JEFE,
            REGION: REGION,
            COMUNA: COMUNA
        },
    })
    .fail(function (request, status, error) {
        alert("error:" + request.status);
    })
    .always(function (data) {

        AmCharts.makeChart("chartdivplatevo",
        {
            "type": "serial",
            "categoryField": "MEDICION",
            "startDuration": 0,
            "path": "http://www.amcharts.com/lib/3/",
            "categoryAxis": {
                "gridPosition": "start",
                "autoGridCount": false,
                "axisColor": "#FFFFFF",
                "dashLength": 12,
                "gridAlpha": 0,
                "gridColor": "#FFFFFF",
                "gridCount": 14,

            },
            "trendLines": [],
            "graphs": [
                    {
                        "bullet": "round",
                        "bulletAlpha": 1,
                        "id": "AmGraph-1",
                        "lineColor": "#0073c6",
                        "lineThickness": 5,
                        "title": "RBA",
                        "valueField": "RBA",
                        "labelText": "[[value]]"
                    },
                    {
                        "bullet": "round",
                        "bulletAlpha": 1,
                        "id": "AmGraph-2",
                        "lineColor": "#03cbc9",
                        "lineThickness": 5,
                        "title": "CODO",
                        "valueField": "CODO",
                        "labelText": "[[value]]"
                    },
                    {
                        "bullet": "round",
                        "bulletAlpha": 1,
                        "id": "AmGraph-3",
                        "lineColor": "#77b82a",
                        "lineThickness": 5,
                        "title": "COCO",
                        "valueField": "COCO",
                        "labelText": "[[value]]"
                    },
                    {
                        "bullet": "round",
                        "bulletAlpha": 1,
                        "id": "AmGraph-4",
                        "lineColor": "#f7d37f",
                        "lineThickness": 5,
                        "title": "DODO",
                        "valueField": "DODO",
                        "labelText": "[[value]]"
                    }
            ],
            "guides": [],
            "valueAxes": [
                {
                    "axisTitleOffset": 0,
                    "id": "ValueAxis-1",
                    "axisAlpha": 0.04,
                    "axisColor": "#FFFFFF",
                    "gridAlpha": 0.24,
                    "gridColor": "#AAB3B3",
                    "gridCount": 0,
                    "minorGridAlpha": 0,
                    "title": ""
                }
            ],
            "allLabels": [],
            "balloon": {},
            "legend": {
                "useGraphSettings": true
            },
            "titles": [
                {
                    "id": "Title-1",
                    "size": 15,
                    "text": ""
                }
            ],
            "dataProvider": data,
        }
        );
    });
}
/*End plataforma*/