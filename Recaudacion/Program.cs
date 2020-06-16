using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Negocio;
using Datos;
using System.Globalization;
using System.Xml.Linq;
using System.Xml;
using System.Threading;
using Npgsql;

namespace Recaudacion
{
    class Program
    {
        public static int _year;
        public static int _mes;
        public static int _dia;
        public static DateTime Hoy = DateTime.Today;

        static void Main(string[] args)
        {

            string dia = "";
            string mes = "";
            string año = "";

            dia = Hoy.ToString("dd");
            mes = Hoy.ToString("MM");
            año = Hoy.ToString("yyyy");

            _year = Convert.ToInt32(año.ToString());
            _mes = Convert.ToInt32(mes.ToString());
            _dia = Convert.ToInt32(dia.ToString());

             procesa_descuentos_aportes();
            //Pruebas();
        }






        public static void Pruebas()
        {

            string cadena1 = "Prueba";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_nombre";
            string cadena3 = "NpgsqlDbType.Varchar";


            try
            {
                DataTable resultado = AccesoLogica.Insert1(cadena1, cadena2, cadena3, "public.ins_var_existe");
                Console.ForegroundColor = ConsoleColor.Blue;
                int reg_descuentos = resultado.Rows.Count;

                Int64 _id_contribucion=0;

                if (reg_descuentos > 0)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {

                        _id_contribucion = Convert.ToInt64(renglon["ins_var_existe"].ToString());
                    }
                 
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine("INSERTADO CORRECTAMENTE -> " + _id_contribucion);
                    Console.WriteLine("------------------------------------------------------------------------------------------------");

                }
                else {
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine(" VACIO -> "  );
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                }



            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar en Descuentos Registrados Detalle Contribucion " + Ex.Message);
               
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");



            }


        }










        public static void procesa_descuentos_aportes()
        {

            int _leidos = 0;
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------COMENZAMOS PROCESO DE DESCUENTOS DE APORTES ->    " + Hoy + "--------------------------------");



            // EMPIEZA PROCESO DE DESCUENTOS DE APORTES
            DataTable dtDescuentos = AccesoLogica.Select("a.id_descuentos_registrados_cabeza, a.id_entidad_patronal, a.id_descuentos_formatos, a.year_descuentos_registrados_cabeza, a.mes_descuentos_registrados_cabeza, a.fecha_descuentos_registrados_cabeza, a.fecha_contable_descuentos_registrados_cabeza, a.usuario_descuentos_registrados_cabeza", "core_descuentos_registrados_cabeza a inner join core_descuentos_formatos b on a.id_descuentos_formatos=b.id_descuentos_formatos", "b.entrada_descuentos_formatos='TRUE' and b.parametro_uno_descuentos_formatos='A' and a.procesado_descuentos_registrados_cabeza='FALSE' and a.erro_descuentos_registrados_cabeza='FALSE' order by a.id_descuentos_registrados_cabeza asc");
            int reg_descuentos = dtDescuentos.Rows.Count;

            if (reg_descuentos > 0)
            {

                Int64 _id_descuentos_registrados_cabeza;
                Int64 _id_entidad_patronal;
                Int64 _id_descuentos_formatos;
                int _year_descuentos_registrados_cabeza;
                int _mes_descuentos_registrados_cabeza;
                DateTime? _fecha_descuentos_registrados_cabeza = null;
                DateTime? _fecha_contable_descuentos_registrados_cabeza = null;
                string _usuario_descuentos_registrados_cabeza = "";


                foreach (DataRow renglon in dtDescuentos.Rows)
                {
                    _leidos++;
                    _id_descuentos_registrados_cabeza = Convert.ToInt64(renglon["id_descuentos_registrados_cabeza"].ToString());
                    _id_entidad_patronal = Convert.ToInt64(renglon["id_entidad_patronal"].ToString());
                    _id_descuentos_formatos = Convert.ToInt64(renglon["id_descuentos_formatos"].ToString());
                    _year_descuentos_registrados_cabeza = Convert.ToInt32(renglon["year_descuentos_registrados_cabeza"].ToString());
                    _mes_descuentos_registrados_cabeza = Convert.ToInt32(renglon["mes_descuentos_registrados_cabeza"].ToString());
                    _fecha_descuentos_registrados_cabeza = Convert.ToDateTime(renglon["fecha_descuentos_registrados_cabeza"].ToString());
                    _fecha_contable_descuentos_registrados_cabeza = Convert.ToDateTime(renglon["fecha_contable_descuentos_registrados_cabeza"].ToString());
                    _usuario_descuentos_registrados_cabeza = renglon["usuario_descuentos_registrados_cabeza"].ToString();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("TOTAL DESCUENTOS APORTES ->   " + reg_descuentos + "    LEIDOS ->  " + _leidos + "      NUMERO REGISTRO CABEZA ->  " + _id_descuentos_registrados_cabeza);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Buscar_Detalle_Descuentos_Aportes(_id_descuentos_registrados_cabeza, _id_entidad_patronal, _id_descuentos_formatos, _year_descuentos_registrados_cabeza, _mes_descuentos_registrados_cabeza, _fecha_descuentos_registrados_cabeza, _fecha_contable_descuentos_registrados_cabeza, _usuario_descuentos_registrados_cabeza);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");


                }
            }


        }


