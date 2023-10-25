# AWSLambdaTrenAPI
Merhaba,
  Proje Bir tren rezervasyonu uygulaması için, istenilen rezervasyonunun yapılıp yapılamayacağını ve yapılabiliyorsa hangi vagon için rezervasyon onaylanabileceğini belirleyen bir HTTP API içermektedir.
  
  API, HTTP Post isteklerine yanıt vermektedir.

  Proje AWS Lambda servisinde canlı olarak bulunmaktadır.
  TRY IT => https://hqhyjbhbu8.execute-api.us-east-1.amazonaws.com/Prod/swagger

  Örnek Request(Girilecek 2 parametre daha var onlar için swagger yönlendirmektedir);

    {
        "Ad":"Doğu Ekspresi",
        "Vagonlar":
        [
            {"Ad":"Vagon 1", "Kapasite":100, "DoluKoltukAdet":68}
            ,{"Ad":"Vagon 2", "Kapasite":90, "DoluKoltukAdet":50}
            ,{"Ad":"Vagon 3", "Kapasite":80, "DoluKoltukAdet":80}
        ]
    }

    Ve Response;

    {"RezervasyonYapilabilir":true,"YerlesimAyrinti":[{"VagonAdi":"Vagon 1","KisiSayisi":2},{"VagonAdi":"Vagon 2","KisiSayisi":1}]}
  
