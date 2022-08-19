using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AppFACPYA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"El resultado de la validación del correo es: {ValidarEmail("emai_@gmail.com")}");
            Console.ReadKey();
        }
        public static bool ValidarEmail(string P_Email)
        {
            bool ValidationIsTrue = true;
            string Cuerpo, Dominio;

            if (!P_Email.Contains("@"))     //Valida si existe @ dentro del email
                return false;

            int IndexArroba = P_Email.IndexOf("@");
            Cuerpo = P_Email.Substring(0, IndexArroba);
            Dominio = P_Email.Substring(IndexArroba + 1);

            //Valida la longitud de la cadena del Dominio y que contenga un caracter "."
            if (Dominio.Substring(0,Dominio.IndexOf(".")).Length < 3 || !Dominio.Contains(".")) 
                ValidationIsTrue = false;

            if (!ValidaEmail(Cuerpo) || !ValidaEmail(Dominio)) //Valida que ambas partes esten correctas
                ValidationIsTrue = false;

            return ValidationIsTrue;
         
        }

        public static bool ValidaEmail(string P_Cadena)
        {
            bool IsValid = true;
            int Length = P_Cadena.Length;

            if (Length < 3)
                IsValid = false;

            // Contiene "-"                 Contiene ".."         El primer caracter es "."     El último caracter es "."
            if (P_Cadena.Contains("-") || P_Cadena.Contains("..") || P_Cadena[0] == '.' || P_Cadena[P_Cadena.Length - 1] == '.')
                IsValid = false;
                
            return IsValid;
        }
               
    }
}
