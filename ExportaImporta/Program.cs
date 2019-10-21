using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Negocio;
using System.Globalization;
using System.Xml.Linq;
using System.Xml;
/// <summary>
/// manuel cambios
/// </summary>
namespace ExportaImporta
{
    class Program
    {
        
        public static int _year;
        public static int _mes;
        public static int _dia;
        public static DateTime Hoy = DateTime.Today;
       
        static void Main(string[] args)
        {
           // Console.WriteLine("Comenzamos Conexión: ");
           
            string dia = "";
            string mes = "";
            string año = "";


           
            dia = Hoy.ToString("dd");
            mes = Hoy.ToString("MM");
            año = Hoy.ToString("yyyy");

            _year = Convert.ToInt32(año.ToString());
            _mes = Convert.ToInt32(mes.ToString());
            _dia = Convert.ToInt32(dia.ToString());


            //Cierre_Mes_Creditos();


            // MIGRACION PARTICIPES, CREDITOS, TABLAS DE AMORTIZACION, CALCULO DE MORAS Y RECAUDACION 
            /*
            restaurar_tablas_rp_c();
            cargar_participes();
            cargar_informacion_adicional_participes();
            cargar_creditos();
            cargar_tablas_amortizacion();
            */calcular_moras();/*
            cargar_parametrizacion_tabla_amortizacion();
            cargar_pagos_tablas_amortizacion();*/



            // MIGRACION APORTES
            /*
             cargar_contribucion_cuenta_individual();
             cargar_contribucion_cuenta_desembolsar();
           */


            Console.Read();
           
        }



        public static void restaurar_tablas_rp_c()
        {
            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------VACIANDO CONTRIBUCIONES----------------------");
            AccesoLogica.TruncateCascade("core_contribucion");
            Console.WriteLine("-----------VACIANDO CONTRIBUCIONES PAGAS----------------------");
            AccesoLogica.TruncateCascade("core_contribucion_pagada");
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
            Console.WriteLine("---------------------------------");







            /// RESTABLECIENDO SECUENCIAS



            

            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
           
            Console.WriteLine("-----------SECUENCIA CONTRIBUCIONES----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_contribucion_id_contribucion_seq RESTART WITH 1");
            Console.WriteLine("-----------SECUENCIA CONTRIBUCIONES PAGAS----------------------");
            AccesoLogica.Select("ALTER SEQUENCE core_contribucion_pagada_id_contribucion_pagada_seq RESTART WITH 1");
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
            Console.WriteLine("---------------------------------");







            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------");
          
            Console.WriteLine("---------------------------------");



        }
        

