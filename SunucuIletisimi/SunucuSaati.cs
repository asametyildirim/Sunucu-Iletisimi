using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunucuIletisimi
{
    internal class SunucuSaati
    {
        public int gun;
        public int saat;
        public int dakika;
        public int saniye;
        public int milisaniye;

        public SunucuSaati(int _gun,
        int _saat,
        int _dakika,
        int _saniye,
        int _milisaniye)
        {
            gun = _gun;
            saat = _saat;
            dakika = _dakika;
            saniye = _saniye;
            milisaniye = _milisaniye;
        }

    }
}
