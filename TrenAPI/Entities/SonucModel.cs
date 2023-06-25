namespace TrenAPI.Entities
{
    public class YerlesimAyrinti
    {
        public string VagonAdi { get; set; }
        public uint KisiSayisi { get; set; }
    }

    public class SonucModel
    {
        public uint Doluluk(uint Kapasite, uint Dolukoltuk)
        {
            uint _kapasite;
            uint Maxkapasite = (uint)(Kapasite* (0.7)); // 12*0,7 = 8,4 ~ 8
            if (Dolukoltuk >= Maxkapasite)// 8 >=  8 / 8,4
            {
                
                _kapasite = 0;
            }
            else
            {
                _kapasite = Maxkapasite - Dolukoltuk; // 8 - 8

            }
            //uint _kapasite = Maxkapasite-Dolukoltuk; if olmadan direk return edilebilir aslında. kontrol et
            return _kapasite;
        }
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
        public SonucModel()
        {
            YerlesimAyrinti = new List<YerlesimAyrinti>();
        }

    }
    
   
}
