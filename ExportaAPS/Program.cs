using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using System.Data;

namespace ExportaAPS
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Comenzamos Conexión: ");
            verificar_afiliado_servicios_online();
            Console.Read();

        }




        public static void verificar_afiliado_servicios_online()
        {

            /// METODO PARA VERIFICAR SI EL PARTICIPE TIENE REGISTRADO SUS DATOS EN LA 231 PARA LOS TURNOS TABLA AFILIADO

            int reg = 0;
            DataTable dtAfiliado = null;

            try
            {
                dtAfiliado = AccesoLogicaSQL.Select("p.IDENTITY_CARD, p.LAST_NAME, p.FIRST_NAME, e.EMPLOYER_ENTITY_ACRONYM, ps.DESCRIPTION", "one.PARTNER p inner join one.EMPLOYER_ENTITY e on p.EMPLOYER_ENTITY_ID=e.EMPLOYER_ENTITY_ID inner join one.PARTNER_STATE ps on p.STATE=ps.PARTNER_STATE_ID AND P.STATUS<>0 ", "1=1");
                reg = dtAfiliado.Rows.Count;


                string _cedula;
                string _apellidos;
                string _nombres;
                string _entidad;
                string _estado;

               


                int _leidos_afiliados = 0;

                Console.WriteLine("---------------------------------");
                if (reg > 0)
                {

                    foreach (DataRow renglon in dtAfiliado.Rows)
                    {


                        _cedula = renglon["IDENTITY_CARD"].ToString();
                        _apellidos = renglon["LAST_NAME"].ToString();
                        _nombres = renglon["FIRST_NAME"].ToString();
                        _entidad = renglon["EMPLOYER_ENTITY_ACRONYM"].ToString();
                        _estado = renglon["DESCRIPTION"].ToString();

                        _leidos_afiliados++;



                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("TOTAL PARTICIPES  -> " + reg + " LEIDOS -> " + _leidos_afiliados);



                        ins_afiliado_servicios_online(_cedula, _apellidos, _nombres, _entidad, _estado);

                    }



                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al Traer Participes De La 208 ->" + ex.Message);
                Console.Read();
                throw;
            }

            Console.WriteLine(reg + "---------------------------------");

        }






        public static void ins_afiliado_servicios_online(string _cedula, string _apellidos, string _nombres, string _entidad, string _estado)
        {


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("LEENDO ->" + _cedula + "?" + _apellidos + "?" + _nombres);
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            string cadena1 = _cedula + "?" + _apellidos + "?" + _nombres + "?" + _entidad + "?" + _estado;
            string cadena2 = "_cedula?_apellidos?_nombres?_entidad?_estado";
            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogicaLocal.Insert(cadena1, cadena2, cadena3, "public.ins_afiliado");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("INSERTADO ->" + _cedula + "?" + _apellidos + "?" + _nombres);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                //_insertado_desembolsar++;

            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al insertar Afiliado" + Ex.Message);
                //_error_insertado_ordinarioS++;

                //SendError.EnviarErrorImportacion("ACUERDOS DE PAGO SOLICITUD: " + cadena1, Ex.Message);
                //Console.ReadLine();
            }


        }




    }
}
