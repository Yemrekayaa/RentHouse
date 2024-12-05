### Ev Kiralama Sistemi

Bu proje, bir ev kiralama sistemi geliştirmek amacıyla yapılmış bir uygulamadır. Projede kullanıcı ve admin olmak üzere iki taraf için özellikler sunulmaktadır. Backend kısmı **Onion Mimarisi**, **CQRS**, **MediatR**, **AutoMapper**, **JSON Web Token (JWT)** ve **FluentValidation** gibi modern teknolojilerle geliştirilmiştir. Frontend ise **ASP.NET Core MVC** ile hazırlanmış ve çeşitli JavaScript kütüphaneleriyle zenginleştirilmiştir.

## Özellikler

### Kullanıcı Tarafı

- **Ev Listeleme**: Kullanıcılar, platformda yer alan tüm kiralık evlerin listesine kolayca erişebilirler. Bu liste, her evin temel bilgilerini ve görsellerini içerir.

- **Ev Detayları**: Kullanıcılar, her bir evin detaylarına tıklayarak şu bilgileri inceleyebilirler:

  - **Boş Günler**: Evin hangi tarihlerde boş olduğunu görebilirler.
  - **Evin Tüm Özellikleri**: Ev hakkında detaylı bilgilere ulaşabilirler (örneğin: oda sayısı, konum, fiyat, olanaklar vb.).

- **Tarihe Göre Filtreleme**: Kullanıcılar, aradıkları tarihlerde müsait olan evleri listelemek için tarih aralığını seçebilirler. Bu sayede kullanıcılar yalnızca uygun evleri görür. Tarih seçimi **Flatpickr** gibi özelleştirilmiş tarih seçici araçları ile yapılır. Kullanıcılar hem başlangıç hem de bitiş tarihlerini belirleyerek yalnızca o tarihlerde müsait evleri listeleme imkanı bulurlar.

- **Ev Fiyatlandırması ve Olanakları**: Evlerin fiyatları, kullanıcıların seçtiği tarihlere göre dinamik olarak güncellenir. Ayrıca, her ev için sunduğu olanaklar (örneğin: Wi-Fi, park yeri, yüzme havuzu) kullanıcılar tarafından görülebilir.

### Admin Paneli

- **Sayfa İçerikleri Yönetimi**:

  - **Sayfa İçeriği**: Admin, kullanıcı tarafındaki tüm sayfa içeriklerini düzenleyenbilir

- **Ev Yönetimi**:
  - **Ev Ekleme, Güncelleme ve Silme**: Admin, yeni evler ekleyebilir, mevcut evlerin bilgilerini güncelleyebilir ve ihtiyaç duyduğunda evleri silebilir.
  - **Çoklu Görsel Yükleme ve Kapak Fotoğrafı Seçimi**: Admin, evlerin görsellerini yüklerken birden fazla fotoğraf ekleyebilir ve evin ana kapak fotoğrafını seçebilir.
- **Rezervasyon Yönetimi**: Admin, panel üzerinden, rezervasyon ekleyebilir, rezervasyonları görüntüleyebilir, rezervasyon işlemlerini yönetebilir, süresi dolmuş rezervasyonlar hakkında bildirimler alabilir ve güncelleyebilir.

### Diğer Özellikler

- **Özelleştirilmiş Tarih Seçme**: Tarih aralığına göre filtreleme ve rezervasyon işlemleri için gelişmiş tarih seçme özelliği bulunmaktadır. Kullanıcılar, sadece belirli bir dönemde müsait olan evleri görmek için tarih aralığını seçebilirler.

- **Ev Olanakları ve Fiyatlandırma**: Admin, her ev için fiyatlandırma seçeneklerini ve sunduğu olanakları belirleyebilir. Kullanıcılar, bu olanaklar ve fiyatlar üzerinden evleri karşılaştırarak seçim yapabilirler.

- **Kullanıcı Yönetimi ve Oturum Açma**: Kullanıcılar, sisteme kayıt olabilir ve oturum açarak geçmiş rezervasyonlarına erişebilir, favori evlerini kaydedebilirler. JWT (Json Web Token) ile güvenli bir oturum açma işlemi gerçekleştirilir.

- **Responsive Tasarım**: Web platformu, farklı cihazlarda (masaüstü, tablet, mobil) kullanıcı dostu bir deneyim sunacak şekilde tasarlanmıştır.

## Kullanılan Teknolojiler ve Kütüphaneler

### **Backend**

- **ASP.NET Core 8**: Uygulama, modern web uygulamaları için kullanılan **ASP.NET Core 8** ile geliştirilmiştir. Bu framework, yüksek performans, güvenlik ve esneklik sunarak uygulamanın backend tarafını sağlam bir şekilde destekler.
- **Onion Mimarisi (Onion Architecture)**: Uygulamanın iş mantığı, veritabanı erişimi ve sunum katmanları birbirinden bağımsız olarak geliştirilmiştir. Bu mimari sayesinde uygulama daha modüler ve bakım yapılabilir hale getirilmiştir.