        public static void Buscar_Detalle_Descuentos_Aportes(Int64 _id_descuentos_registrados_cabeza, Int64 _id_entidad_patronal, Int64 _id_descuentos_formatos, Int32 _year_descuentos_registrados_cabeza, Int32 _mes_descuentos_registrados_cabeza, DateTime? _fecha_descuentos_registrados_cabeza, DateTime? _fecha_contable_descuentos_registrados_cabeza, string _usuario_descuentos_registrados_cabeza)
        {
            int _leidos_aportes = 0;
            Int64 _id_participes;
            double _aporte_personal_descuentos_registrados_detalle_aportes = 0;
            double _aporte_patronal_descuentos_registrados_detalle_aportes = 0;
            double _rmu_descuentos_registrados_detalle_aportes = 0;
            double _liquido_descuentos_registrados_detalle_aportes =  0;
            double _multas_descuentos_registrados_detalle_aportes = 0;
            double _antiguedad_descuentos_registrados_detalle_aportes = 0;
            Int64 _id_descuentos_registrados_detalle_aportes;


            Int64? _id_contribucion = 0;
            int[] _contribuciones_afectadas;
            int _errores = 0;


            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = null;

            // CONSULTO DETALLE DESCUENTOS APORTES
            DataTable dtDetalleAportes = AccesoLogica.Select("a.id_participes, a.aporte_personal_descuentos_registrados_detalle_aportes, a.aporte_patronal_descuentos_registrados_detalle_aportes, a.rmu_descuentos_registrados_detalle_aportes, a.liquido_descuentos_registrados_detalle_aportes, a.multas_descuentos_registrados_detalle_aportes, a.antiguedad_descuentos_registrados_detalle_aportes, a.id_descuentos_registrados_detalle_aportes, a.id_descuentos_registrados_cabeza", "core_descuentos_registrados_detalle_aportes a", "a.id_descuentos_registrados_cabeza = "+_id_descuentos_registrados_cabeza+ " ORDER BY a.id_descuentos_registrados_detalle_aportes ASC");
            int reg_aporte = dtDetalleAportes.Rows.Count;

            if (reg_aporte > 0)
            {
                _contribuciones_afectadas = new int[500];

                //INICIO TRANSACCIONALIDAD PARA ROLL BACK SI HAY ERRORES
                //AccesoLogica.BeginTran("BEGIN");


                connection = new NpgsqlConnection(MetodosDatos.cadenaConexion);
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new NpgsqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;





                foreach (DataRow renglon_pagos in dtDetalleAportes.Rows)
                {
                    _leidos_aportes++;
                     _id_contribucion = 0;
                     _id_participes = Convert.ToInt64(renglon_pagos["id_participes"].ToString());
                     _aporte_personal_descuentos_registrados_detalle_aportes = Convert.ToDouble(renglon_pagos["aporte_personal_descuentos_registrados_detalle_aportes"].ToString());
                     _aporte_patronal_descuentos_registrados_detalle_aportes = Convert.ToDouble(renglon_pagos["aporte_patronal_descuentos_registrados_detalle_aportes"].ToString());
                     _rmu_descuentos_registrados_detalle_aportes = Convert.ToDouble(renglon_pagos["rmu_descuentos_registrados_detalle_aportes"].ToString());
                     _liquido_descuentos_registrados_detalle_aportes = Convert.ToDouble(renglon_pagos["liquido_descuentos_registrados_detalle_aportes"].ToString());
                     _multas_descuentos_registrados_detalle_aportes = Convert.ToDouble(renglon_pagos["multas_descuentos_registrados_detalle_aportes"].ToString());
                     _antiguedad_descuentos_registrados_detalle_aportes = Convert.ToDouble(renglon_pagos["antiguedad_descuentos_registrados_detalle_aportes"].ToString());
                     _id_descuentos_registrados_detalle_aportes =  Convert.ToInt64(renglon_pagos["id_descuentos_registrados_detalle_aportes"].ToString());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TOTAL DETALLE ARCHIVO APORTES ->   " + reg_aporte + "    PROCESADOS ->  " + _leidos_aportes + "      NUMERO REGISTRO DETALLE APORTES ->  " + _id_descuentos_registrados_detalle_aportes);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    _id_contribucion = Ins_Contribucion(_id_participes, _aporte_personal_descuentos_registrados_detalle_aportes, _aporte_patronal_descuentos_registrados_detalle_aportes, _rmu_descuentos_registrados_detalle_aportes, _liquido_descuentos_registrados_detalle_aportes, _multas_descuentos_registrados_detalle_aportes, _antiguedad_descuentos_registrados_detalle_aportes, _id_descuentos_registrados_detalle_aportes, _year_descuentos_registrados_cabeza, _mes_descuentos_registrados_cabeza, _fecha_descuentos_registrados_cabeza, _fecha_contable_descuentos_registrados_cabeza, _usuario_descuentos_registrados_cabeza, _id_entidad_patronal, _id_descuentos_registrados_cabeza);

                    if (_leidos_aportes==1) {
                        _id_contribucion = 0;
                    }


                    if (_id_contribucion>0) {

                        _contribuciones_afectadas[_leidos_aportes] = Convert.ToInt32(_id_contribucion);

                        Console.WriteLine("CORRECTO ID_CONTRIBUCION ->   " + _id_contribucion);
                        Ins_Descuentos_Registrados_Contribucion(_id_descuentos_registrados_detalle_aportes, _id_contribucion, _id_descuentos_registrados_cabeza);
                    
                    }else {
                        _errores++;
                        Console.WriteLine("ERROR ID_CONTRIBUCION ->   " + _id_contribucion);

                        //FORZO ROLL BACK PORQUE HAY ERRORES
                        //AccesoLogica.EndTran("ROLLBACK");
                        if (transaction != null) transaction.Rollback();

                        break;
                       
                    }


                }

                //CREAR DIARIOS CONTABLES DE APORTES

                if (_errores == 0) {

                    int id_contribucion = 0;


                    if (_contribuciones_afectadas.Length>0) {

                        for (int i = 1; i <= _leidos_aportes; i++)
                        {

                            //RECORRO LAS DISTRIBUCIONES AFECTADAS A LAS QUE HAY QUE HACER LOS DIARIOS CONTABLES DE APORTES
                            id_contribucion = 0;
                            id_contribucion = _contribuciones_afectadas[i];
                            Console.WriteLine("CORRECTO ID_CONTRIBUCION_PROCESADO ->   " + id_contribucion);

                            //TERMINO TRANSACCIONALIDAD SIN ERRORES
                            //AccesoLogica.EndTran("COMMIT");
                            transaction.Commit();


                        }


                        if (connection != null) connection.Close();
                    }
                }


            }

        }




