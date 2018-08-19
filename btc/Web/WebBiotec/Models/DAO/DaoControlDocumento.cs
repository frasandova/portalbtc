using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBiotec.Models.DTO;

namespace WebBiotec.Models.DAO
{
    public class DaoControlDocumento
    {
        public static List<facturas> getFacturas(string codCanal, string rutCliente)
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<facturas>("pl_clientes_facturas @p0, @p1, @p2", codCanal, rutCliente,"201801")
                                   .ToList();

            }
        }

        public static List<detalle_factura> getDetalleFacturas(string codCanal, string rutCliente, string numerofactura)
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<detalle_factura>("pl_detalle_factura @p0, @p1, @p2, @p3", codCanal, rutCliente, "", numerofactura)
                                   .ToList();

            }
        }

        public static void IngresarEstadoFactura(string rutCliente, string numerofactura, string codestado, string glosa, string fechaemision, string fechagasto, string cuentaContable, string nuevaCuentaContable, string nuevoMesGasto)
        {

            using (var ctx = new Model1())
            {
                ctx.Database.ExecuteSqlCommand("pl_guardar_estado_factura @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8", rutCliente,numerofactura, codestado, glosa, fechaemision, fechagasto, cuentaContable, nuevaCuentaContable, nuevoMesGasto);

            }
        }

        public static List<cuentasClientes> getClientesCuentas(string rutCliente)
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<cuentasClientes>("pl_clientes_cuentas @p0", rutCliente)
                                   .ToList();

            }
        }

        public static List<cuentasClientes> getMasterCuentas()
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<cuentasClientes>("select valor, (valor + ' ' + texto) as  texto from Master_ConceptosRetail order by valor")
                                   .ToList();

            }
        }

        public static List<ComboboxFiltros> getCanalesUsuarios()
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<ComboboxFiltros>("pl_canales_usuarios_retail")
                             .ToList();

            }
        }


        public static List<detallesDocumentosAdmin> getFacturasEstados(string codCanal, string rutCliente, string mesIni, string mesFin)
        {

            try
            {
                List<detallesDocumentosAdmin> result = new List<detallesDocumentosAdmin>();
                using (var ctx = new Model1())
                {
                    result=  ctx.Database.SqlQuery<detallesDocumentosAdmin>("pl_detalles_doc_admin @p0,@p1,@p2,@p3", codCanal, rutCliente, mesIni, mesFin)
                                        .ToList();
                    //foreach (var item in result)
                    //{
                    //    item.MONTO = item.MONTO.Replace(',', '.');
                    //}

                    return result;
                }
            }
            catch (Exception ex)
            {
                List<detallesDocumentosAdmin> result = new List<detallesDocumentosAdmin>();
                return result;

            }

        }

        public static void setFacturasEstados(string RUTCLIENTE, string FACTURA, string FECHAEMISION, string FECHAGASTO)
        {
            using (var ctx = new Model1())
            {
                 ctx.Database.ExecuteSqlCommand("exec pl_update_estado_fac_admin @p0,@p1,@p2,@p3", RUTCLIENTE, FACTURA, FECHAEMISION, FECHAGASTO);
                 //ctx.Database.ExecuteSqlCommand("exec pl_update_estado_fac_admin @rutCliente, @factura, @fechaEmision, @fechaGasto", RUTCLIENTE, FACTURA, FECHAEMISION, FECHAGASTO);
                //context.Database.ExecuteSqlCommand("exec MySchema.MyProc @customerId, @indicatorTypeId, @indicators, @startDate, @endDate", customerIdParam, typeIdParam, tableParameter, startDateParam, endDateParam);

            }
        }

    }
}