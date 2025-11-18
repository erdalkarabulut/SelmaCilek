using System;
using Bps.BpsBase.Entities.Models.CR.Enums;

namespace Bps.Core.GlobalStaticsVariables
{
	public static class Param
	{
		public static Adaptation ADAPTATION { get; private set; }
		public static string MAMUL_KODU { get; private set; }
		public static bool PAKET { get; private set; }
		public static bool SELF_HOST { get; private set; }
		public static string API_ADDRESS { get; private set; }


		public static void SetAdaptation(Adaptation adaptation)
		{
			ADAPTATION = adaptation;

			switch (adaptation)
			{
				case Adaptation.Aracikan:
					MAMUL_KODU = "001";
					PAKET = true;
					SELF_HOST = true;
					API_ADDRESS = "http://localhost:54012";
					break;
				case Adaptation.Bala:
					MAMUL_KODU = "001";
					PAKET = false;
					SELF_HOST = true;
					API_ADDRESS = "http://localhost:54012";
					break;
				case Adaptation.Nesto:
					MAMUL_KODU = "001";
					PAKET = false;
					SELF_HOST = false;
					API_ADDRESS = "http://localhost:54012";
					break;
				case Adaptation.Ironsan:
					MAMUL_KODU = "01";
					PAKET = false;
					SELF_HOST = true;
					API_ADDRESS = "http://localhost:54012";
					break;
				case Adaptation.Otonom:
					MAMUL_KODU = "01";
					PAKET = false;
					SELF_HOST = false;
					API_ADDRESS = "http://localhost:54012";
					break;
				case Adaptation.SelmaCilek:
					MAMUL_KODU = "01";
					PAKET = false;
					SELF_HOST = false;
					API_ADDRESS = "http://localhost:54012";
					break;
				default:
					MAMUL_KODU = "01";
					PAKET = false;
					SELF_HOST = false;
					API_ADDRESS = "http://localhost:54012";
					break;
			}

			Console.WriteLine("Adaptation has been set to: " + adaptation.ToString());
		}
	}
}