using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunucuIletisimi
{
    internal class TelemetriVerisi
    {
        public int takim_numarasi;
        public float IHA_enlem;
        public float IHA_boylam;
        public float IHA_irtifa;
        public float IHA_dikilme;
        public float IHA_yonelme;
        public float IHA_yatis;
        public float IHA_hiz;
        public float IHA_batarya;
        public int IHA_otonom;
        public int IHA_kilitlenme;

        public int Hedef_merkez_X;
        public int Hedef_merkez_Y;
        public int Hedef_genislik;
        public int Hedef_yukseklik;
        public string GPSSaati;
    }
}