        public static void calcular_moras() {

            int _leidos_individual = 0;
            int _year_buscar;
            int _mes_buscar;
            int _id_creditos = 0;
            double _interes_tipo_creditos;


            DataTable dtCreditos = AccesoLogica.Select("c.id_creditos, (t.interes_tipo_creditos/100) as interes_tipo_creditos", "core_creditos c inner join core_tipo_creditos t on c.id_tipo_creditos=t.id_tipo_creditos", "c.id_estado_creditos = 4 and c.id_estatus = 1 and c.id_creditos=3889 ORDER BY c.id_creditos ASC");
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
                Console.WriteLine("--------------COMENZAMOS VERIFICACIÓN DE MORAS AÑO -> "+ _year_buscar + " MES-> " + _mes_buscar+"----------------");
                foreach (DataRow renglon in dtCreditos.Rows)
                {
                    _leidos_individual++;
                    _id_creditos = Convert.ToInt32(renglon["id_creditos"].ToString());
                    _interes_tipo_creditos = Convert.ToDouble(renglon["interes_tipo_creditos"].ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL CREDITOS ->   " + regT + "    LEIDOS ->  " + _leidos_individual+ "      NUMERO CRÉDITO ->  "+ _id_creditos);
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

           

            DataTable dtAmortizacionesActuales = AccesoLogica.Select("t.id_tabla_amortizacion, t.id_creditos, t.fecha_tabla_amortizacion, t.numero_pago_tabla_amortizacion, t.capital_tabla_amortizacion, t.mora_tabla_amortizacion, t.id_estado_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos="+ _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and to_char(t.fecha_tabla_amortizacion, 'YYYY')='"+ _year_buscar + "' and to_char(t.fecha_tabla_amortizacion, 'MM')=LPAD('" + _mes_buscar + "',2,'0') ORDER BY numero_pago_tabla_amortizacion asc");
            int regT = dtAmortizacionesActuales.Rows.Count;

            if (regT > 0)
            {
                foreach (DataRow renglon1 in dtAmortizacionesActuales.Rows)
                {
                    _leidos_amortizaciones++;

                    _id_tabla_amortizacion= Convert.ToInt32(renglon1["id_tabla_amortizacion"].ToString());
                    _fecha_tabla_amortizacion = Convert.ToDateTime(renglon1["fecha_tabla_amortizacion"].ToString());
                    _numero_pago_tabla_amortizacion = Convert.ToInt32(renglon1["numero_pago_tabla_amortizacion"].ToString());
                    _capital_tabla_amortizacion = Convert.ToDouble(renglon1["capital_tabla_amortizacion"].ToString());
                    _id_estado_tabla_amortizacion = Convert.ToInt32(renglon1["id_estado_tabla_amortizacion"].ToString());
                   

                    DataTable dtAmortizacionesAnteriores = AccesoLogica.Select("min(t.fecha_tabla_amortizacion) as fecha_anterior_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos="+ _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and t.mora_tabla_amortizacion>0");
                    int reg_ante = dtAmortizacionesAnteriores.Rows.Count;

                    if (reg_ante > 0)
                    {
                        foreach (DataRow renglon_ante in dtAmortizacionesAnteriores.Rows)
                        {
                            try
                            {
                                _fecha_anterior_tabla_amortizacion = Convert.ToDateTime(renglon_ante["fecha_anterior_tabla_amortizacion"].ToString());
                            }
                            catch (Exception Ex)
                            {

                                _fecha_anterior_tabla_amortizacion = _fecha_tabla_amortizacion;
                            }

                        }
                    }
                    else {


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
                        catch (Exception Ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("CREDITO NO SE ENCUENTRA EN MORA.");
                            Console.ForegroundColor = ConsoleColor.Green;

                        }
                      
                    }
                   

                }else
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

            DataTable dtAmortizacionesCalcular = AccesoLogica.Select("t.id_tabla_amortizacion, t.id_creditos, t.fecha_tabla_amortizacion,  t.numero_pago_tabla_amortizacion, t.capital_tabla_amortizacion, t.mora_tabla_amortizacion, t.id_estado_tabla_amortizacion", "core_tabla_amortizacion t", "t.id_creditos="+ _id_creditos + " and t.id_estatus=1 and t.id_estado_tabla_amortizacion<>2 and date(t.fecha_tabla_amortizacion) between '"+ _fecha_anterior_tabla_amortizacion + "' and '" + _fecha_tabla_amortizacion + "' order by t.numero_pago_tabla_amortizacion asc");
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
                _dias_reales_mora = _dias_reales_mora - 1;

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

                //Actualiza_Mora(_id_tabla_amortizacion, _id_creditos, _numero_pago_tabla_amortizacion, _valor_mora_cuota);



            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CUOTA ->     " + _numero_pago_tabla_amortizacion + "         NO SE ENCUENTRA EN MORA ->     TIENE    " + _dias_reales_mora + " DIAS");
                Console.ForegroundColor = ConsoleColor.Green;
            }



        }

        
        public static void Actualiza_Mora(int _id_tabla_amortizacion, int _id_creditos, int _numero_pago_tabla_amortizacion, double _valor_mora_cuota) {


            try {

                 AccesoLogica.Update("core_tabla_amortizacion", "mora_tabla_amortizacion=" + _valor_mora_cuota + "", "id_tabla_amortizacion='" + _id_tabla_amortizacion + "' AND id_creditos = "+ _id_creditos + " AND id_estatus=1");
                 AccesoLogica.Update("core_tabla_amortizacion", "total_valor_tabla_amortizacion=total_valor_tabla_amortizacion+mora_tabla_amortizacion, total_balance_tabla_amortizacion=total_balance_tabla_amortizacion+mora_tabla_amortizacion", "id_tabla_amortizacion='" + _id_tabla_amortizacion + "' AND id_creditos = " + _id_creditos + " AND id_estatus=1");


            }
            catch (Exception Ex)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Error al Actualizar Amortización ->    " + _id_tabla_amortizacion +" Error -> "+ Ex.Message);


            }



        } 
        

        public static void cargar_participes()
        {

            DataTable dtParticipes= AccesoLogicaSQL.Select("PARTNER_ID, CASE WHEN DEPENDENCY_ID=0 THEN 228 ELSE DEPENDENCY_ID END  DEPENDENCY_ID, LAST_NAME, FIRST_NAME, IDENTITY_CARD, BIRTH_DATE, ADDRESS, PHONE, PARNERT_MOVIL_PHONE, DATE_ENTRANCE_PN, DATE_OF_DEATH, CASE WHEN STATE=0 THEN 1 ELSE STATE END  STATE, CASE WHEN STATUS=0 THEN 2 ELSE STATUS END  STATUS, DATE_EXIT_PN, GENDER, CASE WHEN MARRITAL_STATUS=0 THEN 2 ELSE MARRITAL_STATUS END MARRITAL_STATUS, OBSERVATION, EMAIL, CASE WHEN EMPLOYER_ENTITY_ID=10000 THEN 104 ELSE EMPLOYER_ENTITY_ID END EMPLOYER_ENTITY_ID, ENTITY_DATE_ENTRY, PARNERT_OCCUPATION, CASE WHEN PARNERT_TYPE_INSTRUCTION=0 THEN 1 ELSE PARNERT_TYPE_INSTRUCTION END PARNERT_TYPE_INSTRUCTION, PARNERT_SPOUSE_LAST_NAME, PARNERT_SPOUSE_NAME, PARNERT_SPOUSE_IDENTIFICATION, PARNERT_NUMBER_DEPENDENTS, ALTERNATIVE_CODE, DATE_ORDER_NUMBER", "one.PARTNER", "1=1 ORDER BY PARTNER_ID ASC");
            
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
            if (reg>0) {

                foreach (DataRow renglon in dtParticipes.Rows)
                {


                    _id_participes                          = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _id_cuidades                            = Convert.ToInt32(renglon["DEPENDENCY_ID"].ToString());
                    _apellido_participes                    = renglon["LAST_NAME"].ToString();
                    _nombre_participes                      = renglon["FIRST_NAME"].ToString();
                    _cedula_participes                      = renglon["IDENTITY_CARD"].ToString();
                    _fecha_nacimiento_participes            = Convert.ToDateTime(renglon["BIRTH_DATE"]);
                    _direccion_participes                   = renglon["ADDRESS"].ToString();
                    _telefono_participes                    = renglon["PHONE"].ToString();
                    _celular_participes                     = renglon["PARNERT_MOVIL_PHONE"].ToString();
                    _fecha_ingreso_participes               = Convert.ToDateTime(renglon["DATE_ENTRANCE_PN"]);
                    _fecha_defuncion_participes             = Convert.ToDateTime(renglon["DATE_OF_DEATH"]);
                    _id_estado_participes                   = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_estatus                             = Convert.ToInt32(renglon["STATUS"].ToString());
                    _fecha_salida_participes                = Convert.ToDateTime(renglon["DATE_EXIT_PN"]);
                    _id_genero_participes                   = Convert.ToInt32(renglon["GENDER"].ToString());
                    _id_estado_civil_participes             = Convert.ToInt32(renglon["MARRITAL_STATUS"].ToString());
                    _observacion_participes                 = renglon["OBSERVATION"].ToString();
                    _correo_participes                      = renglon["EMAIL"].ToString();
                    _id_entidad_patronal                    = Convert.ToInt32(renglon["EMPLOYER_ENTITY_ID"].ToString());
                    _fecha_entrada_patronal_participes      = Convert.ToDateTime(renglon["ENTITY_DATE_ENTRY"]);
                    _ocupacion_participes                   = renglon["PARNERT_OCCUPATION"].ToString();
                    _id_tipo_instruccion_participes         = Convert.ToInt32(renglon["PARNERT_TYPE_INSTRUCTION"].ToString());
                    _nombre_conyugue_participes             = renglon["PARNERT_SPOUSE_LAST_NAME"].ToString();
                    _apellido_esposa_participes             = renglon["PARNERT_SPOUSE_NAME"].ToString();
                    _cedula_conyugue_participes             = renglon["PARNERT_SPOUSE_IDENTIFICATION"].ToString();
                    _numero_dependencias_participes         = Convert.ToInt32(renglon["PARNERT_NUMBER_DEPENDENTS"].ToString());
                    _codigo_alternativo_participes          = Convert.ToInt32(renglon["ALTERNATIVE_CODE"].ToString());
                    
                    _fecha_numero_orden_participes          = Convert.ToDateTime(renglon["DATE_ORDER_NUMBER"]);
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
                Console.Read();

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


                     _id_participes_informacion_adicional                         = Convert.ToInt32(renglon["PARNERT_ADITTIONAL_INFORMATION_ID"].ToString());
                     _id_participes                                               = Convert.ToInt32(renglon["PARNERT_ID"].ToString());
                     _id_distritos                                                = Convert.ToInt32(renglon["PARNERT_REGION"].ToString());
                     _id_provincias                                               = Convert.ToInt32(renglon["PARNERT_PROVINCE"].ToString());
                     _id_ciudades                                                 = Convert.ToInt32(renglon["PARNERT_CITY"].ToString());
                     _parroquia_participes_informacion_adicional                  = renglon["PARNERT_PARISH"].ToString();
                     _sector_participes_informacion_adicional                     = renglon["PARNERT_SECTOR"].ToString();
                     _ciudadela_participes_informacion_adicional                  = renglon["PARNERT_CITADEL"].ToString();
                     _calle_participes_informacion_adicional                      = renglon["PARNERT_STREET"].ToString();
                     _numero_calle_participes_informacion_adicional               = renglon["PARNERT_NUMBER"].ToString();
                     _interseccion_participes_informacion_adicional               = renglon["PARNERT_INTERSECTION"].ToString();
                     _id_tipo_vivienda                                            = Convert.ToInt32(renglon["PARNERT_TYPE_RESIDENCE"].ToString());
                     _anios_residencia_participes_informacion_adicional           = Convert.ToInt32(renglon["PARNERT_YEAR_RESIDENCE"].ToString());
                     _nombre_propietario_participes_informacion_adicional         = renglon["PARNERT_NAME_OWNER"].ToString();
                     _telefono_propietario_participes_informacion_adicional       = renglon["PARNERT_PHONE_OWNER"].ToString();
                     _direccion_referencia_participes_informacion_adicional       = renglon["PARNERT_REFERENCE_ADDRESS"].ToString();
                     _vivienda_hipotecada_participes_informacion_adicional        = Convert.ToBoolean(renglon["PARNERT_STATUS_RESIDENCE"].ToString());
                     _nombre_una_referencia_participes_informacion_adicional      = renglon["PARNERT_NAME_REFERENCE"].ToString();
                     _id_parentesco                                               = Convert.ToInt32(renglon["PARNERT_DESCRIPTION_REFERENCE"].ToString());
                     _telefono_una_referencia_participes_informacion_adicional    = renglon["PARNERT_PHONE_REFERENCE"].ToString();
                     _observaciones_participes_informacion_adicional              = renglon["PARNERT_OBSERVATION"].ToString();
                     _kit_participes_informacion_adicional                        = Convert.ToInt32(renglon["PARNERT_KIT"].ToString());
                     _contrato_adhesion_participes_informacion_adicional          = Convert.ToInt32(renglon["PARNERT_CONTRACT_ADHESION"].ToString());

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
                Console.Read();

            }

        }
        

        public static void cargar_contribucion_cuenta_individual()
        {

            DataTable dtContribucion_Ind = AccesoLogicaSQL.Select("c.CONTRIBUTION_ID, c.PARTNER_ID, c.DATE, c.PERSONNEL_PAY, c.EMPLOYER_PAY, CASE WHEN c.STATUS=0 THEN 2 ELSE c.STATUS END STATUS, c.DESCRIPTION, c.JOURNAL_ID, c.USER_ID, c.USER_NAME, CASE WHEN c.TYPE=0 THEN 3 ELSE c.TYPE END TYPE, CASE WHEN c.STATE=0 THEN 2 ELSE c.STATE END STATE, CASE WHEN c.ENTITY_EMPLOYER_ID=10000 THEN 104 ELSE c.ENTITY_EMPLOYER_ID END ENTITY_EMPLOYER_ID, c.DATE_ACCOUNT, c.DOCUMENT_NUMBER, c.OBSERVATION, isnull(c.LIQUIDATION_ID,0) LIQUIDATION_ID, isnull(c.DISTRIBUTION_ID,0) DISTRIBUTION_ID", "one.CONTRIBUTION c", "1=1 order by c.CONTRIBUTION_ID asc");

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


            int reg = dtContribucion_Ind.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtContribucion_Ind.Rows)
                {
                    _id_participes                          = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _fecha_registro_contribucion            = Convert.ToDateTime(renglon["DATE"]);
                    _valor_personal_contribucion            = Convert.ToDouble(renglon["PERSONNEL_PAY"]);
                    _valor_patronal_contribucion            = Convert.ToDouble(renglon["EMPLOYER_PAY"]);
                    _id_estatus                             = Convert.ToInt32(renglon["STATUS"].ToString());
                    _descripcion_contribucion               = renglon["DESCRIPTION"].ToString();
                    _id_diario                              = Convert.ToInt32(renglon["JOURNAL_ID"].ToString());
                    _id_usuarios                            = Convert.ToInt32(renglon["USER_ID"].ToString());
                    _nombre_usuarios_contribucion           = renglon["USER_NAME"].ToString();
                    _id_contribucion_tipo                   = Convert.ToInt32(renglon["TYPE"].ToString());
                    _id_estado_contribucion                 = Convert.ToInt32(renglon["STATE"].ToString());
                    _id_entidad_patronal                    = Convert.ToInt32(renglon["ENTITY_EMPLOYER_ID"].ToString());
                    _fecha_contable_distribucion            = Convert.ToDateTime(renglon["DATE_ACCOUNT"]);
                    _numero_documento_contribucion          = renglon["DOCUMENT_NUMBER"].ToString();
                    _observacion_contribucion               = renglon["OBSERVATION"].ToString();
                    _id_liquidacion                         = Convert.ToInt64(renglon["LIQUIDATION_ID"].ToString());
                    _id_distribucion                        = Convert.ToInt64(renglon["DISTRIBUTION_ID"].ToString());
                    
                    _leidos_individual++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Total Cuenta Individual -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Cta_Individual(_id_participes, _fecha_registro_contribucion, _valor_personal_contribucion, _valor_patronal_contribucion, _id_estatus, _descripcion_contribucion, _id_diario, _id_usuarios, _nombre_usuarios_contribucion, _id_contribucion_tipo, _id_estado_contribucion, _id_entidad_patronal, _fecha_contable_distribucion, _numero_documento_contribucion, _observacion_contribucion, _id_liquidacion, _id_distribucion);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }

        
        public static void Ins_Cta_Individual(int _id_participes, DateTime _fecha_registro_contribucion, double _valor_personal_contribucion, double _valor_patronal_contribucion, int _id_estatus, string _descripcion_contribucion, int _id_diario, int _id_usuarios, string _nombre_usuarios_contribucion, int _id_contribucion_tipo, int _id_estado_contribucion, int _id_entidad_patronal, DateTime _fecha_contable_distribucion, string _numero_documento_contribucion, string _observacion_contribucion, Int64 _id_liquidacion, Int64 _id_distribucion)
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
                Console.Read();

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
                Console.Read();

            }

        }
        

        public static void cargar_creditos()
        {

            DataTable dtCreditos = AccesoLogicaSQL.Select("c.CREDIT_ID, c.PARTNER_ID, c.CREDIT_PRODUCT_ID, c.AMOUNT, c.BALANCE, c.DATE, CASE WHEN c.STATE=15 THEN 12 WHEN c.STATE=16 THEN 13 ELSE  c.STATE END STATE, c.TERM, c.NET_AMOUNT, c.REQUEST_NUMBER, CASE WHEN c.TYPE=35 THEN 1 WHEN c.TYPE=36 THEN 2 WHEN c.TYPE=38 THEN 3 WHEN c.TYPE=40 THEN 4 WHEN c.TYPE=65 THEN 5 WHEN c.TYPE=66 THEN 6 END TYPE, c.OBSERVATION, CASE WHEN c.STATUS=0 THEN 2 ELSE c.STATUS END  STATUS, c.REQUEST_RECEIVER, c.INTEREST, c.INSURANCE_EXEMPT_TAX, c.DATE_SERVER, c.CALCULO_BASE_PARTNER", "one.CREDIT c", "1=1 order by c.CREDIT_ID asc");

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
                    
                    _id_creditos                    = Convert.ToInt32(renglon["CREDIT_ID"].ToString());
                    _numero_creditos                = renglon["CREDIT_ID"].ToString();
                    _id_participes                  = Convert.ToInt32(renglon["PARTNER_ID"].ToString());
                    _id_creditos_productos          = Convert.ToInt32(renglon["CREDIT_PRODUCT_ID"].ToString());
                    _monto_otorgado_creditos        = Convert.ToDouble(renglon["AMOUNT"]);
                    _saldo_actual_creditos          = Convert.ToDouble(renglon["BALANCE"]);
                    _fecha_concesion_creditos       = Convert.ToDateTime(renglon["DATE"]);
                    _id_estado_creditos             = Convert.ToInt32(renglon["STATE"].ToString());
                    _plazo_creditos                 = Convert.ToInt32(renglon["TERM"].ToString());
                    _monto_neto_entregado_creditos  = Convert.ToDouble(renglon["NET_AMOUNT"]);
                    _numero_solicitud_creditos      = Convert.ToInt32(renglon["REQUEST_NUMBER"]);
                    _id_tipo_creditos               = Convert.ToInt32(renglon["TYPE"].ToString());
                    _observacion_creditos           = renglon["OBSERVATION"].ToString();
                    _id_estatus                     = Convert.ToInt32(renglon["STATUS"].ToString());
                    _receptor_solicitud_creditos    = renglon["REQUEST_RECEIVER"].ToString();
                    _interes_creditos               = Convert.ToDouble(renglon["INTEREST"]);
                    _impuesto_exento_seguro_creditos = Convert.ToDouble(renglon["INSURANCE_EXEMPT_TAX"]);
                    _fecha_servidor_creditos          = Convert.ToDateTime(renglon["DATE_SERVER"]);
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
                Console.Read();

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
                Console.Read();

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
                Console.Read();

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
                Console.Read();

            }

        }


        public static void cargar_pagos_tablas_amortizacion()
        {

            DataTable dtPagos = AccesoLogicaSQL.Select("ap.AMORTIZATION_TABLE_ID, ap.VALUE, ap.BALANCE, CASE WHEN ap.STATUS=0 THEN 2 ELSE ap.STATUS END STATUS, ap.DATE, CASE WHEN ct.CREDIT_TYPE_ID=35 THEN 1  WHEN ct.CREDIT_TYPE_ID=36 THEN 2 WHEN ct.CREDIT_TYPE_ID=38 THEN 3 WHEN ct.CREDIT_TYPE_ID=40 THEN 4 WHEN ct.CREDIT_TYPE_ID=65 THEN 5 WHEN ct.CREDIT_TYPE_ID=66 THEN 6 END CREDIT_TYPE_ID, at.TYPE", "one.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE ap inner join one.AMORTIZATION_TABLE_ADDITIONAL_VALUE at on ap.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID=at.AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID inner join one.CREDIT_PRODUCT cp on at.CREDIT_PRODUCT_ID=cp.CREDIT_PRODUCT_ID inner join one.CREDIT_TYPE ct on cp.CREDIT_TYPE_ID=ct.CREDIT_TYPE_ID", "1=1 order by ap.APROVED_AMORTIZATION_TABLE_ADDITIONAL_VALUE_ID ASC");


            int _leidos_individual = 0;


            int _id_tabla_amortizacion_parametrizacion;
            int _id_tabla_amortizacion;
            double _valor_pago_tabla_amortizacion_pagos;
            double _saldo_cuota_tabla_amortizacion_pagos;
            int _id_estatus;
            DateTime _fecha_pago_tabla_amortizacion_pagos;

            int _id_tipo_creditos;
            int _tipo_tabla_amortizacion_parametrizacion;


            int reg = dtPagos.Rows.Count;

            Console.WriteLine("---------------------------------");
            if (reg > 0)
            {

                foreach (DataRow renglon in dtPagos.Rows)
                {

                    
                    _id_tabla_amortizacion = Convert.ToInt32(renglon["AMORTIZATION_TABLE_ID"].ToString());
                    _valor_pago_tabla_amortizacion_pagos = Convert.ToDouble(renglon["VALUE"].ToString());
                    _saldo_cuota_tabla_amortizacion_pagos = Convert.ToDouble(renglon["BALANCE"].ToString());
                    _id_estatus = Convert.ToInt32(renglon["STATUS"].ToString());
                    _fecha_pago_tabla_amortizacion_pagos = Convert.ToDateTime(renglon["DATE"].ToString());

                    _id_tipo_creditos = Convert.ToInt32(renglon["CREDIT_TYPE_ID"].ToString());
                    _tipo_tabla_amortizacion_parametrizacion = Convert.ToInt32(renglon["TYPE"].ToString());
                    _leidos_individual++;

                    _id_tabla_amortizacion_parametrizacion = BuscarParametrizacion(_id_tipo_creditos, _tipo_tabla_amortizacion_parametrizacion);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL PAGOS TABLAS DE AMORTIZACION -> " + reg + " LEIDOS -> " + _leidos_individual);

                    Ins_Pagos_Tabla_Amortizacion(_id_tabla_amortizacion_parametrizacion, _id_tabla_amortizacion, _valor_pago_tabla_amortizacion_pagos, _saldo_cuota_tabla_amortizacion_pagos, _id_estatus, _fecha_pago_tabla_amortizacion_pagos);

                }

                Console.WriteLine(reg + "---------------------------------");
            }

        }

        
        public static int BuscarParametrizacion(int _id_tipo_creditos, int _tipo_tabla_amortizacion_parametrizacion)
        {
          
            DataTable dtAfiliadosT = AccesoLogica.Select("id_tabla_amortizacion_parametrizacion", "core_tabla_amortizacion_parametrizacion", "id_tipo_creditos="+_id_tipo_creditos+ " AND tipo_tabla_amortizacion_parametrizacion="+ _tipo_tabla_amortizacion_parametrizacion + " ");
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


        public static void Ins_Pagos_Tabla_Amortizacion(int _id_tabla_amortizacion_parametrizacion, int _id_tabla_amortizacion, double _valor_pago_tabla_amortizacion_pagos, double _saldo_cuota_tabla_amortizacion_pagos, int _id_estatus, DateTime _fecha_pago_tabla_amortizacion_pagos)
        {
            string cadena1 = _id_tabla_amortizacion_parametrizacion + "?" + _id_tabla_amortizacion + "?" + _valor_pago_tabla_amortizacion_pagos + "?" + _saldo_cuota_tabla_amortizacion_pagos + "?" + _id_estatus + "?" + _fecha_pago_tabla_amortizacion_pagos;

            CultureInfo ci = new CultureInfo("es-EC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_tabla_amortizacion_parametrizacion?_id_tabla_amortizacion?_valor_pago_tabla_amortizacion_pagos?_saldo_cuota_tabla_amortizacion_pagos?_id_estatus?_fecha_pago_tabla_amortizacion_pagos";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Double?NpgsqlDbType.Double?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTz";

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
                Console.Read();

            }

        }

        
        public static void Cierre_Mes_Creditos() {

            
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


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------COMENZAMOS CIERRE DE MES CRÉDITOS PERIODO-> " + _ultimo_dia_mes + "--------------------------------");

           

            DataTable dtCreditos = AccesoLogica.Select("c.id_creditos, c.id_participes, c.id_tipo_creditos, c.monto_otorgado_creditos, c.plazo_creditos, c.id_estado_creditos", "core_creditos c", "c.id_estatus=1 and c.id_estado_creditos not in (1,2,3,6) and c.fecha_concesion_creditos <='"+ _ultimo_dia_mes + "'");
            int reg_creditos = dtCreditos.Rows.Count;

            if (reg_creditos > 0)
            {
                
                int _id_creditos;
                int _id_participes;
                int _id_tipo_creditos;
                double _monto_otorgado_creditos;
                int _plazo_creditos;
                int _id_estado_creditos;

                
                foreach (DataRow renglon_creditos in dtCreditos.Rows)
                {

                    _id_creditos = Convert.ToInt32(renglon_creditos["id_creditos"].ToString());
                    _id_participes = Convert.ToInt32(renglon_creditos["id_participes"].ToString());
                    _id_tipo_creditos = Convert.ToInt32(renglon_creditos["id_tipo_creditos"].ToString());
                    _monto_otorgado_creditos = Convert.ToDouble(renglon_creditos["monto_otorgado_creditos"].ToString());
                    _plazo_creditos = Convert.ToInt32(renglon_creditos["plazo_creditos"].ToString());
                    _id_estado_creditos = Convert.ToInt32(renglon_creditos["id_estado_creditos"].ToString());


                    Buscar_Pagos_Capital(_id_creditos);

                }
            }

            
        }

        
        public static void Buscar_Pagos_Capital(int _id_creditos)
        {

            double _valor_pagado;
           
            
            DataTable dtPagos = AccesoLogica.Select("sum(tp.valor_pago_tabla_amortizacion_pagos) as valor_pagado", "core_tabla_amortizacion t inner join core_tabla_amortizacion_pagos tp on t.id_tabla_amortizacion=tp.id_tabla_amortizacion inner join core_tabla_amortizacion_parametrizacion tpa on tp.id_tabla_amortizacion_parametrizacion=tpa.id_tabla_amortizacion_parametrizacion", "t.id_creditos="+ _id_creditos + " and tpa.tipo_tabla_amortizacion_parametrizacion=0 and tp.id_estatus=1 ORDER BY t.id_creditos ASC");
            int reg_pagos = dtPagos.Rows.Count;

            if (reg_pagos > 0)
            {
                
                foreach (DataRow renglon_pagos in dtPagos.Rows)
                {

                    _valor_pagado = Convert.ToDouble(renglon_pagos["valor_pagado"].ToString());

                }
            }


        }



















        }

}
