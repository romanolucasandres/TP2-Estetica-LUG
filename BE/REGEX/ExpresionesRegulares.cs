using System;
using System.Text.RegularExpressions;

namespace BE.REGEX
{
    public static class ExpresionesRegulares
    {
        //Solo numeros, para validar DNI y CUIT.
        //NO se admiten espacios en blanco ni nada que no sea un numero
        public static bool ValidarSoloNumeros(string Cadena)
        {

            return Regex.IsMatch(Cadena, "^([0-9]+$)");
        }

        //Alfanumerico y espacios para validar Descripcion, Marca, Razon Social
        public static bool ValidarAlfanumérico(string Cadena)
        {
            return Regex.IsMatch(Cadena, "^([a-zñáéíóúA-ZÑÁÉÍÓÚ0-9\\s]+$)");
        }

        //Alfanumerico sin espacios
        //Lo uso para el nombre de usuario, que puede tener letras mayusculas minusculas y numeros
        public static bool ValidarAlfanuméricoSinEspacios(string Cadena)
        {
            return Regex.IsMatch(Cadena, "^([a-zA-Z0-9]+$)");
        }

        //Solo letras y espacios, incluyo acentos, dieresis en minuscula y mayuscula
        public static bool ValidarSoloLetras(string Cadena)
        {
            return Regex.IsMatch(Cadena, "^([a-zñáéíóúüA-ZÑÁÉÍÓÚÜ\\s]+$)");
        }

        //Cualquier caracter menos el espacio
        //Lo uso para la contraseña, que NO puede contener espacio
        public static bool CualquierCaracterMenosEspacio(string Cadena)
        {
            return Regex.IsMatch(Cadena, "^([^\\s]+$)");
        }
        //Validar telefono
        public static bool ValidarTelefono(string Cadena)
        {
            return Regex.IsMatch(Cadena, "^([0-9]{10}|[0-9]{8})$");
        }

        //hace que directamente se ingrese con punto
        public static bool ValidarDecimal(string Cadena)
        {
            return Regex.IsMatch(Cadena, "^([0-9]+|[0-9]+\\.[0-9]+)$");
        }
    }
}
