using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SunucuIletisimi
{
    internal class API
    {
        private string giris = "giris.php";
        private string saat = "sunucusaati.php";
        private string qr = "qrKoordinati.php";
        private string cikis = "cikis.php";
        private string telemtri_yol = "telemtri.php";


        private static string baseURL = "http://localhost";
     

        private static string url;

        public void setBaseURL(string _baseUrl) {baseURL = _baseUrl;}
        public string getBaseUrl(){ return baseURL;}
        public void seturl(string _url){url = _url;}
        public string geturl(){return url;}

        public void setYol(string _giris, string _saat, string _qr, string _cikis, string _telemtri) { 
            giris = _giris;
            saat = _saat;
            qr = _qr;
            cikis = _cikis;
            telemtri_yol = _telemtri;
        }
        public string getGirisYol() { return giris; }
        public string getSaatYol() { return saat; }
        public string getQRYol() { return qr; }
        public string getCikisYol() { return cikis; }
        public string getTelemetriYol() { return telemtri_yol; }
     




        public string Giris(String kadi, String sifre)
        {
            GirisBilgileri girisBilgileri = new GirisBilgileri(kadi, sifre);
            string cevap = Api_Post(url + giris, girisBilgileri);
            return cevap;
        }

        public string TelemetriYolla(TelemetriVerisi telemetricik)
        {
            string cevap = Api_Post(url + telemtri_yol, telemetricik);
            return cevap;
        }

        public string Saat()
        {
            string cevap = Api_Get(url + saat);
            SunucuSaati sistemSaati = JsonConvert.DeserializeObject<SunucuSaati>(cevap);
            return cevap;
        }

        public SunucuSaati SunucuSaati()
        {
            string cevap = Api_Get(url + saat);
            SunucuSaati sistemSaati = JsonConvert.DeserializeObject<SunucuSaati>(cevap);
            return sistemSaati;
        }

        public string QR()
        {
            string cevap = Api_Get(url + qr);
            QRKoordinat qrKoordinati = JsonConvert.DeserializeObject<QRKoordinat>(cevap);
            return cevap;
        }

        public void  Cikis()
        {
            string cevap = Api_Get(url + cikis);
         
     

        }



   


        public string Api_Post(string adres, object model)
        {
            try
            {
              var client = new HttpClient();
                client.BaseAddress = new Uri(baseURL);

                var json = JsonConvert.SerializeObject(model);
                var icerik = new StringContent(json, Encoding.UTF8, "application/json");
                var sorgu_cevap = client.PostAsync(adres, icerik).Result;

                if (sorgu_cevap.IsSuccessStatusCode)
                {
                    var cevap = sorgu_cevap.Content.ReadAsStringAsync().Result;
                    return cevap;
                }
                else
                {
                    return sorgu_cevap.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return null;
        }

        public string Api_Get(string adres)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseURL);
                var sorgu_cevap = client.GetAsync(adres).Result;

                if (sorgu_cevap.IsSuccessStatusCode)
                {
                    var cevap = sorgu_cevap.Content.ReadAsStringAsync().Result;
                    return cevap;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return null;
        }
    }
}
