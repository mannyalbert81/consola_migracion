using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Negocio;
using System.Globalization;
using System.Xml.Linq;
using System.Xml;
using System.Threading;


namespace ExportaImporta
{
    class Program
    {

        public static int _year;
        public static int _mes;
        public static int _dia;
        public static DateTime Hoy = DateTime.Today.AddDays(-1);

        static void Main(string[] args)
        {
            // Console.WriteLine("Comenzamos Conexión: " + Hoy);

            string dia = "";
            string mes = "";
            string año = "";

            dia = Hoy.ToString("dd");
            mes = Hoy.ToString("MM");
            año = Hoy.ToString("yyyy");

            _year = Convert.ToInt32(año.ToString());
            _mes = Convert.ToInt32(mes.ToString());
            _dia = Convert.ToInt32(dia.ToString());



            // proceso g41 pata biess
            // generar_g41_biess();
<<<<<<< HEAD
            // generar_g42_biess_nueva();
=======
            //          generar_g42_biess_nueva();
>>>>>>> 524930849535fd934071b784eff09e30614ad87e


            // PROCESO DE CIERRE DE MES CREDITOS
             Cierre_Mes_Creditos();



            // MIGRACION PARTICIPES
            /* cargar_participes();
              cargar_informacion_adicional_participes();
              */


            // MIGRACION CREDITOS
            //cargar_creditos();


            // MIGRACION TABLAS DE AMORTIZACION
             //cargar_tablas_amortizacion();


            // MIGRACION DETALLE PAGOS TABLAS DE AMORTIZACION
            /*
            cargar_parametrizacion_tabla_amortizacion();
            cargar_pagos_tablas_amortizacion();
            
            */


            // PROCESO PARA CALCULAR MORAS
            // calcular_moras();


            // MIGRACION DE TRANSACCIONES DE CREDITO 
           /* cargar_modo_pago();
            cargar_transacciones();*/
            


            // MIGRACION APORTES CTA INDIVIDUAL
<<<<<<< HEAD
              //cargar_contribucion_cuenta_individual();
=======
            // cargar_contribucion_cuenta_individual();
>>>>>>> 524930849535fd934071b784eff09e30614ad87e


            // MIGRACION APORTES CTA DESEMBOLSAR
            /* restaurar_tablas_rp_c();
            cargar_contribucion_cuenta_desembolsar();
           */


            ///MANUEL

            //cargar_prestaciones();
            //cargar_documentos_hipotecarios();
            //
            ///PRESTACIONES
            ///
            /*
                        cargar_liquidacion_historico();
                        cargar_tipo_pago_liquidacion();
                        cargar_liquidacion_cabeza();
                        cargar_liquidacion_detalle();
                        cargar_liquidacion_forma_pago_carga();
            */

            ////DESCUENTOS
            ///

            /*
            cargar_core_descuentos_formatos_carga();
            cargar_core_descuentos_registrados_cabeza_carga();
            cargar_core_descuentos_registrados_detalle_aportes();
            cargar_core_descuentos_registrados_detalle_contibucion();
            cargar_core_descuentos_registrados_detalle_creditos();
            cargar_core_descuentos_registrados_detalle_creditos_trans();
            */


            ///SUPERAVIT
            ///
          //  carga_core_superavit_pagos();
           // carga_core_superavit_pagos_cuentas();
           // carga_core_superavit_pagos_credito();
            carga_core_superavit_pagos_trabajados();
        }






        public static void restaurar_tablas_rp_c()
        {

            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            /*
           Console.WriteLine("-----------VACIANDO CONTRIBUCIONES----------------------");
           AccesoLogica.TruncateCascade("core_contribucion");
            */
            Console.WriteLine("-----------VACIANDO CONTRIBUCIONES PAGAS----------------------");
            AccesoLogica.TruncateCascade("core_contribucion_pagada");
            /*


             Console.WriteLine("-----------VACIANDO PAGOS TABLAS AMORTIZACION----------------------");
             AccesoLogica.TruncateCascade("core_tabla_amortizacion_pagos");
             Console.WriteLine("-----------VACIANDO PARAMETRIZACIONES PAGOS TABLAS AMORTIZACION----------------------");
             AccesoLogica.TruncateCascade("core_tabla_amortizacion_parametrizacion");
             Console.WriteLine("-----------VACIANDO TABLAS DE AMORTIZACION HISTORICAS----------------------");
             AccesoLogica.TruncateCascade("core_tabla_amortizacion_historico");
             Console.WriteLine("-----------VACIANDO TABLAS DE AMORTIZACION PAGARES----------------------");
             AccesoLogica.TruncateCascade("core_tabla_amortizacion_pagare");
             Console.WriteLine("-----------VACIANDO TABLAS DE AMORTIZACION----------------------");
             AccesoLogica.TruncateCascade("core_tabla_amortizacion");
             Console.WriteLine("-----------VACIANDO CREDITOS GARANTIAS----------------------");
             AccesoLogica.TruncateCascade("core_creditos_garantias");
             Console.WriteLine("-----------VACIANDO CREDITOS RENOVACIONES----------------------");
             AccesoLogica.TruncateCascade("core_creditos_renovaciones");
             Console.WriteLine("-----------VACIANDO CREDITOS RETENCIONES----------------------");
             AccesoLogica.TruncateCascade("core_creditos_retenciones");
             Console.WriteLine("-----------VACIANDO CREDITOS TRABAJADOS DETALLE----------------------");
             AccesoLogica.TruncateCascade("core_creditos_trabajados_detalle");
             Console.WriteLine("-----------VACIANDO CREDITOS TRABAJADOS CABEZA----------------------");
             AccesoLogica.TruncateCascade("core_creditos_trabajados_cabeza");
             Console.WriteLine("-----------VACIANDO ARCHIVOS DE RECAUDACIONES DETALLE----------------------");
             AccesoLogica.TruncateCascade("core_archivo_recaudaciones_detalle");
             Console.WriteLine("-----------VACIANDO ARCHIVOS DE RECAUDACIONES----------------------");
             AccesoLogica.TruncateCascade("core_archivo_recaudaciones");
             Console.WriteLine("-----------VACIANDO CREDITOS----------------------");
             AccesoLogica.TruncateCascade("core_creditos");
             AccesoLogica.TruncateCascade("core_transacciones");
             Console.WriteLine("-----------VACIANDO TRANSACCIONES DETALLE----------------------");
             AccesoLogica.TruncateCascade("core_transacciones_detalle");
             Console.WriteLine("-----------VACIANDO PRESTACIONES----------------------");
             AccesoLogica.TruncateCascade("core_prestaciones");
             Console.WriteLine("-----------VACIANDO MODO PAGO----------------------");
             AccesoLogica.TruncateCascade("core_modo_pago");
             Console.WriteLine("---------------------------------");
             */



            /*
             Console.WriteLine("-----------VACIANDO FIRMAS PARTICIPES----------------------");
           
            AccesoLogica.TruncateCascade("core_firmas_participes");
            Console.WriteLine("-----------VACIANDO CUENTAS PARTICIPES----------------------");
            AccesoLogica.TruncateCascade("core_participes_cuentas");
            Console.WriteLine("-----------VACIANDO INFORMACION ADICIONAL PARTICIPES----------------------");
            AccesoLogica.TruncateCascade("core_participes_informacion_adicional");
            Console.WriteLine("-----------VACIANDO VALOR DE APORTACIONES POR PARTICIPES----------------------");
            AccesoLogica.TruncateCascade("core_contribucion_tipo_participes");
            Console.WriteLine("-----------VACIANDO PARTICIPES----------------------");
            AccesoLogica.TruncateCascade("core_participes");
            Console.WriteLine("-----------VACIANDO TRANSACCIONES----------------------");
            */




            /// RESTABLECIENDO SECUENCIAS


            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            /*
            Console.WriteLine("-----------SECUENCIA CONTRIBUCIONES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_contribucion_id_contribucion_seq RESTART WITH 1");
             */
            Console.WriteLine("-----------SECUENCIA CONTRIBUCIONES PAGADAS----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_contribucion_pagada_id_contribucion_pagada_seq RESTART WITH 1");

            /*

            Console.WriteLine("-----------SECUENCIA TABLAS DE PAGOS AMORTIZACIONES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_tabla_amortizacion_pagos_id_tabla_amortizacion_pagos_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA TABLAS DE PAGOS PARAMETRIZACION----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_tabla_amortizacion_param_id_core_tabla_amortizacion_pa_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA TABLAS DE AMORTIZACION PAGARES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_tabla_amortizacion_histo_id_tabla_amortizacion_histori_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA TABLAS DE AMORTIZACION PAGARES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_tabla_amortizacion_pagare_id_tabla_amortizacion_pagare_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA TABLAS DE AMORTIZACION----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_tabla_amortizacion_id_tabla_amortizacion_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CREDITOS GARANTIAS----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_creditos_garantias_id_creditos_garantias_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CREDITOS RENOVACIONES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_creditos_renovaciones_id_creditos_renovaciones_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CREDITOS RETENCIONES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_creditos_retenciones_id_creditos_retenciones_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CREDITOS TRABAJADOS DETALLE----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_creditos_trabajados_deta_id_detalle_creditos_trabajado_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CREDITOS TRABAJADOS CABEZA----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_creditos_trabajados_deta_id_detalle_creditos_trabajado_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA ARCHIVOS DE RECAUDACIONES DETALLE----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_archivo_recaudaciones_de_id_archivo_recaudaciones_deta_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA ARCHIVOS DE RECAUDACIONES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_archivo_recaudaciones_id_archivo_recaudaciones_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CREDITOS----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_creditos_id_creditos_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA TRANSACCIONESS----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_transacciones_id_transacciones_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA TRANSACCIONES DETALLE----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_transacciones_detalle_id_core_transacciones_detalle_seq RESTART WITH 1");
            Console.WriteLine("---------------------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_prestaciones_id_prestaciones_seq RESTART WITH 1");
            Console.WriteLine("---------------------------------");
            AccesoLogica.Select("ALTER SEQUENCE modo_pago_id_modo_pago_seq RESTART WITH 1");
            Console.WriteLine("---------------------------------");

            
            Console.WriteLine("-----------SECUENCIA FIRMAS PARTICIPES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_firmas_participes_id_firmas_participes_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CUENTAS PARTICIPES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_participes_cuentas_id_participes_cuentas_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA INFORMACION ADICIONAL PARTICIPES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_participes_informacion_a_id_participes_informacion_adi_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA VALOR DE APORTACIONES POR PARTICIPES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_contribucion_tipo_partic_id_contribucion_tipo_particip_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA PARTICIPES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_participes_id_participes_seq RESTART WITH 1");
          
            */

            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------");

            Console.WriteLine("---------------------------------");



        }