- **CQRS (Command Query Responsibility Segregation)**: Veritabanına yapılan sorgular ve komutlar birbirinden ayrılmıştır. Bu sayede veri okuma ve yazma işlemleri farklı katmanlarda yönetilerek uygulamanın daha ölçeklenebilir ve yönetilebilir olması sağlanmıştır.

- **MediatR**: **CQRS** desenini kullanabilmek için **MediatR** kütüphanesi kullanılmıştır. Bu kütüphane, komutları ve sorguları işlemekte ve bu sayede uygulamanın iş mantığının daha temiz ve modüler olmasına yardımcı olmaktadır.

- **AutoMapper**: Uygulama içerisinde, veri transfer objeleri (DTO) ile entity sınıfları arasındaki dönüşüm işlemlerini kolaylaştırmak amacıyla **AutoMapper** kütüphanesi kullanılmaktadır. Bu sayede, manuel dönüşüm işlemleri ortadan kaldırılmış ve kodun okunabilirliği artırılmıştır.

- **FluentValidation**: Model doğrulama işlemleri için **FluentValidation** kütüphanesi kullanılmıştır. Bu kütüphane sayesinde, kullanıcıdan alınan verilerin doğruluğu basit ve etkili bir şekilde kontrol edilmektedir.

- **JSON Web Token (JWT)**: Kimlik doğrulama işlemleri için **JWT** kullanılmıştır. JWT ile güvenli bir şekilde kullanıcı doğrulama ve yetkilendirme işlemleri yapılmaktadır. Bu sistem, API'ye erişim için token tabanlı bir yöntem kullanır.

- **Entity Framework Core**: Veritabanı işlemleri için **Entity Framework Core** kullanılmıştır. Bu ORM (Object-Relational Mapper) ile veritabanı işlemleri yüksek performansla yapılmaktadır.

- **SQL Server**: Veritabanı yönetim sistemi olarak **SQL Server** kullanılmaktadır. Uygulama, verileri bu veritabanına kaydeder ve sorgularını gerçekleştirir.

### **Frontend**

- **ASP.NET Core MVC**: Frontend kısmı, **ASP.NET Core MVC** ile geliştirilmiştir. Bu yapı, web uygulamanızın view (görünüm) ve controller (denetleyici) katmanlarını ayırarak uygulamanın daha bakımlı olmasına yardımcı olur.

- **HTML5 ve CSS3**: Web sayfalarının temel yapısı için **HTML5** ve **CSS3** kullanılmıştır. Sayfa düzeni ve görsel tasarımda bu iki teknolojinin gücüyle modern bir görünüm elde edilmiştir.

- **Bootstrap 5**: Uygulamanın responsive (mobil uyumlu) olabilmesi için **Bootstrap 5** framework'ü kullanılmıştır. Bu sayede sayfalar farklı cihazlarda sorunsuz bir şekilde görüntülenebilmektedir.

- **JavaScript & jQuery**: Dinamik ve etkileşimli özellikler için **JavaScript** ve **jQuery** kütüphanesi kullanılmıştır. **jQuery**, DOM manipülasyonlarını kolaylaştırarak kullanıcı etkileşimini daha akıcı hale getirmektedir.

- **Slick**: Ev görselleri ve diğer içerikler için kayan galeri özelliği sağlamak amacıyla **Slick** kütüphanesi kullanılmıştır. Bu kütüphane, görsellerin kaydırılabilir olmasını sağlar.

- **Flatpickr**: Tarih seçimi için **Flatpickr** kullanılmıştır. Bu kütüphane, kullanıcıların tarihleri seçmesini kolaylaştıran modern bir tarih seçici bileşeni sunmaktadır.

- **Leaflet**: Harita entegrasyonu için **Leaflet** kütüphanesi kullanılmıştır. Bu kütüphane, interaktif haritalar oluşturmak ve kullanıcılara evlerin konumlarını göstermek için kullanılmaktadır.

- **Font Awesome**: **Font Awesome** ikon seti, uygulamanın görsel kısmında kullanılmakta ve çeşitli ikonlar (örneğin ev, telefon, mesaj gibi) sağlanmaktadır.

### **Diğer Kullanılan Araçlar ve Teknolojiler**

- **Visual Studio 2022**: Proje geliştirme ortamı olarak **Visual Studio 2022** kullanılmaktadır. Geliştiriciler için güçlü hata ayıklama ve test etme araçları sağlar.
- **Swagger UI**: API endpoint'lerini test etmek ve dokümante etmek için **Swagger UI** kullanılmıştır. Bu araç, kullanıcıların API ile etkileşime girmesini kolaylaştırır.