        public static Int64 Ins_Contribucion(Int64 _id_participes, double _aporte_personal_descuentos_registrados_detalle_aportes, double _aporte_patronal_descuentos_registrados_detalle_aportes, double _rmu_descuentos_registrados_detalle_aportes, double _liquido_descuentos_registrados_detalle_aportes, double _multas_descuentos_registrados_detalle_aportes, double _antiguedad_descuentos_registrados_detalle_aportes, Int64 _id_descuentos_registrados_detalle_aportes, int _year_descuentos_registrados_cabeza, int _mes_descuentos_registrados_cabeza, DateTime? _fecha_descuentos_registrados_cabeza, DateTime? _fecha_contable_descuentos_registrados_cabeza, string _usuario_descuentos_registrados_cabeza, Int64 _id_entidad_patronal, Int64 _id_descuentos_registrados_cabeza)
        {
            Int64? _id_contribucion = 0;
            string _descripcion_contribucion = "Descuento mensual correspondiente al año: "+_year_descuentos_registrados_cabeza + " mes: " +_mes_descuentos_registrados_cabeza;
            string _observacion_contribucion = "Archivo procesado: Agregar Ruta";
            int _id_estatus = 1;
            int _id_diario = 0;
            int _id_contribucion_tipo = 1;
            int _id_estado_contribucion = 1;
            string _numero_documento_contribucion = "";
            int _tipo_descuento_contribucion = 2;

            string cadena1 = _id_participes + "?" + 
                            _aporte_personal_descuentos_registrados_detalle_aportes + "?" + 
                            _aporte_patronal_descuentos_registrados_detalle_aportes + "?" +
                            _fecha_descuentos_registrados_cabeza + "?" +
                            _id_estatus + "?" +
                            _descripcion_contribucion + "?" +
                            _id_diario + "?" +
                            _usuario_descuentos_registrados_cabeza + "?" +
                            _id_contribucion_tipo + "?" +
                            _id_estado_contribucion + "?" +
                            _id_entidad_patronal + "?" +
                            _fecha_contable_descuentos_registrados_cabeza + "?" +
                            _numero_documento_contribucion + "?" +
                            _observacion_contribucion + "?" +
                            _tipo_descuento_contribucion;


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_participes?_aporte_personal_descuentos_registrados_detalle_aportes?_aporte_patronal_descuentos_registrados_detalle_aportes?_fecha_descuentos_registrados_cabeza?_id_estatus?_descripcion_contribucion?_id_diario?_usuario_descuentos_registrados_cabeza?_id_contribucion_tipo?_id_estado_contribucion?_id_entidad_patronal?_fecha_contable_descuentos_registrados_cabeza?_numero_documento_contribucion?_observacion_contribucion?_tipo_descuento_contribucion";
            string cadena3 = "NpgsqlDbType.Bigint?NpgsqlDbType.Double?NpgsqlDbType.Double?" +
                "NpgsqlDbType.TimestampTz?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.Integer?" +
                "NpgsqlDbType.TimestampTz?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Varchar?" +
                "NpgsqlDbType.Integer";


            try
            {

                DataTable resultado = AccesoLogica.Insert1(cadena1, cadena2, cadena3, "public.ins_core_contribucion_system_batch");
                int reg_descuentos = resultado.Rows.Count;


                if (reg_descuentos > 0)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {

                        _id_contribucion = Convert.ToInt64(renglon["ins_core_contribucion_system_batch"].ToString());
                    }
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO CORRECTAMENTE -> " + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

          
            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar en Contribucion " + Ex.Message);
                string _error_descuentos_registrados_cabeza = "Error al insertar en Contribucion => " + Ex.Message;
                string cadena4 = _id_descuentos_registrados_cabeza + "?" +
                            _id_descuentos_registrados_detalle_aportes + "?" +
                            _error_descuentos_registrados_cabeza;
                string cadena5 = "_id_descuentos_registrados_cabeza?_id_descuentos_registrados_detalle_aportes?_error_descuentos_registrados_cabeza";
                string cadena6 = "NpgsqlDbType.Bigint?NpgsqlDbType.Bigint?NpgsqlDbType.Varchar";
                DataTable resultado = AccesoLogica.Insert1(cadena4, cadena5, cadena6, "public.ins_core_descuentos_registrados_errores_system_batch");

                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

                _id_contribucion = 0;

            }

            return Convert.ToInt64(_id_contribucion);

        }






