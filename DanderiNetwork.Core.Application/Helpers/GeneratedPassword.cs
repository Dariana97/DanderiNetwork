using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Application.Helpers
{
	public static  class GeneratedPassword
	{
		#region Generated password
		public static string GeneratedPasswordMethod()
		{
			Random rdn = new Random();
			string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
			int longitud = caracteres.Length;
			char letra;
			int longitudContrasenia = 10;
			string contraseniaAleatoria = string.Empty;


			for (int i = 0; i < longitudContrasenia - 7; i++)
			{
				letra = caracteres[rdn.Next(longitud)];
				contraseniaAleatoria += letra.ToString();
			}


			contraseniaAleatoria += rdn.Next(10).ToString();
			contraseniaAleatoria += rdn.Next(10).ToString();


			contraseniaAleatoria += "%$#@";

			if (!contraseniaAleatoria.EndsWith("NETWORK"))
			{
				contraseniaAleatoria += "NETWORK";
			}

			return contraseniaAleatoria;
		}
		#endregion

	}
}
