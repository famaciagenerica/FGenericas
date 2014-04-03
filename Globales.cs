using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciasGenericas
{
    class Globales
    {
        public static bool Conectado;
        public static int idModulo;
        public static string Aplicacion = "poloart.FE";
        public static string NombreAplicacion = "FElectronica PRO";
        public static SqlConnection gConexion;
        public static SqlTransaction gSqlTransac;
        public static string strVersionSistema = "A";
        public static bool blnVerComboCliente = true;
        public static string strFormatoFecha;
        public static string strFormatoFechaHora;

        public static string BaseDeDatos;
        public static string Servidor;
        public static string UsuarioSA;
        public static string PasswordSA;
    }
}