        public static void Ins_Descuentos_Registrados_Contribucion(Int64 _id_descuentos_registrados_detalle_aportes, Int64? _id_contribucion, Int64 _id_descuentos_registrados_cabeza)
        {
           
            string cadena1 = _id_descuentos_registrados_detalle_aportes + "?" + _id_contribucion;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + cadena1);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena2 = "_id_descuentos_registrados_detalle_aportes?_id_contribucion";
            string cadena3 = "NpgsqlDbType.Bigint?NpgsqlDbType.Bigint";


            try
            {

                DataTable resultado = AccesoLogica.Insert1(cadena1, cadena2, cadena3, "public.ins_core_descuentos_registrados_detalle_contibucion_system_batc");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO CORRECTAMENTE -> " + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

               

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar en Descuentos Registrados Detalle Contribucion " + Ex.Message);
                string _error_descuentos_registrados_cabeza = "Error al insertar en Descuentos Registrados Detalle Contribucion id => " +_id_contribucion + " Error=> "+Ex.Message;
                string cadena4 = _id_descuentos_registrados_cabeza + "?" +
                            _id_descuentos_registrados_detalle_aportes + "?" +
                            _error_descuentos_registrados_cabeza;
                string cadena5 = "_id_descuentos_registrados_cabeza?_id_descuentos_registrados_detalle_aportes?_error_descuentos_registrados_cabeza";
                string cadena6 = "NpgsqlDbType.Bigint?NpgsqlDbType.Bigint?NpgsqlDbType.Varchar";
                DataTable resultado = AccesoLogica.Insert1(cadena4, cadena5, cadena6, "public.ins_core_descuentos_registrados_errores_system_batch");

                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("ERROR INSERTADO ->" + cadena1);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

                

            }

            
        }









    }
}
