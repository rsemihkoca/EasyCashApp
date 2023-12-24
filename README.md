# EasyCashApp


- Geliştirme Ortamı: AspNet Core 8.0
- Dil: C#
- Framework: Entity Framework Core
- Mimari: N Tier Architecture (Çok Katmanlı Mimari)
- Design Pattern: Repository + CQRS + Unit Of Work
- Frontend: Html5 + Css3 + Bootstrap5
- Ana kurgu: Identity
- Veri Tabanı: MSSQL

![Alt text](image.png)


DataAccessLayer.Abstract.IGenericDal
Butun tablolarda kullanilacak olan methodlarin tanimlandigi interface
DataAccessLayer.Abstract.ICustomerAccountDal
ise CustomerAccount'a özel methodlarin tanimlandigi interface

DataAccessLayer.Repositories(SERVICE)
Oluşturulan interface'lerin implemente edildiği class'lar

Response tipleri ?

TODO

Register/Logine google facebook apple ile otomatik giriş
Maildeki linke tıklayarak aktivasyon


PresentationLayer.AssemblyInfo
[assembly: AspMvcPartialViewLocationFormat(@"\ViewsShared\Components\{1}\{0}.cshtml")]
[assembly: AspMvcViewLocationFormat(@"\Views\{1}\{0}.cshtml")]
