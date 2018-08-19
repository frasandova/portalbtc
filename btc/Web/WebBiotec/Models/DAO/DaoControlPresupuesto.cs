using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBiotec.Models.DTO;

namespace WebBiotec.Models.DAO
{
    public class DaoControlPresupuesto
    {

        public static List<ComboboxFiltros> getCanales(string perfil)
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<ComboboxFiltros>("pl_canales_retail @p0", perfil)
                                   .ToList();

            }
        }

        public static List<ComboboxFiltros> GetCadenasClientes(string codCanal, string perfil)
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<ComboboxFiltros>("pl_cadenasclientes_retail @p0, @p1", codCanal, perfil)
                                   .ToList();

            }
        }

        public static List<ComboboxClientes> getClientes()
        {
            using (var ctx = new Model1())
            {
                return ctx.Database.SqlQuery<ComboboxClientes>("pl_clientes_retail")
                                   .ToList();
                //return ctx.Database.SqlQuery<Mes_DTO>("pl_clientes_retail @p0", estudio)
                //   .ToList();

            }
        }

        //public static tablaVentas getVentas(string rutCliente, string mes)
        //{
        //    using (var ctx = new Model1())
        //    {
        //        return ctx.Database.SqlQuery<tablaVentas>("pl_totales_ventas @p0, @p1", rutCliente, mes)
        //           .SingleOrDefault();

        //    }
        //}

        public static List<tablaVentas> getVentas(string codCanal,string rutCliente, string mes)
        {
            try
            {
                List<tablaVentas> ventas = new List<tablaVentas>();
                //using (var ctx = new Model1())
                using (var ctx = new Model_BackData())
                {
                        ventas = ctx.Database.SqlQuery<tablaVentas>("pl_totales_ventas @p0, @p1, @p2", codCanal, rutCliente, mes)
                           .ToList();
                    double porcentaje1;
                    double porcentaje2;
                    double porcentaje3;
                    if (ventas[0].valor==0)
                    {
                        porcentaje1 = -100;
                        if (ventas[0].valor == 0 && ventas[0].valor2 == 0)
                        {
                            porcentaje1 = 0;
                        }
                    }
                    else
                    {
                        porcentaje1 = Convert.ToDouble(Math.Round(((ventas[0].valor - ventas[0].valor2) * 100) / ventas[0].valor, 2));
                    }

                    if (ventas[1].valor == 0)
                    {
                        porcentaje2 = -100;
                        if (ventas[1].valor == 0 && ventas[1].valor2 == 0)
                        {
                            porcentaje2 = 0;
                        }


                    }
                    else
                    {
                        porcentaje2 = Convert.ToDouble(Math.Round(((ventas[1].valor - ventas[1].valor2) * 100) / ventas[1].valor, 2));
                    }
                    if (ventas[2].valor == 0)
                    {
                        porcentaje3 = -100;
                        if (ventas[2].valor == 0 && ventas[2].valor2 == 0)
                        {
                            porcentaje3 = 0;
                        }
                    }
                    else
                    {
                        porcentaje3 = Convert.ToDouble(Math.Round(((ventas[2].valor - ventas[2].valor2) * 100) / ventas[2].valor, 2));
                    }


                    
                    ventas[0].porcentaje = porcentaje1;
                    ventas[1].porcentaje = porcentaje2;
                    ventas[2].porcentaje = porcentaje3;


                    return ventas;
                    }
            }
            catch (Exception ex)
            {
                List<tablaVentas> ventas = new List<tablaVentas>();
                //tablaVentas itemventas = new tablaVentas();
                //itemventas.texto = "";
                //itemventas.valor = 0;
                //itemventas.porcentaje = 0;
                //ventas.Add(itemventas);
                return ventas;
            }

        }

        public static List<tablaVentas> getVentasConsoliado(string mes)
        {
            try
            {
                List<tablaVentas> ventas = new List<tablaVentas>();
                    using (var ctx = new Model_BackData())
                    {
                        ventas = ctx.Database.SqlQuery<tablaVentas>("pl_totales_ventas_consolidado @p0", mes)
                           .ToList();

                    double porcentaje1;
                    double porcentaje2;
                    double porcentaje3;
                    if (ventas[0].valor == 0)
                    {
                        porcentaje1 = 0;
                    }
                    else
                    {
                        porcentaje1 = Convert.ToDouble(Math.Round(((ventas[0].valor - ventas[0].valor2) * 100) / ventas[0].valor, 1));
                    }

                    if (ventas[1].valor == 0)
                    {
                        porcentaje2 = 0;
                    }
                    else
                    {
                        porcentaje2 = Convert.ToDouble(Math.Round(((ventas[1].valor - ventas[1].valor2) * 100) / ventas[1].valor, 1));
                    }
                    if (ventas[2].valor == 0)
                    {
                        porcentaje3 = 0;
                    }
                    else
                    {
                        porcentaje3 = Convert.ToDouble(Math.Round(((ventas[2].valor - ventas[2].valor2) * 100) / ventas[2].valor, 1));
                    }

                    ventas[0].porcentaje = porcentaje1;
                    ventas[1].porcentaje = porcentaje2;
                    ventas[2].porcentaje = porcentaje3;

                    //double porcentaje1 = Convert.ToDouble(Math.Round(((ventas[0].valor - ventas[0].valor2) * 100) / ventas[0].valor, 1));
                    //double porcentaje2 = Convert.ToDouble(Math.Round(((ventas[1].valor - ventas[1].valor2) * 100) / ventas[1].valor, 1));
                    //double porcentaje3 = Convert.ToDouble(Math.Round(((ventas[2].valor - ventas[2].valor2) * 100) / ventas[2].valor, 1));
                    //ventas[0].porcentaje = porcentaje1;
                    //ventas[1].porcentaje = porcentaje2;
                    //ventas[2].porcentaje = porcentaje3;




                    return ventas;
                    }
            }
            catch (Exception ex)
            {
                List<tablaVentas> ventas = new List<tablaVentas>();
                return ventas;
            }

        }
        public static string CargarUltimaFecha()
        {
            try
            {
                using (var ctx = new Model_BackData())
                {

                    return ctx.Database.SqlQuery<string>("pl_ultima_fecha")
                   .SingleOrDefault();

                    //return ctx.Database.SqlQuery<string>("SELECT MAX (MES) ULTIMO_MES FROM anavta.dbo.B_data B_data")
                    //                   .SingleOrDefault();

                    //
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static List<graficoVentas> LoadGraficoVentas(string codCanal,string rutCliente, string mes)
        {
            List<graficoVentas> ventas = new List<graficoVentas>();
            if (rutCliente != "0")
            {
                using (var ctx = new Model_BackData())
                {
                    return ctx.Database.SqlQuery<graficoVentas>("pl_totales_ventas_grafico @p0, @p1, @p2", codCanal, rutCliente, mes)
                                       .ToList();

                }
            }
            else
            {
                return ventas;
            }
        }

        public static List<graficoProvisionFacturado> LoadGraficoProvisionFacturas(string codCanal, string rutCliente, string mes)
        {
            try
            {
                List<graficoProvisionFacturado> ventas = new List<graficoProvisionFacturado>();
                if (rutCliente != "0")
                {
                    using (var ctx = new Model1())
                    {
                        return ctx.Database.SqlQuery<graficoProvisionFacturado>("pl_totales_prov_fac_grafico @p0, @p1, @p2", codCanal, rutCliente, mes)
                                            .ToList();

                    }
                }
                else
                {
                    return ventas;
                }
            }
            catch (Exception ex)
            {
                List<graficoProvisionFacturado> ventas = new List<graficoProvisionFacturado>();
                return ventas;
            }
            
        }

        public static List<totalPrevision> getPrevision(string codCanal, string rutCliente, string mes)
        {
            try
            {
                totalPrevision item = new totalPrevision();
                List<totalPrevision> resultado = new List<totalPrevision>();
                using (var ctx = new Model1())
                {
                    resultado = ctx.Database.SqlQuery<totalPrevision>("pl_totales_prevision @p0, @p1, @p2", codCanal, rutCliente, mes)
                             .ToList();

                    if (resultado.Count() == 0)
                    {
                        //totalPrevision item = new totalPrevision();
                        item.MES = "";
                        item.VALOR = 0;
                        resultado.Add(item);
                        resultado.Add(item);
                        resultado.Add(item);
                    }
                    else
                    {

                        if (resultado.Count() == 1)
                        {

                            if (resultado[0].ORDEN == 1)
                            {
                                item.ORDEN = 2;
                                item.MES = "";
                                item.VALOR = 0;
                                resultado.Add(item);
                            }
                            if (resultado[0].ORDEN == 2)
                            {
                                item.ORDEN = 1;
                                item.MES = "";
                                item.VALOR = 0;
                                resultado.Add(item);
                            }
                        }
                        
                        //if (resultado.Count() == 1)
                        //{
                            
                        //    item.MES = "";
                        //    item.VALOR = 0;
                        //    resultado.Add(item);
                        //    resultado.Add(item);
                        //}                  
                        //item.MES = resultado[1].MES;
                        //item.VALOR = resultado[0].VALOR + resultado[1].VALOR;
                        //resultado.Add(item);
                    }

                    resultado = resultado.OrderBy(x => x.ORDEN).ToList();
                    totalPrevision itemAcumulado = new totalPrevision();
                    itemAcumulado.ORDEN = 3;
                    itemAcumulado.MES = resultado[1].MES;
                    itemAcumulado.VALOR = resultado[0].VALOR + resultado[1].VALOR;
                    resultado.Add(itemAcumulado);
                    return resultado;

                    
                }
            }
            catch (Exception ex)
            { 

            List<totalPrevision> resultado = new List<totalPrevision>();
            totalPrevision item = new totalPrevision();
            item.MES = "";
            item.VALOR = 0;
            resultado.Add(item);
            resultado.Add(item);
            return resultado;
            }

        }


        public static List<totalFacturado> getFacturado(string codCanal, string rutCliente, string mes)
        {
            try
            {
                List<totalFacturado> resultado = new List<totalFacturado>();
                using (var ctx = new Model1())
                {
                    resultado = ctx.Database.SqlQuery<totalFacturado>("pl_totales_facturados @p0, @p1, @p2", codCanal, rutCliente, mes)
                             .ToList();

                    if (resultado.Count() == 0)
                    {
                        totalFacturado item = new totalFacturado();
                        item.MES = "";
                        item.VALOR = 0;
                        resultado.Add(item);
                        resultado.Add(item);
                        resultado.Add(item);
                    }
                    else
                    {
                        totalFacturado item = new totalFacturado();
                        item.MES = resultado[1].MES;
                        item.VALOR = resultado[0].VALOR + resultado[1].VALOR;
                        resultado.Add(item);
                    }

                    return resultado;


                }
            }
            catch (Exception ex)
            {

                List<totalFacturado> resultado = new List<totalFacturado>();
                totalFacturado item = new totalFacturado();
                item.MES = "";
                item.VALOR = 0;
                resultado.Add(item);
                resultado.Add(item);
                return resultado;
            }

        }



        public static List<detalleCuenta> getDetallePorCuenta(string codCanal, string rutCliente, string mes)
        {
            List<detalleCuenta> ventas = new List<detalleCuenta>();
            if (rutCliente != "0")
            {
                double vProvision = 0;
                double vFacturado = 0;
                double vDisponible = 0;
                using (var ctx = new Model1())
                {
                    ventas =  ctx.Database.SqlQuery<detalleCuenta>("pl_detalle_porcuenta @p0, @p1, @p2", codCanal, rutCliente, mes)
                                       .ToList();

                    detalleCuenta ItemTotales = new detalleCuenta();
                    foreach (var item in ventas)
                    {
                        vProvision = vProvision + item.PROVISION;
                        vFacturado = vFacturado + item.FACTURADO;
                        vDisponible = vDisponible + item.MONTO_DISPONIBLE;
                    }

                    ItemTotales.MES = "";
                    ItemTotales.CONCEPTO = "TOTAL";
                    ItemTotales.CUENTA = "";
                    ItemTotales.PRESUPUESTO = vProvision;
                    ItemTotales.PROVISION = vProvision;
                    ItemTotales.FACTURADO = vFacturado;
                    ItemTotales.MONTO_DISPONIBLE = vDisponible;
                    ventas.Add(ItemTotales);
                    return ventas;
                }
            }
            else
            {
                return ventas;
            }
        }

        public static List<detalleCuentaGrafico> getDetallePorCuentaGrafico(string codCanal, string rutCliente, string mes)
        {

            try
            {
                List<detalleCuentaGrafico> resultado = new List<detalleCuentaGrafico>();
                if (rutCliente != "0")
                {
                    using (var ctx = new Model1())
                    {
                        return ctx.Database.SqlQuery<detalleCuentaGrafico>("pl_detalle_porcuenta_grafico @p0, @p1, @p2", codCanal, rutCliente, mes)
                                            .ToList();
                    }
                }
                else
                {
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                List<detalleCuentaGrafico> resultado = new List<detalleCuentaGrafico>();
                return resultado;
            }
           
        }

        public static List<detallesDocumentos> getDetallesDocumentos(string codCanal, string rutCliente, string mes)
        {
            List<detallesDocumentos> detalles = new List<detallesDocumentos>();
            if (rutCliente != "0")
            {
                using (var ctx = new Model1())
                {
                    return ctx.Database.SqlQuery<detallesDocumentos>("pl_detalles_documentos @p0, @p1, @p2", codCanal, rutCliente, mes)
                                       .ToList();
                }
            }
            else
            {
                return detalles;
            }
        }


        public static List<detallesDocumentosCuenta> getDetallesDocumentosCuenta(string codCanal, string rutCliente, string mes, string cuenta)
        {
            List<detallesDocumentosCuenta> detalles = new List<detallesDocumentosCuenta>();
            if (rutCliente != "0")
            {
                using (var ctx = new Model1())
                {
                    return ctx.Database.SqlQuery<detallesDocumentosCuenta>("pl_detalles_documentos_cuenta @p0, @p1, @p2, @p3", codCanal, rutCliente, mes, cuenta)
                                       .ToList();
                }
            }
            else
            {
                return detalles;
            }
        }

        public static List<facturas_kams> getFacturasKam()
        {
            try
            {
                using (var ctx = new Model1())
                {
                    return ctx.Database.SqlQuery<facturas_kams>("pl_facturas_kam")
                                       .ToList();
                }
            }
            catch (Exception ex)
            {
                List<facturas_kams> resultado = new List<facturas_kams>();
                return resultado;
            }

        }




    }
}