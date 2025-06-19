BankingCreditSystem
Bu proje, bireysel ve kurumsal müşteriler için kredi başvuru ve yönetim süreçlerini yöneten bir bankacılık uygulamasıdır. Katmanlı mimari ile geliştirilmiş olup, .NET teknolojileri kullanılarak hayata geçirilmiştir.

Katmanlar
BankingCreditSystem.Domain
Temel domain nesneleri ve iş kuralları burada yer alır.

BankingCreditSystem.Application
Uygulama servisleri, iş kuralları, komutlar (CQRS), DTO’lar ve mapping profilleri bu katmanda bulunur.

BankingCreditSystem.Persistence
Entity Framework Core ile veri erişim katmanıdır. DbContext ve repository implementasyonları burada yer alır.

BankingCreditSystem.Core
Ortak altyapı, exception handling, base repository gibi çekirdek bileşenler bu katmanda bulunur.

BankingCreditSystem.WebApi
API katmanıdır. Controller’lar ve endpointler burada tanımlanır.

Temel Özellikler
Bireysel ve kurumsal müşteri yönetimi
Müşteri oluşturma, güncelleme, silme ve listeleme işlemleri
Katmanlı mimari ve temiz kod prensipleri
Exception handling ve iş kuralları yönetimi
MediatR ile CQRS uygulaması


API Kullanımı
Swagger veya Postman ile aşağıdaki endpointleri test edebilirsiniz:
POST /api/IndividualCustomers : Bireysel müşteri oluşturur
PUT /api/IndividualCustomers : Bireysel müşteri günceller (eklenecek)
DELETE /api/IndividualCustomers/{id} : Bireysel müşteri siler (eklenecek)
GET /api/IndividualCustomers/{id} : Müşteri detayını getirir
GET /api/IndividualCustomers : Müşteri listesini getirir
