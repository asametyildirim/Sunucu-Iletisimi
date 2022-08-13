using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Nancy.Json;
using Newtonsoft.Json;

namespace SunucuIletisimi


{ 
   
    public partial class Form1 : Form
    {
       

  
        private int kamikaze = 0;
        private int bos = 0;
        private int takimNumarasi = 10;
        private int telemetri = 0;
        private TelemetriVerisi telemetricik = new TelemetriVerisi();

        API api = new API();

    


        public void logEkle(string Yazi)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(logEkle), new object[] { Yazi });
                return;
            }
          

            this.txt_log.Text += Yazi + "\r\n";
        }

        public int getTelemetriKontrol()
        {
            return this.telemetri;
        }
        public void setTelemetriKontrol(int kontrol)
        {
            this.telemetri = kontrol;
        }

        public int getKamikazeKontrol()
        {
        
           return this.kamikaze;
        }

        public int getTakimNumarasi()
        {

            return this.takimNumarasi;
        }

        public void setTakimNumarasi(int numara)
        {

            this.takimNumarasi = numara;
        }


        public int getBos()
        {

            return this.bos;
        }

        public void setBos(int kamikaze)
        {

            this.bos = kamikaze;
        }

        public void setKamikaze(int kamikaze)
        {

            this.kamikaze = kamikaze;
        }

        public void KamikazeEkle(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(KamikazeEkle), new object[] { value });
                return;
            }
            this.txt_kamikaze.Text += value;
        }

  

        public void TelemEnlem(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemEnlem), new object[] { value });
                return;
            }
            this.txt_telem_iha_enlem.Text = value.ToString();
        }
        public void TelemBoylam(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemBoylam), new object[] { value });
                return;
            }
            this.txt_telem_iha_boylam.Text = value.ToString();
        }
        public void TelemIrtifa(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemIrtifa), new object[] { value });
                return;
            }
            this.txt_telem_iha_irtifa.Text = value.ToString();
        }
        public void TelemNumara(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemNumara), new object[] { value });
                return;
            }
            this.txt_takim_numarasi.Text = value.ToString();
        }
        public void TelemDikilme(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemDikilme), new object[] { value });
                return;
            }
            this.txt_telem_iha_dikilme.Text = value.ToString();
        }
        public void TelemYonelme(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemYonelme), new object[] { value });
                return;
            }
            this.txt_telem_iha_yonelme.Text = value.ToString();
        }
        public void TelemYatis(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemYatis), new object[] { value });
                return;
            }
            this.txt_telem_iha_yatis.Text = value.ToString();
        }
        public void TelemHiz(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemHiz), new object[] { value });
                return;
            }
            this.txt_telem_iha_hiz.Text = value.ToString();
        }
        public void TelemBatarya(float value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<float>(TelemBatarya), new object[] { value });
                return;
            }
            this.txt_telem_iha_batarya.Text = value.ToString();
        }
        public void TelemOtonom(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemOtonom), new object[] { value });
                return;
            }
            this.txt_telem_iha_otonom.Text = value.ToString();
        }
        public void TelemKilitlenme(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemKilitlenme), new object[] { value });
                return;
            }
            this.txt_telem_iha_kilitlenme.Text = value.ToString();
        }
        public void TelemMerkezX(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemMerkezX), new object[] { value });
                return;
            }
            this.txt_telem_hedef_merkez_x.Text = value.ToString();
        }

        public void TelemMerkezY(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemMerkezY), new object[] { value });
                return;
            }
            this.txt_telem_hedef_merkez_y.Text = value.ToString();
        }

        public void TelemGenislik(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemGenislik), new object[] { value });
                return;
            }
            this.txt_telem_hedef_genislik.Text = value.ToString();
        }

        public void TelemYukseklik(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(TelemYukseklik), new object[] { value });
                return;
            }
            this.txt_telem_hedef_yukseklik.Text = value.ToString();
        }

        

              public void TelemSonuc(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(TelemSonuc), new object[] { value });
                return;
            }
            this.txt_telemetriDonus.Text = value;
        }

        public void TelemGps(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(TelemGps), new object[] { value });
                return;
            }
            this.txt_telem_gps_saati.Text = value;
        }
   
        public  void GetInfo()
        {
          string connectionIP = "127.0.0.1";
          int connectionPort = 25001;
          IPAddress localAdd;
          TcpListener listener;
          TcpClient client;
          bool running;


        Console.WriteLine("Burası GetInfo (thread)");
            localAdd = IPAddress.Parse(connectionIP);
            listener = new TcpListener(IPAddress.Any, connectionPort);
            listener.Start();

            client = listener.AcceptTcpClient();

            running = true;

            while (running)
            {
                SendAndReceiveData(client);
            }
            listener.Stop();

        }


        public void SendAndReceiveData(TcpClient client)
        {
            Console.WriteLine("Burası SendAndReceiveData");

            NetworkStream nwStream = client.GetStream();
       


            byte[] buffer = new byte[client.ReceiveBufferSize];
            string dataReceivedson = "";

            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
            string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);


       

            while (true)
            {

                //Console.WriteLine(getKamikazeKontrol());

                if ((dataReceived != dataReceivedson) && (dataReceived == "baglanti_kuruldu"))
                {
                    
                    byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message python! Do you see this message?");
                    nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
                    logEkle("Python ile iletişim başarılı");
                }

                

                if (getKamikazeKontrol() == 1)
                {
                    logEkle("Kamikaze görevi başlatıldı");
                    KamikazeBilgisi kamicik = new KamikazeBilgisi();


                    kamicik.kamikazeBaslangicZamani = api.SunucuSaati();

                    //Console.WriteLine("kamikaze 1 oldu");
                    byte[] myWriteBuffer1 = Encoding.ASCII.GetBytes("kamikaze");
                    nwStream.Write(myWriteBuffer1, 0, myWriteBuffer1.Length);
                    //Console.WriteLine("kamikaze bilgisi gönderildi");
                    kamikaze = 2;

                     bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                   
                    dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    kamicik.kamikazeBitisZamani = api.SunucuSaati();
                    kamicik.qrMetni = dataReceived;

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string json = js.Serialize(kamicik);
                    KamikazeEkle(json);
                    logEkle("Kamikaze değeri bulundu");
                }

                if (getBos() == 1)
                {
                    logEkle("Pythona boş değer gönderildi");
                  
                    byte[] myWriteBuffer1 = Encoding.ASCII.GetBytes("bos");
                    nwStream.Write(myWriteBuffer1, 0, myWriteBuffer1.Length);
                    //Console.WriteLine("kamikaze bilgisi gönderildi");
                    bos = 2;

                    bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                    dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

           
                }




                if ((dataReceived != dataReceivedson) && (dataReceived != null))
                {
                    //Form1.txt_python_test.Text = "merhaba";
                    //this.txt_kamikaze.Text = "merhaba11";
                    
                    Console.WriteLine(dataReceived);
                    
                    //Console.WriteLine("dataReceivedson= " + dataReceivedson + " dataReceived= " + dataReceived);
                    dataReceivedson = dataReceived;

                
                }

                

             
            
            }
           
        }

        public Form1()
        {
          

            InitializeComponent();
            txt_sunucu_adres.Text = "http://localhost";
            txt_sunucu_port.Text = "";
            txt_sunucu_yol.Text = "/asy/api/";

            txt_girisYol.Text = "giris.php";
            txt_saatYol.Text = "sunucusaati.php";
            txt_qrYol.Text = "qrKoordinati.php";
            txt_cikisYol.Text = "cikis.php";
            txt_telemetri_gonder_yol.Text = "telemetri.php";

            txt_qr.ScrollBars = ScrollBars.Both;
            txt_sunucuSaati.ScrollBars = ScrollBars.Both;


            Thread mThread;
            ThreadStart ts = new ThreadStart(GetInfo);
            mThread = new Thread(ts);

            Thread telemetri = new Thread(ThreadTelemetry);
            telemetri.Start();

            mThread.Start();
            Console.WriteLine("Burası Main");
        }

        public void ThreadTelemetry()
        {


         string connectionIPTelemetry = "127.0.0.1";
         int connectionPortTelenetry = 25002;
        IPAddress localAddTelemetry;
       TcpListener listenerTelemetry;
         TcpClient client;
         bool running;

        Console.WriteLine("Burası ThreadTelemetry (thread)");
            localAddTelemetry = IPAddress.Parse(connectionIPTelemetry);
            listenerTelemetry = new TcpListener(IPAddress.Any, connectionPortTelenetry);
            listenerTelemetry.Start();

            client = listenerTelemetry.AcceptTcpClient();

            running = true;

            while (running)
            {
                SendAndReceiveDataTelemetry(client);
            }
            listenerTelemetry.Stop();
        }

        public void SendAndReceiveDataTelemetry(TcpClient client)
        {
          if (getTelemetriKontrol() == 1) { 
            Console.WriteLine("Burası SendAndReceiveDataTelemetry");

            NetworkStream nwStreamTelemetry = client.GetStream();



            byte[] buffer = new byte[client.ReceiveBufferSize];
            string dataReceivedson = "";

            int bytesReadTelemetry = nwStreamTelemetry.Read(buffer, 0, client.ReceiveBufferSize);
            string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesReadTelemetry);



                int logyaz = 0;
            while (true)
            {

                //Console.WriteLine(getKamikazeKontrol());

                if ((dataReceived != dataReceivedson) && (dataReceived == "baglanti_kuruldu_telemetri"))
                {

                    byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message python! Do you see this message?");
                    nwStreamTelemetry.Write(myWriteBuffer, 0, myWriteBuffer.Length);
                    logEkle("Telemetri kodları ile iletişim başarılı");
                }

                if(logyaz == 1)
                    {
                        logEkle("Telemtri veri çekme görevi başlatıldı");
                        logyaz = 2;
                    }

                if (getTelemetriKontrol() == 1)
                {
                        if(logyaz == 2)
                        {

                        }
                        else
                        {
                            logyaz = 1;
                        }
                       

                    //Console.WriteLine("kamikaze 1 oldu");
                        byte[] myWriteBuffer1 = Encoding.ASCII.GetBytes("telemetri");
                    nwStreamTelemetry.Write(myWriteBuffer1, 0, myWriteBuffer1.Length);
                    //Console.WriteLine("kamikaze bilgisi gönderildi");
                 

                    bytesReadTelemetry = nwStreamTelemetry.Read(buffer, 0, client.ReceiveBufferSize);
                    dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesReadTelemetry);


                    this.telemetricik = JsonConvert.DeserializeObject<TelemetriVerisi>(dataReceived);

                      
             


                     JavaScriptSerializer js = new JavaScriptSerializer();
                     string json = js.Serialize(this.telemetricik);
                    this.telemetricik.takim_numarasi = getTakimNumarasi();
                    TelemNumara(this.telemetricik.takim_numarasi);
                    TelemEnlem(this.telemetricik.IHA_enlem);
                    TelemBoylam(this.telemetricik.IHA_boylam);
                    TelemIrtifa(this.telemetricik.IHA_irtifa);
                    TelemDikilme(this.telemetricik.IHA_dikilme);
                    TelemYonelme(this.telemetricik.IHA_yonelme);
                    TelemYatis(this.telemetricik.IHA_yatis);
                    TelemHiz(this.telemetricik.IHA_hiz);
                  
                    TelemBatarya(this.telemetricik.IHA_batarya);
                    TelemOtonom(this.telemetricik.IHA_otonom);
                    TelemKilitlenme(this.telemetricik.IHA_kilitlenme);

                    TelemMerkezX(this.telemetricik.Hedef_merkez_X);
                    TelemMerkezY(this.telemetricik.Hedef_merkez_Y);
                    TelemGenislik(this.telemetricik.Hedef_genislik);
                    TelemYukseklik(this.telemetricik.Hedef_yukseklik);
                    TelemGps(this.telemetricik.GPSSaati);
                    TelemSonuc(api.TelemetriYolla(this.telemetricik));


                        // logEkle("Telemetri gönderildi");


                    }
               
                if (getBos() == 1)
                {
                    logEkle("Pythona boş değer gönderildi");

                    byte[] myWriteBuffer1 = Encoding.ASCII.GetBytes("bos");
                    nwStreamTelemetry.Write(myWriteBuffer1, 0, myWriteBuffer1.Length);
                    //Console.WriteLine("kamikaze bilgisi gönderildi");
                    bos = 2;

                    bytesReadTelemetry = nwStreamTelemetry.Read(buffer, 0, client.ReceiveBufferSize);
                    dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesReadTelemetry);


                }

                }






            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void SocketWrite_GPS1()
        {
            Console.WriteLine("GPS' i tuttuk abi, şimdi ne yapalım?");
           
            txt_qr.Text = "gps verisi alındı";
            txt_sunucuSaati.Text = "gps verisi alındı";
            Console.WriteLine("GPS' i tuttuk abi, şimdi ne yapalım?1");
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
     
            var api = new API();

            string teamNumber = api.Giris(txt_kadi.Text, txt_sifre.Text);

            setTakimNumarasi(Int16.Parse(teamNumber));

            txt_mesaj1.Text = teamNumber;
            logEkle("Giriş butonuna basıldı.");

        }

        public void Kilitlen()
        {

            Thread.Sleep(2000);


        string V = "{ \n \"kilitlenmeBaslangicZamani\": {  \"saat\": 19, \r  \n \"dakika \": 1, \n \"saniye\": 23, \n \"milisaniye\": 507 \n }, \n \"kilitlenmeBitisZamani\": { \n \"saat\": 19, \n  \"dakika\": 1, \n \"saniye\": 45, \n \"milisaniye\": 236 \n }, \n \"otonom_kilitlenme\": 0 \n } ";

        txt_kilitlenme_bilgisi.Text = V;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_sunucuSaati_Click(object sender, EventArgs e)
        {
            txt_sunucuSaati.Text = api.Saat();
            logEkle("Sunucu saati çekildi");
        }

        private void btn_sunucu_url_Click(object sender, EventArgs e)
        {

            

            if(txt_sunucu_port.Text.Equals(""))
            {
                api.setBaseURL(txt_sunucu_adres.Text);
                api.seturl(txt_sunucu_yol.Text);
                txt_sunucu_url.Text = api.getBaseUrl() + api.geturl();
            }
            else
            {
                api.setBaseURL(txt_sunucu_adres.Text);
                api.seturl(":" + txt_sunucu_port.Text + txt_sunucu_yol.Text);
                txt_sunucu_url.Text = api.getBaseUrl()  + api.geturl();

            }

            logEkle("Sunucu yolu ayarlandı");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_qr.Text = api.QR();
            logEkle("QR konumu çekildi.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
           var Secim = MessageBox.Show("Çıkış Yapmayı Onaylıyor musunuz?", "Çıkış Yap?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                api.Cikis();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            api.setYol(txt_girisYol.Text, txt_saatYol.Text, txt_qrYol.Text, txt_cikisYol.Text, txt_telemetri_gonder_yol.Text);

            txt_girisYol.Text = api.getGirisYol();
            txt_saatYol.Text = api.getSaatYol();
            txt_qrYol.Text = api.getQRYol();
            txt_cikisYol.Text = api.getCikisYol();
            txt_telemetri_gonder_yol.Text = api.getTelemetriYol();

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txt_girisYol_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Kilitlen();
        }

        private void btn_python_socket_Click(object sender, EventArgs e)
        {
         
        }

        private void txt_python_test_TextChanged(object sender, EventArgs e)
        {

        }

        public void AppendFieldText(string text)
        {
            txt_python_test.AppendText(text);
        }

        private void txt_qr_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            
            setKamikaze(1);
           
       
        }

        private void bnt_kamikaze_basla_Click(object sender, EventArgs e)
        {

        }

        private void btn_qr_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_bosdeger_Click(object sender, EventArgs e)
        {
            setBos(1);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            setTelemetriKontrol(1);
        }

        private void txt_telem_iha_dikilme_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cikisYol_TextChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
