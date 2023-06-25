using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrenAPI.Entities;

namespace TrenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : ControllerBase
    {
        SonucModel SonucModel = new SonucModel();
        uint toplamKapasite = 0;
        List<uint> kapasiteler = new List<uint>();

        [HttpPost]
        [Route("api/trenler/Tren")]
        public async Task<ActionResult<String>> PostTren(Tren tren, uint RezervasyonYapilacakKisiSayisi, bool KisilerFarkliVagonlaraYerlestirilebilir)
        {

            List<Vagon> vagonlar = new List<Vagon>();
            foreach (Vagon item in tren.Vagonlar)
            {
                vagonlar.Add(item);
                uint kapasite = SonucModel.Doluluk(item.Kapasite, item.DoluKoltukAdet);
                kapasiteler.Add(kapasite);
                toplamKapasite += kapasite;
            }

            if (RezervasyonYapilacakKisiSayisi > toplamKapasite)
            {

                return JsonConvert.SerializeObject(new SonucModel() { RezervasyonYapilabilir = false, YerlesimAyrinti = new List<YerlesimAyrinti>() });
            }
            else
            {

                if (KisilerFarkliVagonlaraYerlestirilebilir)
                {

                    for (int i = 0; i < vagonlar.Count; i++)
                    {
                        if (RezervasyonYapilacakKisiSayisi != 0 && RezervasyonYapilacakKisiSayisi > kapasiteler[i])
                        {
                            SonucModel.RezervasyonYapilabilir = true;
                            SonucModel.YerlesimAyrinti.Add(new YerlesimAyrinti { VagonAdi = vagonlar[i].Ad, KisiSayisi = kapasiteler[i] });

                        }
                        if (RezervasyonYapilacakKisiSayisi != 0 && RezervasyonYapilacakKisiSayisi < kapasiteler[i])
                        {
                            SonucModel.RezervasyonYapilabilir = true;
                            SonucModel.YerlesimAyrinti.Add(new YerlesimAyrinti { VagonAdi = vagonlar[i].Ad, KisiSayisi = RezervasyonYapilacakKisiSayisi });
                            return JsonConvert.SerializeObject(SonucModel);

                        }
                        RezervasyonYapilacakKisiSayisi = (RezervasyonYapilacakKisiSayisi - kapasiteler[i]);
                    }

                }

                else
                {

                    for (int i = 0; i < vagonlar.Count; i++)
                    {
                        if (RezervasyonYapilacakKisiSayisi < kapasiteler[i])
                        {
                            SonucModel.RezervasyonYapilabilir = true;
                            SonucModel.YerlesimAyrinti.Add(new YerlesimAyrinti { VagonAdi = vagonlar[i].Ad, KisiSayisi = RezervasyonYapilacakKisiSayisi });
                            return JsonConvert.SerializeObject(SonucModel);
                        }

                    }

                    SonucModel.RezervasyonYapilabilir = false;
                }

            }

            return JsonConvert.SerializeObject(SonucModel);

        }
    }
}
