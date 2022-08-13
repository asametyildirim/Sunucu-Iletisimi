using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunucuIletisimi
{
    internal class KonumBilgisi
    {

        public int takim_numarasi;
        public float iha_enlem;
        public float iha_boylam;
        public float iha_irtifa;
        public float iha_dikilme;
        public float iha_yonelme;
        public float iha_yatis;
        public float iha_hizi;
        public int zaman_farki;

        public KonumBilgisi(
                int _takim_numarasi,
         float _iha_enlem,
         float _iha_boylam,
         float _iha_irtifa,
         float _iha_dikilme,
         float _iha_yonelme,
         float _iha_yatis,
         float _iha_hizi,
         int _zaman_farki
            )
        {
            takim_numarasi = _takim_numarasi;
            iha_enlem = _iha_enlem;
            iha_boylam = _iha_boylam;
            iha_irtifa = _iha_irtifa;
            iha_dikilme = _iha_dikilme;
            iha_yonelme = _iha_yonelme;
            iha_yatis = _iha_yatis;
            iha_hizi = _iha_hizi;
            zaman_farki = _zaman_farki;


        }
    }
}
