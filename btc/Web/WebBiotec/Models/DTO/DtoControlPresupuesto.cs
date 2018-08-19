using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBiotec.Models.DTO
{
    public class DtoControlPresupuesto
    {

        public int MyProperty { get; set; }
    }


    public class ComboboxClientes
    {

        public string valor { get; set; }
        public string texto { get; set; }
    }

    public class ComboboxFiltros
    {
        public string valor { get; set; }
        public string texto { get; set; }
    }
    //public class tablaVentas
    //{
    //    public double valorAcumulado { get; set; }
    //    public double valorMes { get; set; }
    //    public double total { get; set; }
    //}

    public class tablaVentas
    {
        public int orden { get; set; }
        public string texto { get; set; }
        public double valor { get; set; }

        public double valor2 { get; set; }
        public double porcentaje { get; set; }
        public string ANO { get; set; }
        public string ANO_ANTERIOR { get; set; }

    }

    public class graficoVentas
    {
        public string MES { get; set; }
        public string VALOR { get; set; }
        public string VALOR2 { get; set; }
        public string ANO { get; set; }
        public string ANO_ANTERIOR { get; set; }
    }

    public class graficoProvisionFacturado
    {
        public string MES { get; set; }
        public string FACTURADO { get; set; }
        public string PROVISION { get; set; }
    }

    public class totalPrevision
    {
        public int ORDEN { get; set; }
        public string MES { get; set; }
        public double VALOR { get; set; }
    }

    public class totalFacturado
    {
        public string MES { get; set; }
        public double VALOR { get; set; }
    }



    public class detalleCuenta
    {

        public string RUT { get; set; }
        public string MES { get; set; }
        public string CUENTA { get; set; }
        public string CONCEPTO { get; set; }
        public double PRESUPUESTO { get; set; }
        public double PROVISION { get; set; }
        public double FACTURADO { get; set; }
        public double MONTO_DISPONIBLE { get; set; }
        public double PORCENTAJE { get; set; }
        public string TIPO_CALCULO { get; set; }

    }

    public class detalleCuentaGrafico
    {
        public string CONCEPTO { get; set; }
        public string MONTO_DISPONIBLE { get; set; }
        public string FACTURADO { get; set; }
    }

    public class detallesDocumentos
    {
        public string RUT { get; set; }
        public string FICHA { get; set; }
        public string DOCUMENTO { get; set; }
        public double N_FACTURA { get; set; }
        public string CONCEPTO { get; set; }
        public string FECHA_EMISION { get; set; }
        public string FECHA_GASTO { get; set; }
        public string GLOSA { get; set; }
        public string MONTO { get; set; }
        public string CARPETA { get; set; }
        public string ESTADO { get; set; }
    }

    public class detallesDocumentosCuenta
    {
        public string RUT { get; set; }
        public string FICHA { get; set; }
        public string DOCUMENTO { get; set; }
        public double N_FACTURA { get; set; }
        public string CONCEPTO { get; set; }
        public string FECHA_EMISION { get; set; }
        public string FECHA_GASTO { get; set; }
        public string GLOSA { get; set; }
        public string MONTO { get; set; }
        public string CARPETA { get; set; }
        public string ESTADO { get; set; }

        public string MONTO2 { get; set; }
    }

    public class detalle_factura
    {
        public string RUT { get; set; }
        public string ANO { get; set; }
        public string CARPETA { get; set; }
        public string FECHA_EMISION { get; set; }
        public string FECHA_GASTO { get; set; }
        public string CUENTA { get; set; }
        public string CONCEPTO { get; set; }
        public string GLOSA { get; set; }
    }


    public class facturas
    {
        public double numero_factura { get; set; }
    }

    public class cuentasClientes
    {
        public string TEXTO { get; set; }
        public string VALOR { get; set; }
    }


    public class detallesDocumentosAdmin
    {
        public string RUT { get; set; }
        public string FICHA { get; set; }
        public double N_FACTURA { get; set; }
        public string CONCEPTO { get; set; }
        public string FECHA_EMISION { get; set; }
        public string FECHA_GASTO { get; set; }
        public string MES_GASTO_NUEVO { get; set; }
        public double MONTO { get; set; }
        public string CUENTA { get; set; }
        public string CUENTA_NUEVA { get; set; }
        public string ESTADO { get; set; }
        public string COMENTARIO { get; set; }
        public string CARPETA { get; set; }
    }


    public class facturas_kams
    {
        public string KAM { get; set; }
        public int PENDIENTES { get; set; }
        public int APROBADAS { get; set; }
        public int RECHAZADAS { get; set; }
    }

}