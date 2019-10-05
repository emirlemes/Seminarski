using eFastFood_PCL.Models;
using System;
using System.Configuration;

namespace eFastFood_UI
{
    public static class Global
    {
        public static Uposlenik prijavnjeniKorisnik { get; set; }

        public static int ResizeHeight = Int32.Parse(ConfigurationManager.AppSettings["resizedImgHeight"]);
        public static int ResizeWidth = Int32.Parse(ConfigurationManager.AppSettings["resizedImgWidth"]);

        //public static string EmailAdress = ConfigurationManager.AppSettings["EmailAdress"];
        //public static string EmailHost = ConfigurationManager.AppSettings["EmailHost"];
        //public static int EmailPort = Int32.Parse(ConfigurationManager.AppSettings["EmailPort"]);
        //public static string EmailUsername = ConfigurationManager.AppSettings["EmailUsername"];
        //public static string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"];

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
