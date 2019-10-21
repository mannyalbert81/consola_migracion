using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace aDocumentRobot
{
    class Conexion
    {
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=.Capremci.2018;Database=ad_capremci;Preload Reader = true; CommandTimeout=7200");
    }
}