        public static void calcular_moras()
        {

            int _leidos_individual = 0;
            int _year_buscar;
            int _mes_buscar;
            int _id_creditos = 0;
            double _interes_tipo_creditos;


            DataTable dtCreditos = AccesoLogica.Select("c.id_creditos, (t.interes_tipo_creditos/100) as interes_tipo_creditos", "core_creditos c inner join core_tipo_creditos t on c.id_tipo_creditos=t.id_tipo_creditos", "c.id_estado_creditos = 4 and c.id_estatus = 1  ORDER BY c.id_creditos ASC");
            int regT = dtCreditos.Rows.Count;

            if (regT > 0)
            {

                if (_mes == 01 || _mes == 1)
                {
                    _year_buscar = _year - 1;
                    _mes_buscar = 12;

                }
                else
                {
                    _year_buscar = _year;
                    _mes_buscar = _mes - 1;

                }


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------COMENZAMOS VERIFICACIÓN DE MORAS AÑO -> " + _year_buscar + " MES-> " + _mes_buscar + "----------------");
                foreach (DataRow renglon in dtCreditos.Rows)
                {
                    _leidos_individual++;
                    _id_creditos = Convert.ToInt32(renglon["id_creditos"].ToString());
                    _interes_tipo_creditos = Convert.ToDouble(renglon["interes_tipo_creditos"].ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL CREDITOS ->   " + regT + "    LEIDOS ->  " + _leidos_individual + "      NUMERO CRÉDITO ->  " + _id_creditos);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Buscar_Cuotas_Actuales_En_Mora(_id_creditos, _interes_tipo_creditos, _year_buscar, _mes_buscar);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

                }

            }
            else
            {

            }

        }


        public static void Buscar_Cuotas_Actuales_En_Mora(int _id_creditos, double _interes_tipo_creditos, int _year_buscar, int _mes_buscar)
        {

            int _leidos_amortizaciones = 0;

            int _id_tabla_amortizacion;
            DateTime? _fecha_tabla_amortizacion = null;
            int _numero_pago_tabla_amortizacion;
            double _capital_tabla_amortizacion;
            int _id_estado_tabla_amortizacion;

            DateTime? _fecha_anterior_tabla_amortizacion = null;



            DataTable dtAmortizacionesActuales = AccesoLogica.Select("t.id_tabla_amortizacion, t.id_creditos, t.fecha_tabla_amortizacion, t.numero_pago_tabla_amortizacion, t.capital_tabla_amortizacion, t.mora_tabla_amortizacion, t.id_estado_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos=" + _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and to_char(t.fecha_tabla_amortizacion, 'YYYY')='" + _year_buscar + "' and to_char(t.fecha_tabla_amortizacion, 'MM')=LPAD('" + _mes_buscar + "',2,'0') ORDER BY numero_pago_tabla_amortizacion asc");
            int regT = dtAmortizacionesActuales.Rows.Count;

            if (regT > 0)
            {
                foreach (DataRow renglon1 in dtAmortizacionesActuales.Rows)
                {
                    _leidos_amortizaciones++;

                    _id_tabla_amortizacion = Convert.ToInt32(renglon1["id_tabla_amortizacion"].ToString());
                    _fecha_tabla_amortizacion = Convert.ToDateTime(renglon1["fecha_tabla_amortizacion"].ToString());
                    _numero_pago_tabla_amortizacion = Convert.ToInt32(renglon1["numero_pago_tabla_amortizacion"].ToString());
                    _capital_tabla_amortizacion = Convert.ToDouble(renglon1["capital_tabla_amortizacion"].ToString());
                    _id_estado_tabla_amortizacion = Convert.ToInt32(renglon1["id_estado_tabla_amortizacion"].ToString());


                    DataTable dtAmortizacionesAnteriores = AccesoLogica.Select("min(t.fecha_tabla_amortizacion) as fecha_anterior_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos=" + _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and t.mora_tabla_amortizacion>0");
                    int reg_ante = dtAmortizacionesAnteriores.Rows.Count;

                    if (reg_ante > 0)
                    {
                        foreach (DataRow renglon_ante in dtAmortizacionesAnteriores.Rows)
                        {
                            try
                            {
                                _fecha_anterior_tabla_amortizacion = Convert.ToDateTime(renglon_ante["fecha_anterior_tabla_amortizacion"].ToString());
                            }
                            catch (Exception)
                            {

                                _fecha_anterior_tabla_amortizacion = _fecha_tabla_amortizacion;
                            }

                        }
                    }
                    else
                    {


                        if (_fecha_anterior_tabla_amortizacion == null)
                        {
                            _fecha_anterior_tabla_amortizacion = _fecha_tabla_amortizacion;

                        }
                    }


                    Calcular_Valor_Mora_Cuotas_Actuales(_id_creditos, _interes_tipo_creditos, _fecha_tabla_amortizacion, _fecha_anterior_tabla_amortizacion);

                }

            }
            else
            {
                // CREDITOS VENCIDOS

                DataTable dtAmortizacionesAnterioresVencidos = AccesoLogica.Select("min(t.fecha_tabla_amortizacion) as fecha_anterior_tabla_amortizacion, max(t.fecha_tabla_amortizacion) as fecha_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos=" + _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and t.mora_tabla_amortizacion>0");
                int reg_vencidos = dtAmortizacionesAnterioresVencidos.Rows.Count;

                if (reg_vencidos > 0)
                {


                    foreach (DataRow renglon_vencidos in dtAmortizacionesAnterioresVencidos.Rows)
                    {

                        try
                        {

                            _fecha_tabla_amortizacion = Convert.ToDateTime(renglon_vencidos["fecha_tabla_amortizacion"].ToString());
                            _fecha_anterior_tabla_amortizacion = Convert.ToDateTime(renglon_vencidos["fecha_anterior_tabla_amortizacion"].ToString());

                            Calcular_Valor_Mora_Cuotas_Actuales(_id_creditos, _interes_tipo_creditos, _fecha_tabla_amortizacion, _fecha_anterior_tabla_amortizacion);


                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("CREDITO NO SE ENCUENTRA EN MORA.");
                            Console.ForegroundColor = ConsoleColor.Green;

                        }

                    }


                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("CREDITO NO SE ENCUENTRA EN MORA.");
                    Console.ForegroundColor = ConsoleColor.Green;

                }


            }

        }


        public static void Calcular_Valor_Mora_Cuotas_Actuales(int _id_creditos, double _interes_tipo_creditos, DateTime? _fecha_tabla_amortizacion, DateTime? _fecha_anterior_tabla_amortizacion)
        {

            int _id_tabla_amortizacion;
            DateTime _fecha_cuota_tabla_amortizacion;
            int _numero_pago_tabla_amortizacion;
            double _capital_tabla_amortizacion;
            int _id_estado_tabla_amortizacion;

            DataTable dtAmortizacionesCalcular = AccesoLogica.Select("t.id_tabla_amortizacion, t.id_creditos, t.fecha_tabla_amortizacion,  t.numero_pago_tabla_amortizacion, t.capital_tabla_amortizacion, t.mora_tabla_amortizacion, t.id_estado_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos=" + _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and date(t.fecha_tabla_amortizacion) between '" + _fecha_anterior_tabla_amortizacion + "' and '" + _fecha_tabla_amortizacion + "' order by t.numero_pago_tabla_amortizacion asc");
            int reg_calcular = dtAmortizacionesCalcular.Rows.Count;

            if (reg_calcular > 0)
            {
                foreach (DataRow renglon_calcular in dtAmortizacionesCalcular.Rows)
                {

                    _id_tabla_amortizacion = Convert.ToInt32(renglon_calcular["id_tabla_amortizacion"].ToString());
                    _fecha_cuota_tabla_amortizacion = Convert.ToDateTime(renglon_calcular["fecha_tabla_amortizacion"].ToString());
                    _numero_pago_tabla_amortizacion = Convert.ToInt32(renglon_calcular["numero_pago_tabla_amortizacion"].ToString());
                    _capital_tabla_amortizacion = Convert.ToDouble(renglon_calcular["capital_tabla_amortizacion"].ToString());
                    _id_estado_tabla_amortizacion = Convert.ToInt32(renglon_calcular["id_estado_tabla_amortizacion"].ToString());


                    Devuelve_Valor_Calculado_Mora(_id_creditos, _fecha_cuota_tabla_amortizacion, _capital_tabla_amortizacion, _interes_tipo_creditos, _numero_pago_tabla_amortizacion, _id_tabla_amortizacion);



                }
            }




        }


        public static void Devuelve_Valor_Calculado_Mora(int _id_creditos, DateTime _fecha_cuota_tabla_amortizacion, double _capital_tabla_amortizacion, double _interes_tipo_creditos, int _numero_pago_tabla_amortizacion, int _id_tabla_amortizacion)
        {

            TimeSpan interval = Hoy - _fecha_cuota_tabla_amortizacion;
            int _dias_reales_mora = interval.Days;
            DataTable dtFactor;
            double _factor_porcentaje = 0;
            double _valor_mora_cuota = 0;


            if (_dias_reales_mora > 5)
            {

                //temporal para pruebas
                // _dias_reales_mora = _dias_reales_mora - 1;

                if (_dias_reales_mora <= 70)
                {

                    dtFactor = AccesoLogica.Select("m.porcentaje_parametrizacion_moras", "core_parametrizacion_moras m", "dias_parametrizacion_moras=" + _dias_reales_mora + "");

                }
                else
                {

                    dtFactor = AccesoLogica.Select("m.porcentaje_parametrizacion_moras", "core_parametrizacion_moras m", "dias_parametrizacion_moras=71");

                }



                int reg_factor = dtFactor.Rows.Count;
                if (reg_factor > 0)
                {
                    foreach (DataRow renglon_factor in dtFactor.Rows)
                    {
                        _factor_porcentaje = Convert.ToDouble(renglon_factor["porcentaje_parametrizacion_moras"].ToString());
                    }
                }



                _valor_mora_cuota = (_capital_tabla_amortizacion * _interes_tipo_creditos * _factor_porcentaje * _dias_reales_mora) / 360;
                _valor_mora_cuota = Math.Round(_valor_mora_cuota, 2);






                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CUOTA ->     " + _numero_pago_tabla_amortizacion + "      SE ENCUENTRA EN MORA ->        " + _dias_reales_mora + " DIAS" + "         VALOR POR MORA ->        " + _valor_mora_cuota);
                Console.ForegroundColor = ConsoleColor.Green;




                //ENVIO ACTUALIZACION A BASE DE DATOS

                Actualiza_Mora(_id_tabla_amortizacion, _id_creditos, _numero_pago_tabla_amortizacion, _valor_mora_cuota);



            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CUOTA ->     " + _numero_pago_tabla_amortizacion + "         NO SE ENCUENTRA EN MORA ->     TIENE    " + _dias_reales_mora + " DIAS");
                Console.ForegroundColor = ConsoleColor.Green;
            }



        }


        public static void Actualiza_Mora(int _id_tabla_amortizacion, int _id_creditos, int _numero_pago_tabla_amortizacion, double _valor_mora_cuota)
        {


            try
            {



                // RECUPERO EL ID DE PARAMETRIZACION DE MORA
                int _id_tabla_amortizacion_parametrizacion = 0;

                DataTable dtTipoParametrizacion;
                dtTipoParametrizacion = AccesoLogica.Select("id_tabla_amortizacion_parametrizacion", "core_tabla_amortizacion_parametrizacion p inner join core_tipo_creditos t on p.id_tipo_creditos = t.id_tipo_creditos inner join core_creditos c on t.id_tipo_creditos = c.id_tipo_creditos", "c.id_creditos = " + _id_creditos + " and p.tipo_tabla_amortizacion_parametrizacion = 7 and p.id_estado = 114");

                int reg_factor = dtTipoParametrizacion.Rows.Count;
                if (reg_factor > 0)
                {
                    foreach (DataRow renglon_factor in dtTipoParametrizacion.Rows)
                    {
                        _id_tabla_amortizacion_parametrizacion = Convert.ToInt32(renglon_factor["id_tabla_amortizacion_parametrizacion"].ToString());
                    }


                    // ACTUALIZO EL RUBRO POR MORA EN LA TABLA DE AMORTIZACION PAGOS
                    AccesoLogica.Update("core_tabla_amortizacion_pagos", "valor_pago_tabla_amortizacion_pagos=" + _valor_mora_cuota + "", "id_tabla_amortizacion=" + _id_tabla_amortizacion + " AND id_tabla_amortizacion_parametrizacion=" + _id_tabla_amortizacion_parametrizacion + "");






                    // RECUPERO VALOR PAGADO DE MORA DE ESA CUOTA
                    double _total_pago_mora_pagado = 0;
                    double _saldo_mora = 0;

                    DataTable dtPagosMoraPagado;
                    dtPagosMoraPagado = AccesoLogica.Select("coalesce(sum(ctd.valor_transaccion_detalle),0) as total", "core_transacciones ct inner join core_transacciones_detalle ctd on ct.id_transacciones=ctd.id_transacciones inner join core_tabla_amortizacion_pagos ctap on ctd.id_tabla_amortizacion_pago=ctap.id_tabla_amortizacion_pagos inner join core_tabla_amortizacion_parametrizacion ctapa on ctap.id_tabla_amortizacion_parametrizacion=ctapa.id_tabla_amortizacion_parametrizacion", "ct.id_status=1 and ct.id_estado_transacciones=1 and ctapa.tipo_tabla_amortizacion_parametrizacion=7 and ct.id_creditos=" + _id_creditos + " and ctap.id_tabla_amortizacion=" + _id_tabla_amortizacion + "");

                    int reg = dtPagosMoraPagado.Rows.Count;
                    if (reg > 0)
                    {
                        foreach (DataRow renglon in dtPagosMoraPagado.Rows)
                        {
                            _total_pago_mora_pagado = Convert.ToDouble(renglon["total"].ToString());
                        }

                    }

                    _saldo_mora = _valor_mora_cuota - _total_pago_mora_pagado;

                    // ACTUALIZO EL SALDO DEL RUBRO POR MORA EN LA TABLA DE AMORTIZACION PAGOS
                    AccesoLogica.Update("core_tabla_amortizacion_pagos", "saldo_cuota_tabla_amortizacion_pagos=" + _saldo_mora + "", "id_tabla_amortizacion=" + _id_tabla_amortizacion + " AND id_tabla_amortizacion_parametrizacion=" + _id_tabla_amortizacion_parametrizacion + "");





                }








                // RECUPERO VALORES A PAGAR DE LA CUOTA
                double _total_valor_tabla_amortizacion = 0;
                double _total_balance_tabla_amortizacion = 0;

                DataTable dtCuota;
                dtCuota = AccesoLogica.Select("coalesce(sum(p.valor_pago_tabla_amortizacion_pagos),0) as total_cuota, coalesce(sum(p.saldo_cuota_tabla_amortizacion_pagos),0) as total_saldo", "core_tabla_amortizacion_pagos p", "p.id_tabla_amortizacion=" + _id_tabla_amortizacion + "");

                int reg_cuota = dtCuota.Rows.Count;
                if (reg_cuota > 0)
                {
                    foreach (DataRow renglon_cuota in dtCuota.Rows)
                    {
                        _total_valor_tabla_amortizacion = Convert.ToDouble(renglon_cuota["total_cuota"].ToString());
                        _total_balance_tabla_amortizacion = Convert.ToDouble(renglon_cuota["total_saldo"].ToString());
                    }


                    // ACTUALIZO EL CAMPO MORA EN LA TABLA DE AMORTIZACION
                    AccesoLogica.Update("core_tabla_amortizacion", "mora_tabla_amortizacion=" + _valor_mora_cuota + ", total_valor_tabla_amortizacion=" + _total_valor_tabla_amortizacion + ", total_balance_tabla_amortizacion=" + _total_balance_tabla_amortizacion + "", "id_tabla_amortizacion=" + _id_tabla_amortizacion + " AND id_creditos = " + _id_creditos + " AND id_estatus=1");

                }



            }
            catch (Exception Ex)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Error al Actualizar Amortización ->    " + _id_tabla_amortizacion + " Error -> " + Ex.Message);


            }



        }


        public static void cargar_participes()
        {

            DataTable dtParticipes = AccesoLogicaSQL.Select("PARTNER_ID, CASE WHEN DEPENDENCY_ID=0 THEN 228 ELSE DEPENDENCY_ID END  DEPENDENCY_ID, LAST_NAME, FIRST_NAME, IDENTITY_CARD, BIRTH_DATE, ADDRESS, PHONE, PARNERT_MOVIL_PHONE, DATE_ENTRANCE_PN, DATE_OF_DEATH, CASE WHEN STATE=0 THEN 1 ELSE STATE END  STATE, CASE WHEN STATUS=0 THEN 2 ELSE STATUS END  STATUS, DATE_EXIT_PN, GENDER, CASE WHEN MARRITAL_STATUS=0 THEN 2 ELSE MARRITAL_STATUS END MARRITAL_STATUS, OBSERVATION, EMAIL, CASE WHEN EMPLOYER_ENTITY_ID=10000 THEN 104 ELSE EMPLOYER_ENTITY_ID END EMPLOYER_ENTITY_ID, ENTITY_DATE_ENTRY, PARNERT_OCCUPATION, CASE WHEN PARNERT_TYPE_INSTRUCTION=0 THEN 1 ELSE PARNERT_TYPE_INSTRUCTION END PARNERT_TYPE_INSTRUCTION, PARNERT_SPOUSE_LAST_NAME, PARNERT_SPOUSE_NAME, PARNERT_SPOUSE_IDENTIFICATION, PARNERT_NUMBER_DEPENDENTS, ALTERNATIVE_CODE, DATE_ORDER_NUMBER", "one.PARTNER", "1=1 ORDER BY PARTNER_ID ASC");

            int _leidos_individual = 0;

            int _id_participes;
            int _id_cuidades;
            string _apellido_participes;
            string _nombre_participes;
            string _cedula_participes;
            DateTime _fecha_nacimiento_participes;
            string _direccion_participes;
            string _telefono_participes;
            string _celular_participes;
            DateTime _fecha_ingreso_participes;
            DateTime _fecha_defuncion_participes;
            int _id_estado_participes;
            int _id_estatus;
            DateTime _fecha_salida_participes;
            int _id_genero_participes;
            int _id_estado_civil_participes;
            string _observacion_participes;
            string _correo_participes;
            int _id_entidad_patronal;
            DateTime _fecha_entrada_patronal_participes;
            string _ocupacion_participes;
            int _id_tipo_instruccion_participes;
            string _nombre_conyugue_participes;
            string _apellido_esposa_participes;
            string _cedula_conyugue_participes;
            int _numero_dependencias_participes;
            int _codigo_alternativo_participes;
            DateTime _fecha_numero_orden_participes;


            int reg = dtParticipes.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtParticipes.Rows)
                {


                    _id_participes = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _id_cuidades = Convert.ToInt32(renglon["DEPENDENCY_ID"].ToString());
                    _apellido_participes = renglon["LAST_NAME"].ToString();
                    _nombre_participes = renglon["FIRST_NAME"].ToString();
                    _cedula_participes = renglon["IDENTITY_CARD"].ToString();
                    _fecha_nacimiento_participes = Convert.ToDateTime(renglon["BIRTH_DATE"]);
                    _direccion_participes = renglon["ADDRESS"].ToString();
                    _telefono_participes = renglon["PHONE"].ToString();
                    _celular_participes = renglon["PARNERT_MOVIL_PHONE"].ToString();
                    _fecha_ingreso_participes = Convert.ToDateTime(renglon["DATE_ENTRANCE_PN"]);
                    _fecha_defuncion_participes = Convert.ToDateTime(renglon["DATE_OF_DEATH"]);
                    _id_estado_participes = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _fecha_salida_participes = Convert.ToDateTime(renglon["DATE_EXIT_PN"]);
                    _id_genero_participes = Convert.ToInt32(renglon["GENDER"].ToString());
                    _id_estado_civil_participes = Convert.ToInt32(renglon["MARRITAL_STATUS"].ToString());
                    _observacion_participes = renglon["OBSERVATION"].ToString();
                    _correo_participes = renglon["EMAIL"].ToString();
                    _id_entidad_patronal = Convert.ToInt32(renglon["EMPLOYER_ENTITY_ID"].ToString());
                    _fecha_entrada_patronal_participes = Convert.ToDateTime(renglon["ENTITY_DATE_ENTRY"]);
                    _ocupacion_participes = renglon["PARNERT_OCCUPATION"].ToString();
                    _id_tipo_instruccion_participes = Convert.ToInt32(renglon["PARNERT_TYPE_INSTRUCTION"].ToString());
                    _nombre_conyugue_participes = renglon["PARNERT_SPOUSE_LAST_NAME"].ToString();
                    _apellido_esposa_participes = renglon["PARNERT_SPOUSE_NAME"].ToString();
                    _cedula_conyugue_participes = renglon["PARNERT_SPOUSE_IDENTIFICATION"].ToString();
                    _numero_dependencias_participes = Convert.ToInt32(renglon["PARNERT_NUMBER_DEPENDENTS"].ToString());
                    _codigo_alternativo_participes = Convert.ToInt32(renglon["ALTERNATIVE_CODE"].ToString());

                    _fecha_numero_orden_participes = Convert.ToDateTime(renglon["DATE_ORDER_NUMBER"]);
                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PARTICIPES -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Participes(_id_participes, _id_cuidades, _apellido_participes, _nombre_participes, _cedula_participes, _fecha_nacimiento_participes, _direccion_participes, _telefono_participes, _celular_participes, _fecha_ingreso_participes, _fecha_defuncion_participes, _id_estado_participes, _id_estatus, _fecha_salida_participes, _id_genero_participes, _id_estado_civil_participes, _observacion_participes, _correo_participes, _id_entidad_patronal, _fecha_entrada_patronal_participes, _ocupacion_participes, _id_tipo_instruccion_participes, _nombre_conyugue_participes, _apellido_esposa_participes, _cedula_conyugue_participes, _numero_dependencias_participes, _codigo_alternativo_participes, _fecha_numero_orden_participes);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_Participes(int _id_participes, int _id_cuidades, string _apellido_participes, string _nombre_participes, string _cedula_participes, DateTime _fecha_nacimiento_participes, string _direccion_participes, string _telefono_participes, string _celular_participes, DateTime _fecha_ingreso_participes, DateTime _fecha_defuncion_participes, int _id_estado_participes, int _id_estatus, DateTime _fecha_salida_participes, int _id_genero_participes, int _id_estado_civil_participes, string _observacion_participes, string _correo_participes, int _id_entidad_patronal, DateTime _fecha_entrada_patronal_participes, string _ocupacion_participes, int _id_tipo_instruccion_participes, string _nombre_conyugue_participes, string _apellido_esposa_participes, string _cedula_conyugue_participes, int _numero_dependencias_participes, int _codigo_alternativo_participes, DateTime _fecha_numero_orden_participes)
        {

            string cadena1 = _id_participes + "?" + _id_cuidades + "?" + _apellido_participes + "?" + _nombre_participes + "?" + _cedula_participes + "?" + _fecha_nacimiento_participes + "?" + _direccion_participes + "?" + _telefono_participes + "?" + _celular_participes + "?" + _fecha_ingreso_participes + "?" + _fecha_defuncion_participes + "?" + _id_estado_participes + "?" + _id_estatus + "?" + _fecha_salida_participes + "?" + _id_genero_participes + "?" + _id_estado_civil_participes + "?" + _observacion_participes + "?" + _correo_participes + "?" + _id_entidad_patronal + "?" + _fecha_entrada_patronal_participes + "?" + _ocupacion_participes + "?" + _id_tipo_instruccion_participes + "?" + _nombre_conyugue_participes + "?" + _apellido_esposa_participes + "?" + _cedula_conyugue_participes + "?" + _numero_dependencias_participes + "?" + _codigo_alternativo_participes + "?" + _fecha_numero_orden_participes;


            CultureInfo ci = new CultureInfo("es-EC");
            //public.afiliado_transacc_cta_desemb(_ordtran integer, _histo_transacsys character varying, _cedula character varying, _fecha_conta date, _descripcion character varying, _mes_anio character varying, _valorper numeric, _valorpat numeric, _saldoper numeric, _saldopat numeric)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");



            string cadena2 = "_id_participes?_id_cuidades?_apellido_participes?_nombre_participes?_cedula_participes?_fecha_nacimiento_participes?_direccion_participes?_telefono_participes?_celular_participes?_fecha_ingreso_participes?_fecha_defuncion_participes?_id_estado_participes?_id_estatus?_fecha_salida_participes?_id_genero_participes?_id_estado_civil_participes?_observacion_participes?_correo_participes?_id_entidad_patronal?_fecha_entrada_patronal_participes?_ocupacion_participes?_id_tipo_instruccion_participes?_nombre_conyugue_participes?_apellido_esposa_participes?_cedula_conyugue_participes?_numero_dependencias_participes?_codigo_alternativo_participes?_fecha_numero_orden_participes";

            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.TimestampTZ?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_participes_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");


            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Participes" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }






        }


        public static void cargar_informacion_adicional_participes()
        {

            DataTable dtInformacionParticipes = AccesoLogicaSQL.Select("pai.PARNERT_ADITTIONAL_INFORMATION_ID, pai.PARNERT_ID, CASE WHEN pai.PARNERT_REGION=0 THEN 5 ELSE pai.PARNERT_REGION END PARNERT_REGION, CASE WHEN pai.PARNERT_PROVINCE=0 THEN 25 ELSE pai.PARNERT_PROVINCE END PARNERT_PROVINCE, CASE WHEN pai.PARNERT_CITY='0' THEN 228 WHEN pai.PARNERT_CITY='-1' THEN 228 ELSE pai.PARNERT_CITY END PARNERT_CITY, pai.PARNERT_PARISH, pai.PARNERT_SECTOR, pai.PARNERT_CITADEL, pai.PARNERT_STREET, pai.PARNERT_NUMBER, pai.PARNERT_INTERSECTION, CASE WHEN pai.PARNERT_TYPE_RESIDENCE=0 THEN 1 ELSE pai.PARNERT_TYPE_RESIDENCE END PARNERT_TYPE_RESIDENCE, pai.PARNERT_YEAR_RESIDENCE, pai.PARNERT_NAME_OWNER, pai.PARNERT_PHONE_OWNER, pai.PARNERT_REFERENCE_ADDRESS, CASE WHEN pai.PARNERT_STATUS_RESIDENCE=0 THEN 'TRUE' ELSE 'FALSE' END PARNERT_STATUS_RESIDENCE, pai.PARNERT_NAME_REFERENCE,  CASE WHEN pai.PARNERT_DESCRIPTION_REFERENCE='N/A' THEN 10 WHEN pai.PARNERT_DESCRIPTION_REFERENCE='-1' THEN 10 ELSE pai.PARNERT_DESCRIPTION_REFERENCE END PARNERT_DESCRIPTION_REFERENCE, pai.PARNERT_PHONE_REFERENCE, pai.PARNERT_OBSERVATION, CASE WHEN pai.PARNERT_KIT=1 THEN 1 ELSE 0 END PARNERT_KIT, CASE WHEN pai.PARNERT_CONTRACT_ADHESION=1 THEN 1 ELSE 0 END PARNERT_CONTRACT_ADHESION", "one.PARNERT_ADITTIONAL_INFORMATION pai", "1=1 ORDER BY PARNERT_ADITTIONAL_INFORMATION_ID ASC");
            int _leidos = 0;


            int _id_participes_informacion_adicional;
            int _id_participes;
            int _id_distritos;
            int _id_provincias;
            int _id_ciudades;
            string _parroquia_participes_informacion_adicional;
            string _sector_participes_informacion_adicional;
            string _ciudadela_participes_informacion_adicional;
            string _calle_participes_informacion_adicional;
            string _numero_calle_participes_informacion_adicional;
            string _interseccion_participes_informacion_adicional;
            int _id_tipo_vivienda;
            int _anios_residencia_participes_informacion_adicional;
            string _nombre_propietario_participes_informacion_adicional;
            string _telefono_propietario_participes_informacion_adicional;
            string _direccion_referencia_participes_informacion_adicional;
            Boolean _vivienda_hipotecada_participes_informacion_adicional;
            string _nombre_una_referencia_participes_informacion_adicional;
            int _id_parentesco;
            string _telefono_una_referencia_participes_informacion_adicional;
            string _observaciones_participes_informacion_adicional;
            int _kit_participes_informacion_adicional;
            int _contrato_adhesion_participes_informacion_adicional;



            int reg = dtInformacionParticipes.Rows.Count;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtInformacionParticipes.Rows)
                {


                    _id_participes_informacion_adicional = Convert.ToInt32(renglon["PARNERT_ADITTIONAL_INFORMATION_ID"].ToString());
                    _id_participes = Convert.ToInt32(renglon["PARNERT_ID"].ToString());
                    _id_distritos = Convert.ToInt32(renglon["PARNERT_REGION"].ToString());
                    _id_provincias = Convert.ToInt32(renglon["PARNERT_PROVINCE"].ToString());
                    _id_ciudades = Convert.ToInt32(renglon["PARNERT_CITY"].ToString());
                    _parroquia_participes_informacion_adicional = renglon["PARNERT_PARISH"].ToString();
                    _sector_participes_informacion_adicional = renglon["PARNERT_SECTOR"].ToString();
                    _ciudadela_participes_informacion_adicional = renglon["PARNERT_CITADEL"].ToString();
                    _calle_participes_informacion_adicional = renglon["PARNERT_STREET"].ToString();
                    _numero_calle_participes_informacion_adicional = renglon["PARNERT_NUMBER"].ToString();
                    _interseccion_participes_informacion_adicional = renglon["PARNERT_INTERSECTION"].ToString();
                    _id_tipo_vivienda = Convert.ToInt32(renglon["PARNERT_TYPE_RESIDENCE"].ToString());
                    _anios_residencia_participes_informacion_adicional = Convert.ToInt32(renglon["PARNERT_YEAR_RESIDENCE"].ToString());
                    _nombre_propietario_participes_informacion_adicional = renglon["PARNERT_NAME_OWNER"].ToString();
                    _telefono_propietario_participes_informacion_adicional = renglon["PARNERT_PHONE_OWNER"].ToString();
                    _direccion_referencia_participes_informacion_adicional = renglon["PARNERT_REFERENCE_ADDRESS"].ToString();
                    _vivienda_hipotecada_participes_informacion_adicional = Convert.ToBoolean(renglon["PARNERT_STATUS_RESIDENCE"].ToString());
                    _nombre_una_referencia_participes_informacion_adicional = renglon["PARNERT_NAME_REFERENCE"].ToString();
                    _id_parentesco = Convert.ToInt32(renglon["PARNERT_DESCRIPTION_REFERENCE"].ToString());
                    _telefono_una_referencia_participes_informacion_adicional = renglon["PARNERT_PHONE_REFERENCE"].ToString();
                    _observaciones_participes_informacion_adicional = renglon["PARNERT_OBSERVATION"].ToString();
                    _kit_participes_informacion_adicional = Convert.ToInt32(renglon["PARNERT_KIT"].ToString());
                    _contrato_adhesion_participes_informacion_adicional = Convert.ToInt32(renglon["PARNERT_CONTRACT_ADHESION"].ToString());

                    _leidos++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL INFORMACIÓN PARTICIPES -> " + reg + " LEIDOS -> " + _leidos);


                    Ins_InformacionAddParticipes(_id_participes_informacion_adicional, _id_participes, _id_distritos, _id_provincias, _id_ciudades, _parroquia_participes_informacion_adicional, _sector_participes_informacion_adicional, _ciudadela_participes_informacion_adicional, _calle_participes_informacion_adicional, _numero_calle_participes_informacion_adicional, _interseccion_participes_informacion_adicional, _id_tipo_vivienda, _anios_residencia_participes_informacion_adicional, _nombre_propietario_participes_informacion_adicional, _telefono_propietario_participes_informacion_adicional, _direccion_referencia_participes_informacion_adicional, _vivienda_hipotecada_participes_informacion_adicional, _nombre_una_referencia_participes_informacion_adicional, _id_parentesco, _telefono_una_referencia_participes_informacion_adicional, _observaciones_participes_informacion_adicional, _kit_participes_informacion_adicional, _contrato_adhesion_participes_informacion_adicional);


                }
                Console.WriteLine("---------------------------------");
            }


        }


        public static void Ins_InformacionAddParticipes(int _id_participes_informacion_adicional, int _id_participes, int _id_distritos, int _id_provincias, int _id_ciudades, string _parroquia_participes_informacion_adicional, string _sector_participes_informacion_adicional, string _ciudadela_participes_informacion_adicional, string _calle_participes_informacion_adicional, string _numero_calle_participes_informacion_adicional, string _interseccion_participes_informacion_adicional, int _id_tipo_vivienda, int _anios_residencia_participes_informacion_adicional, string _nombre_propietario_participes_informacion_adicional, string _telefono_propietario_participes_informacion_adicional, string _direccion_referencia_participes_informacion_adicional, Boolean _vivienda_hipotecada_participes_informacion_adicional, string _nombre_una_referencia_participes_informacion_adicional, int _id_parentesco, string _telefono_una_referencia_participes_informacion_adicional, string _observaciones_participes_informacion_adicional, int _kit_participes_informacion_adicional, int _contrato_adhesion_participes_informacion_adicional)
        {

            string cadena1 = _id_participes_informacion_adicional + "?" + _id_participes + "?" + _id_distritos + "?" + _id_provincias + "?" + _id_ciudades + "?" + _parroquia_participes_informacion_adicional + "?" + _sector_participes_informacion_adicional + "?" + _ciudadela_participes_informacion_adicional + "?" + _calle_participes_informacion_adicional + "?" + _numero_calle_participes_informacion_adicional + "?" + _interseccion_participes_informacion_adicional + "?" + _id_tipo_vivienda + "?" + _anios_residencia_participes_informacion_adicional + "?" + _nombre_propietario_participes_informacion_adicional + "?" + _telefono_propietario_participes_informacion_adicional + "?" + _direccion_referencia_participes_informacion_adicional + "?" + _vivienda_hipotecada_participes_informacion_adicional + "?" + _nombre_una_referencia_participes_informacion_adicional + "?" + _id_parentesco + "?" + _telefono_una_referencia_participes_informacion_adicional + "?" + _observaciones_participes_informacion_adicional + "?" + _kit_participes_informacion_adicional + "?" + _contrato_adhesion_participes_informacion_adicional;


            CultureInfo ci = new CultureInfo("es-EC");
            //public.afiliado_transacc_cta_desemb(_ordtran integer, _histo_transacsys character varying, _cedula character varying, _fecha_conta date, _descripcion character varying, _mes_anio character varying, _valorper numeric, _valorpat numeric, _saldoper numeric, _saldopat numeric)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            string cadena2 = "_id_participes_informacion_adicional?_id_participes?_id_distritos?_id_provincias?_id_ciudades?_parroquia_participes_informacion_adicional?_sector_participes_informacion_adicional?_ciudadela_participes_informacion_adicional?_calle_participes_informacion_adicional?_numero_calle_participes_informacion_adicional?_interseccion_participes_informacion_adicional?_id_tipo_vivienda?_anios_residencia_participes_informacion_adicional?_nombre_propietario_participes_informacion_adicional?_telefono_propietario_participes_informacion_adicional?_direccion_referencia_participes_informacion_adicional?_vivienda_hipotecada_participes_informacion_adicional?_nombre_una_referencia_participes_informacion_adicional?_id_parentesco?_telefono_una_referencia_participes_informacion_adicional?_observaciones_participes_informacion_adicional?_kit_participes_informacion_adicional?_contrato_adhesion_participes_informacion_adicional";

            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Boolean?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_participes_informacion_adicional_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");


            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Informacion Adicional Participes" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }

        }


        public static void cargar_contribucion_cuenta_individual()
        {

            DataTable dtContribucion_Ind = AccesoLogicaSQL.Select("c.CONTRIBUTION_ID, c.PARTNER_ID, c.DATE, c.PERSONNEL_PAY, c.EMPLOYER_PAY, CASE WHEN c.STATUS=0 THEN 2 ELSE c.STATUS END STATUS, c.DESCRIPTION, c.JOURNAL_ID, c.USER_ID, c.USER_NAME, CASE WHEN c.TYPE=0 THEN 3 ELSE c.TYPE END TYPE, CASE WHEN c.STATE=0 THEN 2 ELSE c.STATE END STATE, CASE WHEN c.ENTITY_EMPLOYER_ID=10000 THEN 104 ELSE c.ENTITY_EMPLOYER_ID END ENTITY_EMPLOYER_ID, c.DATE_ACCOUNT, c.DOCUMENT_NUMBER, c.OBSERVATION, isnull(c.LIQUIDATION_ID,0) LIQUIDATION_ID, isnull(c.DISTRIBUTION_ID,0) DISTRIBUTION_ID, isnull(c.DISCOUNT_TYPE,0) as DISCOUNT_TYPE", "one.CONTRIBUTION c", "1=1 order by c.CONTRIBUTION_ID asc");

            int _leidos_individual = 0;
            Int64 _id_contribucion;
            int _id_participes;
            DateTime _fecha_registro_contribucion;
            double _valor_personal_contribucion;
            double _valor_patronal_contribucion;
            int _id_estatus;
            string _descripcion_contribucion;
            int _id_diario;
            int _id_usuarios;
            string _nombre_usuarios_contribucion;
            int _id_contribucion_tipo;
            int _id_estado_contribucion;
            int _id_entidad_patronal;
            DateTime _fecha_contable_distribucion;
            string _numero_documento_contribucion;
            string _observacion_contribucion;
            Int64 _id_liquidacion;
            Int64 _id_distribucion;
            Int32 _tipo_descuento_contribucion;

            int reg = dtContribucion_Ind.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtContribucion_Ind.Rows)
                {
                    _id_contribucion = Convert.ToInt64(renglon["CONTRIBUTION_ID"].ToString());
                    _id_participes = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _fecha_registro_contribucion = Convert.ToDateTime(renglon["DATE"]);
                    _valor_personal_contribucion = Convert.ToDouble(renglon["PERSONNEL_PAY"]);
                    _valor_patronal_contribucion = Convert.ToDouble(renglon["EMPLOYER_PAY"]);
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _descripcion_contribucion = renglon["DESCRIPTION"].ToString();
                    _id_diario = Convert.ToInt32(renglon["JOURNAL_ID"].ToString());
                    _id_usuarios = Convert.ToInt32(renglon["USER_ID"].ToString());
                    _nombre_usuarios_contribucion = renglon["USER_NAME"].ToString();
                    _id_contribucion_tipo = Convert.ToInt32(renglon["TYPE"].ToString());
                    _id_estado_contribucion = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_entidad_patronal = Convert.ToInt32(renglon["ENTITY_EMPLOYER_ID"].ToString());
                    _fecha_contable_distribucion = Convert.ToDateTime(renglon["DATE_ACCOUNT"]);
                    _numero_documento_contribucion = renglon["DOCUMENT_NUMBER"].ToString();
                    _observacion_contribucion = renglon["OBSERVATION"].ToString();
                    _id_liquidacion = Convert.ToInt64(renglon["LIQUIDATION_ID"].ToString());
                    _id_distribucion = Convert.ToInt64(renglon["DISTRIBUTION_ID"].ToString());
                    _tipo_descuento_contribucion = Convert.ToInt32(renglon["DISCOUNT_TYPE"].ToString());
                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Total Cuenta Individual -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Cta_Individual(_id_contribucion, _id_participes, _fecha_registro_contribucion, _valor_personal_contribucion, _valor_patronal_contribucion, _id_estatus, _descripcion_contribucion, _id_diario, _id_usuarios, _nombre_usuarios_contribucion, _id_contribucion_tipo, _id_estado_contribucion, _id_entidad_patronal, _fecha_contable_distribucion, _numero_documento_contribucion, _observacion_contribucion, _id_liquidacion, _id_distribucion, _tipo_descuento_contribucion);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_Cta_Individual(Int64 _id_contribucion, int _id_participes, DateTime _fecha_registro_contribucion, double _valor_personal_contribucion, double _valor_patronal_contribucion, int _id_estatus, string _descripcion_contribucion, int _id_diario, int _id_usuarios, string _nombre_usuarios_contribucion, int _id_contribucion_tipo, int _id_estado_contribucion, int _id_entidad_patronal, DateTime _fecha_contable_distribucion, string _numero_documento_contribucion, string _observacion_contribucion, Int64 _id_liquidacion, Int64 _id_distribucion, Int32 _tipo_descuento_contribucion)
        {

            string cadena1 = _id_contribucion + "?" + _id_participes + "?" + _fecha_registro_contribucion + "?" + _valor_personal_contribucion + "?" + _valor_patronal_contribucion + "?" + _id_estatus + "?" + _descripcion_contribucion + "?" + _id_diario + "?" + _id_usuarios + "?" + _nombre_usuarios_contribucion + "?" + _id_contribucion_tipo + "?" + _id_estado_contribucion + "?" + _id_entidad_patronal + "?" + _fecha_contable_distribucion + "?" + _numero_documento_contribucion + "?" + _observacion_contribucion + "?" + _id_liquidacion + "?" + _id_distribucion + "?" +  _tipo_descuento_contribucion;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_contribucion?_id_participes?_fecha_registro_contribucion?_valor_personal_contribucion?_valor_patronal_contribucion?_id_estatus?_descripcion_contribucion?_id_diario?_id_usuarios?_nombre_usuarios_contribucion?_id_contribucion_tipo?_id_estado_contribucion?_id_entidad_patronal?_fecha_contable_distribucion?_numero_documento_contribucion?_observacion_contribucion?_id_liquidacion?_id_distribucion?_tipo_descuento_contribucion";
            string cadena3 = "NpgsqlDbType.Bigint?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Bigint?NpgsqlDbType.Bigint?NpgsqlDbType.Integer";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_contribucion_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");


            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Cta Individual" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }


        public static void cargar_contribucion_cuenta_desembolsar()
        {

            DataTable dtContribucion_Desem = AccesoLogicaSQL.Select("c.CONTRIBUTION_EMPLOYER_PAY_OUT, c.PARTNER_ID, c.DATE, c.PERSONNEL_PAY, c.EMPLOYER_PAY, CASE WHEN c.STATUS=0 THEN 2 ELSE c.STATUS END STATUS, c.DESCRIPTION, isnull(c.JOURNAL_ID,0) JOURNAL_ID, c.USER_ID, c.USER_NAME, CASE WHEN c.TYPE=0 THEN 3 ELSE c.TYPE END TYPE, CASE WHEN c.STATE=0 THEN 2 ELSE c.STATE END STATE, CASE WHEN c.ENTITY_EMPLOYER_ID=10000 THEN 104 ELSE c.ENTITY_EMPLOYER_ID END ENTITY_EMPLOYER_ID, c.DATE_ACCOUNT, c.DOCUMENT_NUMBER, c.OBSERVATION, isnull(c.LIQUIDATION_ID,0) LIQUIDATION_ID, isnull(c.DISTRIBUTION_ID,0) DISTRIBUTION_ID", "one.CONTRIBUTION_EMPLOYER_PAY_OUT c", "1=1 order by c.CONTRIBUTION_EMPLOYER_PAY_OUT asc");

            int _leidos_individual = 0;

            int _id_participes;
            DateTime _fecha_registro_contribucion;
            double _valor_personal_contribucion;
            double _valor_patronal_contribucion;
            int _id_estatus;
            string _descripcion_contribucion;
            int _id_diario;
            int _id_usuarios;
            string _nombre_usuarios_contribucion;
            int _id_contribucion_tipo;
            int _id_estado_contribucion;
            int _id_entidad_patronal;
            DateTime _fecha_contable_distribucion;
            string _numero_documento_contribucion;
            string _observacion_contribucion;
            Int64 _id_liquidacion;
            Int64 _id_distribucion;


            int reg = dtContribucion_Desem.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtContribucion_Desem.Rows)
                {
                    _id_participes = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _fecha_registro_contribucion = Convert.ToDateTime(renglon["DATE"]);
                    _valor_personal_contribucion = Convert.ToDouble(renglon["PERSONNEL_PAY"]);
                    _valor_patronal_contribucion = Convert.ToDouble(renglon["EMPLOYER_PAY"]);
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _descripcion_contribucion = renglon["DESCRIPTION"].ToString();
                    _id_diario = Convert.ToInt32(renglon["JOURNAL_ID"].ToString());
                    _id_usuarios = Convert.ToInt32(renglon["USER_ID"].ToString());
                    _nombre_usuarios_contribucion = renglon["USER_NAME"].ToString();
                    _id_contribucion_tipo = Convert.ToInt32(renglon["TYPE"].ToString());
                    _id_estado_contribucion = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_entidad_patronal = Convert.ToInt32(renglon["ENTITY_EMPLOYER_ID"].ToString());
                    _fecha_contable_distribucion = Convert.ToDateTime(renglon["DATE_ACCOUNT"]);
                    _numero_documento_contribucion = renglon["DOCUMENT_NUMBER"].ToString();
                    _observacion_contribucion = renglon["OBSERVATION"].ToString();
                    _id_liquidacion = Convert.ToInt64(renglon["LIQUIDATION_ID"].ToString());
                    _id_distribucion = Convert.ToInt64(renglon["DISTRIBUTION_ID"].ToString());

                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Total Cuenta Desembolsar -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Cta_Desembolsar(_id_participes, _fecha_registro_contribucion, _valor_personal_contribucion, _valor_patronal_contribucion, _id_estatus, _descripcion_contribucion, _id_diario, _id_usuarios, _nombre_usuarios_contribucion, _id_contribucion_tipo, _id_estado_contribucion, _id_entidad_patronal, _fecha_contable_distribucion, _numero_documento_contribucion, _observacion_contribucion, _id_liquidacion, _id_distribucion);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_Cta_Desembolsar(int _id_participes, DateTime _fecha_registro_contribucion, double _valor_personal_contribucion, double _valor_patronal_contribucion, int _id_estatus, string _descripcion_contribucion, int _id_diario, int _id_usuarios, string _nombre_usuarios_contribucion, int _id_contribucion_tipo, int _id_estado_contribucion, int _id_entidad_patronal, DateTime _fecha_contable_distribucion, string _numero_documento_contribucion, string _observacion_contribucion, Int64 _id_liquidacion, Int64 _id_distribucion)
        {
            string cadena1 = _id_participes + "?" + _fecha_registro_contribucion + "?" + _valor_personal_contribucion + "?" + _valor_patronal_contribucion + "?" + _id_estatus + "?" + _descripcion_contribucion + "?" + _id_diario + "?" + _id_usuarios + "?" + _nombre_usuarios_contribucion + "?" + _id_contribucion_tipo + "?" + _id_estado_contribucion + "?" + _id_entidad_patronal + "?" + _fecha_contable_distribucion + "?" + _numero_documento_contribucion + "?" + _observacion_contribucion + "?" + _id_liquidacion + "?" + _id_distribucion;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_participes?_fecha_registro_contribucion?_valor_personal_contribucion?_valor_patronal_contribucion?_id_estatus?_descripcion_contribucion?_id_diario?_id_usuarios?_nombre_usuarios_contribucion?_id_contribucion_tipo?_id_estado_contribucion?_id_entidad_patronal?_fecha_contable_distribucion?_numero_documento_contribucion?_observacion_contribucion?_id_liquidacion?_id_distribucion";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Bigint?NpgsqlDbType.Bigint";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_contribucion_pagada_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Cta Desembolsar" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }


        public static void cargar_creditos()
        {

            DataTable dtCreditos = AccesoLogicaSQL.Select("c.CREDIT_ID, c.PARTNER_ID, c.CREDIT_PRODUCT_ID, c.AMOUNT, c.BALANCE, c.DATE, CASE WHEN c.STATE=15 THEN 12 WHEN c.STATE=16 THEN 13 ELSE  c.STATE END STATE, c.TERM, c.NET_AMOUNT, c.REQUEST_NUMBER, CASE WHEN c.TYPE=35 THEN 1 WHEN c.TYPE=36 THEN 2 WHEN c.TYPE=38 THEN 3 WHEN c.TYPE=40 THEN 4 WHEN c.TYPE=65 THEN 5 WHEN c.TYPE=66 THEN 6 END TYPE, LTRIM(RTRIM(c.OBSERVATION)) AS OBSERVATION, CASE WHEN c.STATUS=0 THEN 2 ELSE c.STATUS END  STATUS, c.REQUEST_RECEIVER, c.INTEREST, c.INSURANCE_EXEMPT_TAX, c.DATE_SERVER, c.CALCULO_BASE_PARTNER", "one.CREDIT c", "1=1 order by c.CREDIT_ID asc");

            int _leidos_individual = 0;


            int _id_creditos;
            string _numero_creditos;
            int _id_participes;
            int _id_creditos_productos;
            double _monto_otorgado_creditos;
            double _saldo_actual_creditos;
            DateTime _fecha_concesion_creditos;
            int _id_estado_creditos;
            int _plazo_creditos;
            double _monto_neto_entregado_creditos;
            int _numero_solicitud_creditos;
            int _id_tipo_creditos;
            string _observacion_creditos;
            int _id_estatus;
            string _receptor_solicitud_creditos;
            double _interes_creditos;
            double _impuesto_exento_seguro_creditos;
            DateTime _fecha_servidor_creditos;
            double _base_calculo_participes_creditos;



            int reg = dtCreditos.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtCreditos.Rows)
                {

                    _id_creditos = Convert.ToInt32(renglon["CREDIT_ID"].ToString());
                    _numero_creditos = renglon["CREDIT_ID"].ToString();
                    _id_participes = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _id_creditos_productos = Convert.ToInt32(renglon["CREDIT_PRODUCT_ID"].ToString());
                    _monto_otorgado_creditos = Convert.ToDouble(renglon["AMOUNT"]);
                    _saldo_actual_creditos = Convert.ToDouble(renglon["BALANCE"]);
                    _fecha_concesion_creditos = Convert.ToDateTime(renglon["DATE"]);
                    _id_estado_creditos = Convert.ToInt32(renglon["STATE"].ToString());
                    _plazo_creditos = Convert.ToInt32(renglon["TERM"].ToString());
                    _monto_neto_entregado_creditos = Convert.ToDouble(renglon["NET_AMOUNT"]);
                    _numero_solicitud_creditos = Convert.ToInt32(renglon["REQUEST_NUMBER"]);
                    _id_tipo_creditos = Convert.ToInt32(renglon["TYPE"].ToString());
                    _observacion_creditos = renglon["OBSERVATION"].ToString();
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _receptor_solicitud_creditos = renglon["REQUEST_RECEIVER"].ToString();
                    _interes_creditos = Convert.ToDouble(renglon["INTEREST"]);
                    _impuesto_exento_seguro_creditos = Convert.ToDouble(renglon["INSURANCE_EXEMPT_TAX"]);
                    _fecha_servidor_creditos = Convert.ToDateTime(renglon["DATE_SERVER"]);
                    _base_calculo_participes_creditos = Convert.ToDouble(renglon["CALCULO_BASE_PARTNER"]);



                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Total Créditos -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Creditos(_id_creditos, _numero_creditos, _id_participes, _id_creditos_productos, _monto_otorgado_creditos, _saldo_actual_creditos, _fecha_concesion_creditos, _id_estado_creditos, _plazo_creditos, _monto_neto_entregado_creditos, _numero_solicitud_creditos, _id_tipo_creditos, _observacion_creditos, _id_estatus, _receptor_solicitud_creditos, _interes_creditos, _impuesto_exento_seguro_creditos, _fecha_servidor_creditos, _base_calculo_participes_creditos);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_Creditos(int _id_creditos, string _numero_creditos, int _id_participes, int _id_creditos_productos, double _monto_otorgado_creditos, double _saldo_actual_creditos, DateTime _fecha_concesion_creditos, int _id_estado_creditos, int _plazo_creditos, double _monto_neto_entregado_creditos, int _numero_solicitud_creditos, int _id_tipo_creditos, string _observacion_creditos, int _id_estatus, string _receptor_solicitud_creditos, double _interes_creditos, double _impuesto_exento_seguro_creditos, DateTime _fecha_servidor_creditos, double _base_calculo_participes_creditos)
        {
            string cadena1 = _id_creditos + "?" + _numero_creditos + "?" + _id_participes + "?" + _id_creditos_productos + "?" + _monto_otorgado_creditos + "?" + _saldo_actual_creditos + "?" + _fecha_concesion_creditos + "?" + _id_estado_creditos + "?" + _plazo_creditos + "?" + _monto_neto_entregado_creditos + "?" + _numero_solicitud_creditos + "?" + _id_tipo_creditos + "?" + _observacion_creditos + "?" + _id_estatus + "?" + _receptor_solicitud_creditos + "?" + _interes_creditos + "?" + _impuesto_exento_seguro_creditos + "?" + _fecha_servidor_creditos + "?" + _base_calculo_participes_creditos;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_creditos?_numero_creditos?_id_participes?_id_creditos_productos?_monto_otorgado_creditos?_saldo_actual_creditos?_fecha_concesion_creditos?_id_estado_creditos?_plazo_creditos?_monto_neto_entregado_creditos?_numero_solicitud_creditos?_id_tipo_creditos?_observacion_creditos?_id_estatus?_receptor_solicitud_creditos?_interes_creditos?_impuesto_exento_seguro_creditos?_fecha_servidor_creditos?_base_calculo_participes_creditos";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Date?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Date?NpgsqlDbType.Double";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_creditos_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Créditos" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //  Console.Read();

            }

        }


        public static void cargar_tablas_amortizacion()
        {

            DataTable dtAmortizacion = AccesoLogicaSQL.Select("at.AMORTIZATION_TABLE_ID, at.CREDIT_ID, at.DATE, at.NUMBER_PAY, at.CAPITAL, at.INTEREST, at.DIVIDEND, at.BALANCE, at.TOTAL_VALUE, at.TOTAL_BALANCE, at.PROVISION, at.MOOR, CASE WHEN at.STATE=0 THEN 3 ELSE at.STATE END  STATE, CASE WHEN at.STATUS=0 THEN 2 ELSE at.STATUS END  STATUS, at.INTEREST_PERCENTAGE, at.NUMBER_DAYS, at.SERVER_DATE", "one.AMORTIZATION_TABLE at", "1=1 order by at.AMORTIZATION_TABLE_ID asc");

            int _leidos_individual = 0;


            int _id_tabla_amortizacion;
            int _id_creditos;
            DateTime _fecha_tabla_amortizacion;
            int _numero_pago_tabla_amortizacion;
            double _capital_tabla_amortizacion;
            double _interes_tabla_amortizacion;
            double _dividendo_tabla_amortizacion;
            double _balance_tabla_amortizacion;
            double _total_valor_tabla_amortizacion;
            double _total_balance_tabla_amortizacion;
            double _provision_tabla_amortizacion;
            double _mora_tabla_amortizacion;
            int _id_estado_tabla_amortizacion;
            int _id_estatus;
            double _porcentaje_interes_tabla_amortizacion;
            int _numero_dias_tabla_amortizacion;
            DateTime _fecha_servidor_tabla_amortizacion;


            int reg = dtAmortizacion.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtAmortizacion.Rows)
                {


                    _id_tabla_amortizacion = Convert.ToInt32(renglon["AMORTIZATION_TABLE_ID"].ToString());
                    _id_creditos = Convert.ToInt32(renglon["CREDIT_ID"].ToString());
                    _fecha_tabla_amortizacion = Convert.ToDateTime(renglon["DATE"]);
                    _numero_pago_tabla_amortizacion = Convert.ToInt32(renglon["NUMBER_PAY"].ToString());
                    _capital_tabla_amortizacion = Convert.ToDouble(renglon["CAPITAL"]);
                    _interes_tabla_amortizacion = Convert.ToDouble(renglon["INTEREST"]);
                    _dividendo_tabla_amortizacion = Convert.ToDouble(renglon["DIVIDEND"]);
                    _balance_tabla_amortizacion = Convert.ToDouble(renglon["BALANCE"]);
                    _total_valor_tabla_amortizacion = Convert.ToDouble(renglon["TOTAL_VALUE"]);
                    _total_balance_tabla_amortizacion = Convert.ToDouble(renglon["TOTAL_BALANCE"]);
                    _provision_tabla_amortizacion = Convert.ToDouble(renglon["PROVISION"]);
                    _mora_tabla_amortizacion = Convert.ToDouble(renglon["MOOR"]);
                    _id_estado_tabla_amortizacion = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _porcentaje_interes_tabla_amortizacion = Convert.ToDouble(renglon["INTEREST_PERCENTAGE"]);
                    _numero_dias_tabla_amortizacion = Convert.ToInt32(renglon["NUMBER_DAYS"].ToString());
                    _fecha_servidor_tabla_amortizacion = Convert.ToDateTime(renglon["SERVER_DATE"]);


                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Total Amortizaciones -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Tablas_Amortizacion(_id_tabla_amortizacion, _id_creditos, _fecha_tabla_amortizacion, _numero_pago_tabla_amortizacion, _capital_tabla_amortizacion, _interes_tabla_amortizacion, _dividendo_tabla_amortizacion, _balance_tabla_amortizacion, _total_valor_tabla_amortizacion, _total_balance_tabla_amortizacion, _provision_tabla_amortizacion, _mora_tabla_amortizacion, _id_estado_tabla_amortizacion, _id_estatus, _porcentaje_interes_tabla_amortizacion, _numero_dias_tabla_amortizacion, _fecha_servidor_tabla_amortizacion);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_Tablas_Amortizacion(int _id_tabla_amortizacion, int _id_creditos, DateTime _fecha_tabla_amortizacion, int _numero_pago_tabla_amortizacion, double _capital_tabla_amortizacion, double _interes_tabla_amortizacion, double _dividendo_tabla_amortizacion, double _balance_tabla_amortizacion, double _total_valor_tabla_amortizacion, double _total_balance_tabla_amortizacion, double _provision_tabla_amortizacion, double _mora_tabla_amortizacion, int _id_estado_tabla_amortizacion, int _id_estatus, double _porcentaje_interes_tabla_amortizacion, int _numero_dias_tabla_amortizacion, DateTime _fecha_servidor_tabla_amortizacion)
        {
            string cadena1 = _id_tabla_amortizacion + "?" + _id_creditos + "?" + _fecha_tabla_amortizacion + "?" + _numero_pago_tabla_amortizacion + "?" + _capital_tabla_amortizacion + "?" + _interes_tabla_amortizacion + "?" + _dividendo_tabla_amortizacion + "?" + _balance_tabla_amortizacion + "?" + _total_valor_tabla_amortizacion + "?" + _total_balance_tabla_amortizacion + "?" + _provision_tabla_amortizacion + "?" + _mora_tabla_amortizacion + "?" + _id_estado_tabla_amortizacion + "?" + _id_estatus + "?" + _porcentaje_interes_tabla_amortizacion + "?" + _numero_dias_tabla_amortizacion + "?" + _fecha_servidor_tabla_amortizacion;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_tabla_amortizacion?_id_creditos?_fecha_tabla_amortizacion?_numero_pago_tabla_amortizacion?_capital_tabla_amortizacion?_interes_tabla_amortizacion?_dividendo_tabla_amortizacion?_balance_tabla_amortizacion?_total_valor_tabla_amortizacion?_total_balance_tabla_amortizacion?_provision_tabla_amortizacion?_mora_tabla_amortizacion?_id_estado_tabla_amortizacion?_id_estatus?_porcentaje_interes_tabla_amortizacion?_numero_dias_tabla_amortizacion?_fecha_servidor_tabla_amortizacion";
            string cadena3 = "NpgsqlDbType.Bigint?NpgsqlDbType.Integer?NpgsqlDbType.Date?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Date";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_tabla_amortizacion_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Amortización" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }


        public static void cargar_formulas()
        {

            DataTable dtFormulas = AccesoLogicaSQL.Select("fo.FORMULA_ID, fo.EXPRESSION, fo.DESCRIPTION, case when fo.STATUS = 1 then 112 else 113 end as id_estado", "( select formula_id from one.AMORTIZATION_TABLE_ADDITIONAL_VALUE group by formula_id) f inner join one.FORMULA fo on fo.FORMULA_ID = f.FORMULA_ID", "1=1");


            int _leidos_individual = 0;



            string _expresion_formulas;
            string _descripcion_formulas;
            int _id_estado;
            int _id_temporal;
            int reg = dtFormulas.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtFormulas.Rows)
                {


                    _expresion_formulas = renglon["EXPRESSION"].ToString();
                    _descripcion_formulas = renglon["DESCRIPTION"].ToString();
                    _id_estado = Convert.ToInt32(renglon["id_estado"].ToString());
                    _id_temporal = Convert.ToInt32(renglon["FORMULA_ID"].ToString());
                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL FORMULAS -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Formulas(_expresion_formulas, _descripcion_formulas, _id_estado, _id_temporal);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_Formulas(string _expresion_formulas, string _descripcion_formulas, int _id_estado, int _id_temporal)
        {
            string cadena1 = _expresion_formulas + "?" + _descripcion_formulas + "?" + _id_estado + "?" + _id_temporal;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_expresion_formulas?_descripcion_formulas?_id_estado?_id_temporal";
            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_formulas_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Amortización" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //  Console.Read();

            }

        }


        // PARAMETRIZACION RECAUDACION DE CREDITOS

        public static void cargar_parametrizacion_tabla_amortizacion()
        {

            DataTable dtParametrizacion = AccesoLogicaSQL.Select("CASE WHEN ct.CREDIT_TYPE_ID=35 THEN 1  WHEN ct.CREDIT_TYPE_ID=36 THEN 2 WHEN ct.CREDIT_TYPE_ID=38 THEN 3 WHEN ct.CREDIT_TYPE_ID=40 THEN 4 WHEN ct.CREDIT_TYPE_ID=65 THEN 5 WHEN ct.CREDIT_TYPE_ID=66 THEN 6 END CREDIT_TYPE_ID, at.NAME, at.TYPE, at.ORDER_COLLECTION, CASE WHEN at.STATUS=1 THEN 114 ELSE 115 END STATUS, at.ACCOUNT_ID, at.USER_LOGIN", "(select a.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID  from one.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE a inner join one.AMORTIZATION_TABLE_ADDITIONAL_VALUE at1 on a.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID=at1.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID group by a.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID) t inner join one.AMORTIZATION_TABLE_ADDITIONAL_VALUE at on t.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID=at.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID inner join one.CREDIT_PRODUCT cp on at.CREDIT_PRODUCT_ID=cp.CREDIT_PRODUCT_ID inner join one.CREDIT_TYPE ct on cp.CREDIT_TYPE_ID=ct.CREDIT_TYPE_ID", "1=1 order by ct.CREDIT_TYPE_ID ASC");


            int _leidos_individual = 0;


            int _id_tipo_creditos;
            string _descripcion_tabla_amortizacion_parametrizacion;
            int _tipo_tabla_amortizacion_parametrizacion;
            int _orden_tabla_amortizacion_parametrizacion;
            int _id_plan_cuentas;
            int _id_estado;
            string _usuario_usuarios;



            int reg = dtParametrizacion.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtParametrizacion.Rows)
                {

                    _id_tipo_creditos = Convert.ToInt32(renglon["CREDIT_TYPE_ID"].ToString());
                    _descripcion_tabla_amortizacion_parametrizacion = renglon["NAME"].ToString();
                    _tipo_tabla_amortizacion_parametrizacion = Convert.ToInt32(renglon["TYPE"].ToString());
                    _orden_tabla_amortizacion_parametrizacion = Convert.ToInt32(renglon["ORDER_COLLECTION"].ToString());
                    _id_plan_cuentas = Convert.ToInt32(renglon["ACCOUNT_ID"].ToString());
                    _id_estado = Convert.ToInt32(renglon["STATUS"].ToString());
                    _usuario_usuarios = renglon["USER_LOGIN"].ToString();



                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PARAMETRIZACIONES RECAUDO TABLAS DE AMORTIZACION -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Parametrizacion_Tabla_Amortizacion(_id_tipo_creditos, _descripcion_tabla_amortizacion_parametrizacion, _tipo_tabla_amortizacion_parametrizacion, _orden_tabla_amortizacion_parametrizacion, _id_plan_cuentas, _id_estado, _usuario_usuarios);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }

        public static void Ins_Parametrizacion_Tabla_Amortizacion(int _id_tipo_creditos, string _descripcion_tabla_amortizacion_parametrizacion, int _tipo_tabla_amortizacion_parametrizacion, int _orden_tabla_amortizacion_parametrizacion, int _id_plan_cuentas, int _id_estado, string _usuario_usuarios)
        {
            string cadena1 = _id_tipo_creditos + "?" + _descripcion_tabla_amortizacion_parametrizacion + "?" + _tipo_tabla_amortizacion_parametrizacion + "?" + _orden_tabla_amortizacion_parametrizacion + "?" + _id_plan_cuentas + "?" + _id_estado + "?" + _usuario_usuarios;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_tipo_creditos?_descripcion_tabla_amortizacion_parametrizacion?_tipo_tabla_amortizacion_parametrizacion?_orden_tabla_amortizacion_parametrizacion?_id_plan_cuentas?_id_estado?_usuario_usuarios";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_tabla_amortizacion_parametrizacion_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Parametrización Recaudacion Tabla de Amortización" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }

        }


        public static void cargar_pagos_tablas_amortizacion()
        {

            DataTable dtPagos = AccesoLogicaSQL.Select("ap.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID, ap.AMORTIZATION_TABLE_ID, ap.VALUE, ap.BALANCE, CASE WHEN ap.STATUS=0 THEN 2 ELSE ap.STATUS END STATUS, ap.DATE, CASE WHEN ct.CREDIT_TYPE_ID=35 THEN 1  WHEN ct.CREDIT_TYPE_ID=36 THEN 2 WHEN ct.CREDIT_TYPE_ID=38 THEN 3 WHEN ct.CREDIT_TYPE_ID=40 THEN 4 WHEN ct.CREDIT_TYPE_ID=65 THEN 5 WHEN ct.CREDIT_TYPE_ID=66 THEN 6 END CREDIT_TYPE_ID, at.TYPE, at.NAME", "one.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE ap inner join one.AMORTIZATION_TABLE_ADDITIONAL_VALUE at on ap.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID=at.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID inner join one.CREDIT_PRODUCT cp on at.CREDIT_PRODUCT_ID=cp.CREDIT_PRODUCT_ID inner join one.CREDIT_TYPE ct on cp.CREDIT_TYPE_ID=ct.CREDIT_TYPE_ID", "1=1 order by ap.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID ASC");


            int _leidos_individual = 0;

            Int64 _id_tabla_amortizacion_pagos;
            int _id_tabla_amortizacion_parametrizacion;
            Int64 _id_tabla_amortizacion;
            double _valor_pago_tabla_amortizacion_pagos;
            double _saldo_cuota_tabla_amortizacion_pagos;
            int _id_estatus;
            DateTime _fecha_pago_tabla_amortizacion_pagos;

            int _id_tipo_creditos;
            int _tipo_tabla_amortizacion_parametrizacion;
            string _descripcion_tabla_amortizacion_parametrizacion;

            int reg = dtPagos.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtPagos.Rows)
                {

                    _id_tabla_amortizacion_pagos = Convert.ToInt64(renglon["APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID"].ToString());
                    _id_tabla_amortizacion = Convert.ToInt64(renglon["AMORTIZATION_TABLE_ID"].ToString());
                    _valor_pago_tabla_amortizacion_pagos = Convert.ToDouble(renglon["VALUE"].ToString());
                    _saldo_cuota_tabla_amortizacion_pagos = Convert.ToDouble(renglon["BALANCE"].ToString());
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _fecha_pago_tabla_amortizacion_pagos = Convert.ToDateTime(renglon["DATE"].ToString());

                    _id_tipo_creditos = Convert.ToInt32(renglon["CREDIT_TYPE_ID"].ToString());
                    _tipo_tabla_amortizacion_parametrizacion = Convert.ToInt32(renglon["TYPE"].ToString());
                    _descripcion_tabla_amortizacion_parametrizacion = renglon["NAME"].ToString();


                    _leidos_individual++;

                    _id_tabla_amortizacion_parametrizacion = BuscarParametrizacion(_id_tipo_creditos, _tipo_tabla_amortizacion_parametrizacion, _descripcion_tabla_amortizacion_parametrizacion);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PAGOS TABLAS DE AMORTIZACION -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Pagos_Tabla_Amortizacion(_id_tabla_amortizacion_pagos, _id_tabla_amortizacion_parametrizacion, _id_tabla_amortizacion, _valor_pago_tabla_amortizacion_pagos, _saldo_cuota_tabla_amortizacion_pagos, _id_estatus, _fecha_pago_tabla_amortizacion_pagos);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static int BuscarParametrizacion(int _id_tipo_creditos, int _tipo_tabla_amortizacion_parametrizacion, string _descripcion_tabla_amortizacion_parametrizacion)
        {

            DataTable dtAfiliadosT = AccesoLogica.Select("id_tabla_amortizacion_parametrizacion", "core_tabla_amortizacion_parametrizacion", "id_tipo_creditos=" + _id_tipo_creditos + " AND tipo_tabla_amortizacion_parametrizacion=" + _tipo_tabla_amortizacion_parametrizacion + " AND descripcion_tabla_amortizacion_parametrizacion='" + _descripcion_tabla_amortizacion_parametrizacion + "' ");
            int regT = dtAfiliadosT.Rows.Count;


            int _id_tabla_amortizacion_parametrizacion = 0;

            if (regT > 0)
            {
                foreach (DataRow renglon in dtAfiliadosT.Rows)
                {
                    _id_tabla_amortizacion_parametrizacion = Convert.ToInt32(renglon["id_tabla_amortizacion_parametrizacion"].ToString());
                }

            }
            else
            {

            }

            return _id_tabla_amortizacion_parametrizacion;

        }


        public static void Ins_Pagos_Tabla_Amortizacion(Int64 _id_tabla_amortizacion_pagos, int _id_tabla_amortizacion_parametrizacion, Int64 _id_tabla_amortizacion, double _valor_pago_tabla_amortizacion_pagos, double _saldo_cuota_tabla_amortizacion_pagos, int _id_estatus, DateTime _fecha_pago_tabla_amortizacion_pagos)
        {
            string cadena1 = _id_tabla_amortizacion_pagos + "?" + _id_tabla_amortizacion_parametrizacion + "?" + _id_tabla_amortizacion + "?" + _valor_pago_tabla_amortizacion_pagos + "?" + _saldo_cuota_tabla_amortizacion_pagos + "?" + _id_estatus + "?" + _fecha_pago_tabla_amortizacion_pagos;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");





            string cadena2 = "_id_tabla_amortizacion_pagos?_id_tabla_amortizacion_parametrizacion?_id_tabla_amortizacion?_valor_pago_tabla_amortizacion_pagos?_saldo_cuota_tabla_amortizacion_pagos?_id_estatus?_fecha_pago_tabla_amortizacion_pagos";
            string cadena3 = "NpgsqlDbType.Bigint?NpgsqlDbType.Integer?NpgsqlDbType.Bigint?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTz";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_tabla_amortizacion_pagos_migracion");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Pagos Recaudacion Tabla de Amortización" + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }

        }


        public static void Cierre_Mes_Creditos()
        {

            int _leidos = 0;
            int _year_buscar;
            int _mes_buscar;

            if (_mes == 01 || _mes == 1)
            {
                _year_buscar = _year - 1;
                _mes_buscar = 12;

            }
            else
            {
                _year_buscar = _year;
                _mes_buscar = _mes - 1;

            }


            DateTime _primer_dia_mes = new DateTime(_year_buscar, _mes_buscar, 1);
            DateTime _ultimo_dia_mes = _primer_dia_mes.AddMonths(1).AddDays(-1);

            
            // VACIO DATOS DEL MES EXISTENTES
            DataTable dt_cierre_mes = AccesoLogica.Select("id_creditos_cierre_mes", "core_creditos_cierre_mes c", "c.mes_cierre_mes=" + _mes_buscar + " and c.anio_cierre_mes=" + _year_buscar + "");
            int reg_cierre = dt_cierre_mes.Rows.Count;
            int _id_creditos_cierre_mes = 0;

            if (reg_cierre > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------ELIMINANDO CREDITOS CERRADOS EN EL MES ->      " + _ultimo_dia_mes + "-----------------------------");



                foreach (DataRow renglon2 in dt_cierre_mes.Rows)
                {
                    _id_creditos_cierre_mes = Convert.ToInt32(renglon2["id_creditos_cierre_mes"].ToString());
                    //eliminando
                    int result2 = AccesoLogica.Delete("id_creditos_cierre_mes= '" + _id_creditos_cierre_mes + "'", "core_creditos_cierre_mes");

                    Console.WriteLine("ELIMINANDO ->           " + _id_creditos_cierre_mes);

                }
                Console.WriteLine("");
                Console.WriteLine("TOTAL CREDITOS CERRADOS EN EL MES ELIMINADOS ->" + reg_cierre);


            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------COMENZAMOS CARGA DE CREDITOS CRÉDITOS PERIODO ->    " + _ultimo_dia_mes + "--------------------------------");
           


            // EMPIEZA CIEERRE DE MES CONSULTANDO LOS CREDITOS
            DataTable dtCreditos = AccesoLogica.Select("c.id_creditos, c.id_participes, c.monto_otorgado_creditos, c.id_estado_creditos", "core_creditos c", "c.id_estatus=1 and c.id_estado_creditos not in (1,2,3,6)  and c.fecha_concesion_creditos <='" + _ultimo_dia_mes + "' ORDER BY c.id_estado_creditos ASC");
            int reg_creditos = dtCreditos.Rows.Count;

            if (reg_creditos > 0)
            {

                int _id_creditos;
                int _id_participes;
                double _monto_otorgado_creditos = 0;
                int _id_estado_creditos;


                foreach (DataRow renglon_creditos in dtCreditos.Rows)
                {
                    _leidos++;
                    _id_creditos = Convert.ToInt32(renglon_creditos["id_creditos"].ToString());
                    _id_participes = Convert.ToInt32(renglon_creditos["id_participes"].ToString());
                    _monto_otorgado_creditos = Convert.ToDouble(renglon_creditos["monto_otorgado_creditos"].ToString());
                    _id_estado_creditos = Convert.ToInt32(renglon_creditos["id_estado_creditos"].ToString());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL CREDITOS ->   " + reg_creditos + "    LEIDOS ->  " + _leidos + "      NUMERO CRÉDITO ->  " + _id_creditos);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Buscar_Pagos_Capital(_id_creditos, _id_participes, _monto_otorgado_creditos, _id_estado_creditos, _year_buscar, _mes_buscar, _ultimo_dia_mes);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");


                }
            }


        }


        public static void Buscar_Pagos_Capital(int _id_creditos, int _id_participes, double _monto_otorgado_creditos, int _id_estado_creditos, int _year_buscar, int _mes_buscar, DateTime _ultimo_dia_mes)
        {

            double _mov_ini = 0;
            int _year_buscar_inicial;
            int _mes_buscar_inicial = 12;

            // CONSIGO EL AÑO PARA VERIFICAR MOVIMIENTO INICIAL DEL PERIODO
            _year_buscar_inicial = _year_buscar - 1;

            DateTime _primer_dia_mes_inicial = new DateTime(_year_buscar_inicial, _mes_buscar_inicial, 1);
            DateTime _ultimo_dia_mes_inicial = _primer_dia_mes_inicial.AddMonths(1).AddDays(-1);




            // CONSULTO MOVIMIENTO INICIAL DEL PERIODO
            DataTable dtPagos = AccesoLogica.Select("coalesce(sum(ctd.valor_transaccion_detalle),0) as total_movimiento", "core_transacciones ct inner join core_transacciones_detalle ctd on ct.id_transacciones=ctd.id_transacciones inner join core_tabla_amortizacion_pagos ctap on ctd.id_tabla_amortizacion_pago=ctap.id_tabla_amortizacion_pagos inner join core_tabla_amortizacion_parametrizacion ctapa on ctap.id_tabla_amortizacion_parametrizacion=ctapa.id_tabla_amortizacion_parametrizacion", "ct.id_creditos=" + _id_creditos + " and ct.id_status=1 and ct.id_estado_transacciones=1 and ctapa.tipo_tabla_amortizacion_parametrizacion=0 and date(ct.fecha_contable_core_transacciones) <='" + _ultimo_dia_mes_inicial + "'");
            int reg_pagos = dtPagos.Rows.Count;

            if (reg_pagos > 0)
            {

                foreach (DataRow renglon_pagos in dtPagos.Rows)
                {

                    _mov_ini = Convert.ToDouble(renglon_pagos["total_movimiento"].ToString());

                }
            }




            // BUSCO PAGOS MENSAULES
            int _meses_buscar = 1;
            double _mov_ene = 0;
            double _mov_feb = 0;
            double _mov_mar = 0;
            double _mov_abr = 0;
            double _mov_may = 0;
            double _mov_jun = 0;
            double _mov_jul = 0;
            double _mov_ago = 0;
            double _mov_sep = 0;
            double _mov_oct = 0;
            double _mov_nov = 0;
            double _mov_dic = 0;

            // consigo saldo capital por mes
            double _sal_ini = _monto_otorgado_creditos - _mov_ini;
            double _sal_ene = 0;
            double _sal_feb = 0;
            double _sal_mar = 0;
            double _sal_abr = 0;
            double _sal_may = 0;
            double _sal_jun = 0;
            double _sal_jul = 0;
            double _sal_ago = 0;
            double _sal_sep = 0;
            double _sal_oct = 0;
            double _sal_nov = 0;
            double _sal_dic = 0;



            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("MOV_INI->        " + _mov_ini + "        SAL_INI->       " + _sal_ini);





            for (_meses_buscar = 1; _meses_buscar <= _mes_buscar; _meses_buscar++)
            {

                // consigo movimiento de enero
                if (_meses_buscar == 1)
                {

                    _mov_ene = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_ene = _monto_otorgado_creditos - (_mov_ini + _mov_ene);

                    Console.WriteLine("MOV_ENE->        " + _mov_ene + "     SAL_ENE->       " + _sal_ene);
                }

                // consigo movimiento de febrero
                if (_meses_buscar == 2)
                {

                    _mov_feb = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_feb = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb);

                    Console.WriteLine("MOV_FEB->        " + _mov_feb + "     SAL_FEB->       " + _sal_feb);
                }

                // consigo movimiento de marzo
                if (_meses_buscar == 3)
                {

                    _mov_mar = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_mar = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar);

                    Console.WriteLine("MOV_MAR->        " + _mov_mar + "     SAL_MAR->       " + _sal_mar);
                }

                // consigo movimiento de abril
                if (_meses_buscar == 4)
                {

                    _mov_abr = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_abr = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr);

                    Console.WriteLine("MOV_ABR->        " + _mov_abr + "     SAL_ABR->       " + _sal_abr);
                }

                // consigo movimiento de mayo
                if (_meses_buscar == 5)
                {

                    _mov_may = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_may = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may);

                    Console.WriteLine("MOV_MAY->        " + _mov_may + "     SAL_MAY->       " + _sal_may);
                }


                // consigo movimiento de junio
                if (_meses_buscar == 6)
                {

                    _mov_jun = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_jun = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun);

                    Console.WriteLine("MOV_JUN->        " + _mov_jun + "     SAL_JUN->       " + _sal_jun);
                }

                // consigo movimiento de julio
                if (_meses_buscar == 7)
                {

                    _mov_jul = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_jul = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun + _mov_jul);

                    Console.WriteLine("MOV_JUL->        " + _mov_jul + "        SAL_JUL->       " + _sal_jul);
                }

                // consigo movimiento de agosto
                if (_meses_buscar == 8)
                {

                    _mov_ago = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_ago = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun + _mov_jul + _mov_ago);

                    Console.WriteLine("MOV_AGO->        " + _mov_ago + "        SAL_AGO->       " + _sal_ago);
                }

                // consigo movimiento de septiembre
                if (_meses_buscar == 9)
                {

                    _mov_sep = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_sep = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun + _mov_jul + _mov_ago + _mov_sep);

                    Console.WriteLine("MOV_SEP->       " + _mov_sep + "      SAL_SEP->       " + _sal_sep);
                }

                // consigo movimiento de octubre
                if (_meses_buscar == 10)
                {

                    _mov_oct = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_oct = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun + _mov_jul + _mov_ago + _mov_sep + _mov_oct);

                    Console.WriteLine("MOV_OCT->        " + _mov_oct + "        SAL_OCT->       " + _sal_oct);
                }

                // consigo movimiento de noviembre
                if (_meses_buscar == 11)
                {

                    _mov_nov = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_nov = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun + _mov_jul + _mov_ago + _mov_sep + _mov_oct + _mov_nov);

                    Console.WriteLine("MOV_NOV->        " + _mov_nov + "        SAL_NOV->       " + _sal_nov);
                }

