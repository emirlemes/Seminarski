using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace eFastFood
{
    public static class Global
    {
        public static Klijent prijavnjeniKorisnik { get; set; }
        public static List<NarudzbaStavka> stavkeNarudzbe { get; set; }
        public static List<GotoviProizvod> proizvodi { get; set; }

        #region API Route
        public static string ApiUrl = Application.Current.Resources["APIAddress"].ToString();


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
