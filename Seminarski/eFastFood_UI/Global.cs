using eFastFood_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_UI
{
    public static class Global
    {
        public static Uposlenik prijavnjeniKorisnik { get; set; }

        public static int ResizeHeight = Int32.Parse(ConfigurationManager.AppSettings["resizedImgHeight"]);
        public static int ResizeWidth = Int32.Parse(ConfigurationManager.AppSettings["resizedImgWidth"]);

        #region API Route
        public static string ApiUrl = ConfigurationManager.AppSettings["APIAddress"];


        public static string UposleniciRoute = "Uposlenik";
        public static string GotoviProizvodRoute = "GotoviProizvod";
        public static string KategorijaRoute = "Kategorija";
        public static string ProizvoidRoute = "Proizvod";
        public static string DobavljacRoute = "Dobavljac";
        public static string MjernaJedinicaRoute = "MjernaJedinica";
        public static string GPProizvodRoute = "GPProizvod";
        public static string KlijentRoute = "Klijent";
        public static string NarudzbeRoute = "Narudzba";
        public static string UlogeRoute = "Uloga";

        #endregion
    }
}