                // consigo movimiento de diciembre
                if (_meses_buscar == 12)
                {

                    _mov_dic = Buscar_Pagos_Mensuales(_id_creditos, _year_buscar, _meses_buscar);
                    _sal_dic = _monto_otorgado_creditos - (_mov_ini + _mov_ene + _mov_feb + _mov_mar + _mov_abr + _mov_may + _mov_jun + _mov_jul + _mov_ago + _mov_sep + _mov_oct + _mov_nov + _mov_dic);

                    Console.WriteLine("MOV_DIC->        " + _mov_dic + "        SAL_DIC->       " + _sal_dic);
                }

            }




            int _dias_reales = 0;
            string _estado_credito_sbs = "";
            DateTime? _fecha_tabla_amortizacion = null;


            // determino si el credito esta vencido o esta por vencer
            // AQUI FINALIZO PROCESOS PARA VER SI ESTA VENCIDO O POR VENCER OMANDO EN CUENTA SI EL EL SALDO ES MAYOR A 0 Y EL CREDITO AUN NO ESTA CANCELADO



            
            if (_mes_buscar == 1)
            {
                if (_sal_ene > 0)
                {

                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;


                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else {

                    _fecha_tabla_amortizacion = null;

                }

            }


            if (_mes_buscar == 2)
            {
                if (_sal_feb > 0)
                {

                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);


                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }

            }


            if (_mes_buscar == 3)
            {
                if (_sal_mar > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }

                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }

            }


            if (_mes_buscar == 4)
            {
                if (_sal_abr > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }


            if (_mes_buscar == 5)
            {

                if (_sal_may > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }



            if (_mes_buscar == 6)
            {
                if (_sal_jun > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;


                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }


            if (_mes_buscar == 7)
            {
                if (_sal_jul > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }


            if (_mes_buscar == 8)
            {
                if (_sal_ago > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;


                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }



                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }

            if (_mes_buscar == 9)
            {
                if (_sal_sep > 0)
                {

                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }

                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }


            if (_mes_buscar == 10)
            {

                if (_sal_oct > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }


            if (_mes_buscar == 11)
            {
                if (_sal_nov > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;


                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }


            if (_mes_buscar == 12)
            {

                if (_sal_dic > 0)
                {
                    // consigo la fecha de ultimo pago de capital
                    _fecha_tabla_amortizacion = Buscar_Fecha_Ultimo_Pago_Capital(_id_creditos, _ultimo_dia_mes);

                    // saco diferencia de dias
                    TimeSpan interval = Convert.ToDateTime(_fecha_tabla_amortizacion) - _ultimo_dia_mes;
                    _dias_reales = 0;
                    _dias_reales = interval.Days;

                    if (_dias_reales >= 90)
                    {

                        _estado_credito_sbs = "VENCIDO";
                    }
                    else
                    {

                        _estado_credito_sbs = "POR VENCER";
                    }


                }
                else
                {

                    _fecha_tabla_amortizacion = null;

                }
            }

            



            Console.WriteLine("ESTADO SBS->       " + _estado_credito_sbs + "      DIAS->      " + _dias_reales);


            double _saldo_personal_participes_cta_individual = 0;
            double _saldo_patronal_participes_cta_individual = 0;
            string _cedula_garante = "";
            string _nombre_garante = "";




            // inserto en la base de datos
            Ins_Cierre_Mes_Creditos(_id_creditos, _id_participes, _mov_ini, _mov_ene, _mov_feb, _mov_mar, _mov_abr, _mov_may, _mov_jun, _mov_jul, _mov_ago, _mov_sep, _mov_oct, _mov_nov, _mov_dic, _sal_ini, _sal_ene, _sal_feb, _sal_mar, _sal_abr, _sal_may, _sal_jun, _sal_jul, _sal_ago, _sal_sep, _sal_oct, _sal_nov, _sal_dic, _id_estado_creditos, _fecha_tabla_amortizacion, _estado_credito_sbs, _dias_reales, _saldo_personal_participes_cta_individual, _saldo_patronal_participes_cta_individual, _year_buscar, _mes_buscar, _cedula_garante, _nombre_garante);







            Console.ForegroundColor = ConsoleColor.Green;


        }




        public static double Buscar_Pagos_Mensuales(int _id_creditos, int _year_buscar, int _mes_buscar)
        {

            double _movimiento = 0.00;


            DataTable dtPagosMensual = AccesoLogica.Select("coalesce(sum(ctd.valor_transaccion_detalle),0) as total_movimiento", "core_transacciones ct inner join core_transacciones_detalle ctd on ct.id_transacciones=ctd.id_transacciones inner join core_tabla_amortizacion_pagos ctap on ctd.id_tabla_amortizacion_pago=ctap.id_tabla_amortizacion_pagos inner join core_tabla_amortizacion_parametrizacion ctapa on ctap.id_tabla_amortizacion_parametrizacion=ctapa.id_tabla_amortizacion_parametrizacion", "ct.id_creditos=" + _id_creditos + " and ct.id_status=1 and ct.id_estado_transacciones=1 and ctapa.tipo_tabla_amortizacion_parametrizacion=0 and to_char(ct.fecha_contable_core_transacciones, 'YYYY') ='" + _year_buscar + "' and to_char(ct.fecha_contable_core_transacciones, 'MM')=LPAD('" + _mes_buscar + "',2,'0')");
            int reg_pagos = dtPagosMensual.Rows.Count;

            if (reg_pagos > 0)
            {

                foreach (DataRow renglon_pagos in dtPagosMensual.Rows)
                {

                    _movimiento = Convert.ToDouble(renglon_pagos["total_movimiento"].ToString());

                }
            }


            return _movimiento;


        }




        public static DateTime Buscar_Fecha_Ultimo_Pago_Capital(int _id_creditos, DateTime _ultimo_dia_mes)
        {

            // CONSIGO FECHA ULTIMO PAGO DE CAPITAL
            DateTime? _fecha_tabla_amortizacion = null;

            int _id_transacciones = 0;
            double _capital_pagado = 0;

            DataTable dtFecha = AccesoLogica.Select("min(t.fecha_tabla_amortizacion) as fecha_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos=" + _id_creditos + " and t.id_estado_tabla_amortizacion<>2 and t.id_estatus=1");
            int reg_fecha = dtFecha.Rows.Count;

            if (reg_fecha > 0)
            {
                foreach (DataRow renglon_fecha in dtFecha.Rows)
                {
                    try
                    {
                        _fecha_tabla_amortizacion = Convert.ToDateTime(renglon_fecha["fecha_tabla_amortizacion"].ToString());
                    }
                    catch (Exception)
                    {

                    }

                }
            }



            // si la fecha es nula busco el ultimo pago de capital en las transacciones
            if (_fecha_tabla_amortizacion == null)
            {



                DataTable dtFechaUltPagCap = AccesoLogica.Select("id_transacciones", "core_transacciones ct", "ct.id_creditos=" + _id_creditos + " and ct.id_status=1 and ct.id_estado_transacciones=1 and date(ct.fecha_contable_core_transacciones) <= '" + _ultimo_dia_mes + "' order by ct.id_transacciones desc");
                int reg_fecha_transacciones = dtFechaUltPagCap.Rows.Count;

                if (reg_fecha_transacciones > 0)
                {
                    foreach (DataRow renglon_fecha_t in dtFechaUltPagCap.Rows)
                    {

                        _id_transacciones = Convert.ToInt32(renglon_fecha_t["id_transacciones"].ToString());



                        // consigo capital pagado 

                        DataTable dtFecha_Ultima = AccesoLogica.Select("coalesce(sum(ctd.valor_transaccion_detalle),0) as total_pagado_capital_credito", "core_transacciones_detalle ctd inner join core_tabla_amortizacion_pagos tap on ctd.id_tabla_amortizacion_pago=tap.id_tabla_amortizacion_pagos and tap.id_tabla_amortizacion in (select t.id_tabla_amortizacion from core_tabla_amortizacion t where t.id_creditos=" + _id_creditos + ") and tap.id_tabla_amortizacion_parametrizacion in (select p.id_tabla_amortizacion_parametrizacion from core_tabla_amortizacion_parametrizacion p where p.descripcion_tabla_amortizacion_parametrizacion ='CAPITAL')", "ctd.id_status=1 and ctd.id_transacciones=" + _id_transacciones + "");
                        int reg_fecha_ultima = dtFecha_Ultima.Rows.Count;

                        if (reg_fecha_ultima > 0)
                        {
                            foreach (DataRow renglon_fecha_u in dtFecha_Ultima.Rows)
                            {

                                _capital_pagado = Convert.ToDouble(renglon_fecha_u["total_pagado_capital_credito"].ToString());



                                // consigo la fecha maxima
                                DataTable dtFecha_max = AccesoLogica.Select("max(t.fecha_tabla_amortizacion) as fecha_tabla_amortizacion", "core_tabla_amortizacion t inner join core_tabla_amortizacion_pagos ta on t.id_tabla_amortizacion=ta.id_tabla_amortizacion and ta.id_tabla_amortizacion_parametrizacion in (select p.id_tabla_amortizacion_parametrizacion from core_tabla_amortizacion_parametrizacion p where p.descripcion_tabla_amortizacion_parametrizacion ='CAPITAL') inner join core_transacciones_detalle td on td.id_transacciones=" + _id_transacciones + "", "t.id_creditos =" + _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion=2");
                                int reg_fecha_max = dtFecha_max.Rows.Count;

                                if (reg_fecha_max > 0)
                                {
                                    foreach (DataRow renglon_fecha_max in dtFecha_max.Rows)
                                    {
                                        try
                                        {
                                            _fecha_tabla_amortizacion = Convert.ToDateTime(renglon_fecha_max["fecha_tabla_amortizacion"].ToString());
                                        }
                                        catch (Exception)
                                        {

                                        }

                                    }
                                }



                                if (_capital_pagado > 0.00)
                                {

                                    break;
                                }


                            }
                        }


                    }
                }



            }




            return Convert.ToDateTime(_fecha_tabla_amortizacion);


        }



        public static void Ins_Cierre_Mes_Creditos(int _id_creditos, int _id_participes, double _movimiento_inicial, double _movimiento_enero, double _movimiento_febrero, double _movimiento_marzo, double _movimiento_abril, double _movimiento_mayo, double _movimiento_junio, double _movimiento_julio, double _movimiento_agosto, double _movimiento_septiembre, double _movimiento_octubre, double _movimiento_noviembre, double _movimiento_diciembre, double _saldo_inicial, double _saldo_enero, double _saldo_febrero, double _saldo_marzo, double _saldo_abril, double _saldo_mayo, double _saldo_junio, double _saldo_julio, double _saldo_agosto, double _saldo_septiembre, double _saldo_octubre, double _saldo_noviembre, double _saldo_diciembre, int _id_estado_creditos, DateTime? _fecha_ultimo_pago_capital, string _estado_credito_sbs, int _dias_vencidos_sbs, double _saldo_personal_participes_cta_individual, double _saldo_patronal_participes_cta_individual, int _anio_cierre_mes, int _mes_cierre_mes, string _cedula_garante, string _nombre_garante)
        {
            string cadena1 = _id_creditos + "?" + _id_participes + "?" + _movimiento_inicial + "?" + _movimiento_enero + "?" + _movimiento_febrero + "?" + _movimiento_marzo + "?" + _movimiento_abril + "?" + _movimiento_mayo + "?" + _movimiento_junio + "?" + _movimiento_julio + "?" + _movimiento_agosto + "?" + _movimiento_septiembre + "?" + _movimiento_octubre + "?" + _movimiento_noviembre + "?" + _movimiento_diciembre + "?" + _saldo_inicial + "?" + _saldo_enero + "?" + _saldo_febrero + "?" + _saldo_marzo + "?" + _saldo_abril + "?" + _saldo_mayo + "?" + _saldo_junio + "?" + _saldo_julio + "?" + _saldo_agosto + "?" + _saldo_septiembre + "?" + _saldo_octubre + "?" + _saldo_noviembre + "?" + _saldo_diciembre + "?" + _id_estado_creditos + "?" + _fecha_ultimo_pago_capital + "?" + _estado_credito_sbs + "?" + _dias_vencidos_sbs + "?" + _saldo_personal_participes_cta_individual + "?" + _saldo_patronal_participes_cta_individual + "?" + _anio_cierre_mes + "?" + _mes_cierre_mes + "?" + _cedula_garante + "?" + _nombre_garante;
            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_creditos?_id_participes?_movimiento_inicial?_movimiento_enero?_movimiento_febrero?_movimiento_marzo?_movimiento_abril?_movimiento_mayo?_movimiento_junio?_movimiento_julio?_movimiento_agosto?_movimiento_septiembre?_movimiento_octubre?_movimiento_noviembre?_movimiento_diciembre?_saldo_inicial?_saldo_enero?_saldo_febrero?_saldo_marzo?_saldo_abril?_saldo_mayo?_saldo_junio?_saldo_julio?_saldo_agosto?_saldo_septiembre?_saldo_octubre?_saldo_noviembre?_saldo_diciembre?_id_estado_creditos?_fecha_ultimo_pago_capital?_estado_credito_sbs?_dias_vencidos_sbs?_saldo_personal_participes_cta_individual?_saldo_patronal_participes_cta_individual?_anio_cierre_mes?_mes_cierre_mes?_cedula_garante?_nombre_garante";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Date?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_cierre_mes_creditos");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Cierre de Mes " + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }

        }






        public static void generar_g41_biess()
        {

            int _leidos = 0;
            int _year_buscar;
            int _mes_buscar;

            if (_mes == 01 || _mes == 1)
            {
                _year_buscar = _year - 1;
                _mes_buscar = 12;

            }
            else
            {
                _year_buscar = _year;
                _mes_buscar = _mes - 1;

            }


            _year_buscar = 2020;
            _mes_buscar = 01;

            DateTime _primer_dia_mes = new DateTime(_year_buscar, _mes_buscar, 1);
            DateTime _ultimo_dia_mes = _primer_dia_mes.AddMonths(1).AddDays(-1);




            // VACIO DATOS DEL MES EXISTENTES
            DataTable dt_cierre_mes = AccesoLogica.Select("id_g41_biess", "core_g41_biess c", "c.mes=" + _mes_buscar + " and c.anio=" + _year_buscar + "");
            int reg_cierre = dt_cierre_mes.Rows.Count;
            int _id_creditos_cierre_mes = 0;


            if (reg_cierre > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------ELIMINANDO G41 BIESS EN EL MES ->      " + _ultimo_dia_mes + "-----------------------------");



                foreach (DataRow renglon2 in dt_cierre_mes.Rows)
                {
                    _id_creditos_cierre_mes = Convert.ToInt32(renglon2["id_g41_biess"].ToString());
                    //eliminando
                    int result2 = AccesoLogica.Delete("id_g41_biess= '" + _id_creditos_cierre_mes + "'", "core_g41_biess");

                    Console.WriteLine("ELIMINANDO ->           " + _id_creditos_cierre_mes);

                }
                Console.WriteLine("");
                Console.WriteLine("TOTAL G41 ->" + reg_cierre);


            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------COMENZAMOS G41 BIESS PERIODO ->    " + _ultimo_dia_mes + "--------------------------------");






            // EMPIEZA CIEERRE DE MES CONSULTANDO LOS CREDITOS


            DataTable dt = new DataTable();
            DataTable tabla = AccesoLogicaSQL.AccesoG41_BIESS(_ultimo_dia_mes);
            dt = tabla;
            int reg_creditos = dt.Rows.Count;

            if (reg_creditos > 0)
            {
                int _numero_registros_g41_biess = 0;
                string _tipo_identificacion_g41_biess = "";
                string _identificacion_participe_g41_biess = "";
                string _correo_participe_g41_biess = "";
                string _nombre_participe_g41_biess = "";
                string _sexo_participe_g41_biess = "";
                string _estado_civil_g41_biess = "";
                DateTime _fecha_ingreso_participe_g41_biess;
                string _tipo_registro_aporte_g41_biess = "";
                string _base_calculo_aportacion_g41_biess = "";
                string _relacion_laboral_g41_biess = "";
                string _estado_registro_g41_biess = "";
                string _tipo_aportacion_g41_biess = "";
                int _anio = _year_buscar;
                int _mes = _mes_buscar;



                foreach (DataRow renglon_creditos in dt.Rows)
                {
                    _leidos++;

                    _numero_registros_g41_biess = Convert.ToInt32(renglon_creditos["NUMERO_REGISTRO"].ToString());
                    _tipo_identificacion_g41_biess = renglon_creditos["TIPO_IDENTIFICACION"].ToString();
                    _identificacion_participe_g41_biess = renglon_creditos["IDENTIFICACION_PARTICIPE"].ToString();
                    _correo_participe_g41_biess = renglon_creditos["CORREO_PARTICIPE"].ToString();


                    _nombre_participe_g41_biess = renglon_creditos["NOMBRE_PARTICIPE"].ToString();
                    _sexo_participe_g41_biess = renglon_creditos["SEXO_PARTICIPE"].ToString();
                    _estado_civil_g41_biess = renglon_creditos["ESTADO_CIVIL_PARTICIPE"].ToString();
                    _fecha_ingreso_participe_g41_biess = Convert.ToDateTime(renglon_creditos["FECHA_INGRESO_PARTICPE"].ToString());
                    _tipo_registro_aporte_g41_biess = renglon_creditos["TIPO_REGISTRO_APORTE"].ToString();
                    _base_calculo_aportacion_g41_biess = renglon_creditos["BASE_CALCULO_APORTACION"].ToString();
                    _relacion_laboral_g41_biess = renglon_creditos["RELACION_LABORAL"].ToString();
                    _estado_registro_g41_biess = renglon_creditos["ESTADO_REGISTRO"].ToString();
                    _tipo_aportacion_g41_biess = renglon_creditos["TIPO_PRESTACION"].ToString();





                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL CREDITOS ->   " + reg_creditos + "    LEIDOS ->  " + _leidos + "      NUMERO CEDULA ->  " + _identificacion_participe_g41_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Insertar_G41_BIESS(_numero_registros_g41_biess, _tipo_identificacion_g41_biess, _identificacion_participe_g41_biess, _correo_participe_g41_biess, _nombre_participe_g41_biess, _sexo_participe_g41_biess, _estado_civil_g41_biess, _fecha_ingreso_participe_g41_biess, _tipo_registro_aporte_g41_biess, _base_calculo_aportacion_g41_biess, _relacion_laboral_g41_biess, _estado_registro_g41_biess, _tipo_aportacion_g41_biess, _anio, _mes);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");


                }
            }


        }



        public static void Insertar_G41_BIESS(int _numero_registros_g41_biess, string _tipo_identificacion_g41_biess, string _identificacion_participe_g41_biess, string _correo_participe_g41_biess, string _nombre_participe_g41_biess, string _sexo_participe_g41_biess, string _estado_civil_g41_biess, DateTime _fecha_ingreso_participe_g41_biess, string _tipo_registro_aporte_g41_biess, string _base_calculo_aportacion_g41_biess, string _relacion_laboral_g41_biess, string _estado_registro_g41_biess, string _tipo_aportacion_g41_biess, int _anio, int _mes)

        {

            string cadena1 = _numero_registros_g41_biess + "?" + _tipo_identificacion_g41_biess + "?" + _identificacion_participe_g41_biess + "?" + _correo_participe_g41_biess + "?" + _nombre_participe_g41_biess + "?" + _sexo_participe_g41_biess + "?" + _estado_civil_g41_biess + "?" + _fecha_ingreso_participe_g41_biess + "?" + _tipo_registro_aporte_g41_biess + "?" + _base_calculo_aportacion_g41_biess + "?" + _relacion_laboral_g41_biess + "?" + _estado_registro_g41_biess + "?" + _tipo_aportacion_g41_biess + "?" + _anio + "?" + _mes;




            string cadena2 = "_numero_registros_g41_biess?_tipo_identificacion_g41_biess?_identificacion_participe_g41_biess?_correo_participe_g41_biess?_nombre_participe_g41_biess?_sexo_participe_g41_biess?_estado_civil_g41_biess?_fecha_ingreso_participe_g41_biess?_tipo_registro_aporte_g41_biess?_base_calculo_aportacion_g41_biess?_relacion_laboral_g41_biess?_estado_registro_g41_biess?_tipo_aportacion_g41_biess?_anio?_mes";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.DateTime?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_g41_biess");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Modo de pagos" + Ex.Message);

                //string cadena5 = "_error_errores_importacion";
                //string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }




        public static void generar_g42_biess()
        {

            int _leidos = 0;
            int _year_buscar;
            int _mes_buscar;

            if (_mes == 01 || _mes == 1)
            {
                _year_buscar = _year - 1;
                _mes_buscar = 12;

            }
            else
            {
                _year_buscar = _year;
                _mes_buscar = _mes - 1;

            }



            _year_buscar = 2019;
            _mes_buscar = 10;



            DateTime _primer_dia_mes = new DateTime(_year_buscar, _mes_buscar, 1);
            DateTime _ultimo_dia_mes = _primer_dia_mes.AddMonths(1).AddDays(-1);





            // VACIO DATOS DEL MES EXISTENTES
            DataTable dt_cierre_mes = AccesoLogica.Select("id_g42_biess", "core_g42_biess c", "c.mes_g42_biess=" + _mes_buscar + " and c.anio_g42_biess=" + _year_buscar + "");
            int reg_cierre = dt_cierre_mes.Rows.Count;
            int _id_creditos_cierre_mes = 0;


            if (reg_cierre > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------ELIMINANDO G42 BIESS EN EL MES ->      " + _ultimo_dia_mes + "-----------------------------");



                foreach (DataRow renglon2 in dt_cierre_mes.Rows)
                {
                    _id_creditos_cierre_mes = Convert.ToInt32(renglon2["id_g42_biess"].ToString());
                    //eliminando
                    int result2 = AccesoLogica.Delete("id_g42_biess= '" + _id_creditos_cierre_mes + "'", "core_g42_biess");

                    Console.WriteLine("ELIMINANDO ->           " + _id_creditos_cierre_mes);

                }
                Console.WriteLine("");
                Console.WriteLine("TOTAL G42 ->" + reg_cierre);


            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------COMENZAMOS G42 BIESS PERIODO ->    " + _ultimo_dia_mes + "--------------------------------");











            // EMPIEZA CIEERRE DE MES CONSULTANDO LOS CREDITOS


            DataTable dt = new DataTable();
            DataTable tabla = AccesoLogicaSQL.AccesoG42_BIESS(_ultimo_dia_mes);
            dt = tabla;
            int reg_creditos = dt.Rows.Count;

            if (reg_creditos > 0)
            {

                string _tipo_identificacion_g42_biess = "";
                string _identificacion_g42_biess = "";
                string _tipo_prestacion_g42_biess = "";
                string _estado_participe_cesante_g42_biess = "";
                string _estado_participe_jubilado_g42_biess = "";
                double _aporte_personal_cesantia_g42_biess = 0;
                double _aporte_personal_jubilado_g42_biess = 0;
                double _aporte_adicional_jubilacion_g42_biess = 0;
                double _aporte_adicional_cesantia_g42_biess = 0;
                double _saldo_cuenta_individual_patronal_g42_biess = 0;
                double _saldo_cuenta_individual_cesantia_g42_biess = 0;
                double _saldo_cuenta_individual_jubilacion_g42_biess = 0;
                double _saldo_aporte_personal_jubilacion_g42_biess = 0;
                double _saldo_aporte_personal_cesantia_g42_biess = 0;
                double _saldo_aporte_adicional_jubilacion_g42_biess = 0;
                double _saldo_aporte_adicional_cesantia_g42_biess = 0;
                double _saldo_rendimiento_patronal_otros_g42_biess = 0;
                double _saldo_rendimiento_aporte_personal_jubilacion_g42_biess = 0;
                double _saldo_rendimiento_aporte_personal_cesantia_g42_biess = 0;
                double _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess = 0;
                double _retencion_fiscal_g42_biess = 0;
                DateTime? _fecha_desafiliacion_voluntaria_g42_biess = null;
                double _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42 = 0;
                double _valor_pendiente_pago_desafiliacion_g42_biess = 0;
                double _valor_pagado_participe_desafiliado_g42_biess = 0;
                string _motivo_liquidacion_g42_biess = "";
                DateTime? _fecha_termino_relacion_laboral_g42_biess = null;
                double _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42_bie = 0;
                double _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42_bie = 0;
                double _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess = 0;
                double _valores_pagados_fondo_g42_biess = 0;
                double _valores_pendientes_pago_cuentas_por_pagar_particpe_g42_biess = 0;
                double _valor_pagado_participe_por_cesantia_g42_biess = 0;
                double _valor_pagado_participe_por_jubiliacion_g42_biess = 0;
                string _descripcion_otros_conceptos_g42_biess = "";
                double _valores_pagados_al_participe_otros_conceptos_g42_biess = 0;
                int _anio_g42_biess = _year_buscar;
                int _mes_g42_biess = _mes_buscar;
                double _saldo_rendimiento_aporte_adicional_cesantia_g42_biess = 0;



                foreach (DataRow renglon_creditos in dt.Rows)
                {
                    _leidos++;


                    _tipo_identificacion_g42_biess = renglon_creditos["TIPO_IDENTIFICACION"].ToString();
                    _identificacion_g42_biess = renglon_creditos["IDENTIFICACION"].ToString();
                    _tipo_prestacion_g42_biess = renglon_creditos["TIPO_PRESTACION"].ToString();
                    _estado_participe_cesante_g42_biess = renglon_creditos["ESTADO_PARTICPE_CESANTE"].ToString();
                    _estado_participe_jubilado_g42_biess = renglon_creditos["ESTADO_PARTICIPE_JUBILADO"].ToString();
                    _aporte_personal_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["APORTE_PERSONAL_CESANTIA"].ToString());
                    _aporte_personal_jubilado_g42_biess = Convert.ToDouble(renglon_creditos["APORTE_PERSONAL_JUBILADO"].ToString());
                    _aporte_adicional_jubilacion_g42_biess = Convert.ToDouble(renglon_creditos["APORTE_ADICIONAL_JUBILACION"].ToString());
                    _aporte_adicional_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["APORTE_ADICIONAL_CESANTIA"].ToString());
                    _saldo_cuenta_individual_patronal_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_CUENTA_INDIVIDUAL_PATRONAL"].ToString());
                    _saldo_cuenta_individual_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_CUENTA_INDIVIDUAL_CESANTIA"].ToString());
                    _saldo_cuenta_individual_jubilacion_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_CUENTA_INDIVIDUAL_JUBILACION"].ToString());
                    _saldo_aporte_personal_jubilacion_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_APORTE_PERSONAL_JUBILACION"].ToString());
                    _saldo_aporte_personal_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_APORTE_PERSONAL_CESANTIA"].ToString());
                    _saldo_aporte_adicional_jubilacion_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_APORTE_ADICIONAL_JUBILACION"].ToString());
                    _saldo_aporte_adicional_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_APORTE_ADICIONAL_CESANTIA"].ToString());
                    _saldo_rendimiento_patronal_otros_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_RENDIMIENTO_PATRONAL_OTROS"].ToString());
                    _saldo_rendimiento_aporte_personal_jubilacion_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_RENDIMIENTO_APORTE_PERSONAL_JUBILACION"].ToString());
                    _saldo_rendimiento_aporte_personal_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_RENDIMIENTO_APORTE_PERSONAL_CESANTIA"].ToString());

                    _saldo_rendimiento_aporte_adicional_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_RENDIMIENTO_APORTE_ADICIONAL_CESANTIA"].ToString());

                    _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess = Convert.ToDouble(renglon_creditos["SALDO_RENDIMIENTO_APORTE_ADICIONAL_JUBILACION"].ToString());










                    _retencion_fiscal_g42_biess = Convert.ToDouble(renglon_creditos["RETENCION_FISCAL"].ToString());


                    try
                    {
                        _fecha_desafiliacion_voluntaria_g42_biess = Convert.ToDateTime(renglon_creditos["FECHA_DESAFILIACION_VOLUNTARIA"].ToString());

                    }
                    catch (Exception)
                    {
                        _fecha_desafiliacion_voluntaria_g42_biess = null;
                    }
                    _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42 = Convert.ToDouble(renglon_creditos["MONTO_DESAFILIACION_VOLUNTARIA_LIQUIDACION_POR_DESAFILIACION"].ToString());
                    _valor_pendiente_pago_desafiliacion_g42_biess = Convert.ToDouble(renglon_creditos["VALOR_PENDIENTE_PAGO_DESAFILIACION"].ToString());
                    _valor_pagado_participe_desafiliado_g42_biess = Convert.ToDouble(renglon_creditos["VALOR_PAGADO_PARTICIPE_DESAFILIADO"].ToString());
                    _motivo_liquidacion_g42_biess = renglon_creditos["MOTIVO_LIQUIDACION"].ToString();

                    try
                    {
                        _fecha_termino_relacion_laboral_g42_biess = Convert.ToDateTime(renglon_creditos["FECHA_TERMINO_RELACION_LABORAL"].ToString());


                    }
                    catch (Exception)
                    {

                        _fecha_termino_relacion_laboral_g42_biess = null;


                    }

                    _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42_bie = Convert.ToDouble(renglon_creditos["SALDO_CUENTA_INDIVIDUAL_LIQUIDACION_PRESTACION_CESANTIA"].ToString());

                    _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42_bie = Convert.ToDouble(renglon_creditos["SALDO_CUENTA_INDIVIDUAL_LIQUIDACION_PRESTACION_JUBILADO"].ToString());


                    try
                    {
                        _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess = Convert.ToDouble(renglon_creditos["DETALLE_OTROS_VALORES_PAGADOS_Y_PENDIENTES_PAGO"].ToString());


                    }
                    catch (Exception)
                    {

                        _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess = 0;


                    }
                    _valores_pagados_fondo_g42_biess = Convert.ToDouble(renglon_creditos["VALORES_PAGADOS_FONDO"].ToString());
                    _valores_pendientes_pago_cuentas_por_pagar_particpe_g42_biess = Convert.ToDouble(renglon_creditos["VALORES_PENDIENTES_PAGO_CUENTAS_POR_PAGAR_PARTICPE"].ToString());
                    _valor_pagado_participe_por_cesantia_g42_biess = Convert.ToDouble(renglon_creditos["VALOR_PAGADO_PARTICIPE_POR_CESANTIA"].ToString());
                    _valor_pagado_participe_por_jubiliacion_g42_biess = Convert.ToDouble(renglon_creditos["VALOR_PAGADO_PARTICIPE_POR_JUBILIACION"].ToString());
                    _descripcion_otros_conceptos_g42_biess = renglon_creditos["DESCRIPCION_OTROS_CONCEPTOS"].ToString();
                    _valores_pagados_al_participe_otros_conceptos_g42_biess = Convert.ToDouble(renglon_creditos["VALORES_PAGADOS_AL_PARTICIPE_OTROS_CONCEPTOS"].ToString());







                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL CREDITOS ->   " + reg_creditos + "    LEIDOS ->  " + _leidos + "      NUMERO CEDULA ->  " + _identificacion_g42_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    //  Insertar_G42_BIESS(_tipo_identificacion_g42_biess, _identificacion_g42_biess, _tipo_prestacion_g42_biess, _estado_participe_cesante_g42_biess, _estado_participe_jubilado_g42_biess, _aporte_personal_cesantia_g42_biess, _aporte_personal_jubilado_g42_biess, _aporte_adicional_jubilacion_g42_biess, _aporte_adicional_cesantia_g42_biess, _saldo_cuenta_individual_patronal_g42_biess, _saldo_cuenta_individual_cesantia_g42_biess, _saldo_cuenta_individual_jubilacion_g42_biess, _saldo_aporte_personal_jubilacion_g42_biess, _saldo_aporte_personal_cesantia_g42_biess, _saldo_aporte_adicional_jubilacion_g42_biess, _saldo_aporte_adicional_cesantia_g42_biess, _saldo_rendimiento_patronal_otros_g42_biess, _saldo_rendimiento_aporte_personal_jubilacion_g42_biess, _saldo_rendimiento_aporte_personal_cesantia_g42_biess, _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess, _retencion_fiscal_g42_biess, _fecha_desafiliacion_voluntaria_g42_biess, _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42, _valor_pendiente_pago_desafiliacion_g42_biess, _valor_pagado_participe_desafiliado_g42_biess, _motivo_liquidacion_g42_biess, _fecha_termino_relacion_laboral_g42_biess, _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42_bie, _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42_bie, _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess, _valores_pagados_fondo_g42_biess, _valores_pendientes_pago_cuentas_por_pagar_particpe_g42_biess, _valor_pagado_participe_por_cesantia_g42_biess, _valor_pagado_participe_por_jubiliacion_g42_biess, _descripcion_otros_conceptos_g42_biess, _valores_pagados_al_participe_otros_conceptos_g42_biess, _anio_g42_biess, _mes_g42_biess, _saldo_rendimiento_aporte_adicional_cesantia_g42_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");


                }
            }


        }








        // DESDE AQUI G42 MAYCOL


        public static void generar_g42_biess_nueva()
        {

            int _leidos = 0;
            int _year_buscar;
            int _mes_buscar;

            if (_mes == 01 || _mes == 1)
            {
                _year_buscar = _year - 1;
                _mes_buscar = 12;

            }
            else
            {
                _year_buscar = _year;
                _mes_buscar = _mes - 1;

            }



            _year_buscar = 2020;
            _mes_buscar = 02;



            DateTime _primer_dia_mes = new DateTime(_year_buscar, _mes_buscar, 1);
            DateTime _ultimo_dia_mes = _primer_dia_mes.AddMonths(1).AddDays(-1);





            // VACIO DATOS DEL MES EXISTENTES
            DataTable dt_cierre_mes = AccesoLogica.Select("id_g42_biess", "core_g42_biess c", "c.mes_g42_biess=" + _mes_buscar + " and c.anio_g42_biess=" + _year_buscar + "");
            int reg_cierre = dt_cierre_mes.Rows.Count;
            int _id_creditos_cierre_mes = 0;


            if (reg_cierre > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------ELIMINANDO G42 BIESS EN EL MES ->      " + _ultimo_dia_mes + "-----------------------------");



                foreach (DataRow renglon2 in dt_cierre_mes.Rows)
                {
                    _id_creditos_cierre_mes = Convert.ToInt32(renglon2["id_g42_biess"].ToString());
                    //eliminando
                    int result2 = AccesoLogica.Delete("id_g42_biess= '" + _id_creditos_cierre_mes + "'", "core_g42_biess");

                    Console.WriteLine("ELIMINANDO ->           " + _id_creditos_cierre_mes);

                }
                Console.WriteLine("");
                Console.WriteLine("TOTAL G42 ->" + reg_cierre);


            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------COMENZAMOS G42 BIESS PERIODO ->    " + _ultimo_dia_mes + "--------------------------------");











            // EMPIEZA GENERACION DE G42
            int _id_participes;




            // esto es para cuenta individual
            int _numero_registros_g42_biess = 0;
            string _tipo_identificacion_g42_biess = "";
            string _identificacion_g42_biess = "";
            string _tipo_prestacion_g42_biess = "";
            string _estado_participe_cesante_g42_biess = "";
            string _estado_participe_jubilado_g42_biess = "";
            double _aporte_personal_cesantia_g42_biess = 0;
            double _aporte_personal_jubilado_g42_biess = 0;
            double _aporte_adicional_jubilacion_g42_biess = 0;
            double _aporte_adicional_cesantia_g42_biess = 0;
            double _rendimiento_anual_g42_biess = 0;


            double _saldo_cuenta_individual_patronal_g42_biess = 0;
            double _saldo_cuenta_individual_cesantia_g42_biess = 0;
            double _saldo_cuenta_individual_jubilacion_g42_biess = 0;
            double _saldo_aporte_personal_jubilacion_g42_biess = 0;
            double _saldo_aporte_personal_cesantia_g42_biess = 0;
            double _saldo_aporte_adicional_jubilacion_g42_biess = 0;
            double _saldo_aporte_adicional_cesantia_g42_biess = 0;
            double _saldo_rendimiento_patronal_otros_g42_biess = 0;
            double _saldo_rendimiento_aporte_personal_jubilacion_g42_biess = 0;
            double _saldo_rendimiento_aporte_personal_cesantia_g42_biess = 0;
            double _saldo_rendimiento_aporte_adicional_cesantia_g42_biess = 0;
            double _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess = 0;
            double _retencion_fiscal_g42_biess = 0;



            DateTime? _fecha_desafiliacion_voluntaria_g42_biess = null;
            double _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42 = 0;
            double _valor_pendiente_pago_desafiliacion_g42_biess = 0;
            double _valor_pagado_participe_desafiliado_g42_biess = 0;




            string _motivo_liquidacion_g42_biess = "PORCESANTIA";
            DateTime? _fecha_termino_relacion_laboral_g42_biess = null;
            double _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42 = 0;
            double _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42 = 0;
            string _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess = "";

            double _valores_pagados_al_fondo_g42_biess = 0;

            double _valores_pendientes_pago_al_fondo_g42_biess = 0;
            double _valor_pagado_participe_por_cesantia_g42_biess = 0;

            double _valor_pagado_participe_por_jubiliacion_g42_biess = 0;
            string _descripcion_otros_conceptos_g42_biess = "";
            double _valores_pagados_al_participe_otros_conceptos_g42_biess = 0;

            int _anio_g42_biess = _year_buscar;
            int _mes_g42_biess = _mes_buscar;










            // consulto a base de datos SQL
            DataTable dtParticipes_Activos = AccesoLogicaSQL.Select("RPT.PARTNER_ID, CASE WHEN LEN(RPT.cedu)=10 THEN 'CED' WHEN LEN(RPT.cedu)=13 THEN 'RUC' WHEN LEN(RPT.cedu)>13 THEN 'PAS' END TIPO_IDENTIFICACION," +
             " RPT.cedu IDENTIFICACION, 'CESANTIA' AS TIPO_PRESTACION, CASE WHEN RPT.Estado = 'Activo' THEN 'PARTICIPEACTIVO' WHEN RPT.Estado = 'Desafiliado' THEN 'PASIVODESAF' WHEN RPT.Estado = 'Liquidado Cesante' THEN 'LIQUIDADO' END ESTADO_PARTICPE_CESANTE," +
             " RPT.SAL_PAT_FINAL SALDO_PATRONAL_FINAL, RPT.SAL_PER_FINAL SALDO_PERSONAL_FINAL, RPT.SAL_PAT_FINAL + RPT.SAL_PER_FINAL as CUENTA_INDIVIDUAL," +
             " (select ISNULL(SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY), 0)" +
             " from one.CONTRIBUTION c" +
             " where c.TYPE = 1 and c.STATUS <> 0" +
             " AND c.PARTNER_ID = RPT.PARTNER_ID and year(c.DATE) = " + _year_buscar + " and MONTH(c.DATE) = " + _mes_buscar + "" +
             " AND(c.DESCRIPTION LIKE '%Descuento mensual%'" +
             " OR c.DESCRIPTION LIKE '%APOR%'" +
             " OR c.DESCRIPTION LIKE ''" +
             " OR c.DESCRIPTION LIKE '%TRANSACCTAINDIVIDUAL%')" +
             " AND(c.DESCRIPTION <> 'Liquidacion' and c.DESCRIPTION not like 'Pago del crédito:%'" +
            " AND c.DESCRIPTION <> 'Reingreso(Aporte Patronal)'" +
            " and c.DESCRIPTION <> 'Envio Superavit REINCORPORADO'" +
            " AND c.DESCRIPTION not like 'Paso Reg Superavit(%'" +
            " and c.DESCRIPTION not like '%ENVIO A CXPDF%'" +
            " AND c.DESCRIPTION <> 'Reingreso(Aporte Personal)'" +
            " and c.DESCRIPTION not like 'Pago Superávit%'" +
            " AND c.DESCRIPTION not like 'Pago por cobro Garantía%'" +
            " AND c.DESCRIPTION is not null)" +
            " ) as APORTE_PERSONAL_MENSUAL," +
            " (select ISNULL(SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY), 0)" +
            " from one.CONTRIBUTION c" +
            " where c.TYPE in (49) and c.STATUS <> 0" +
            " AND c.PARTNER_ID = RPT.PARTNER_ID" +
            " AND(c.DESCRIPTION <> 'Liquidacion' and c.DESCRIPTION not like 'Pago del crédito:%'" +
            " AND c.DESCRIPTION <> 'Reingreso(Aporte Patronal)'" +
            " and c.DESCRIPTION <> 'Envio Superavit REINCORPORADO'" +
            " AND c.DESCRIPTION not like 'Paso Reg Superavit(%'" +
            " and c.DESCRIPTION not like '%ENVIO A CXPDF%'" +
            " AND c.DESCRIPTION <> 'Reingreso(Aporte Personal)'" +
            " and c.DESCRIPTION not like 'Pago Superávit%'" +
            " AND c.DESCRIPTION not like 'Pago por cobro Garantía%'" +
            " AND c.DESCRIPTION is not null)" +
            " ) as RENDIMIENTO_PATRONAL," +
            " (select ISNULL(SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY), 0)" +
            " from one.CONTRIBUTION c" +
             " where c.TYPE in (50) and c.STATUS <> 0" +
             " AND c.PARTNER_ID = RPT.PARTNER_ID" +
             " AND(c.DESCRIPTION <> 'Liquidacion' and c.DESCRIPTION not like 'Pago del crédito:%'" +
               " AND c.DESCRIPTION <> 'Reingreso(Aporte Patronal)'" +
                " and c.DESCRIPTION <> 'Envio Superavit REINCORPORADO'" +
                " AND c.DESCRIPTION not like 'Paso Reg Superavit(%'" +
                " and c.DESCRIPTION not like '%ENVIO A CXPDF%'" +
                " AND c.DESCRIPTION <> 'Reingreso(Aporte Personal)'" +
                " and c.DESCRIPTION not like 'Pago Superávit%'" +
                " AND c.DESCRIPTION not like 'Pago por cobro Garantía%'" +
                " AND c.DESCRIPTION is not null)" +
             "  )as RENDIMIENTO_PERSONAL," +
             "  (select ISNULL(SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY), 0)" +
             "  from one.CONTRIBUTION c" +
             "  where c.TYPE in (49, 50) and c.STATUS <> 0" +
             "  AND c.PARTNER_ID = RPT.PARTNER_ID and year(c.DATE) = " + _year_buscar + "" +
             "  AND(c.DESCRIPTION <> 'Liquidacion' and c.DESCRIPTION not like 'Pago del crédito:%'" +
             "  AND c.DESCRIPTION <> 'Reingreso(Aporte Patronal)'" +
             "  and c.DESCRIPTION <> 'Envio Superavit REINCORPORADO'" +
             "  AND c.DESCRIPTION not like 'Paso Reg Superavit(%'" +
             "  and c.DESCRIPTION not like '%ENVIO A CXPDF%'" +
             "  AND c.DESCRIPTION <> 'Reingreso(Aporte Personal)'" +
             "  and c.DESCRIPTION not like 'Pago Superávit%'" +
             "  AND c.DESCRIPTION not like 'Pago por cobro Garantía%'" +
             "  AND c.DESCRIPTION is not null)" +
            "  ) as RENDIMIENTO_ANUAL," +
            "  (select ISNULL(SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY), 0) * (-1)" +
            "   from one.CONTRIBUTION c" +
            "  where c.TYPE in (10) and c.STATUS <> 0" +
            "  AND c.PARTNER_ID = RPT.PARTNER_ID" +
            " ) as RETENCION_FISCAL", " ONE.RPT_CTAIND RPT (NOLOCK)", " RPT.SAL_PER_FINAL+RPT.SAL_PAT_FINAL>0 and RPT.anio = " + _year_buscar + " and RPT.mes = " + _mes_buscar + " ORDER BY RPT.EMPLOYER_ENTITY_ID, RPT.NOMB");




            int reg_participes_activos = dtParticipes_Activos.Rows.Count;



            if (reg_participes_activos > 0)
            {

                foreach (DataRow renglon_ac in dtParticipes_Activos.Rows)
                {
                    _leidos++;

                    _numero_registros_g42_biess = _leidos;
                    _id_participes = Convert.ToInt32(renglon_ac["PARTNER_ID"].ToString());
                    _tipo_identificacion_g42_biess = renglon_ac["TIPO_IDENTIFICACION"].ToString();
                    _identificacion_g42_biess = renglon_ac["IDENTIFICACION"].ToString();
                    _tipo_prestacion_g42_biess = renglon_ac["TIPO_PRESTACION"].ToString();
                    _estado_participe_cesante_g42_biess = renglon_ac["ESTADO_PARTICPE_CESANTE"].ToString();

                    _saldo_cuenta_individual_patronal_g42_biess = Convert.ToDouble(renglon_ac["SALDO_PATRONAL_FINAL"].ToString());
                    _saldo_aporte_personal_cesantia_g42_biess = Convert.ToDouble(renglon_ac["SALDO_PERSONAL_FINAL"].ToString());
                    _saldo_cuenta_individual_cesantia_g42_biess = Convert.ToDouble(renglon_ac["CUENTA_INDIVIDUAL"].ToString());
                    _aporte_personal_cesantia_g42_biess = Convert.ToDouble(renglon_ac["APORTE_PERSONAL_MENSUAL"].ToString());
                    _saldo_rendimiento_patronal_otros_g42_biess = Convert.ToDouble(renglon_ac["RENDIMIENTO_PATRONAL"].ToString());
                    _saldo_rendimiento_aporte_personal_cesantia_g42_biess = Convert.ToDouble(renglon_ac["RENDIMIENTO_PERSONAL"].ToString());
                    _rendimiento_anual_g42_biess = Convert.ToDouble(renglon_ac["RENDIMIENTO_ANUAL"].ToString());
                    _retencion_fiscal_g42_biess = Convert.ToDouble(renglon_ac["RETENCION_FISCAL"].ToString());






                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PARTICIPES ACTIVOS ->   " + reg_participes_activos + "    LEIDOS ->  " + _leidos + "      NUMERO CEDULA ->  " + _identificacion_g42_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Insertar_G42_BIESS_ACTIVOS(_numero_registros_g42_biess,
                     _tipo_identificacion_g42_biess,
                     _identificacion_g42_biess,
                     _tipo_prestacion_g42_biess,
                     _estado_participe_cesante_g42_biess,
                     _estado_participe_jubilado_g42_biess,
                     _aporte_personal_cesantia_g42_biess,
                     _aporte_personal_jubilado_g42_biess,
                     _aporte_adicional_jubilacion_g42_biess,
                     _aporte_adicional_cesantia_g42_biess,
                     _rendimiento_anual_g42_biess,
                     _saldo_cuenta_individual_patronal_g42_biess,
                     _saldo_cuenta_individual_cesantia_g42_biess,
                     _saldo_cuenta_individual_jubilacion_g42_biess,
                     _saldo_aporte_personal_jubilacion_g42_biess,
                     _saldo_aporte_personal_cesantia_g42_biess,
                     _saldo_aporte_adicional_jubilacion_g42_biess,
                     _saldo_aporte_adicional_cesantia_g42_biess,
                     _saldo_rendimiento_patronal_otros_g42_biess,
                     _saldo_rendimiento_aporte_personal_jubilacion_g42_biess,
                     _saldo_rendimiento_aporte_personal_cesantia_g42_biess,
                     _saldo_rendimiento_aporte_adicional_cesantia_g42_biess,
                     _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess,
                     _retencion_fiscal_g42_biess,
                     _anio_g42_biess,
                     _mes_g42_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");



                }
            }















            // para participes pasivos en el mes

            // consulto a base de datos SQL
            DataTable dtParticipes_Pasivos = AccesoLogicaSQL.Select("IDENTITY_CARD, ctaind+cXPDF cuenta_individual, pago PAGO, DATE_FOLDER_PAY, patronal_restante+personal_restante restante",

                   " (" +
                   "  select p.PARTNER_ID, l.LIQUIDATION_ID, l.TYPE, p.IDENTITY_CARD, p.LAST_NAME + ' ' + p.FIRST_NAME nomb" +
                   "  , tipo =case when l.TYPE = 3 then 'Desafiliado' when l.TYPE IN(1) then 'Cesante' when l.TYPE = 2 then 'Fallecido' when l.TYPE = 4 then 'CXPDF' when l.TYPE = 5 then 'Expulsión' end" +
                   "  , l.DOCUMENT_NUMBER, l.DATE_FOLDER_PAY, MONTH(l.DATE_FOLDER_PAY)MES, YEAR(l.DATE_FOLDER_PAY) ANIO" +
                   "  ," +
                    "   isnull(" +
                    "  (" +
                    "     select SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY)" +

                     "    from one.CONTRIBUTION c" +

                      "   where c.PARTNER_ID = l.PARTNER_ID" +

                      "   and c.STATUS <> 0" +

                     "    and STATE <> 0" +

                      "   and c.LIQUIDATION_ID = l.LIQUIDATION_ID" +

                     "    and c.DESCRIPTION not like '%Pago del crédito:%'" +

                      "   and c.OBSERVATION not like '%Liquidacion%'" +

                  "   ), 0) ctaind" +
                 "    ," +
                  "   isnull(" +
                 "    (" +
                   "      select SUM(c.PERSONNEL_PAY + c.EMPLOYER_PAY)" +

                   "      from one.CONTRIBUTION_EMPLOYER_PAY_OUT c" +

                   "      where c.PARTNER_ID = l.PARTNER_ID" +

                   "      and c.STATUS <> 0" +

                   "      and STATE <> 0" +

                    "     and c.LIQUIDATION_ID = l.LIQUIDATION_ID" +

                   "  ), 0) cXPDF" +
                  "  ," +

                  "   isnull(" +
                  "   (" +
                   "      select ls.VALUE * (-1)" +

                    "     from one.LIQUIDATION_SUMMARY ls" +

                    "     where ls.LIQUIDATION_ID = l.LIQUIDATION_ID" +

                   "      and ls.code = 9" +

                    "     and ls.VALUE <> 0" +
                    " ),0) pago," +

                   "  (" +
                   "       select isnull(sum(VALUE), 0)" +

                    "      from one.LIQUIDATION_SUMMARY (nolock)" +
                   "       where LIQUIDATION_ID = l.LIQUIDATION_ID and VALUE > 0 and CODE = 2" +
                  "   ) as patronal_restante," +

                   "  (" +
                     "     select isnull(sum(VALUE), 0)" +

                    "      from one.LIQUIDATION_SUMMARY (nolock)" +
                    "      where LIQUIDATION_ID = l.LIQUIDATION_ID and VALUE > 0 and CODE = 1" +

                    "      AND MOTIVE LIKE '%Total aportes personales 2 50%'" +
                   "  ) as personal_restante FROM one.LIQUIDATION l inner join one.PARTNER p on p.PARTNER_ID=l.PARTNER_ID where l.STATUS<>0 and l.STATE in (4) )T", " YEAR(T.DATE_FOLDER_PAY)=" + _year_buscar + " and MONTH(T.DATE_FOLDER_PAY)=" + _mes_buscar + " and t.TYPE=3");




            int reg_participes_pasivos = dtParticipes_Pasivos.Rows.Count;



            if (reg_participes_pasivos > 0)
            {

                foreach (DataRow renglon_pa in dtParticipes_Pasivos.Rows)
                {

                    _identificacion_g42_biess = renglon_pa["IDENTITY_CARD"].ToString();
                    _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42 = Convert.ToDouble(renglon_pa["cuenta_individual"].ToString());
                    _valor_pagado_participe_desafiliado_g42_biess = Convert.ToDouble(renglon_pa["PAGO"].ToString());
                    _fecha_desafiliacion_voluntaria_g42_biess = Convert.ToDateTime(renglon_pa["DATE_FOLDER_PAY"].ToString());
                    _valor_pendiente_pago_desafiliacion_g42_biess = Convert.ToDouble(renglon_pa["restante"].ToString());




                    DataTable dtParticipes = AccesoLogica.Select("identificacion_g42_biess", "core_g42_biess", "identificacion_g42_biess='" + _tipo_identificacion_g42_biess + "' AND anio_g42_biess=" + _year_buscar + " and mes_g42_biess=" + _mes_buscar + "");
                    int reg_calcular = dtParticipes.Rows.Count;

                    if (reg_calcular > 0)
                    {

                    }
                    else
                    {
                        _leidos++;
                    }

                    _numero_registros_g42_biess = _leidos;


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PARTICIPES PASIVOS ->   " + reg_participes_pasivos + "    LEIDOS ->  " + _leidos + "      NUMERO CEDULA ->  " + _identificacion_g42_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Insertar_G42_BIESS_PASIVOS(_numero_registros_g42_biess, _identificacion_g42_biess, _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42, _valor_pagado_participe_desafiliado_g42_biess, _fecha_desafiliacion_voluntaria_g42_biess, _valor_pendiente_pago_desafiliacion_g42_biess,
                   _anio_g42_biess,
                   _mes_g42_biess);

                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");



                }
            }




















            // para participes cesantes en el mes

            // consulto a base de datos SQL
            DataTable dtParticipes_Cesantes = AccesoLogicaSQL.Select("LIQUIDATION_ID, tipo, IDENTITY_CARD, ctaind+cXPDF cuenta_individual, pago PAGO, DATE_FOLDER_PAY, restante, credito_valor_pagado+impuesto_patronal valor_pagado_al_fondo, credito_valor_pagado, impuesto_patronal,  saldo_adeuda_fondo",
    " ( " +
    " select p.PARTNER_ID, l.LIQUIDATION_ID, l.TYPE, p.IDENTITY_CARD, p.LAST_NAME + ' '+p.FIRST_NAME nomb" +
    " ,tipo=case when l.TYPE=3 then 'Desafiliado' when l.TYPE IN (1) then 'Cesante' when l.TYPE =2 then 'Fallecido' when l.TYPE=4 then 'CXPDF' when l.TYPE=5 then 'Expulsión' end " +
    " , l.DOCUMENT_NUMBER, l.DATE_FOLDER_PAY, MONTH(l.DATE_FOLDER_PAY)MES,YEAR(l.DATE_FOLDER_PAY) ANIO" +
    " , " +
    " isnull(" +
    " (" +
    "	select SUM(c.PERSONNEL_PAY+c.EMPLOYER_PAY)" +
    "	from one.CONTRIBUTION c" +
    " 	where c.PARTNER_ID=l.PARTNER_ID" +
    "	and c.STATUS<>0" +
    "	and STATE<>0" +
    "	and c.LIQUIDATION_ID=l.LIQUIDATION_ID" +
    "	and c.DESCRIPTION not like '%Pago del crédito:%'" +
    "	and c.OBSERVATION not like '%Liquidacion%'" +
    " ),0) ctaind" +
    " , isnull(" +
    " (" +
    "	select SUM(c.PERSONNEL_PAY+c.EMPLOYER_PAY)*(-1)" +
    "	from one.CONTRIBUTION c" +
    "	where c.PARTNER_ID=l.PARTNER_ID" +
    "	and c.STATUS<>0" +
    "	and STATE<>0" +
    "	and c.LIQUIDATION_ID=l.LIQUIDATION_ID" +
    "	and c.DESCRIPTION like '%Pago del crédito:%'" +
    "	and c.OBSERVATION not like '%Liquidacion%'" +
    " ),0) credito_valor_pagado" +
    " , " +
    " isnull(" +
    " (" +
    "	select SUM(c.PERSONNEL_PAY+c.EMPLOYER_PAY)" +
    "	from one.CONTRIBUTION_EMPLOYER_PAY_OUT c" +
    "	where c.PARTNER_ID=l.PARTNER_ID" +
    "	and c.STATUS<>0" +
    "	and STATE<>0" +
    "	and c.LIQUIDATION_ID=l.LIQUIDATION_ID" +
    " ),0) cXPDF" +
    " ," +
    " isnull( " +
    " (" +
    "	select ls.VALUE*(-1)" +
    "	from one.LIQUIDATION_SUMMARY ls " +
    "	where ls.LIQUIDATION_ID=l.LIQUIDATION_ID" +
    "	and ls.code=9" +
    "	and ls.VALUE<>0" +
    " ),0) pago," +
    " (" +
    "	 select isnull(sum(VALUE),0) " +
    "	 from   one.LIQUIDATION_SUMMARY (nolock) " +
    "	 where LIQUIDATION_ID= l.LIQUIDATION_ID" +
    " ) as restante," +
    " (" +
    "	 select isnull(sum(VALUE)*(-1),0) " +
    "	 from   one.LIQUIDATION_SUMMARY (nolock) " +
    "	 where LIQUIDATION_ID= l.LIQUIDATION_ID  and CODE = 8" +
    " ) as impuesto_patronal," +
    " (" +
    "	select isnull(SUM(ap.BALANCE),0) from one.CREDIT c" +
    "	inner join one.AMORTIZATION_TABLE at on c.CREDIT_ID=at.CREDIT_ID" +
    "	inner join one.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE ap on at.AMORTIZATION_TABLE_ID=ap.AMORTIZATION_TABLE_ID" +
    "	inner join one.AMORTIZATION_TABLE_ADDITIONAL_VALUE ad on ap.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID=ad.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID" +
    "	where c.PARTNER_ID=l.PARTNER_ID and c.STATUS<>0 and at.STATUS<>0 and ad.TYPE=0 AND C.STATE<>6" +
    " )as saldo_adeuda_fondo" +

    " from one.LIQUIDATION l inner join one.PARTNER p on p.PARTNER_ID=l.PARTNER_ID" +
    " where l.STATUS<>0 and l.STATE in (4) )	T	", " YEAR(T.DATE_FOLDER_PAY)=" + _year_buscar + " and MONTH(T.DATE_FOLDER_PAY)=" + _mes_buscar + " and t.TYPE<>3 order by t.tipo");




            int reg_participes_cesantes = dtParticipes_Cesantes.Rows.Count;
            string _tipo = "";


            if (reg_participes_cesantes > 0)
            {

                foreach (DataRow renglon_c in dtParticipes_Cesantes.Rows)
                {

                    _tipo = renglon_c["tipo"].ToString();
                    _identificacion_g42_biess = renglon_c["IDENTITY_CARD"].ToString();
                    _fecha_termino_relacion_laboral_g42_biess = Convert.ToDateTime(renglon_c["DATE_FOLDER_PAY"].ToString());
                    _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42 = Convert.ToDouble(renglon_c["cuenta_individual"].ToString());
                    _valores_pagados_al_fondo_g42_biess = Convert.ToDouble(renglon_c["valor_pagado_al_fondo"].ToString());
                    _valores_pendientes_pago_al_fondo_g42_biess = Convert.ToDouble(renglon_c["saldo_adeuda_fondo"].ToString());
                    _valor_pagado_participe_por_cesantia_g42_biess = Convert.ToDouble(renglon_c["PAGO"].ToString());


                    if (_tipo == "Cesante")
                    {

                        if (_valores_pagados_al_fondo_g42_biess > 0)
                        {

                            _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess = "PORPRESTAOTORPART";
                        }


                    }
                    else
                    {

                        if (_valores_pagados_al_fondo_g42_biess > 0)
                        {

                            _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess = "OTROSCONCEPTOS";
                        }


                    }





                    DataTable dtParticipes1 = AccesoLogica.Select("identificacion_g42_biess", "core_g42_biess", "identificacion_g42_biess='" + _tipo_identificacion_g42_biess + "' AND anio_g42_biess=" + _year_buscar + " and mes_g42_biess=" + _mes_buscar + "");
                    int reg_calcular1 = dtParticipes1.Rows.Count;

                    if (reg_calcular1 > 0)
                    {

                    }
                    else
                    {
                        _leidos++;
                    }

                    _numero_registros_g42_biess = _leidos;


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PARTICIPES CESANTES ->   " + reg_participes_pasivos + "    LEIDOS ->  " + _leidos + "      NUMERO CEDULA ->  " + _identificacion_g42_biess);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Insertar_G42_BIESS_CESANTES(_numero_registros_g42_biess,
                    _identificacion_g42_biess,
                     _motivo_liquidacion_g42_biess,
                    _fecha_termino_relacion_laboral_g42_biess,
                     _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42,
                    _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42,
                     _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess,
                     _valores_pagados_al_fondo_g42_biess,
                     _valores_pendientes_pago_al_fondo_g42_biess,
                    _valor_pagado_participe_por_cesantia_g42_biess,
                     _valor_pagado_participe_por_jubiliacion_g42_biess,
                     _descripcion_otros_conceptos_g42_biess,
                     _valores_pagados_al_participe_otros_conceptos_g42_biess,
                   _anio_g42_biess,
                   _mes_g42_biess);

                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");



                }
            }










            Console.Read();


        }





        public static void Insertar_G42_BIESS_ACTIVOS(int _numero_registros_g42_biess,
                    string _tipo_identificacion_g42_biess,
                    string _identificacion_g42_biess,
                    string _tipo_prestacion_g42_biess,
                    string _estado_participe_cesante_g42_biess,
                    string _estado_participe_jubilado_g42_biess,
                    double _aporte_personal_cesantia_g42_biess,
                    double _aporte_personal_jubilado_g42_biess,
                    double _aporte_adicional_jubilacion_g42_biess,
                    double _aporte_adicional_cesantia_g42_biess,
                    double _rendimiento_anual_g42_biess,
                    double _saldo_cuenta_individual_patronal_g42_biess,
                    double _saldo_cuenta_individual_cesantia_g42_biess,
                    double _saldo_cuenta_individual_jubilacion_g42_biess,
                    double _saldo_aporte_personal_jubilacion_g42_biess,
                    double _saldo_aporte_personal_cesantia_g42_biess,
                    double _saldo_aporte_adicional_jubilacion_g42_biess,
                    double _saldo_aporte_adicional_cesantia_g42_biess,
                    double _saldo_rendimiento_patronal_otros_g42_biess,
                    double _saldo_rendimiento_aporte_personal_jubilacion_g42_biess,
                    double _saldo_rendimiento_aporte_personal_cesantia_g42_biess,
                    double _saldo_rendimiento_aporte_adicional_cesantia_g42_biess,
                    double _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess,
                    double _retencion_fiscal_g42_biess,
                    int _anio_g42_biess,
                    int _mes_g42_biess)

        {


            string cadena1 = _numero_registros_g42_biess + "?" + _tipo_identificacion_g42_biess + "?" + _identificacion_g42_biess + "?" + _tipo_prestacion_g42_biess + "?" + _estado_participe_cesante_g42_biess + "?" + _estado_participe_jubilado_g42_biess + "?" + _aporte_personal_cesantia_g42_biess + "?" + _aporte_personal_jubilado_g42_biess + "?" + _aporte_adicional_jubilacion_g42_biess + "?" + _aporte_adicional_cesantia_g42_biess + "?" + _rendimiento_anual_g42_biess + "?" + _saldo_cuenta_individual_patronal_g42_biess + "?" + _saldo_cuenta_individual_cesantia_g42_biess + "?" + _saldo_cuenta_individual_jubilacion_g42_biess + "?" + _saldo_aporte_personal_jubilacion_g42_biess + "?" + _saldo_aporte_personal_cesantia_g42_biess + "?" + _saldo_aporte_adicional_jubilacion_g42_biess + "?" + _saldo_aporte_adicional_cesantia_g42_biess + "?" + _saldo_rendimiento_patronal_otros_g42_biess + "?" + _saldo_rendimiento_aporte_personal_jubilacion_g42_biess + "?" + _saldo_rendimiento_aporte_personal_cesantia_g42_biess + "?" + _saldo_rendimiento_aporte_adicional_cesantia_g42_biess + "?" + _saldo_rendimiento_aporte_adicional_jubilacion_g42_biess + "?" + _retencion_fiscal_g42_biess + "?" + _anio_g42_biess + "?" + _mes_g42_biess;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_numero_registros_g42_biess?_tipo_identificacion_g42_biess?_identificacion_g42_biess?_tipo_prestacion_g42_biess?_estado_participe_cesante_g42_biess?_estado_participe_jubilado_g42_biess?_aporte_personal_cesantia_g42_biess?_aporte_personal_jubilado_g42_biess?_aporte_adicional_jubilacion_g42_biess?_aporte_adicional_cesantia_g42_biess?_rendimiento_anual_g42_biess?_saldo_cuenta_individual_patronal_g42_biess?_saldo_cuenta_individual_cesantia_g42_biess?_saldo_cuenta_individual_jubilacion_g42_biess?_saldo_aporte_personal_jubilacion_g42_biess?_saldo_aporte_personal_cesantia_g42_biess?_saldo_aporte_adicional_jubilacion_g42_biess?_saldo_aporte_adicional_cesantia_g42_biess?_saldo_rendimiento_patronal_otros_g42_biess?_saldo_rendimiento_aporte_personal_jubilacion_g42_biess?_saldo_rendimiento_aporte_personal_cesantia_g42_biess?_saldo_rendimiento_aporte_adicional_cesantia_g42_biess?_saldo_rendimiento_aporte_adicional_jubilacion_g42_biess?_retencion_fiscal_g42_biess?_anio_g42_biess?_mes_g42_biess";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Integer";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_g42_biess_activos");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Cierre de Mes " + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }




        }



        public static void Insertar_G42_BIESS_PASIVOS(int _numero_registros_g42_biess,
                  string _identificacion_g42_biess,
                 double _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42,
                 double _valor_pagado_participe_desafiliado_g42_biess,
                 DateTime? _fecha_desafiliacion_voluntaria_g42_biess, double _valor_pendiente_pago_desafiliacion_g42_biess,
                  int _anio_g42_biess,
                  int _mes_g42_biess)

        {


            string cadena1 = _numero_registros_g42_biess + "?" + _identificacion_g42_biess + "?" + _fecha_desafiliacion_voluntaria_g42_biess + "?" + _monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42 + "?" + _valor_pendiente_pago_desafiliacion_g42_biess + "?" + _valor_pagado_participe_desafiliado_g42_biess + "?" + _anio_g42_biess + "?" + _mes_g42_biess;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_numero_registros_g42_biess?_identificacion_g42_biess?_fecha_desafiliacion_voluntaria_g42_biess?_monto_desafiliacion_voluntaria_liquidacion_desafiliacion_g42?_valor_pendiente_pago_desafiliacion_g42_biess?_valor_pagado_participe_desafiliado_g42_biess?_anio_g42_biess?_mes_g42_biess";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.DateTime?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.Integer";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_g42_biess_pasivos");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Cierre de Mes " + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }




        }



        public static void Insertar_G42_BIESS_CESANTES(int _numero_registros_g42_biess, string _identificacion_g42_biess,
                    string _motivo_liquidacion_g42_biess,
                    DateTime? _fecha_termino_relacion_laboral_g42_biess,
                    double _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42,
                    double _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42,
                    string _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess,
                    double _valores_pagados_al_fondo_g42_biess,
                     double _valores_pendientes_pago_al_fondo_g42_biess,
                    double _valor_pagado_participe_por_cesantia_g42_biess,
                    double _valor_pagado_participe_por_jubiliacion_g42_biess,
                    string _descripcion_otros_conceptos_g42_biess,
                    double _valores_pagados_al_participe_otros_conceptos_g42_biess,
                     int _anio_g42_biess,
                     int _mes_g42_biess)

        {


            string cadena1 = _numero_registros_g42_biess + "?" + _identificacion_g42_biess + "?" + _motivo_liquidacion_g42_biess + "?" + _fecha_termino_relacion_laboral_g42_biess + "?" + _saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42 + "?" + _saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42 + "?" + _detalle_otros_valores_pagados_y_pendientes_pago_g42_biess + "?" + _valores_pagados_al_fondo_g42_biess + "?" + _valores_pendientes_pago_al_fondo_g42_biess + "?" + _valor_pagado_participe_por_cesantia_g42_biess + "?" + _valor_pagado_participe_por_jubiliacion_g42_biess + "?" + _descripcion_otros_conceptos_g42_biess + "?" + _valores_pagados_al_participe_otros_conceptos_g42_biess + "?" + _anio_g42_biess + "?" + _mes_g42_biess;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_numero_registros_g42_biess?_identificacion_g42_biess?_motivo_liquidacion_g42_biess?_fecha_termino_relacion_laboral_g42_biess?_saldo_cuenta_individual_liquidacion_prestacion_cesantia_g42?_saldo_cuenta_individual_liquidacion_prestacion_jubilado_g42?_detalle_otros_valores_pagados_y_pendientes_pago_g42_biess?_valores_pagados_al_fondo_g42_biess?_valores_pendientes_pago_al_fondo_g42_biess?_valor_pagado_participe_por_cesantia_g42_biess?_valor_pagado_participe_por_jubiliacion_g42_biess?_descripcion_otros_conceptos_g42_biess?_valores_pagados_al_participe_otros_conceptos_g42_biess?_anio_g42_biess?_mes_g42_biess";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.DateTime?NpgsqlDbType.double?NpgsqlDbType.double?NpgsqlDbType.Varchar?NpgsqlDbType.double?NpgsqlDbType.double?NpgsqlDbType.double?NpgsqlDbType.double??NpgsqlDbType.Varchar??NpgsqlDbType.double?NpgsqlDbType.Integer?NpgsqlDbType.Integer";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_g42_biess_cesantes");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Cierre de Mes " + Ex.Message);
                string cadena5 = "_error_errores_importacion";
                string cadena6 = "NpgsqlDbType.Varchar";
                int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }




        }


        // TERMINA G42 MAYCOL

















        ///////MANUEL
        ///
        public static void cargar_prestaciones()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtLiquidation = AccesoLogicaSQL.Select("LIQUIDATION_ID, REFERENCE_ID, HISTORICAL_BASIC_QUANTITY_ID, HISTORICAL_PAY_PERCENTAGE_ID, PARTNER_ID, CORRECTION_FACTOR_VALUE_ID, DATE_CONCLUSION, SUBTOTAL, NET_VALUE_TO_PAY, IMPOSITION_NUMBERS, STATUS , OBSERVATION , TYPE  , STATE  , VOUCHER  , CHECK_NUMBER , PARTNER_IS_ALIVE, FOLDER_NUMBER, FILE_NUMBER, DATE_FOLDER_ENTRANCE, DOCUMENT_NUMBER, USER_ID, USER_NAME, JOURNAL_ID, YEAR_FOR_SEVERANCE, YEAR_FOR_SEVERANCE_PAY, PRORATE_FACTOR_VALUE, FOLDER_STATE_ID,ISNULL( DATE_FOLDER_PAY,'') AS DATE_FOLDER_PAY, NUMBER_FOLDER, DATE_ENTRANCE_PN , DATE_EXIT_PN , OUTCOME_VALUE , LIQUIDATION_HISTORICAL_ID, LIQUIDATION_HISTORICAL_ID_ADITIONAL", " one.LIQUIDATION", " LIQUIDATION_ID > 0");



            int _id_prestaciones;
            int _id_participe;
            //double _mitad_aporte_personal_prestaciones;
            //double _total_aporte_personal_prestaciones;
            //double _total_descuentos_prestaciones;
            double _total_recibir_prestaciones;
            int _numero_aportaciones_prestaciones;
            int _id_estatus;
            string _observacion_prestaciones;
            int _id_tipo_prestaciones;
            int _id_estado_prestaciones;
            string _cuenta_participe_pago_prestaciones;
            string _carpeta_prestaciones;
            string _archivo_prestaciones;
            string _numero_prestaciones;
            DateTime _fecha_solicitud_prestaciones;
            DateTime _fecha_pago_prestaciones;
            string _usuario_usuarios;

            int reg = dtLiquidation.Rows.Count;

            int _leidos_prestaciones = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtLiquidation.Rows)
                {
                    _leidos_prestaciones++;

                    _id_prestaciones = Convert.ToInt32(renglon["LIQUIDATION_ID"].ToString());
                    _id_participe = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _total_recibir_prestaciones = Convert.ToDouble(renglon["NET_VALUE_TO_PAY"].ToString());
                    _numero_aportaciones_prestaciones = Convert.ToInt32(renglon["IMPOSITION_NUMBERS"].ToString());
                    // Convert.ToInt32(renglon["STATUS"].ToString());
                    if (Convert.ToBoolean(renglon["STATUS"].ToString()) == true)
                    {
                        _id_estatus = 1;
                    }
                    else
                    {
                        _id_estatus = 2;
                    }
                    Console.WriteLine("STATUS -> " + _id_estatus + "  " + renglon["STATUS"].ToString());
                    // Console.Read();

                    _observacion_prestaciones = Convert.ToString(renglon["OBSERVATION"].ToString());
                    _id_tipo_prestaciones = Convert.ToInt32(renglon["TYPE"].ToString());
                    if (Convert.ToInt32(renglon["STATE"].ToString()) == 0)
                    {
                        _id_estado_prestaciones = 5;
                    }
                    else
                    {
                        _id_estado_prestaciones = Convert.ToInt32(renglon["STATE"].ToString());
                    }


                    _cuenta_participe_pago_prestaciones = Convert.ToString(renglon["VOUCHER"].ToString());
                    _carpeta_prestaciones = Convert.ToString(renglon["FOLDER_NUMBER"].ToString());
                    _archivo_prestaciones = Convert.ToString(renglon["FILE_NUMBER"].ToString());

                    _fecha_solicitud_prestaciones = Convert.ToDateTime(renglon["DATE_FOLDER_ENTRANCE"].ToString());


                    _numero_prestaciones = Convert.ToString(renglon["DOCUMENT_NUMBER"].ToString());
                    _usuario_usuarios = Convert.ToString(renglon["USER_NAME"].ToString());
                    _fecha_pago_prestaciones = Convert.ToDateTime(renglon["DATE_FOLDER_PAY"].ToString());
                    Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE PRESTACIONES PROCESADAS -> " + reg + " LEIDOS -> " + _leidos_prestaciones);

                    Ins_prestaciones(_id_prestaciones, _id_participe, 0, 0, 0, _total_recibir_prestaciones, _numero_aportaciones_prestaciones, _id_estatus, _observacion_prestaciones, _id_tipo_prestaciones, _id_estado_prestaciones, _cuenta_participe_pago_prestaciones, _carpeta_prestaciones, _archivo_prestaciones, _numero_prestaciones, _fecha_solicitud_prestaciones, _fecha_pago_prestaciones, _usuario_usuarios);
                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }




        public static void Ins_prestaciones(int _id_prestaciones, int _id_participe, double _mitad_aporte_personal_prestaciones, double _total_aporte_personal_prestaciones, double _total_descuentos_prestaciones, double _total_recibir_prestaciones, int _numero_aportaciones_prestaciones, int _id_estatus, string _observacion_prestaciones, int _id_tipo_prestaciones, int _id_estado_prestaciones, string _cuenta_participe_pago_prestaciones, string _carpeta_prestaciones, string _archivo_prestaciones, string _numero_prestaciones, DateTime _fecha_solicitud_prestaciones, DateTime _fecha_pago_prestaciones, string _usuario_usuarios)
        {

            string cadena1 = _id_prestaciones + "?" +
                _id_participe + "?" +
                _mitad_aporte_personal_prestaciones + "?" +
                _total_aporte_personal_prestaciones + "?" +
                _total_descuentos_prestaciones + "?" +
                _total_recibir_prestaciones + "?" +
                _numero_aportaciones_prestaciones + "?" +
                _id_estatus + "?" +
                _observacion_prestaciones + "?" +
                _id_tipo_prestaciones + "?" +
                _id_estado_prestaciones + "?" +
                _cuenta_participe_pago_prestaciones + "?" +
                _carpeta_prestaciones + "?" +
                _archivo_prestaciones + "?" +
                _numero_prestaciones + "?" +
                _fecha_solicitud_prestaciones + "?" +
                _fecha_pago_prestaciones + "?" +
                _usuario_usuarios;




            string cadena2 = "_id_prestaciones?" +
                "_id_participe?" +
                "_mitad_aporte_personal_prestaciones?" +
                "_total_aporte_personal_prestaciones?" +
                "_total_descuentos_prestaciones?" +
                "_total_recibir_prestaciones?" +
                "_numero_aportaciones_prestaciones?" +
                "_id_estatus?" +
                "_observacion_prestaciones?" +
                "_id_tipo_prestaciones?" +
                "_id_estado_prestaciones?" +
                "_cuenta_participe_pago_prestaciones?" +
                "_carpeta_prestaciones?" +
                "_archivo_prestaciones?" +
                "_numero_prestaciones?" +
                "_fecha_solicitud_prestaciones?" +
                "_fecha_pago_prestaciones?" +
                "_usuario_usuarios";
            string cadena3 = "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Double?" +
                "NpgsqlDbType.Double?" +
                "NpgsqlDbType.Double?" +
                "?NpgsqlDbType.Double?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.TimestampTz?" +
                "NpgsqlDbType.TimestampTz?" +
                "NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_prestaciones_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Prestaciones" + Ex.Message);
                //  string cadena5 = "_error_errores_importacion";
                //   string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //Console.Read();

            }

        }





        public static void cargar_modo_pago()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtModoPago = AccesoLogicaSQL.Select("CREDIT_PAYMENT_MODE_ID, NAME, DESCRIPTION ", "one.CREDIT_PAYMENT_MODE", " CREDIT_PAYMENT_MODE_ID > 0");



            int _id_modo_pago;
            string _nombre_modo_pago;
            string _descripcion_modo_pago;

            int reg = dtModoPago.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtModoPago.Rows)
                {
                    _leidos++;

                    _id_modo_pago = Convert.ToInt32(renglon["CREDIT_PAYMENT_MODE_ID"].ToString());
                    _nombre_modo_pago = Convert.ToString(renglon["NAME"].ToString());
                    _descripcion_modo_pago = Convert.ToString(renglon["DESCRIPTION"].ToString());

                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE MODO DE PAGOS PROCESADOS -> " + reg + " LEIDOS -> " + _leidos);

                    Ins_modo_pago(_id_modo_pago, _nombre_modo_pago, _descripcion_modo_pago);
                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void Ins_modo_pago(int _id_modo_pago, string _nombre_modo_pago, string _descripcion_modo_pago)

        {

            string cadena1 = _id_modo_pago + "?" +
                _nombre_modo_pago + "?" +
                _descripcion_modo_pago;




            string cadena2 = "_id_modo_pago?_nombre_modo_pago?_descripcion_modo_pago";
            string cadena3 = "NpgsqlDbType.Integer?" +

                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_modo_pago_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Modo de pagos" + Ex.Message);
                //string cadena5 = "_error_errores_importacion";
                //string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }




        public static void cargar_transacciones()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO CABEZA->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtTransacciones = AccesoLogicaSQL.Select("CREDIT_TRANSACTION_ID," +
                "CREDIT_ID," +
                "PARTNER_ID," +
                "TYP_TYPE_PAYMENT_ID," +
                "DATE," +
                "VALUE," +
                "COMMENTS," +
                "USER_LOGIN," +
                "EVENT_ID," +
                "JOURNAL_ID," +
                "NUM_MIGRATED," +
                "CURRENCY_ID," +
                "DATE_PROCESS," +
                "OLD_CODE," +
                "CASE WHEN STATUS = 0 THEN 2 ELSE STATUS END AS STATUS," +
                "CASE WHEN STATE = 0 THEN 2 ELSE STATE END AS STATE," +
                "CREDIT_PAYMENT_MODE_ID," +
                "REFERENCE_NUMBER," +
                "JOURNAL_REVERSE_ID," +
                "SERVER_DATE", " one.CREDIT_TRANSACTION", " PARTNER_ID > 0 ORDER BY CREDIT_TRANSACTION_ID ASC");

            Int64 _id_transacciones;
            Int64 _id_creditos;
            Int64 _id_participes;
            DateTime _fecha_transacciones;
            Double _valor_transacciones;
            string _observacion_transacciones;
            string _usuario_usuarios;
            Int64 _id_ccomprobantes_ant;
            DateTime _fecha_contable_core_transacciones;
            int _id_status;
            int _id_estado_transacciones;
            int _id_modo_pago;
            int _id_creditos_tipo_pago=0;
            int _id_ccomprobantes_reversa=0;


<<<<<<< HEAD
=======

>>>>>>> 524930849535fd934071b784eff09e30614ad87e
            int reg = dtTransacciones.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtTransacciones.Rows)
                {
                    _leidos++;

                    _id_transacciones = Convert.ToInt64(renglon["CREDIT_TRANSACTION_ID"].ToString());
                    _id_creditos = Convert.ToInt64(renglon["CREDIT_ID"].ToString());
                    _id_participes = Convert.ToInt64(renglon["PARTNER_ID"].ToString());
                    _fecha_transacciones = Convert.ToDateTime(renglon["DATE"].ToString());
                    _valor_transacciones = Convert.ToDouble(renglon["VALUE"].ToString());
                    _observacion_transacciones = Convert.ToString(renglon["COMMENTS"].ToString());
                    _usuario_usuarios = Convert.ToString(renglon["USER_LOGIN"].ToString());
                    _id_ccomprobantes_ant = Convert.ToInt64(renglon["JOURNAL_ID"].ToString());
                    _fecha_contable_core_transacciones = Convert.ToDateTime(renglon["DATE_PROCESS"].ToString());
                    _id_status = Convert.ToInt32(renglon["STATUS"].ToString());
                    _id_estado_transacciones = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_modo_pago = Convert.ToInt32(renglon["CREDIT_PAYMENT_MODE_ID"].ToString());
                    _id_creditos_tipo_pago = Convert.ToInt32(renglon["TYP_TYPE_PAYMENT_ID"].ToString());
                    _id_ccomprobantes_reversa = Convert.ToInt32(renglon["JOURNAL_REVERSE_ID"].ToString());



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE MODO DE PAGOS PROCESADOS -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_transacciones(_id_transacciones, _id_creditos, _id_participes, _fecha_transacciones, _valor_transacciones, _observacion_transacciones, _usuario_usuarios, _id_ccomprobantes_ant, _fecha_contable_core_transacciones, _id_status, _id_estado_transacciones, _id_modo_pago, _id_creditos_tipo_pago, _id_ccomprobantes_reversa);

                    cargar_transacciones_detalle(_id_transacciones);
                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


<<<<<<< HEAD
        public static void ins_core_transacciones(Int64 _id_transacciones, Int64 _id_creditos, Int64 _id_participes, DateTime _fecha_transacciones, double  _valor_transacciones, string  _observacion_transacciones, string  _usuario_usuarios, Int64  _id_ccomprobantes_ant, DateTime _fecha_contable_core_transacciones, int _id_status,  int _id_estado_transacciones, int _id_modo_pago, int _id_creditos_tipo_pago, int _id_ccomprobantes_reversa)
        {

            string cadena1 = _id_transacciones+"?"+
                _id_creditos + "?" + 
                _id_participes + "?" + 
                _fecha_transacciones + "?" + 
                _valor_transacciones + "?" + 
                _observacion_transacciones + "?" + 
                _usuario_usuarios + "?" + 
                _id_ccomprobantes_ant + "?" + 
                _fecha_contable_core_transacciones + "?" + 
                _id_status + "?" + 
                _id_estado_transacciones + "?" +
                _id_modo_pago + "?" +
                _id_creditos_tipo_pago + "?" +
                _id_ccomprobantes_reversa;
=======
        public static void ins_core_transacciones(Int64 _id_transacciones, Int64 _id_creditos, Int64 _id_participes, DateTime _fecha_transacciones, double _valor_transacciones, string _observacion_transacciones, string _usuario_usuarios, Int64 _id_ccomprobantes_ant, DateTime _fecha_contable_core_transacciones, int _id_status, int _id_estado_transacciones, int _id_modo_pago)
        {

            string cadena1 = _id_transacciones + "?" +
                _id_creditos + "?" +
                _id_participes + "?" +
                _fecha_transacciones + "?" +
                _valor_transacciones + "?" +
                _observacion_transacciones + "?" +
                _usuario_usuarios + "?" +
                _id_ccomprobantes_ant + "?" +
                _fecha_contable_core_transacciones + "?" +
                _id_status + "?" +
                _id_estado_transacciones + "?" +
                _id_modo_pago;
>>>>>>> 524930849535fd934071b784eff09e30614ad87e




            string cadena2 = "_id_transacciones?" +
                "_id_creditos?" +
                "_id_participes?" +
                "_fecha_transacciones?" +
                "_valor_transacciones?" +
                "_observacion_transacciones?" +
                "_usuario_usuarios?" +
                "_id_ccomprobantes_ant?" +
                "_fecha_contable_core_transacciones?" +
                "_id_status?" +
                "_id_estado_transacciones?" +
<<<<<<< HEAD
                "_id_modo_pago?" +
                "_id_creditos_tipo_pago?" +
                "_id_ccomprobantes_reversa";
=======
                "_id_modo_pago";

>>>>>>> 524930849535fd934071b784eff09e30614ad87e
            string cadena3 = "NpgsqlDbType.Bigint?" +
                            "NpgsqlDbType.Bigint?" +
                            "NpgsqlDbType.Bigint?" +
                             "NpgsqlDbType.TimestampTz?" +
                            "NpgsqlDbType.Numeric?" +
                            "NpgsqlDbType.Varchar?" +
                            "NpgsqlDbType.Varchar?" +
                            "NpgsqlDbType.Bigint?" +
                            "NpgsqlDbType.TimestampTz?" +
                            "NpgsqlDbType.Integer?" +
                            "NpgsqlDbType.Integer?" +
                            "NpgsqlDbType.Integer?" +
                            "NpgsqlDbType.Integer?" +
                            "NpgsqlDbType.Integer?";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_transacciones_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Transacciones" + Ex.Message);
                // string cadena5 = "_error_errores_importacion";
                // string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }



        public static void cargar_transacciones_detalle(Int64 _id_transacciones)
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO DETALLE ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtTransacciones = AccesoLogicaSQL.Select("CREDIT_TRANSACTION_DETAIL_ID, " +
                "CREDIT_TRANSACTION_ID, " +
                "APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID," +
                "VALUE," +
                "CASE WHEN STATUS = 0 THEN 2 ELSE STATUS END AS STATUS," +
                "CASE WHEN STATE = 0 THEN 2 ELSE STATE END AS STATE", " one.CREDIT_TRANSACTION_DETAIL", " CREDIT_TRANSACTION_ID=" + _id_transacciones + " ORDER BY CREDIT_TRANSACTION_DETAIL_ID ASC");

            Int64 _id_transacciones_detalle;
            // Int64 _id_transacciones;
            Int64 _id_tabla_amortizacion_pago;
            double _valor_transaccion_detalle;
            int _id_status;
            int _id_estado_transacciones;


            int reg = dtTransacciones.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtTransacciones.Rows)
                {
                    _leidos++;

                    _id_transacciones_detalle = Convert.ToInt64(renglon["CREDIT_TRANSACTION_DETAIL_ID"].ToString());
                    _id_transacciones = Convert.ToInt64(renglon["CREDIT_TRANSACTION_ID"].ToString());

                    _id_tabla_amortizacion_pago = Convert.ToInt64(renglon["APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID"].ToString());
                    _valor_transaccion_detalle = Convert.ToDouble(renglon["VALUE"].ToString());
                    _id_status = Convert.ToInt32(renglon["STATUS"].ToString());
                    _id_estado_transacciones = Convert.ToInt32(renglon["STATE"].ToString());



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE MODO DE PAGOS PROCESADOS -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_transacciones_detalle_carga(_id_transacciones_detalle, _id_transacciones, _id_tabla_amortizacion_pago, _valor_transaccion_detalle, _id_status, _id_estado_transacciones);
                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void ins_core_transacciones_detalle_carga(Int64 _id_transacciones_detalle, Int64 _id_transacciones, Int64 _id_tabla_amortizacion_pago, double _valor_transaccion_detalle, int _id_status, int _id_estado_transacciones)
        {

            string cadena1 = _id_transacciones_detalle + "?" + _id_transacciones + "?" + _id_tabla_amortizacion_pago + "?" + _valor_transaccion_detalle + "?" + _id_status + "?" + _id_estado_transacciones;
            string cadena2 = "_id_transacciones_detalle?_id_transacciones?_id_tabla_amortizacion_pago?_valor_transaccion_detalle?_id_status?_id_estado_transacciones";
            string cadena3 = "NpgsqlDbType.Bigint?" +
                            "NpgsqlDbType.Bigint?" +
                            "NpgsqlDbType.Bigint?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Integer?" +
                             "NpgsqlDbType.Integer?";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "public.ins_core_transacciones_detalle_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO DETALLE ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Tabla de Transacciones detalle" + Ex.Message);
                //  string cadena5 = "_error_errores_importacion";
                //  string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }




        public static void cargar_documentos_hipotecarios()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO DETALLE ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtTransacciones = AccesoLogicaSQL.Select("CREDIT_ID, " +
                "PROPERTY_APPRAISAL ", "one.MORTGAGE_DATA", "  1 = 1");

            Int64 _id_credito;
            // Int64 _id_transacciones;

            double _valor_avaluo_core_documentos_hipotecario = 0;

            int reg = dtTransacciones.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtTransacciones.Rows)
                {
                    _leidos++;

                    _id_credito = Convert.ToInt64(renglon["CREDIT_ID"].ToString());
                    _valor_avaluo_core_documentos_hipotecario = Convert.ToDouble(renglon["PROPERTY_APPRAISAL"].ToString());



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE garantias procesadas -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_documentos_hipotecarios(_id_credito, _valor_avaluo_core_documentos_hipotecario);
                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }


        public static void ins_core_documentos_hipotecarios(Int64 _id_creditos, double _valor_avaluo_core_documentos_hipotecario)
        {
            string cadena1 = _id_creditos + "?" + _valor_avaluo_core_documentos_hipotecario;
            string cadena2 = "_id_creditos?_valor_avaluo_core_documentos_hipotecario";
            string cadena3 = "NpgsqlDbType.Bigint?" +
                             "NpgsqlDbType.Numeric?";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_documentos_hipotecario_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO DETALLE ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar documentos hipotecarios" + Ex.Message);
                //   string cadena5 = "_error_errores_importacion";
                //  string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }




        /// <summary>
        /// /LIQUIDACIONES HISTORICOS
        /// </summary>
        public static void cargar_liquidacion_historico()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO LIQUIDACION HISTORICO ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");




            DataTable dtLiquidacionHistorico = AccesoLogicaSQL.Select("l.LIQUIDATION_HISTORICAL_ID, " +
                "l.LIQUIDATION_STATE, " +
                "l.REGISTER_DATE, " +
                "l.USER_NAME, " +
                "l.OBSERVATION, " +
                "CASE WHEN l.STATUS = 0 THEN 2 " +
                "ELSE l.STATUS END AS STATUS",
                " one.LIQUIDATION_HISTORICAL l ",
                " 1= 1");
            /*
            public.ins_core_liquidaciones_historico_carga(
    _id_liquidaciones_historico integer,
    _id_estado_prestaciones integer,
    _fecha_registro_liquidaciones_historico timestamp with time zone,
    _observaciones_liquidacion_historico character varying,
    _id_usuarios integer,
    _id_status integer)
    */

            int _id_liquidaciones_historico;
            int _id_estado_prestaciones;
            DateTime _fecha_registro_liquidaciones_historico;
            string _observaciones_liquidacion_historico;
            int _id_usuarios;
            int _id_status;


            int reg = dtLiquidacionHistorico.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtLiquidacionHistorico.Rows)
                {
                    _leidos++;


                    _id_liquidaciones_historico = Convert.ToInt32(renglon["LIQUIDATION_HISTORICAL_ID"].ToString());
                    _id_estado_prestaciones = Convert.ToInt32(renglon["LIQUIDATION_STATE"].ToString());
                    _fecha_registro_liquidaciones_historico = Convert.ToDateTime(renglon["REGISTER_DATE"].ToString());
                    _observaciones_liquidacion_historico = Convert.ToString(renglon["OBSERVATION"].ToString()) + " USER:" + Convert.ToString(renglon["USER_NAME"].ToString());
                    _id_usuarios = 34;
                    _id_status = Convert.ToInt32(renglon["STATUS"].ToString());



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE LIQUIDACION HISTORICOS PROCSADOS -> " + reg + " LEIDOS -> " + _leidos);

                    //Console.WriteLine("DETALLE: " + _id_liquidaciones_historico+" Estado: "+ _id_estado_prestaciones + " Fecha: " + _fecha_registro_liquidaciones_historico + " Observacion: " + _observaciones_liquidacion_historico + " id Usuario: " + _id_usuarios + " Starus: " + _id_status);
                    ins_core_liquidaciones_historico_carga(_id_liquidaciones_historico, _id_estado_prestaciones, _fecha_registro_liquidaciones_historico, _observaciones_liquidacion_historico, _id_usuarios, _id_status);





                    //cargar_transacciones_detalle(_id_transacciones);
                }

                Console.Read();
                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_liquidaciones_historico_carga(int _id_liquidaciones_historico, int _id_estado_prestaciones, DateTime _fecha_registro_liquidaciones_historico, string _observaciones_liquidacion_historico, int _id_usuarios, int _id_status)
        {
            Console.WriteLine("1->" + _id_liquidaciones_historico + "2-> " + _id_estado_prestaciones + "3-> " + _fecha_registro_liquidaciones_historico + "4-> " + _observaciones_liquidacion_historico + "5-> " + _id_usuarios + "6-> " + _id_status);
            string cadena1 = _id_liquidaciones_historico + "?" + _id_estado_prestaciones + "?" + _fecha_registro_liquidaciones_historico + "?" + _observaciones_liquidacion_historico + "?" + _id_usuarios + "?" + _id_status;
            string cadena2 = "_id_liquidaciones_historico?_id_estado_prestaciones?_fecha_registro_liquidaciones_historico?_observaciones_liquidacion_historico?_id_usuarios?_id_status";
            string cadena3 = "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.TimestampTz?" +
                            "NpgsqlDbType.Varchar?" +
                            "NpgsqlDbType.Int?" +
                            "NpgsqlDbType.Int";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_liquidaciones_historico_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO LIQUIDACIONES HISTORICOS ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");




            }
            catch (Exception Ex)

            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Error al insertar LIQUIDACIONES HISTORICOS " + Ex.Message);
                //    string cadena5 = "_error_errores_importacion";
                //    string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.Read();


            }

        }





        public static void cargar_tipo_pago_liquidacion()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO TIPO PAGO LIQUIDACION  ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtPagoLiquidacion = AccesoLogicaSQL.Select("CATALOG_VALUE, CATALOG_NAME, CATALOG_DESCRIPTION",
                " one.CATALOG c",
                " c.CATALOG_IDENTITY like '%LIQUIDATION_SUMMARY_ID%' ");

            int _id_tipo_pago_liquidacion;
            string _nombre_tipo_pago_liquidacion;
            string _descripcion_tipo_pago_liquidacion;

            int reg = dtPagoLiquidacion.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtPagoLiquidacion.Rows)
                {
                    _leidos++;



                    _id_tipo_pago_liquidacion = Convert.ToInt32(renglon["CATALOG_VALUE"].ToString());
                    _nombre_tipo_pago_liquidacion = Convert.ToString(renglon["CATALOG_NAME"].ToString());
                    _descripcion_tipo_pago_liquidacion = Convert.ToString(renglon["CATALOG_DESCRIPTION"].ToString());


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE TIPO PAGO  LIQUIDACION  PROCSADOS -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_tipo_pago_liquidacion_carga(_id_tipo_pago_liquidacion, _nombre_tipo_pago_liquidacion, _descripcion_tipo_pago_liquidacion);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }






        public static void ins_core_tipo_pago_liquidacion_carga(int _id_tipo_pago_liquidacion, string _nombre_tipo_pago_liquidacion, string _descripcion_tipo_pago_liquidacion)
        {
            string cadena1 = _id_tipo_pago_liquidacion + "?" + _nombre_tipo_pago_liquidacion + "?" + _descripcion_tipo_pago_liquidacion;
            string cadena2 = "_id_tipo_pago_liquidacion?_nombre_tipo_pago_liquidacion?_descripcion_tipo_pago_liquidacion";
            string cadena3 = "NpgsqlDbType.Int?" +
                            "NpgsqlDbType.Varchar?" +
                            "NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_tipo_pago_liquidacion_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO TIPO PAGO LIQUIDACIONES ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar TIPO PAGO LIQUIDACIONES" + Ex.Message);
                //   string cadena5 = "_error_errores_importacion";
                //   string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }






        public static void cargar_liquidacion_cabeza()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            CultureInfo culture = CultureInfo.CurrentCulture;
            Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO TIPO  LIQUIDACION CABEZA  ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtLiquidacionCabeza = AccesoLogicaSQL.Select("l.LIQUIDATION_ID, " +
                "l.PARTNER_ID, " +
                "l.DATE_CONCLUSION, " +
                "l.NET_VALUE_TO_PAY, " +
                "l.IMPOSITION_NUMBERS, " +
                "CASE WHEN l.STATUS=0 THEN 2 ELSE l.STATUS END AS STATUS, " +
                "l.OBSERVATION, " +
                "l.TYPE, " +
                "l.STATE, " +
                "l.VOUCHER, " +
                "l.FOLDER_NUMBER, " +
                "l.FILE_NUMBER, " +
                "CONVERT(datetime, l.DATE_FOLDER_ENTRANCE , 21) AS DATE_FOLDER_ENTRANCE, " +
                "l.DOCUMENT_NUMBER, " +
                "l.USER_NAME, " +
                "CONVERT(datetime, l.DATE_FOLDER_PAY , 21) AS DATE_FOLDER_PAY , " +
                "l.NUMBER_FOLDER, " +
                "l.DATE_ENTRANCE_PN, " +
                "l.DATE_EXIT_PN, " +
                "l.LIQUIDATION_HISTORICAL_ID",
                " one.LIQUIDATION l",
                "  1=1 ");

            /*
             public.ins_core_liquidacion_cabeza_carga(
    _id_liquidacion_cabeza integer,
    _id_participes bigint,
    _valor_neto_pagar_liquidacion_cabeza numeric,
    _cantidad_aportaciones_liquidacion_cabeza integer,
    _id_status integer,
    _observacion_liquidacion_cabeza character varying,
    _id_tipo_prestaciones integer,
    _id_estado_prestaciones integer,
    _sustento_liquidacion_cabeza character varying,
    _carpeta_numero_liquidacion_cabeza character varying,
    _file_number_liquidacion_cabeza integer,
    _fecha_entrada_carpeta_liquidacion_cabeza timestamp with time zone,
    _user_name character varying,
    _id_usuarios integer,
    _fecha_pago_carpeta_liquidacion_cabeza timestamp with time zone,
    _numero_documento_liquidacion_cabeza integer,
    _fecha_entrada_liquidacion_cabeza timestamp with time zone,
    _numero_carpeta_liquidacion_cabeza integer,
    _fecha_salida_liquidacion_cabeza timestamp with time zone,
    _id_liquidaciones_historico integer)
            */


            int _id_liquidacion_cabeza;
            Int64 _id_participes;
            double _valor_neto_pagar_liquidacion_cabeza;
            int _cantidad_aportaciones_liquidacion_cabeza;
            int _id_status;
            string _observacion_liquidacion_cabeza;
            int _id_tipo_prestaciones;
            int _id_estado_prestaciones;
            string _sustento_liquidacion_cabeza;
            string _carpeta_numero_liquidacion_cabeza;
            int _file_number_liquidacion_cabeza;
            DateTime _fecha_entrada_carpeta_liquidacion_cabeza;
            string _user_name;
            int _id_usuarios;
            DateTime _fecha_pago_carpeta_liquidacion_cabeza;
            int _numero_documento_liquidacion_cabeza;
            DateTime _fecha_entrada_liquidacion_cabeza;
            int _numero_carpeta_liquidacion_cabeza;
            DateTime _fecha_salida_liquidacion_cabeza;
            int _id_liquidaciones_historico;



            int reg = dtLiquidacionCabeza.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtLiquidacionCabeza.Rows)
                {
                    _leidos++;


                    _id_liquidacion_cabeza = Convert.ToInt32(renglon["LIQUIDATION_ID"].ToString());
                    _id_participes = Convert.ToInt64(renglon["PARTNER_ID"].ToString());
                    _valor_neto_pagar_liquidacion_cabeza = Convert.ToDouble(renglon["NET_VALUE_TO_PAY"].ToString());
                    _cantidad_aportaciones_liquidacion_cabeza = Convert.ToInt32(renglon["IMPOSITION_NUMBERS"].ToString());
                    _id_status = Convert.ToInt32(renglon["STATUS"].ToString());
                    _observacion_liquidacion_cabeza = Convert.ToString(renglon["OBSERVATION"].ToString());
                    _id_tipo_prestaciones = Convert.ToInt32(renglon["TYPE"].ToString());
                    _id_estado_prestaciones = Convert.ToInt32(renglon["STATE"].ToString());
                    _sustento_liquidacion_cabeza = Convert.ToString(renglon["VOUCHER"].ToString());
                    _carpeta_numero_liquidacion_cabeza = Convert.ToString(renglon["FOLDER_NUMBER"].ToString());
                    _file_number_liquidacion_cabeza = Convert.ToInt32(renglon["FILE_NUMBER"].ToString());
                    _fecha_entrada_carpeta_liquidacion_cabeza = Convert.ToDateTime(renglon["DATE_FOLDER_ENTRANCE"].ToString());
                    _user_name = Convert.ToString(renglon["USER_NAME"].ToString());
                    _id_usuarios = 34; //Convert.ToInt32(renglon["CATALOG_VALUE"].ToString());

                    if (renglon["DATE_FOLDER_PAY"].ToString() != "")
                    {
                        _fecha_pago_carpeta_liquidacion_cabeza = Convert.ToDateTime(renglon["DATE_FOLDER_PAY"].ToString());
                    }
                    else
                    {
                        _fecha_pago_carpeta_liquidacion_cabeza = Convert.ToDateTime("1/1/1900 9:48:32");

                    }


                    _numero_documento_liquidacion_cabeza = Convert.ToInt32(renglon["NUMBER_FOLDER"].ToString());
                    _fecha_entrada_liquidacion_cabeza = Convert.ToDateTime(renglon["DATE_ENTRANCE_PN"].ToString());

                    _numero_carpeta_liquidacion_cabeza = Convert.ToInt32(renglon["NUMBER_FOLDER"].ToString());
                    _fecha_salida_liquidacion_cabeza = Convert.ToDateTime(renglon["DATE_EXIT_PN"].ToString());
                    if (renglon["LIQUIDATION_HISTORICAL_ID"].ToString() != "")
                    {
                        _id_liquidaciones_historico = Convert.ToInt32(renglon["LIQUIDATION_HISTORICAL_ID"].ToString());
                    }
                    else
                    {
                        _id_liquidaciones_historico = 0;
                    }





                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE TIPO PAGO  LIQUIDACION  PROCSADOS -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_liquidacion_cabeza_carga(_id_liquidacion_cabeza, _id_participes, _valor_neto_pagar_liquidacion_cabeza, _cantidad_aportaciones_liquidacion_cabeza, _id_status, _observacion_liquidacion_cabeza, _id_tipo_prestaciones, _id_estado_prestaciones, _sustento_liquidacion_cabeza, _carpeta_numero_liquidacion_cabeza, _file_number_liquidacion_cabeza, _fecha_entrada_carpeta_liquidacion_cabeza, _user_name, _id_usuarios, _fecha_pago_carpeta_liquidacion_cabeza, _numero_documento_liquidacion_cabeza, _fecha_entrada_liquidacion_cabeza, _numero_carpeta_liquidacion_cabeza, _fecha_salida_liquidacion_cabeza, _id_liquidaciones_historico);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }




        public static void ins_core_liquidacion_cabeza_carga(int _id_liquidacion_cabeza, Int64 _id_participes, double _valor_neto_pagar_liquidacion_cabeza, int _cantidad_aportaciones_liquidacion_cabeza, int _id_status, string _observacion_liquidacion_cabeza, int _id_tipo_prestaciones, int _id_estado_prestaciones, string _sustento_liquidacion_cabeza, string _carpeta_numero_liquidacion_cabeza, int _file_number_liquidacion_cabeza, DateTime _fecha_entrada_carpeta_liquidacion_cabeza, string _user_name, int _id_usuarios, DateTime _fecha_pago_carpeta_liquidacion_cabeza, int _numero_documento_liquidacion_cabeza, DateTime _fecha_entrada_liquidacion_cabeza, int _numero_carpeta_liquidacion_cabeza, DateTime _fecha_salida_liquidacion_cabeza, int _id_liquidaciones_historico)
        {
            string cadena1 = _id_liquidacion_cabeza + "?" + _id_participes + "?" + _valor_neto_pagar_liquidacion_cabeza + "?" + _cantidad_aportaciones_liquidacion_cabeza + "?" + _id_status + "?" + _observacion_liquidacion_cabeza + "?" + _id_tipo_prestaciones + "?" + _id_estado_prestaciones + "?" + _sustento_liquidacion_cabeza + "?" + _carpeta_numero_liquidacion_cabeza + "?" + _file_number_liquidacion_cabeza + "?" + _fecha_entrada_carpeta_liquidacion_cabeza + "?" + _user_name + "?" + _id_usuarios + "?" + _fecha_pago_carpeta_liquidacion_cabeza + "?" + _numero_documento_liquidacion_cabeza + "?" + _fecha_entrada_liquidacion_cabeza + "?" + _numero_carpeta_liquidacion_cabeza + "?" + _fecha_salida_liquidacion_cabeza + "?" + _id_liquidaciones_historico;
            string cadena2 = " _id_liquidacion_cabeza?_id_participes?_valor_neto_pagar_liquidacion_cabeza?_cantidad_aportaciones_liquidacion_cabeza?_id_status?_observacion_liquidacion_cabeza?_id_tipo_prestaciones?_id_estado_prestaciones?_sustento_liquidacion_cabeza?_carpeta_numero_liquidacion_cabeza?_file_number_liquidacion_cabeza?_fecha_entrada_carpeta_liquidacion_cabeza?_user_name?_id_usuarios?_fecha_pago_carpeta_liquidacion_cabeza?_numero_documento_liquidacion_cabeza?_fecha_entrada_liquidacion_cabeza?_numero_carpeta_liquidacion_cabeza?_fecha_salida_liquidacion_cabeza?_id_liquidaciones_historico";
            string cadena3 = "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Bigint?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.TimestampTz?" +
                            "NpgsqlDbType.Varchar?" +
                            "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.TimestampTz?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.TimestampTz?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.TimestampTz?" +
                             "NpgsqlDbType.Int";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_liquidacion_cabeza_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO TIPO PAGO LIQUIDACIONES ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar TIPO PAGO LIQUIDACIONES" + Ex.Message);
                //  string cadena5 = "_error_errores_importacion";
                //  string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR hISTORICO ->" + _id_liquidaciones_historico);
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.Read();

            }

        }






        public static void cargar_liquidacion_detalle()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO TIPO  LIQUIDACION DETALLE  ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtLiquidacionDetalle = AccesoLogicaSQL.Select("L.LIQUIDATION_SUMMARY_ID, " +
                "L.LIQUIDATION_ID, " +
                "L.MOTIVE, " +
                "L.VALUE, " +
                "l.PERCENTAGE, " +
                "l.CALCULATION_BASE, " +
                "l.REGISTER_DATE, " +
                "l.code as typo_liquidacion, " +
                "l.TABLE_NAME, " +
                "l.OBSERVATION      ",
                " one.LIQUIDATION_SUMMARY l",
                " 1=1 ");

            /*
             public.ins_core_liquidacion_detalle_carga(
    _id_liquidacion_detalle integer,
    _id_liquidacion_cabeza integer,
    _motivo_liquidacion_detalle character varying,
    _valor_liquidacion_detalle numeric,
    _porcentaje_liquidacion_detalle numeric,
    _base_calcuo_liquidacion_detalle numeric,
    _fecha_registro_liquidacion_detalle timestamp with time zone,
    _id_tipo_prestaciones integer,
    _nombre_tabla_liquidacion_detalle character varying,
    _observacion_liquidacion_detalle character varying)
            */


            int _id_liquidacion_detalle;
            int _id_liquidacion_cabeza;
            string _motivo_liquidacion_detalle;
            double _valor_liquidacion_detalle;
            double _porcentaje_liquidacion_detalle;
            double _base_calcuo_liquidacion_detalle;
            DateTime _fecha_registro_liquidacion_detalle;
            int _id_tipo_prestaciones;
            string _nombre_tabla_liquidacion_detalle;
            string _observacion_liquidacion_detalle;



            int reg = dtLiquidacionDetalle.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtLiquidacionDetalle.Rows)
                {
                    _leidos++;

                    _id_liquidacion_detalle = Convert.ToInt32(renglon["LIQUIDATION_SUMMARY_ID"].ToString());
                    _id_liquidacion_cabeza = Convert.ToInt32(renglon["LIQUIDATION_ID"].ToString());
                    _motivo_liquidacion_detalle = Convert.ToString(renglon["MOTIVE"].ToString());
                    _valor_liquidacion_detalle = Convert.ToDouble(renglon["VALUE"].ToString());
                    _porcentaje_liquidacion_detalle = Convert.ToDouble(renglon["PERCENTAGE"].ToString());
                    _base_calcuo_liquidacion_detalle = Convert.ToDouble(renglon["CALCULATION_BASE"].ToString());
                    _fecha_registro_liquidacion_detalle = Convert.ToDateTime(renglon["REGISTER_DATE"].ToString());
                    _id_tipo_prestaciones = Convert.ToInt32(renglon["typo_liquidacion"].ToString());
                    _nombre_tabla_liquidacion_detalle = Convert.ToString(renglon["TABLE_NAME"].ToString());
                    _observacion_liquidacion_detalle = Convert.ToString(renglon["OBSERVATION"].ToString());

                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE TIPO LIQUIDACION  DETALLE -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_liquidacion_detalle_carga(_id_liquidacion_detalle, _id_liquidacion_cabeza, _motivo_liquidacion_detalle, _valor_liquidacion_detalle, _porcentaje_liquidacion_detalle, _base_calcuo_liquidacion_detalle, _fecha_registro_liquidacion_detalle, _id_tipo_prestaciones, _nombre_tabla_liquidacion_detalle, _observacion_liquidacion_detalle);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_liquidacion_detalle_carga(int _id_liquidacion_detalle, int _id_liquidacion_cabeza, string _motivo_liquidacion_detalle, double _valor_liquidacion_detalle, double _porcentaje_liquidacion_detalle, double _base_calcuo_liquidacion_detalle, DateTime _fecha_registro_liquidacion_detalle, int _id_tipo_prestaciones, string _nombre_tabla_liquidacion_detalle, string _observacion_liquidacion_detalle)
        {


            string cadena1 = _id_liquidacion_detalle + "?" + _id_liquidacion_cabeza + "?" + _motivo_liquidacion_detalle + "?" + _valor_liquidacion_detalle + "?" + _porcentaje_liquidacion_detalle + "?" + _base_calcuo_liquidacion_detalle + "?" + _fecha_registro_liquidacion_detalle + "?" + _id_tipo_prestaciones + "?" + _nombre_tabla_liquidacion_detalle + "?" + _observacion_liquidacion_detalle;
            string cadena2 = "_id_liquidacion_detalle?_id_liquidacion_cabeza?_motivo_liquidacion_detalle?_valor_liquidacion_detalle?_porcentaje_liquidacion_detalle?_base_calcuo_liquidacion_detalle?_fecha_registro_liquidacion_detalle?_id_tipo_prestaciones?_nombre_tabla_liquidacion_detalle?_observacion_liquidacion_detalle";

            string cadena3 = "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.TimestampTz?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_liquidacion_detalle_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  LIQUIDACIONES DETALLE ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  LIQUIDACIONES DETALLE" + Ex.Message);
                //  string cadena5 = "_error_errores_importacion";
                //   string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.Read();

            }

        }








        public static void cargar_liquidacion_forma_pago_carga()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  LIQUIDACION FORMA PAGO   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtLiquidacionFormaPago = AccesoLogicaSQL.Select("l.LIQUIDATION_PAYMENT_FORM_ID, " +
                "l.LIQUIDATION_ID, " +
                "l.PAYMENT_TYPE, " +
                "l.MOVEMENT_TYPE, " +
                "l.BANK_ID, " +
                "l.BANK_NAME, " +
                "l.NUMBER_ACCOUNT, " +
                "l.VALUE, " +
                "CASE WHEN l.STATUS=0 THEN 2 ELSE l." +
                "STATUS END AS STATUS",
                " one.LIQUIDATION_PAYMENT_FORM l",
                " 1=1 ");

            /*
              public.ins_core_liquidacion_forma_pago_carga(
    _id_liquidacion_forma_pago integer,
    _id_liquidacion_cabeza integer,
    _tipo_pago_liquidacion_forma_pago integer,
    _tipo_movimiento integer,
    _id_bancos integer,
    _nombre_banco_liquidacion_forma_pago character varying,
    _numero_cuenta_liquidacion_forma_pago character varying,
    _valor_liquidacion_forma_pago numeric,
    _id_status integer*/


            int _id_liquidacion_forma_pago;
            int _id_liquidacion_cabeza;
            int _tipo_pago_liquidacion_forma_pago;
            int _tipo_movimiento;
            int _id_bancos;
            string _nombre_banco_liquidacion_forma_pago;
            string _numero_cuenta_liquidacion_forma_pago;
            double _valor_liquidacion_forma_pago;
            int _id_status;


            int reg = dtLiquidacionFormaPago.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtLiquidacionFormaPago.Rows)
                {
                    _leidos++;



                    _id_liquidacion_forma_pago = Convert.ToInt32(renglon["LIQUIDATION_PAYMENT_FORM_ID"].ToString());
                    _id_liquidacion_cabeza = Convert.ToInt32(renglon["LIQUIDATION_ID"].ToString());
                    _tipo_pago_liquidacion_forma_pago = Convert.ToInt32(renglon["PAYMENT_TYPE"].ToString());
                    _tipo_movimiento = Convert.ToInt32(renglon["MOVEMENT_TYPE"].ToString());
                    _id_bancos = 0;
                    if (renglon["BANK_ID"].ToString() != "")
                    {

                        if (renglon["BANK_ID"].ToString() == "BG" || renglon["BANK_ID"].ToString() == "BGR" || renglon["BANK_ID"].ToString() == "BP" || renglon["BANK_ID"].ToString() == "BPI" || renglon["BANK_ID"].ToString() == "PR" || renglon["BANK_ID"].ToString() == "PRODU")
                        {
                            switch (renglon["BANK_ID"].ToString())
                            {
                                case "BG":
                                    _id_bancos = 1020;
                                    break;
                                case "BGR":
                                    _id_bancos = 1020;
                                    break;
                                case "BP":
                                    _id_bancos = 1029;
                                    break;
                                case "BPI":
                                    _id_bancos = 1029;
                                    break;
                                case "PR":
                                    _id_bancos = 1033;
                                    break;
                                case "PRODU":
                                    _id_bancos = 1033;
                                    break;
                            }


                        }
                        else
                        {
                            _id_bancos = Convert.ToInt32(renglon["BANK_ID"].ToString());
                        }


                    }
                    else
                    {
                        _id_bancos = 0;
                    }

                    _nombre_banco_liquidacion_forma_pago = Convert.ToString(renglon["BANK_NAME"].ToString());
                    _numero_cuenta_liquidacion_forma_pago = Convert.ToString(renglon["NUMBER_ACCOUNT"].ToString());
                    _valor_liquidacion_forma_pago = Convert.ToDouble(renglon["VALUE"].ToString());
                    _id_status = Convert.ToInt32(renglon["STATUS"].ToString());

                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE TIPO LIQUIDACION  DETALLE -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_liquidacion_forma_pago_carga(_id_liquidacion_forma_pago, _id_liquidacion_cabeza, _tipo_pago_liquidacion_forma_pago, _tipo_movimiento, _id_bancos, _nombre_banco_liquidacion_forma_pago, _numero_cuenta_liquidacion_forma_pago, _valor_liquidacion_forma_pago, _id_status);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_liquidacion_forma_pago_carga(int _id_liquidacion_forma_pago,
                                                                    int _id_liquidacion_cabeza,
                                                                    int _tipo_pago_liquidacion_forma_pago,
                                                                    int _tipo_movimiento,
                                                                    int _id_bancos,
                                                                    string _nombre_banco_liquidacion_forma_pago,
                                                                    string _numero_cuenta_liquidacion_forma_pago,
                                                                    double _valor_liquidacion_forma_pago,
                                                                    int _id_status)
        {


            string cadena1 = _id_liquidacion_forma_pago + "?" + _id_liquidacion_cabeza + "?" + _tipo_pago_liquidacion_forma_pago + "?" + _tipo_movimiento + "?" + _id_bancos + "?" + _nombre_banco_liquidacion_forma_pago + "?" + _numero_cuenta_liquidacion_forma_pago + "?" + _valor_liquidacion_forma_pago + "?" + _id_status;
            string cadena2 = "_id_liquidacion_forma_pago?_id_liquidacion_cabeza?_tipo_pago_liquidacion_forma_pago?_tipo_movimiento?_id_bancos?_nombre_banco_liquidacion_forma_pago?_numero_cuenta_liquidacion_forma_pago?_valor_liquidacion_forma_pago?_id_status";

            string cadena3 = "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Int";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_liquidacion_forma_pago_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  FORMAS DE PAGO LIQUIDACIONES ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  LIQUIDACIONES FORMA DE PAGO" + Ex.Message);
                //   string cadena5 = "_error_errores_importacion";
                //   string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }





        ///DESCUENTOS
        ///


        public static void cargar_core_descuentos_formatos_carga()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  LIQUIDACION FORMA PAGO   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtDescuentos = AccesoLogicaSQL.Select("ID, " +
                "ID_ENTIDAD_PATRONAL, " +
                "NOMBRE, " +
                "SP, " +
                "PARAMETRO1, " +
                "PARAMETRO2, " +
                "PARAMETRO3, " +
                "ENTRADA ",
                " one.DESCUENTOS_FORMATOS",
                " 1=1 ");

            /*
               public.ins_core_descuentos_formatos_carga(
    _id_descuentos_formatos integer,
    _id_entidad_patronal integer,
    _nombre_descuentos_formatos character varying,
    _sp_descuentos_formatos character varying,
    _parametro_uno_descuentos_formatos character varying,
    _parametro_dos_descuentos_formatos character varying,
    _parametro_tres_descuentos_formatos character varying,
    _entrada_descuentos_formatos boolean)*/


            int _id_descuentos_formatos;
            int _id_entidad_patronal;
            string _nombre_descuentos_formatos;
            string _sp_descuentos_formatos;
            string _parametro_uno_descuentos_formatos;
            string _parametro_dos_descuentos_formatos;
            string _parametro_tres_descuentos_formatos;
            bool _entrada_descuentos_formatos;


            int reg = dtDescuentos.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;

                    _id_descuentos_formatos = Convert.ToInt32(renglon["ID"].ToString());
                    _id_entidad_patronal = Convert.ToInt32(renglon["ID_ENTIDAD_PATRONAL"].ToString());
                    _nombre_descuentos_formatos = Convert.ToString(renglon["NOMBRE"].ToString());
                    _sp_descuentos_formatos = Convert.ToString(renglon["SP"].ToString());
                    _parametro_uno_descuentos_formatos = Convert.ToString(renglon["PARAMETRO1"].ToString());
                    _parametro_dos_descuentos_formatos = Convert.ToString(renglon["PARAMETRO2"].ToString());
                    _parametro_tres_descuentos_formatos = Convert.ToString(renglon["PARAMETRO3"].ToString());
                    _entrada_descuentos_formatos = Convert.ToBoolean(renglon["ENTRADA"].ToString());


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE TIPO LIQUIDACION  DETALLE -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_descuentos_formatos_carga(_id_descuentos_formatos, _id_entidad_patronal, _nombre_descuentos_formatos, _sp_descuentos_formatos, _parametro_uno_descuentos_formatos, _parametro_dos_descuentos_formatos, _parametro_tres_descuentos_formatos, _entrada_descuentos_formatos);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_descuentos_formatos_carga(
                                        int _id_descuentos_formatos,
                                        int _id_entidad_patronal,
                                        string _nombre_descuentos_formatos,
                                        string _sp_descuentos_formatos,
                                        string _parametro_uno_descuentos_formatos,
                                        string _parametro_dos_descuentos_formatos,
                                        string _parametro_tres_descuentos_formatos,
                                        bool _entrada_descuentos_formatos)
        {


            string cadena1 = _id_descuentos_formatos + "?" + _id_entidad_patronal + "?" + _nombre_descuentos_formatos + "?" + _sp_descuentos_formatos + "?" + _parametro_uno_descuentos_formatos + "?" + _parametro_dos_descuentos_formatos + "?" + _parametro_tres_descuentos_formatos + "?" + _entrada_descuentos_formatos;
            string cadena2 = "_id_descuentos_formatos?_id_entidad_patronal?_nombre_descuentos_formatos?_sp_descuentos_formatos?_parametro_uno_descuentos_formatos?_parametro_dos_descuentos_formatos?_parametro_tres_descuentos_formatos?_entrada_descuentos_formatos";

            string cadena3 = "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Boolean";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_descuentos_formatos_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  DESCUENTOS FORMAS DE PAGO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  DESCUENTOS FORMAS DE PAGO" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }






        public static void cargar_core_descuentos_registrados_cabeza_carga()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  DESCUENTOS REGISTRADOS CABEZA   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtDescuentos = AccesoLogicaSQL.Select("DESCUENTOS_REGISTRADOS_ID, " +
                "ID_ENTIDAD_PATRONAL, " +
                "ANIO, " +
                "MES, " +
                "USUARIO, " +
                "FECHA, " +
                "ARCHIVO, " +
                "ID_FORMATO, " +
                "PROCESADO, " +
                "ERROR, " +
                "TIPO_CREDITO, OBSERVATION, " +
                "proccess_server",
                " one.DESCUENTOS_REGISTRADOS",
                " 1=1 ORDER BY DESCUENTOS_REGISTRADOS_ID ASC ");

            /*
              
            public.ins_core_descuentos_registrados_cabeza_carga(
    _id_descuentos_registrados_cabeza integer,
    _id_entidad_patronal integer,
    _year_descuentos_registrados_cabeza integer,
    _mes_descuentos_registrados_cabeza integer,
    _usuario_descuentos_registrados_cabeza character varying,
    _id_usuarios integer,
    _fecha_descuentos_registrados_cabeza timestamp with time zone,
    _nombre_archivo_descuentos_registrados_cabeza character varying,
    _id_descuentos_formatos integer,
    _procesado_descuentos_registrados_cabeza boolean,
    _erro_descuentos_registrados_cabeza boolean,
    _tipo_credito integer,
    _observacion_descuentos_registrados_cabeza integer,
    _fecha_proceso_descuentos_registrados_cabeza timestamp with time zone)
             
             
             */


            int _id_descuentos_registrados_cabeza;
            int _id_entidad_patronal;
            int _year_descuentos_registrados_cabeza;
            int _mes_descuentos_registrados_cabeza;
            string _usuario_descuentos_registrados_cabeza;
            int _id_usuarios;
            DateTime _fecha_descuentos_registrados_cabeza;
            string _nombre_archivo_descuentos_registrados_cabeza;
            int _id_descuentos_formatos;
            bool _procesado_descuentos_registrados_cabeza;
            bool _erro_descuentos_registrados_cabeza;
            int _tipo_credito;
            string _observacion_descuentos_registrados_cabeza;
            DateTime _fecha_proceso_descuentos_registrados_cabeza;

            int reg = dtDescuentos.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;

                    _id_descuentos_registrados_cabeza = Convert.ToInt32(renglon["DESCUENTOS_REGISTRADOS_ID"].ToString());

                    if (renglon["ID_ENTIDAD_PATRONAL"].ToString() == "-1")
                    {
                        _id_entidad_patronal = 999;
                    }
                    else
                    {
                        _id_entidad_patronal = Convert.ToInt32(renglon["ID_ENTIDAD_PATRONAL"].ToString());

                    }

                    
                    
                    _year_descuentos_registrados_cabeza = Convert.ToInt32(renglon["ANIO"].ToString());
                    _mes_descuentos_registrados_cabeza = Convert.ToInt32(renglon["MES"].ToString());
                    _usuario_descuentos_registrados_cabeza = Convert.ToString(renglon["USUARIO"].ToString());
                    _id_usuarios = 34; // Convert.ToInt32(renglon["ID"].ToString());
                    _fecha_descuentos_registrados_cabeza = Convert.ToDateTime(renglon["FECHA"].ToString());
                    _nombre_archivo_descuentos_registrados_cabeza = Convert.ToString(renglon["ARCHIVO"].ToString());
                    _id_descuentos_formatos = Convert.ToInt32(renglon["ID_FORMATO"].ToString());
                    _procesado_descuentos_registrados_cabeza = Convert.ToBoolean(renglon["PROCESADO"].ToString());
                    _erro_descuentos_registrados_cabeza = Convert.ToBoolean(renglon["ERROR"].ToString());
                    if (renglon["TIPO_CREDITO"].ToString() != "")
                    {
                        _tipo_credito = Convert.ToInt32(renglon["TIPO_CREDITO"].ToString());
                    }
                    else
                    {
                        _tipo_credito = 0;
                    }
                    
                    _observacion_descuentos_registrados_cabeza = Convert.ToString(renglon["OBSERVATION"].ToString());
                    _fecha_proceso_descuentos_registrados_cabeza = Convert.ToDateTime(renglon["proccess_server"].ToString());



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_descuentos_registrados_cabeza_carga(_id_descuentos_registrados_cabeza, _id_entidad_patronal, _year_descuentos_registrados_cabeza, _mes_descuentos_registrados_cabeza, _usuario_descuentos_registrados_cabeza, _id_usuarios, _fecha_descuentos_registrados_cabeza, _nombre_archivo_descuentos_registrados_cabeza, _id_descuentos_formatos, _procesado_descuentos_registrados_cabeza, _erro_descuentos_registrados_cabeza, _tipo_credito, _observacion_descuentos_registrados_cabeza, _fecha_proceso_descuentos_registrados_cabeza);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_descuentos_registrados_cabeza_carga(int _id_descuentos_registrados_cabeza,
            int _id_entidad_patronal,
            int _year_descuentos_registrados_cabeza,
            int _mes_descuentos_registrados_cabeza,
            string _usuario_descuentos_registrados_cabeza,
            int _id_usuarios,
            DateTime _fecha_descuentos_registrados_cabeza,
            string _nombre_archivo_descuentos_registrados_cabeza,
            int _id_descuentos_formatos,
            bool _procesado_descuentos_registrados_cabeza, 
            bool _erro_descuentos_registrados_cabeza, 
            int _tipo_credito,  
            string _observacion_descuentos_registrados_cabeza,  
            DateTime _fecha_proceso_descuentos_registrados_cabeza)

        {

            
            string cadena1 = _id_descuentos_registrados_cabeza + "?"+_id_entidad_patronal + "?" + _year_descuentos_registrados_cabeza + "?" + _mes_descuentos_registrados_cabeza + "?" + _usuario_descuentos_registrados_cabeza + "?" + _id_usuarios + "?" + _fecha_descuentos_registrados_cabeza + "?" + _nombre_archivo_descuentos_registrados_cabeza + "?" + _id_descuentos_formatos + "?" + _procesado_descuentos_registrados_cabeza + "?" + _erro_descuentos_registrados_cabeza + "?" + _tipo_credito + "?" + _observacion_descuentos_registrados_cabeza + "?" + _fecha_proceso_descuentos_registrados_cabeza;
            string cadena2 = "_id_descuentos_registrados_cabeza?_id_entidad_patronal?_year_descuentos_registrados_cabeza?_mes_descuentos_registrados_cabeza?_usuario_descuentos_registrados_cabeza?_id_usuarios?_fecha_descuentos_registrados_cabeza?_nombre_archivo_descuentos_registrados_cabeza?_id_descuentos_formatos?_procesado_descuentos_registrados_cabeza?_erro_descuentos_registrados_cabeza?_tipo_credito?_observacion_descuentos_registrados_cabez?_fecha_proceso_descuentos_registrados_cabeza";

            string cadena3 = "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.TimestampTz?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Boolean?" +
                             "NpgsqlDbType.Boolean?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.TimestampTz";

            
            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_descuentos_registrados_cabeza_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  DESCUENTOS  CABEZA ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  DESCUENTOS CABEZA" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
             //    Console.Read();

            }

        }







        public static void cargar_core_descuentos_registrados_detalle_aportes()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  DESCUENTOS REGISTRADOS CABEZA   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtDescuentos = AccesoLogicaSQL.Select("DESCUENTOS_REGISTRADOS_ID," +
                "ID," +
                "ID_ENTIDAD_PATRONAL," +
                "ANIO," +
                "MES," +
                "ID_AFILIADO," +
                "APORTE_PERSONAL, " +
                "APORTE_PATRONAL," +
                "RMU," +
                "LIQUIDO," +
                "MULTAS," +
                "ANTIGUEDAD," +
                "ALTA," +
                "ID_FORMATO," +
                "PROCESADO," +
                "SALDO",
                " one.DESCUENTOS_REGISTRADOS_APORTE",
                " 1=1  ORDER BY ID ASC");

            /*
              public.ins_core_descuentos_registrados_detalle_aportes_carga(
    _id_descuentos_registrados_detalle_aportes bigint,
    _id_descuentos_registrados_cabeza integer
    _id_entidad_patronal integer,
    _year_descuentos_registrados_detalle_aportes integer,
    _mes_descuentos_registrados_detalle_aportes integer,
    _id_participes integer,
    _aporte_personal_descuentos_registrados_detalle_aportes numeric,
    _aporte_patronal_descuentos_registrados_detalle_aportes numeric,
    _rmu_descuentos_registrados_detalle_aportes numeric,
    _liquido_descuentos_registrados_detalle_aportes numeric,
    _multas_descuentos_registrados_detalle_aportes numeric,
    _antiguedad_descuentos_registrados_detalle_aportes numeric,
    _alta_descuentos_registrados_detalle_aportes boolean,
    _id_descuentos_formatos integer,
    _procesado_descuentos_registrados_detalle_aportes boolean,
    _saldo_descuentos_registrados_detalle_aportes numeric)
             */

            Int64 _id_descuentos_registrados_detalle_aportes;
            int _id_descuentos_registrados_cabeza;
            int _id_entidad_patronal;
            int _year_descuentos_registrados_detalle_aportes;
            int _mes_descuentos_registrados_detalle_aportes;
            int _id_participes;
            double _aporte_personal_descuentos_registrados_detalle_aportes;
            double _aporte_patronal_descuentos_registrados_detalle_aportes;
            double _rmu_descuentos_registrados_detalle_aportes;
            double _liquido_descuentos_registrados_detalle_aportes;
            double _multas_descuentos_registrados_detalle_aportes;
            double _antiguedad_descuentos_registrados_detalle_aportes;
            bool _alta_descuentos_registrados_detalle_aportes;
            int _id_descuentos_formatos;
            bool _procesado_descuentos_registrados_detalle_aportes;
            double _saldo_descuentos_registrados_detalle_aportes;
            

            int reg = dtDescuentos.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;
                    _id_descuentos_registrados_detalle_aportes                    = Convert.ToInt64(renglon["ID"].ToString());
                    _id_descuentos_registrados_cabeza                              = Convert.ToInt32(renglon["DESCUENTOS_REGISTRADOS_ID"].ToString());
                    _id_entidad_patronal                                            = Convert.ToInt32(renglon["ID_ENTIDAD_PATRONAL"].ToString()); 
                    _year_descuentos_registrados_detalle_aportes                    = Convert.ToInt32(renglon["ANIO"].ToString()); 
                    _mes_descuentos_registrados_detalle_aportes                     = Convert.ToInt32(renglon["MES"].ToString()); 
                    _id_participes                                                  = Convert.ToInt32(renglon["ID_AFILIADO"].ToString()); 
                    _aporte_personal_descuentos_registrados_detalle_aportes      = Convert.ToDouble(renglon["APORTE_PERSONAL"].ToString()); 
                    _aporte_patronal_descuentos_registrados_detalle_aportes      = Convert.ToDouble(renglon["APORTE_PATRONAL"].ToString()); 
                    _rmu_descuentos_registrados_detalle_aportes                  = Convert.ToDouble(renglon["RMU"].ToString());
                    _liquido_descuentos_registrados_detalle_aportes              = Convert.ToDouble(renglon["LIQUIDO"].ToString());
                    _multas_descuentos_registrados_detalle_aportes               = Convert.ToDouble(renglon["MULTAS"].ToString());
                    _antiguedad_descuentos_registrados_detalle_aportes           = Convert.ToDouble(renglon["ANTIGUEDAD"].ToString());
                    _alta_descuentos_registrados_detalle_aportes                   = Convert.ToBoolean(renglon["ALTA"].ToString()); 
                    _id_descuentos_formatos                                         = Convert.ToInt32(renglon["ID_FORMATO"].ToString());
                    _procesado_descuentos_registrados_detalle_aportes              = Convert.ToBoolean(renglon["PROCESADO"].ToString());
                    _saldo_descuentos_registrados_detalle_aportes                = Convert.ToDouble(renglon["SALDO"].ToString());
                    



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_descuentos_registrados_detalle_aportes_carga(_id_descuentos_registrados_detalle_aportes,
                                    _id_descuentos_registrados_cabeza,
                                    _id_entidad_patronal,
                                    _year_descuentos_registrados_detalle_aportes,
                                    _mes_descuentos_registrados_detalle_aportes,
                                    _id_participes,
                                    _aporte_personal_descuentos_registrados_detalle_aportes,
                                    _aporte_patronal_descuentos_registrados_detalle_aportes,
                                    _rmu_descuentos_registrados_detalle_aportes,
                                    _liquido_descuentos_registrados_detalle_aportes,
                                    _multas_descuentos_registrados_detalle_aportes,
                                    _antiguedad_descuentos_registrados_detalle_aportes,
                                    _alta_descuentos_registrados_detalle_aportes,
                                    _id_descuentos_formatos,
                                    _procesado_descuentos_registrados_detalle_aportes,
                                    _saldo_descuentos_registrados_detalle_aportes);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_descuentos_registrados_detalle_aportes_carga(
            Int64 _id_descuentos_registrados_detalle_aportes,
            int _id_descuentos_registrados_cabeza,
        int _id_entidad_patronal,
        int _year_descuentos_registrados_detalle_aportes,
        int _mes_descuentos_registrados_detalle_aportes,
        int _id_participes,
        double _aporte_personal_descuentos_registrados_detalle_aportes,
        double _aporte_patronal_descuentos_registrados_detalle_aportes,
        double _rmu_descuentos_registrados_detalle_aportes,
        double _liquido_descuentos_registrados_detalle_aportes,
        double _multas_descuentos_registrados_detalle_aportes,
        double _antiguedad_descuentos_registrados_detalle_aportes,
        bool _alta_descuentos_registrados_detalle_aportes,
        int _id_descuentos_formatos,
        bool _procesado_descuentos_registrados_detalle_aportes,
        double _saldo_descuentos_registrados_detalle_aportes)

        {


            string cadena1 = 
                _id_descuentos_registrados_detalle_aportes+"?"+
                _id_descuentos_registrados_cabeza + "?" +
                _id_entidad_patronal + "?" + 
                _year_descuentos_registrados_detalle_aportes + "?" + 
                _mes_descuentos_registrados_detalle_aportes+"?" + 
                _id_participes+ "?" + 
                _aporte_personal_descuentos_registrados_detalle_aportes+"?" + 
                _aporte_patronal_descuentos_registrados_detalle_aportes+"?" + 
                _rmu_descuentos_registrados_detalle_aportes+"?" + 
                _liquido_descuentos_registrados_detalle_aportes+"?" + 
                _multas_descuentos_registrados_detalle_aportes+"?" + 
                _antiguedad_descuentos_registrados_detalle_aportes+"?" + 
                _alta_descuentos_registrados_detalle_aportes+"?" + 
                _id_descuentos_formatos+"?" + 
                _procesado_descuentos_registrados_detalle_aportes+"?" + 
                _saldo_descuentos_registrados_detalle_aportes;

            string cadena2 = "_id_descuentos_registrados_detalle_aportes?" +
                "_id_descuentos_registrados_cabeza?" +
                "_id_entidad_patrona?" +
                "_year_descuentos_registrados_detalle_aportes?" +
                "_mes_descuentos_registrados_detalle_aportes?" +
                "_id_participes?" +
                "_aporte_personal_descuentos_registrados_detalle_aportes?" +
                "_aporte_patronal_descuentos_registrados_detalle_aportes?" +
                "_rmu_descuentos_registrados_detalle_aportes?" +
                "_liquido_descuentos_registrados_detalle_aportes?" +
                "_multas_descuentos_registrados_detalle_aportes?" +
                "_antiguedad_descuentos_registrados_detalle_aportes?" +
                "_alta_descuentos_registrados_detalle_aportes?" +
                "_id_descuentos_formatos?" +
                "_procesado_descuentos_registrados_detalle_aportes?" +
                "_saldo_descuentos_registrados_detalle_aportes";

            string cadena3 = "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Boolean?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Boolean?" +
                             "NpgsqlDbType.Numeric";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_descuentos_registrados_detalle_aportes_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  DESCUENTOS  DETALLE APORTES ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  DESCUENTOS DETALLE APORTES" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }





        public static void cargar_core_descuentos_registrados_detalle_contibucion()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  DESCUENTOS REGISTRADOS DETALLE CONTRIBUCION   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtDescuentos = AccesoLogicaSQL.Select("ID, DESCUENTOS_REGISTRADOS_APORTES_ID, CONTRIBUTION_ID",
                " one.DESCUENTOS_REGISTRADOS_CONTRIBUTION",
                " 1=1 ORDER BY ID ASC");

            /*
               public.ins_core_descuentos_registrados_detalle_contibucion_carga(
    _id_descuentos_registrados_detalle_contibucion bigint,
    _id_descuentos_registrados_detalle_aportes bigint,
    _id_contribucion bigint)
             */
            Int64 _id_descuentos_registrados_detalle_contibucion;
            Int64 _id_descuentos_registrados_detalle_aportes;
            Int64    _id_contribucion;


            int reg = dtDescuentos.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;
                    _id_descuentos_registrados_detalle_contibucion = Convert.ToInt64(renglon["ID"].ToString());
                    _id_descuentos_registrados_detalle_aportes = Convert.ToInt64(renglon["DESCUENTOS_REGISTRADOS_APORTES_ID"].ToString());
                    _id_contribucion = Convert.ToInt64(renglon["CONTRIBUTION_ID"].ToString());

                    


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_descuentos_registrados_detalle_contibucion_carga(
                                            _id_descuentos_registrados_detalle_contibucion,
                                            _id_descuentos_registrados_detalle_aportes,
                                            _id_contribucion);


                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_descuentos_registrados_detalle_contibucion_carga(Int64 _id_descuentos_registrados_detalle_contibucion, 
                                            Int64 _id_descuentos_registrados_detalle_aportes,
                                            Int64  _id_contribucion)
            
        {
            
            string cadena1 = _id_descuentos_registrados_detalle_contibucion + "?" + _id_descuentos_registrados_detalle_aportes + "?" + _id_contribucion;
            string cadena2 = "_id_descuentos_registrados_detalle_contibucion?_id_descuentos_registrados_detalle_aportes?_id_contribucion";

            string cadena3 = "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.BigInt";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_descuentos_registrados_detalle_contibucion_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  DESCUENTOS  DETALLE CONTRIBUCION ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  DESCUENTOS DETALLE CONTRIBUCION" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }

               

        public static void cargar_core_descuentos_registrados_detalle_creditos()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  DESCUENTOS REGISTRADOS DETALLE CREDITOS   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtDescuentos = AccesoLogicaSQL.Select("DESCUENTOS_REGISTRADOS_ID, " +
                "ID," +
                "ID_ENTIDAD_PATRONAL, " +
                "ANIO, " +
                "MES, " +
                "ID_TIPO_DESCUENTO, " +
                "ID_AFILIADO, " +
                "ID_CREDITO, " +
                "CUOTA," +
                "MONTO," +
                "PLAZO, " +
                "ALTA, " +
                "ID_FORMATO, " +
                "PROCESADO," +
                "SALDO, " +
                "MORA, " +
                "CREDIT_PAY_RESULT, " +
                "MES_DESCUENTO",
                " one.DESCUENTOS_REGISTRADOS_CREDITO",
                " 1=1 ORDER BY ID ASC");

            /*
               public.ins_core_descuentos_registrados_detalle_creditos_carga(
    _id_descuentos_registrados_detalle_creditos bigint,
    _id_descuentos_registrados_cabeza integer,
    _id_entidad_patronal integer,
    _year_descuentos_registrados_detalle_creditos integer,
    _mes_descuentos_registrados_detalle_creditos integer,
    _id_tipo_descuento integer,
    _id_participes integer,
    _id_creditos bigint,
    _cuota_descuentos_registrados_detalle_creditos numeric,
    _monto_descuentos_registrados_detalle_creditos numeric,
    _plazo_descuentos_registrados_detalle_creditos integer,
    _alta_descuentos_registrados_detalle_creditos boolean,
    _id_descuentos_formatos integer,
    _procesado_descuentos_registrados_detalle_creditos boolean,
    _saldo_descuentos_registrados_detalle_creditos numeric,
    _mora_descuentos_registrados_detalle_creditos numeric,
    _credito_pay_descuentos_registrados_detalle_creditos integer,
    _mes_desc_descuentos_registrados_detalle_creditos character varying
             */
            Int64 _id_descuentos_registrados_detalle_creditos;
            int _id_descuentos_registrados_cabeza;
            int _id_entidad_patronal;
            int _year_descuentos_registrados_detalle_creditos;
            int _mes_descuentos_registrados_detalle_creditos;
            int _id_tipo_descuento;
            int _id_participes;
            Int64 _id_creditos;
            double _cuota_descuentos_registrados_detalle_creditos;
            double _monto_descuentos_registrados_detalle_creditos;
            int _plazo_descuentos_registrados_detalle_creditos;
            bool _alta_descuentos_registrados_detalle_creditos;
            int _id_descuentos_formatos;
            bool _procesado_descuentos_registrados_detalle_creditos;
            double _saldo_descuentos_registrados_detalle_creditos;
            double _mora_descuentos_registrados_detalle_creditos;
            int _credito_pay_descuentos_registrados_detalle_creditos;
            string _mes_desc_descuentos_registrados_detalle_creditos;



            int reg = dtDescuentos.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;
                   
                    _id_descuentos_registrados_detalle_creditos           = Convert.ToInt64(renglon["ID"].ToString());
                    _id_descuentos_registrados_cabeza                       = Convert.ToInt32(renglon["DESCUENTOS_REGISTRADOS_ID"].ToString());
                    _id_entidad_patronal                                    = Convert.ToInt32(renglon["ID_ENTIDAD_PATRONAL"].ToString());
                    _year_descuentos_registrados_detalle_creditos           = Convert.ToInt32(renglon["ANIO"].ToString());
                    _mes_descuentos_registrados_detalle_creditos            = Convert.ToInt32(renglon["MES"].ToString());
                    if (renglon["ID_TIPO_DESCUENTO"].ToString() != "")
                    {
                        _id_tipo_descuento = Convert.ToInt32(renglon["ID_TIPO_DESCUENTO"].ToString());
                    }
                    else
                    {
                        _id_tipo_descuento = 0;
                    }
                    
                    _id_participes                                          = Convert.ToInt32(renglon["ID_AFILIADO"].ToString());
                    if (renglon["ID_CREDITO"].ToString() != "")
                    {
                        _id_creditos = Convert.ToInt64(renglon["ID_CREDITO"].ToString());
                    }
                    else
                    {
                        _id_creditos = 0;
                    }
                    
                    _cuota_descuentos_registrados_detalle_creditos       = Convert.ToDouble(renglon["CUOTA"].ToString());
                    _monto_descuentos_registrados_detalle_creditos       = Convert.ToDouble(renglon["MONTO"].ToString());
                    _plazo_descuentos_registrados_detalle_creditos          = Convert.ToInt32(renglon["PLAZO"].ToString());
                    _alta_descuentos_registrados_detalle_creditos          = Convert.ToBoolean(renglon["ALTA"].ToString());
                    _id_descuentos_formatos                                 = Convert.ToInt32(renglon["ID_FORMATO"].ToString());
                    _procesado_descuentos_registrados_detalle_creditos     = Convert.ToBoolean(renglon["PROCESADO"].ToString());
                    _saldo_descuentos_registrados_detalle_creditos       = Convert.ToDouble(renglon["SALDO"].ToString());
                    _mora_descuentos_registrados_detalle_creditos        = Convert.ToDouble(renglon["MORA"].ToString());
                    if (renglon["CREDIT_PAY_RESULT"].ToString() != "")
                    {
                        _credito_pay_descuentos_registrados_detalle_creditos = Convert.ToInt32(renglon["CREDIT_PAY_RESULT"].ToString());
                    }
                    else
                    {
                        _credito_pay_descuentos_registrados_detalle_creditos = 0;
                    }
                    
                    _mes_desc_descuentos_registrados_detalle_creditos    = Convert.ToString(renglon["MES_DESCUENTO"].ToString());
                    


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_descuentos_registrados_detalle_creditos_carga( _id_descuentos_registrados_detalle_creditos,
                                    _id_descuentos_registrados_cabeza,
                                    _id_entidad_patronal,
                                    _year_descuentos_registrados_detalle_creditos,
                                    _mes_descuentos_registrados_detalle_creditos,
                                    _id_tipo_descuento,
                                    _id_participes,
                                    _id_creditos,
                                    _cuota_descuentos_registrados_detalle_creditos,
                                    _monto_descuentos_registrados_detalle_creditos,
                                    _plazo_descuentos_registrados_detalle_creditos,
                                    _alta_descuentos_registrados_detalle_creditos,
                                    _id_descuentos_formatos,
                                    _procesado_descuentos_registrados_detalle_creditos,
                                    _saldo_descuentos_registrados_detalle_creditos,
                                    _mora_descuentos_registrados_detalle_creditos,
                                    _credito_pay_descuentos_registrados_detalle_creditos,
                                    _mes_desc_descuentos_registrados_detalle_creditos);


                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_descuentos_registrados_detalle_creditos_carga(Int64 _id_descuentos_registrados_detalle_creditos,
                                    int _id_descuentos_registrados_cabeza,
                                    int _id_entidad_patronal,
                                    int _year_descuentos_registrados_detalle_creditos,
                                    int _mes_descuentos_registrados_detalle_creditos,
                                    int _id_tipo_descuento,
                                    int _id_participes,
                                    Int64 _id_creditos,
                                    double _cuota_descuentos_registrados_detalle_creditos,
                                    double _monto_descuentos_registrados_detalle_creditos,
                                    int _plazo_descuentos_registrados_detalle_creditos,
                                    bool _alta_descuentos_registrados_detalle_creditos,
                                    int _id_descuentos_formatos,
                                    bool _procesado_descuentos_registrados_detalle_creditos,
                                    double _saldo_descuentos_registrados_detalle_creditos,
                                    double _mora_descuentos_registrados_detalle_creditos,
                                    int _credito_pay_descuentos_registrados_detalle_creditos,
                                    string _mes_desc_descuentos_registrados_detalle_creditos)


        {

            string cadena1 = _id_descuentos_registrados_detalle_creditos+"?"+
                                    _id_descuentos_registrados_cabeza + "?" +
                                    _id_entidad_patronal + "?" +
                                    _year_descuentos_registrados_detalle_creditos + "?" +
                                    _mes_descuentos_registrados_detalle_creditos + "?" +
                                    _id_tipo_descuento + "?" +
                                    _id_participes + "?" +
                                    _id_creditos + "?" +
                                    _cuota_descuentos_registrados_detalle_creditos + "?" +
                                    _monto_descuentos_registrados_detalle_creditos + "?" +
                                    _plazo_descuentos_registrados_detalle_creditos + "?" +
                                    _alta_descuentos_registrados_detalle_creditos + "?" +
                                    _id_descuentos_formatos + "?" +
                                    _procesado_descuentos_registrados_detalle_creditos + "?" +
                                    _saldo_descuentos_registrados_detalle_creditos + "?" +
                                    _mora_descuentos_registrados_detalle_creditos + "?" +
                                    _credito_pay_descuentos_registrados_detalle_creditos + "?" +
                                    _mes_desc_descuentos_registrados_detalle_creditos;
            string cadena2 = "_id_descuentos_registrados_detalle_creditos?" +
                "_id_descuentos_registrados_cabeza?" +
                "_id_entidad_patronal?" +
                "_year_descuentos_registrados_detalle_creditos?" +
                "_mes_descuentos_registrados_detalle_creditos?" +
                "_id_tipo_descuento?" +
                "_id_participes?" +
                "_id_creditos?" +
                "_cuota_descuentos_registrados_detalle_creditos?" +
                "_monto_descuentos_registrados_detalle_creditos?" +
                "_plazo_descuentos_registrados_detalle_creditos?" +
                "_alta_descuentos_registrados_detalle_creditos?" +
                "_id_descuentos_formatos?" +
                "_procesado_descuentos_registrados_detalle_creditos?" +
                "_saldo_descuentos_registrados_detalle_creditos?" +
                "_mora_descuentos_registrados_detalle_creditos?" +
                "_credito_pay_descuentos_registrados_detalle_creditos?" +
                "_mes_desc_descuentos_registrados_detalle_creditos";

            string cadena3 = "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Boolean?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Boolean?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_descuentos_registrados_detalle_creditos_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  DESCUENTOS  DETALLE CREDITOS ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  DESCUENTOS DETALLE CREDITOS" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                // Console.Read();

            }

        }






        public static void cargar_core_descuentos_registrados_detalle_creditos_trans()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  DESCUENTOS REGISTRADOS DETALLE CREDITOS TRANSACCIONES   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtDescuentos = AccesoLogicaSQL.Select("ID," +
                "DESCUENTOS_REGISTRADOS_CREDITO_ID, " +
                "CREDIT_TRANSACTION_ID, " +
                "VALOR_CUENTA_POR_PAGAR, " +
                "CREDIT_PAY_RESULT, " +
                "CXP_VCHRNMBR, " +
                "OBSERVATION" ,
                " one.DESCUENTOS_REGISTRADOS_CREDITO_TRANSACCION",
                " 1=1 ORDER BY ID ASC");

            /*
               public.ins_core_descuentos_registrados_detalle_creditos_trans_carga(
    _id_descuentos_registrados_detalle_creditos_trans bigint,
    _id_descuentos_registrados_detalle_creditos bigint,
    _id_transacciones bigint,
    _valor_cxp_descuentos_registrados_detalle_creditos_trans numeric,
    _credit_pay_descuentos_registrados_detalle_creditos_trans integer,
    _cxp_voucher_descuentos_registrados_detalle_creditos_trans character varying,
    _observacion_descuentos_registrados_detalle_creditos_trans character varying)
             */
            Int64 _id_descuentos_registrados_detalle_creditos_trans;
            Int64 _id_descuentos_registrados_detalle_creditos;
            Int64 _id_transacciones;
            double _valor_cxp_descuentos_registrados_detalle_creditos_trans;
            int _credit_pay_descuentos_registrados_detalle_creditos_trans;
            string _cxp_voucher_descuentos_registrados_detalle_creditos_trans;
            string _observacion_descuentos_registrados_detalle_creditos_trans;



            int reg = dtDescuentos.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;

                    _id_descuentos_registrados_detalle_creditos_trans         = Convert.ToInt64(renglon["ID"].ToString());
                    _id_descuentos_registrados_detalle_creditos               = Convert.ToInt64(renglon["ID"].ToString());
                    _id_transacciones                                         = Convert.ToInt64(renglon["ID"].ToString());
                    _valor_cxp_descuentos_registrados_detalle_creditos_trans = Convert.ToInt64(renglon["ID"].ToString());
                    _credit_pay_descuentos_registrados_detalle_creditos_trans   = Convert.ToInt32(renglon["ID"].ToString());
                    _cxp_voucher_descuentos_registrados_detalle_creditos_trans =  Convert.ToString(renglon["ID"].ToString());
                    _observacion_descuentos_registrados_detalle_creditos_trans  = Convert.ToString(renglon["ID"].ToString());

                    


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_descuentos_registrados_detalle_creditos_trans_carga(_id_descuentos_registrados_detalle_creditos_trans,
                    _id_descuentos_registrados_detalle_creditos,
                    _id_transacciones,
                    _valor_cxp_descuentos_registrados_detalle_creditos_trans,
                    _credit_pay_descuentos_registrados_detalle_creditos_trans,
                    _cxp_voucher_descuentos_registrados_detalle_creditos_trans,
                    _observacion_descuentos_registrados_detalle_creditos_trans);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_descuentos_registrados_detalle_creditos_trans_carga(Int64 _id_descuentos_registrados_detalle_creditos_trans,
                    Int64 _id_descuentos_registrados_detalle_creditos,
                    Int64 _id_transacciones,
                    double _valor_cxp_descuentos_registrados_detalle_creditos_trans,
                    int _credit_pay_descuentos_registrados_detalle_creditos_trans,
                    string _cxp_voucher_descuentos_registrados_detalle_creditos_trans,
                    string _observacion_descuentos_registrados_detalle_creditos_trans)


        {

            string cadena1 = _id_descuentos_registrados_detalle_creditos_trans+"?"+
                    _id_descuentos_registrados_detalle_creditos + "?" +
                    _id_transacciones + "?" +
                    _valor_cxp_descuentos_registrados_detalle_creditos_trans + "?" +
                    _credit_pay_descuentos_registrados_detalle_creditos_trans + "?" +
                    _cxp_voucher_descuentos_registrados_detalle_creditos_trans + "?" +
                    _observacion_descuentos_registrados_detalle_creditos_trans;

            string cadena2 = "_id_descuentos_registrados_detalle_creditos_trans?" +
                "_id_descuentos_registrados_detalle_creditos?" +
                "_id_transacciones?" +
                "_valor_cxp_descuentos_registrados_detalle_creditos_trans?" +
                "_credit_pay_descuentos_registrados_detalle_creditos_trans?" +
                "_cxp_voucher_descuentos_registrados_detalle_creditos_trans?" +
                "_observacion_descuentos_registrados_detalle_creditos_trans";

            string cadena3 = "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.BigInt?" +
                             "NpgsqlDbType.Numeric?" +
                             "NpgsqlDbType.Int?" +
                             "NpgsqlDbType.Varchar?" +
                             "NpgsqlDbType.Varchar";
            

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_descuentos_registrados_detalle_creditos_trans_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  DESCUENTOS  DETALLE CREDITOS TRANSACCIONES ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  DESCUENTOS DETALLE CREDITOS TRANSACCIONES" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
               //  Console.Read();

            }

        }




        public static void carga_core_superavit_pagos()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  SUPERAVIT PAGOS   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtSuperavit = AccesoLogicaSQL.Select("[SURPLUS_PAYMENT_ID], " +
                "[PARTNER_ID]," +
                "[TYPE_SURPLUS_PAYMENT_ID]," +
                "[SUPERAVIT_PAYMENT_FORM_ID], " +
                "[YEAR_PAY]," +
                "[SURPLUS_PERSONAL_CTAIND], " +
                "[SURPLUS_PATRONAL_CTAIND]," +
                "[SURPLUS_PERSONAL_CXPDF]," +
                "[SURPLUS_PATRONAL_CXPDF], " +
                "[IR_PER_COBRADO_CTAIND], " +
                "[IR_PAT_COBRADO_CTAIND], " +
                "[IR_PER_COBRADO_CXPDF], " +
                "[IR_PAT_COBRADO_CXPDF], " +
                "[IR_PER_CALCULADO_CTAIND], " +
                "[IR_PAT_CALCULADO_CTAIND], " +
                "[IR_PER_CALCULADO_CXPDF], " +
                "[IR_PAT_CALCULADO_CXPDF], " +
                "[VALUE_TO_PAY], " +
                "[OBSERVATION], " +
                "[USER_NAME], " +
                "[DATE_ENTRANCE], " +
                "[DATE_ACCOUNT], " +
                "[JOURNAL], " +
                "[JOURNAL_ORIGIN], " +
                "[STATE], " +
                "[STATUS], " +
                "[USER_PAID]",
                "one.SURPLUS_PAYMENT",
                " 1=1 ORDER BY SURPLUS_PAYMENT_ID ASC");

            /*
              public.ins_core_superavit_pagos_carga(
    _id_superavit_pagos bigint,
    _id_participes integer,
    _tipo_superavit_pagos integer,
    _form_superavit_pagos integer,
    _year_superavit_pagos integer,
    _ctaind_personal_superavit_pagos numeric,
    _ctaind_patronal_superavit_pagos numeric,
    _cxpdf_personal_superavit_pagos numeric,
    _cxpdf_patronal_superavit_pagos numeric,
    _ir_personal_cobrado_ctaind_superavit_pagos numeric,
    _ir_patronal_cobrado_ctaind_superavit_pagos numeric,
    _ir_personal_cobrado_cxpdf_superavit_pagos numeric,
    _ir_patronal_cobrado_cxpdf_superavit_pagos numeric,
    _ir_personal_calculado_ctaind_superavit_pagos numeric,
    _ir_patronal_calculado_ctaind_superavit_pagos numeric,
    _ir_personal_calculado_cxpdf_superavit_pagos numeric,
    _ir_patronal_calculado_cxpdf_superavit_pagos numeric,
    _valor_pagar_superavit_pagos numeric,
    _observacion_superavit_pagos character varying,
    _usuario__superavit_pagos character varying,
    _fecha_entrada_superavit_pagos timestamp with time zone,
    _fecha_cuenta_superavit_pagos timestamp with time zone,
    _diario_superavit_pagos integer,
    _diario_origen_superavit_pagos integer,
    _id_superavit_estados integer,
    _id_estatus integer,
    _usuario_paga_superavit_pagos character varying)
             */
            Int64 _id_superavit_pagos;
            Int64 _id_participes;
            int _tipo_superavit_pagos;
            int _form_superavit_pagos;
            int _year_superavit_pagos;
            double _ctaind_personal_superavit_pagos;
            double _ctaind_patronal_superavit_pagos;
            double _cxpdf_personal_superavit_pagos;
            double _cxpdf_patronal_superavit_pagos;
            double _ir_personal_cobrado_ctaind_superavit_pagos;
            double _ir_patronal_cobrado_ctaind_superavit_pagos;
            double _ir_personal_cobrado_cxpdf_superavit_pagos;
            double _ir_patronal_cobrado_cxpdf_superavit_pagos;
            double _ir_personal_calculado_ctaind_superavit_pagos;
            double _ir_patronal_calculado_ctaind_superavit_pagos;
            double _ir_personal_calculado_cxpdf_superavit_pagos;
            double _ir_patronal_calculado_cxpdf_superavit_pagos;
            double _valor_pagar_superavit_pagos;
            string _observacion_superavit_pagos;
            string _usuario__superavit_pagos;
            DateTime _fecha_entrada_superavit_pagos;
            DateTime _fecha_cuenta_superavit_pagos;
            int _diario_superavit_pagos;
            int _diario_origen_superavit_pagos;
            int _id_superavit_estados;
            int _id_estatus;
            string _usuario_paga_superavit_pagos;



            int reg = dtSuperavit.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtSuperavit.Rows)
                {
                    _leidos++;


                    _id_superavit_pagos                               =  Convert.ToInt64(renglon["SURPLUS_PAYMENT_ID"].ToString());
                    _id_participes                                    = Convert.ToInt64(renglon["PARTNER_ID"].ToString());
                    _tipo_superavit_pagos                               = Convert.ToInt32(renglon["TYPE_SURPLUS_PAYMENT_ID"].ToString());
                    if (renglon["SUPERAVIT_PAYMENT_FORM_ID"].ToString() != "")
                    {
                        _form_superavit_pagos = Convert.ToInt32(renglon["SUPERAVIT_PAYMENT_FORM_ID"].ToString());
                    }
                    else
                    {
                        _form_superavit_pagos = 0;
                    }
                    
                    _year_superavit_pagos                               = Convert.ToInt32(renglon["YEAR_PAY"].ToString());
                    _ctaind_personal_superavit_pagos                 = Convert.ToDouble(renglon["SURPLUS_PERSONAL_CTAIND"].ToString());
                    _ctaind_patronal_superavit_pagos                 = Convert.ToDouble(renglon["SURPLUS_PATRONAL_CTAIND"].ToString());
                    _cxpdf_personal_superavit_pagos                  = Convert.ToDouble(renglon["SURPLUS_PERSONAL_CXPDF"].ToString());
                    _cxpdf_patronal_superavit_pagos                  = Convert.ToDouble(renglon["SURPLUS_PATRONAL_CXPDF"].ToString());
                    _ir_personal_cobrado_ctaind_superavit_pagos      = Convert.ToDouble(renglon["IR_PER_COBRADO_CTAIND"].ToString());
                    _ir_patronal_cobrado_ctaind_superavit_pagos      = Convert.ToDouble(renglon["IR_PAT_COBRADO_CTAIND"].ToString());
                    _ir_personal_cobrado_cxpdf_superavit_pagos       = Convert.ToDouble(renglon["IR_PER_COBRADO_CXPDF"].ToString());

                    if (renglon["IR_PAT_COBRADO_CXPDF"].ToString() != "")
                    {
                        _ir_patronal_cobrado_cxpdf_superavit_pagos = Convert.ToDouble(renglon["IR_PAT_COBRADO_CXPDF"].ToString());
                    }
                    else
                    {
                        _ir_patronal_cobrado_cxpdf_superavit_pagos = 0;
                    }
                    
                    
                    _ir_personal_calculado_ctaind_superavit_pagos    = Convert.ToDouble(renglon["IR_PER_CALCULADO_CTAIND"].ToString());
                    _ir_patronal_calculado_ctaind_superavit_pagos    = Convert.ToDouble(renglon["IR_PAT_CALCULADO_CTAIND"].ToString());
                    _ir_personal_calculado_cxpdf_superavit_pagos     = Convert.ToDouble(renglon["IR_PER_CALCULADO_CXPDF"].ToString());
                    _ir_patronal_calculado_cxpdf_superavit_pagos     = Convert.ToDouble(renglon["IR_PAT_CALCULADO_CXPDF"].ToString());
                    _valor_pagar_superavit_pagos                     = Convert.ToDouble(renglon["VALUE_TO_PAY"].ToString());
                    _observacion_superavit_pagos                     = Convert.ToString(renglon["OBSERVATION"].ToString());
                    _usuario__superavit_pagos                        = Convert.ToString(renglon["USER_NAME"].ToString());

                    
                    if (renglon["DATE_ENTRANCE"].ToString() != "")
                    {
                        _fecha_entrada_superavit_pagos = Convert.ToDateTime(renglon["DATE_ENTRANCE"].ToString());
                    }
                    else
                    {
                        _fecha_entrada_superavit_pagos = Convert.ToDateTime("01-01-1900");
                    }

                    if (renglon["DATE_ACCOUNT"].ToString() != "")
                    {
                        _fecha_cuenta_superavit_pagos = Convert.ToDateTime(renglon["DATE_ACCOUNT"].ToString());
                    }
                    else
                    {
                        _fecha_cuenta_superavit_pagos = Convert.ToDateTime("01-01-1900");
                    }
                    if (renglon["JOURNAL"].ToString() != "")
                    {
                        _diario_superavit_pagos = Convert.ToInt32(renglon["JOURNAL"].ToString());
                    }
                    else
                    {
                        _diario_superavit_pagos = 0;
                    }

                    if (renglon["JOURNAL_ORIGIN"].ToString() != "")
                    {
                        _diario_origen_superavit_pagos = Convert.ToInt32(renglon["JOURNAL_ORIGIN"].ToString());
                    }
                    else
                    {
                        _diario_origen_superavit_pagos = 0;
                    }
                    
                    _id_superavit_estados                               = Convert.ToInt32(renglon["STATE"].ToString());

                    

                    if (renglon["STATUS"].ToString() == "0")
                    {
                        _id_estatus = 2;
                    }
                    else
                    {
                        _id_estatus = 1;
                    }

                    _usuario_paga_superavit_pagos = Convert.ToString(renglon["USER_PAID"].ToString());


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_superavit_pagos_carga(_id_superavit_pagos,
                    _id_participes,
                    _tipo_superavit_pagos,
                    _form_superavit_pagos,
                    _year_superavit_pagos,
                    _ctaind_personal_superavit_pagos,
                    _ctaind_patronal_superavit_pagos,
                    _cxpdf_personal_superavit_pagos,
                    _cxpdf_patronal_superavit_pagos,
                    _ir_personal_cobrado_ctaind_superavit_pagos,
                    _ir_patronal_cobrado_ctaind_superavit_pagos,
                    _ir_personal_cobrado_cxpdf_superavit_pagos,
                    _ir_patronal_cobrado_cxpdf_superavit_pagos,
                    _ir_personal_calculado_ctaind_superavit_pagos,
                    _ir_patronal_calculado_ctaind_superavit_pagos,
                    _ir_personal_calculado_cxpdf_superavit_pagos,
                    _ir_patronal_calculado_cxpdf_superavit_pagos,
                    _valor_pagar_superavit_pagos,
                    _observacion_superavit_pagos,
                    _usuario__superavit_pagos,
                    _fecha_entrada_superavit_pagos,
                    _fecha_cuenta_superavit_pagos,
                    _diario_superavit_pagos,
                    _diario_origen_superavit_pagos,
                    _id_superavit_estados,
                    _id_estatus,
                    _usuario_paga_superavit_pagos);



                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_superavit_pagos_carga(
                        Int64 _id_superavit_pagos,
                        Int64 _id_participes,
                        int _tipo_superavit_pagos,
                        int _form_superavit_pagos,
                        int _year_superavit_pagos,
                        double _ctaind_personal_superavit_pagos,
                        double _ctaind_patronal_superavit_pagos,
                        double _cxpdf_personal_superavit_pagos,
                        double _cxpdf_patronal_superavit_pagos,
                        double _ir_personal_cobrado_ctaind_superavit_pagos,
                        double _ir_patronal_cobrado_ctaind_superavit_pagos,
                        double _ir_personal_cobrado_cxpdf_superavit_pagos,
                        double _ir_patronal_cobrado_cxpdf_superavit_pagos,
                        double _ir_personal_calculado_ctaind_superavit_pagos,
                        double _ir_patronal_calculado_ctaind_superavit_pagos,
                        double _ir_personal_calculado_cxpdf_superavit_pagos,
                        double _ir_patronal_calculado_cxpdf_superavit_pagos,
                        double _valor_pagar_superavit_pagos,
                        string _observacion_superavit_pagos,
                        string _usuario__superavit_pagos,
                        DateTime _fecha_entrada_superavit_pagos,
                        DateTime _fecha_cuenta_superavit_pagos,
                        int _diario_superavit_pagos,
                        int _diario_origen_superavit_pagos,
                        int _id_superavit_estados,
                        int _id_estatus,
                        string _usuario_paga_superavit_pagos)


        {

            string cadena1 = _id_superavit_pagos+"?"+
                            _id_participes + "?" +
                            _tipo_superavit_pagos + "?" +
                            _form_superavit_pagos + "?" +
                            _year_superavit_pagos + "?" +
                            _ctaind_personal_superavit_pagos + "?" +
                            _ctaind_patronal_superavit_pagos + "?" +
                            _cxpdf_personal_superavit_pagos + "?" +
                            _cxpdf_patronal_superavit_pagos + "?" +
                            _ir_personal_cobrado_ctaind_superavit_pagos + "?" +
                            _ir_patronal_cobrado_ctaind_superavit_pagos + "?" +
                            _ir_personal_cobrado_cxpdf_superavit_pagos + "?" +
                            _ir_patronal_cobrado_cxpdf_superavit_pagos + "?" +
                            _ir_personal_calculado_ctaind_superavit_pagos + "?" +
                            _ir_patronal_calculado_ctaind_superavit_pagos + "?" +
                            _ir_personal_calculado_cxpdf_superavit_pagos + "?" +
                            _ir_patronal_calculado_cxpdf_superavit_pagos + "?" +
                            _valor_pagar_superavit_pagos + "?" +
                            _observacion_superavit_pagos + "?" +
                            _usuario__superavit_pagos + "?" +
                            _fecha_entrada_superavit_pagos + "?" +
                            _fecha_cuenta_superavit_pagos + "?" +
                            _diario_superavit_pagos + "?" +
                            _diario_origen_superavit_pagos + "?" +
                            _id_superavit_estados + "?" +
                            _id_estatus + "?" +
                            _usuario_paga_superavit_pagos;

            string cadena2 = "_id_superavit_pagos?" +
                "_id_participes?" +
                "_tipo_superavit_pagos?" +
                "_form_superavit_pagos?" +
                "_year_superavit_pagos?" +
                "_ctaind_personal_superavit_pagos?" +
                "_ctaind_patronal_superavit_pagos?" +
                "_cxpdf_personal_superavit_pagos?" +
                "_cxpdf_patronal_superavit_pagos?" +
                "_ir_personal_cobrado_ctaind_superavit_pagos?" +
                "_ir_patronal_cobrado_ctaind_superavit_pagos?" +
                "_ir_personal_cobrado_cxpdf_superavit_pagos?" +
                "_ir_patronal_cobrado_cxpdf_superavit_pagos?" +
                "_ir_personal_calculado_ctaind_superavit_pagos?" +
                "_ir_patronal_calculado_ctaind_superavit_pagos?" +
                "_ir_personal_calculado_cxpdf_superavit_pagos?" +
                "_ir_patronal_calculado_cxpdf_superavit_pagos?" +
                "_valor_pagar_superavit_pagos?" +
                "_observacion_superavit_pagos?" +
                "_usuario__superavit_pagos?" +
                "_fecha_entrada_superavit_pagos?" +
                "_fecha_cuenta_superavit_pagos?" +
                "_diario_superavit_pagos?" +
                "_diario_origen_superavit_pagos?" +
                "_id_superavit_estados?" +
                "_id_estatus?" +
                "_usuario_paga_superavit_pagos";

            string cadena3 = "NpgsqlDbType.Bigint?" +
                                "NpgsqlDbType.Bigint?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Numeric?" +
                                "NpgsqlDbType.Varchar?" +
                                "NpgsqlDbType.Varchar?" +
                                "NpgsqlDbType.TimestampTz?" +
                                "NpgsqlDbType.TimestampTz?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Integer?" +
                                "NpgsqlDbType.Varchar";
            

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_superavit_pagos_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  SUPERAVIT PAGOS ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  SUPERAVIT PAGOS" + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //  Console.Read();

            }

        }





        public static void carga_core_superavit_pagos_cuentas()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  SUPERAVIT PAGOS CUENTAS   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtSuperavit = AccesoLogicaSQL.Select("[SURPLUS_PAYMENT_ACCOUNT_ID] , " +
                "[PROCESS], " +
                "[ACCOUNTING_ACCOUNTS_INDEX], " +
                "[ORIENTATION], " +
                "[STATUS]",
                "one.SURPLUS_PAYMENT_ACCOUNT",
                " 1=1 ");

            /*
              public.ins_core_superavit_pagos_cuentas_carga(
    _id_superavit_pagos_cuentas integer,
    _proceso_superavit_pagos_cuentas character varying,
    _id_plan_cuentas integer,
    _cuenta_ant_superavit_pagos_cuentas integer,
    _naturaleza_superavit_pagos_cuentas character varying,
    _id_estatus integer)
             */
            int _id_superavit_pagos_cuentas;
            string _proceso_superavit_pagos_cuentas;
            int _id_plan_cuentas;
            int _cuenta_ant_superavit_pagos_cuentas;
            string _naturaleza_superavit_pagos_cuentas;
            int _id_estatus;



            int reg = dtSuperavit.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtSuperavit.Rows)
                {
                    _leidos++;

                    _id_superavit_pagos_cuentas                 = Convert.ToInt32(renglon["SURPLUS_PAYMENT_ACCOUNT_ID"].ToString());
                    _proceso_superavit_pagos_cuentas         = Convert.ToString(renglon["PROCESS"].ToString());;
                    _id_plan_cuentas = 588;
                    _cuenta_ant_superavit_pagos_cuentas         = Convert.ToInt32(renglon["ACCOUNTING_ACCOUNTS_INDEX"].ToString());
                    _naturaleza_superavit_pagos_cuentas      = Convert.ToString(renglon["ORIENTATION"].ToString());

                    if (renglon["STATUS"].ToString() == "0")
                    {
                        _id_estatus = 2;
                    }
                    else
                    {
                        _id_estatus = 1;
                    }



                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_superavit_pagos_cuentas_carga(_id_superavit_pagos_cuentas, 
                        _proceso_superavit_pagos_cuentas, 
                        _id_plan_cuentas, 
                        _cuenta_ant_superavit_pagos_cuentas, 
                        _naturaleza_superavit_pagos_cuentas, 
                        _id_estatus);


                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_superavit_pagos_cuentas_carga(int _id_superavit_pagos_cuentas,
                                string _proceso_superavit_pagos_cuentas,
                                int _id_plan_cuentas,
                                int _cuenta_ant_superavit_pagos_cuentas,
                                string _naturaleza_superavit_pagos_cuentas,
                                int _id_estatus)


        {

            string cadena1 = _id_superavit_pagos_cuentas+"?"+
                            _proceso_superavit_pagos_cuentas + "?" +
                            _id_plan_cuentas + "?" +
                            _cuenta_ant_superavit_pagos_cuentas + "?" +
                            _naturaleza_superavit_pagos_cuentas + "?" +
                            _id_estatus;

            string cadena2 = "_id_superavit_pagos_cuentas?" +
                "_proceso_superavit_pagos_cuentas?" +
                "_id_plan_cuentas?" +
                "_cuenta_ant_superavit_pagos_cuentas?" +
                "_naturaleza_superavit_pagos_cuentas?" +
                "_id_estatus";

            string cadena3 = "NpgsqlDbType.Int?" +
                              "NpgsqlDbType.Varchar?" +
                              "NpgsqlDbType.Int?" +
                              "NpgsqlDbType.Int?" +
                              "NpgsqlDbType.Varchar?" +
                              "NpgsqlDbType.Int";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_superavit_pagos_cuentas_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  SUPERAVIT PAGOS CUENTAS ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  SUPERAVIT PAGOS CUENTAS " + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                  Console.Read();

            }

        }



        

        public static void carga_core_superavit_pagos_credito()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  SUPERAVIT PAGOS CREDITOS   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtSuperavit = AccesoLogicaSQL.Select("SURPLUS_PAYMENT_CREDIT_ID, SURPLUS_PAYMENT_ID, CREDIT_TRANSACTION, STATE, STATUS ",
                "one.SURPLUS_PAYMENT_CREDIT",
                " 1=1 ");

            /*
              ins_core_superavit_pagos_credito_carga(
    _id_superavit_pagos_credito bigint,
    _id_superavit_pagos bigint,
    _id_transacciones bigint,
    _id_superavit_estados integer,
    _id_estatus integer)
    */

            Int64 _id_superavit_pagos_credito;
            Int64 _id_superavit_pagos;
            Int64 _id_transacciones;
            int _id_superavit_estados;
            int _id_estatus;
            

            int reg = dtSuperavit.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtSuperavit.Rows)
                {
                    _leidos++;

                    _id_superavit_pagos_credito           = Convert.ToInt64(renglon["SURPLUS_PAYMENT_CREDIT_ID"].ToString()); 
                    _id_superavit_pagos                   = Convert.ToInt64(renglon["SURPLUS_PAYMENT_ID"].ToString());
                    _id_transacciones                     = Convert.ToInt64(renglon["CREDIT_TRANSACTION"].ToString());
                    _id_superavit_estados                 = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_estatus                           = Convert.ToInt32(renglon["STATUS"].ToString());
                    
                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_superavit_pagos_credito_carga(_id_superavit_pagos_credito,
                                                           _id_superavit_pagos,
                                                           _id_transacciones,
                                                           _id_superavit_estados,
                                                           _id_estatus);


                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_superavit_pagos_credito_carga(Int64 _id_superavit_pagos_credito,
                                Int64 _id_superavit_pagos,
                                Int64 _id_transacciones,
                                int _id_superavit_estados,
                                int _id_estatus)


        {

            string cadena1 = _id_superavit_pagos_credito+"?"+
                             _id_superavit_pagos + "?" +
                             _id_transacciones + "?" +
                             _id_superavit_estados + "?" +
                             _id_estatus;

            string cadena2 = "_id_superavit_pagos_credito?" +
                "_id_superavit_pagos?" +
                "_id_transacciones?" +
                "_id_superavit_estados?" +
                "_id_estatus";

            string cadena3 = "NpgsqlDbType.Bigint?" +
                              "NpgsqlDbType.Bigint?" +
                              "NpgsqlDbType.Bigint?" +
                              "NpgsqlDbType.Int?" +
                              "NpgsqlDbType.Int";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_superavit_pagos_credito_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  SUPERAVIT PAGOS CREDITOS ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  SUPERAVIT PAGOS CREDITOS " + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //  Console.Read();

            }

        }






        public static void carga_core_superavit_pagos_trabajados()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("es-EC");
            // CultureInfo culture = CultureInfo.CurrentCulture;
            //Console.WriteLine("The current culture is {0} [{1}]", culture.NativeName, culture.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dtm = DateTime.Now;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEYENDO  SUPERAVIT PAGOS TRABAJADOS   ->" + dtm);
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            DataTable dtSuperavit = AccesoLogicaSQL.Select("[SURPLUS_PAYMENT_WORK_FLOW_ID], " +
                "[SURPLUS_PAYMENT_ID], " +
                "[DOCUMENT_NUMBER], " +
                "[HAS_CREDIT], " +
                "[CREDIT_CROSS]," +
                " [COMMENT], " +
                "[LAST_USER], " +
                "[STATE], " +
                "[DATE_PROCESS], " +
                "[DATE_CANCELLATION]",
                "one.SURPLUS_PAYMENT_WORK_FLOW",
                " 1=1 ");

            /*
              ins_core_superavit_pagos_trabajados_carga(
    _id_superavit_pagos_trabajados bigint,
    _id_superavit_pagos bigint,
    _documento_numero_superavit_pagos_trabajados character varying,
    _tiene_credito_superavit_pagos_trabajados boolean,
    _cruce_credito_superavit_pagos_trabajados boolean,
    _comentario_superavit_pagos_trabajados character varying,
    _ultimo_usuario_superavit_pagos_trabajados character varying,
    _id_superavit_estados integer,
    _fecha_proceso_superavit_pagos_trabajados timestamp with time zone,
    _fecha_cancelacion_superavit_pagos_trabajados timestamp with time zone)
    */

            Int64 _id_superavit_pagos_trabajados;
            Int64 _id_superavit_pagos;
            Int64 _documento_numero_superavit_pagos_trabajados;
            bool _tiene_credito_superavit_pagos_trabajados;
            bool _cruce_credito_superavit_pagos_trabajados;
            string _comentario_superavit_pagos_trabajados;
            string _ultimo_usuario_superavit_pagos_trabajados;
            int _id_superavit_estados;
            DateTime _fecha_proceso_superavit_pagos_trabajados;
            DateTime _fecha_cancelacion_superavit_pagos_trabajados;

            int reg = dtSuperavit.Rows.Count;

            int _leidos = 0;
            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtSuperavit.Rows)
                {
                    _leidos++;

                    _id_superavit_pagos_trabajados                    = Convert.ToInt64(renglon["SURPLUS_PAYMENT_WORK_FLOW_ID"].ToString()); 
                    _id_superavit_pagos                               = Convert.ToInt64(renglon["SURPLUS_PAYMENT_ID"].ToString());
                    _documento_numero_superavit_pagos_trabajados      = Convert.ToInt64(renglon["DOCUMENT_NUMBER"].ToString());

                    if (renglon["HAS_CREDIT"].ToString() != "")
                    {
                        _tiene_credito_superavit_pagos_trabajados = Convert.ToBoolean(renglon["HAS_CREDIT"].ToString());
                    }
                    else
                    {
                        _tiene_credito_superavit_pagos_trabajados = false;
                    }


                    if (renglon["HAS_CREDIT"].ToString() != "")
                    {
                        _cruce_credito_superavit_pagos_trabajados = Convert.ToBoolean(renglon["CREDIT_CROSS"].ToString());
                    }
                    else
                    {
                        _cruce_credito_superavit_pagos_trabajados = false;
                    }



                    

                    _comentario_superavit_pagos_trabajados           = Convert.ToString(renglon["COMMENT"].ToString());
                    _ultimo_usuario_superavit_pagos_trabajados       = Convert.ToString(renglon["LAST_USER"].ToString());
                    _id_superavit_estados                               = Convert.ToInt32(renglon["STATE"].ToString());
                    _fecha_proceso_superavit_pagos_trabajados      = Convert.ToDateTime(renglon["DATE_PROCESS"].ToString());

                    if (renglon["DATE_CANCELLATION"].ToString() != "")
                    {
                        _fecha_cancelacion_superavit_pagos_trabajados = Convert.ToDateTime(renglon["DATE_CANCELLATION"].ToString());
                    }
                    else
                    {
                        _fecha_cancelacion_superavit_pagos_trabajados = Convert.ToDateTime("01-01-1900");
                    }
                    


                    //  Console.WriteLine(_fecha_pago_prestaciones);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DE descuentos cabeza -> " + reg + " LEIDOS -> " + _leidos);

                    ins_core_superavit_pagos_trabajados_carga(
                                        _id_superavit_pagos_trabajados,
                                        _id_superavit_pagos,
                                        _documento_numero_superavit_pagos_trabajados,
                                        _tiene_credito_superavit_pagos_trabajados,
                                        _cruce_credito_superavit_pagos_trabajados,
                                        _comentario_superavit_pagos_trabajados,
                                        _ultimo_usuario_superavit_pagos_trabajados,
                                        _id_superavit_estados,
                                        _fecha_proceso_superavit_pagos_trabajados,
                                        _fecha_cancelacion_superavit_pagos_trabajados);


                }

                //cargar_transacciones_detalle(_id_transacciones);



                Console.WriteLine(reg + "---------------------------------");
            }

        }



        public static void ins_core_superavit_pagos_trabajados_carga(Int64 _id_superavit_pagos_trabajados,
                            Int64 _id_superavit_pagos,
                            Int64 _documento_numero_superavit_pagos_trabajados,
                            bool _tiene_credito_superavit_pagos_trabajados,
                            bool _cruce_credito_superavit_pagos_trabajados,
                            string _comentario_superavit_pagos_trabajados,
                            string _ultimo_usuario_superavit_pagos_trabajados,
                            int _id_superavit_estados,
                            DateTime _fecha_proceso_superavit_pagos_trabajados,
                            DateTime _fecha_cancelacion_superavit_pagos_trabajados)


        {

            string cadena1 = _id_superavit_pagos_trabajados+"?"+_id_superavit_pagos + "?" +
                            _documento_numero_superavit_pagos_trabajados + "?" +
                            _tiene_credito_superavit_pagos_trabajados + "?" +
                            _cruce_credito_superavit_pagos_trabajados + "?" +
                            _comentario_superavit_pagos_trabajados + "?" +
                            _ultimo_usuario_superavit_pagos_trabajados + "?" +
                            _id_superavit_estados + "?" +
                            _fecha_proceso_superavit_pagos_trabajados + "?" +
                            _fecha_cancelacion_superavit_pagos_trabajados;

            string cadena2 = "_id_superavit_pagos_trabajados?" +
                "_id_superavit_pagos?" +
                "_documento_numero_superavit_pagos_trabajados?" +
                "_tiene_credito_superavit_pagos_trabajados?" +
                "_cruce_credito_superavit_pagos_trabajados?" +
                "_comentario_superavit_pagos_trabajados?" +
                "_ultimo_usuario_superavit_pagos_trabajados?" +
                "_id_superavit_estados?" +
                "_fecha_proceso_superavit_pagos_trabajados?" +
                "_fecha_cancelacion_superavit_pagos_trabajados";

            string cadena3 = "NpgsqlDbType.Bigint?" +
                              "NpgsqlDbType.Bigint?" +
                              "NpgsqlDbType.Bigint?" +
                              "NpgsqlDbType.Boolean?" +
                              "NpgsqlDbType.Boolean?" +
                              "NpgsqlDbType.Varchar?" +
                              "NpgsqlDbType.Varchar?" +
                              "NpgsqlDbType.Int?" +
                              "NpgsqlDbType.TimestampTz ? " +
                              "NpgsqlDbType.TimestampTz";


            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_core_superavit_pagos_trabajados_carga");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO  SUPERAVIT PAGOS TRABAJADOS ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar  SUPERAVIT PAGOS TRABAJADOS " + Ex.Message);
                //     string cadena5 = "_error_errores_importacion";
                //     string cadena6 = "NpgsqlDbType.Varchar";
                // int resultado = AccesoLogica.Insert(cadena1, cadena5, cadena6, "public.ins_core_errores_importacion");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //  Console.Read();

            }

        }










    }


}
